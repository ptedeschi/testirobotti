//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

using BotTester.Core;
using BotTester.Exception;
using BotTester.Model;
using BotTester.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using TestiRobotti.Worker;

namespace BotTester.View
{
    public partial class MainForm : Form
    {
        private List<BackgroundWorker> backgroundWorkers = new List<BackgroundWorker>();
        private DateTime beginTime;
        private System.Timers.Timer watch = new System.Timers.Timer();
        private int numOfDone = 0;
        private int numOfThreads = 0;
        private int numOfTimeouts = 0;
        private int numOfErrors = 0;
        private int actualIteration = 0;
        private static List<TimeSpan> executionTime = new List<TimeSpan>();
        private TestSuite testSuite;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Reset();
            UpdateUI();

            btnExecute.Enabled = false;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtTestSuitePath.Text = openFileDialog.FileName;

                try
                {
                    String json = File.ReadAllText(txtTestSuitePath.Text);
                    testSuite = JsonConvert.DeserializeObject<TestSuite>(json);

                    btnExecute.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Invalid Test Suite");

                    btnExecute.Enabled = false;
                }
            }
        }

        private void Reset()
        {
            numOfDone = 0;
            numOfThreads = 0;
            numOfTimeouts = 0;
            numOfErrors = 0;
            actualIteration = 0;
            executionTime.Clear();
        }

        private void btnExecute_Click(object sender, System.EventArgs e)
        {
            // Reset all vars
            Reset();

            beginTime = DateTime.Now;

            watch.Start();
            watch.Interval = 200;
            watch.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            watch.Enabled = true;

            int iterations = Convert.ToInt32(txtIterations.Text);
            int users = Convert.ToInt32(txtUsers.Text);

            for (int i = 0; i < users; i++)
            {
                var worker = new NamedBackgroundWorker();
                worker.Id = i;
                worker.DoWork += new DoWorkEventHandler(Run);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunCompleted);
                worker.RunWorkerAsync(iterations);
                worker.WorkerSupportsCancellation = true;

                backgroundWorkers.Add(worker);
            }
        }

        public static void List(TimeSpan timeSpan)
        {
            lock (executionTime)
            {
                executionTime.Add(timeSpan);
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (txtTime.InvokeRequired)
            {
                txtTime.Invoke((MethodInvoker)delegate
                {
                    DateTime start = beginTime;
                    DateTime end = e.SignalTime;
                    TimeSpan timeSpan = (end - start);

                    txtTime.Text = timeSpan.ToString();
                });
            }
        }

        private void RunCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            numOfThreads--;
            numOfDone++;
            UpdateUI();

            if (numOfThreads == 0)
            {
                watch.Stop();
            }
        }

        [STAThread]
        private void Run(object sender, DoWorkEventArgs e)
        {
            numOfThreads++;
            UpdateUI();

            try
            {
                var worker = sender as NamedBackgroundWorker;

                if (worker.CancellationPending)
                {
                    Debug.WriteLine("Worker Cancellation or Pending #1");

                    e.Cancel = true;
                    return;
                }

                int iterations = (int)e.Argument;
                string userId = Guid.NewGuid().ToString();

                Bot bot = new Bot(testSuite.secretKey);
                bot.StartConversation();

                //while (true)
                //{
                //    Activities welcome = bot.ReceiveWelcomeMessage();

                //    if (welcome == null || welcome.activities.Length != 0)
                //    {
                //        break;
                //    }
                //}

                foreach (Test test in testSuite.test)
                {
                    try
                    {
                        Validate(bot, userId, test.request, test.custom_request, test.response);
                    }
                    catch (ConnectException ex)
                    {
                        LogDetail(ex.Message);

                        numOfTimeouts++;
                        UpdateUI();
                    }
                }

                for (int i = 0; i < iterations; i++)
                {
                    System.Diagnostics.Debug.WriteLine("WorkId: " + worker.Id);

                    // As several BackgroundWorker can have access to this code
                    // incrementing the actual iteration only for first created thread
                    if (worker.Id == 0)
                    {
                        actualIteration++;

                        // Refresh token each 10 times
                        if (actualIteration%10 == 0)
                        {
                            bot.Reauthenticate();
                        }
                    }

                    UpdateUI();

                    if (testSuite.looptest != null)
                    {
                        foreach (Looptest looptest in testSuite.looptest)
                        {
                            try
                            {
                                Validate(bot, userId, looptest.request, looptest.custom_request, looptest.response);
                            }
                            catch (ConnectException ex)
                            {
                                LogDetail(ex.Message);

                                numOfTimeouts++;
                                UpdateUI();
                            }

                           Thread.Sleep(1000);
                        }
                    }
                }
            }
            catch (StateException ex)
            {
                LogDetail(ex.Message);

                numOfErrors++;
                UpdateUI();
            }
        }

        private void LogUser(string tag, string text)
        {
            text = TextUtils.Clean(text);

            txtLog1.Invoke((Action)delegate
            {
                txtLog1.Text += string.Format("[{0}] {1}{2}", tag, text, Environment.NewLine);

                txtLog1.SelectionStart = txtLog1.Text.Length;
                txtLog1.ScrollToCaret();
            });
        }

        private void LogBot(string tag, string text)
        {
            text = TextUtils.Clean(text);

            txtLog1.Invoke((Action)delegate
            {
                txtLog1.Text += string.Format("\t[{0}] {1}{2}", tag, text, Environment.NewLine);

                txtLog1.SelectionStart = txtLog1.Text.Length;
                txtLog1.ScrollToCaret();
            });
        }

        private void LogDetail(string text)
        {
            txtDetail.Invoke((Action)delegate
            {
                txtDetail.Text += string.Format("{0}{1}", text, Environment.NewLine);

                txtDetail.SelectionStart = txtLog1.Text.Length;
                txtDetail.ScrollToCaret();
            });
        }

        private void UpdateUI()
        {
            this.labelThread.Invoke((Action)delegate
            {
                txtThreads.Text = numOfThreads.ToString();
                txtTimeouts.Text = numOfTimeouts.ToString();
                txtErrors.Text = numOfErrors.ToString();
                txtDone.Text = numOfDone.ToString();
                txtActualIteration.Text = actualIteration.ToString();

                if (executionTime.Count > 0)
                {
                    var res = executionTime.Average(timeSpan => timeSpan.TotalMilliseconds);
                    txtRequestTime.Text = TimeSpan.FromMilliseconds(res).ToString();
                }
            });
        }

        private void CopyToClipboard(String data)
        {
            this.labelThread.Invoke((Action)delegate
            {
                txtErrorDetail.Text += data;
            });
        }

        private void Validate(Bot bot, string userId, string text, string custom_text, params string[] parameters)
        {
            LogUser(userId, text);
            string id = "";

            if (!string.IsNullOrEmpty(text))
            {
                id = bot.SendActivityToBot(userId, text);
            }
            else if (!string.IsNullOrEmpty(custom_text))
            {
                custom_text = custom_text.Replace("default-user", userId);
                id = bot.SendCustomActivityToBot(custom_text);
            }

            Activities data = bot.ReceiveActivitiesFromBot(id);

            int index = 0;

            foreach (Activity activity in data.activities)
            {
                LogBot("Bot", activity.text);

                if (data.activities.Length >= 100)
                {
                    // For some unknown reason, in some cases, the id is 0000000 or 0000001
                    // so it's returning all the messages. Skipping the behavior for now
                    return;
                }

                if (data.activities.Length != parameters.Length)
                {
                    CopyToClipboard(text + custom_text + JsonConvert.SerializeObject(data));
                    throw new StateException(string.Format("Activities length doesn't match.\n\nReceived: {0}\nExpected: {1}", data.activities.Length, parameters.Length));
                }

                if (!TextUtils.Clean(activity.text).Equals(TextUtils.Clean(parameters[index])))
                {
                    CopyToClipboard(text + custom_text + JsonConvert.SerializeObject(data));
                    throw new StateException(string.Format("Text doesn't match.\n\nReceived: {0}\nExpected: {1}", activity.text, parameters[index]));
                }

                index++;
            }

            UpdateUI();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionText = version.Major + "." + version.Minor + " (build " + version.Build + ")";
            string developerText = "Developed by Patrick Tedeschi, 2018";

            MessageBox.Show(Text + " " + versionText + "\n\n" + developerText);
        }
    }
}