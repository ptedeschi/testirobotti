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
using System.Timers;
using System.Windows.Forms;

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

            //this.txtTestSuitePath.Text = @"C:\Users\patrick.tedeschi\Desktop\ikro test.json";
        }

        private void btnExecute_Click(object sender, System.EventArgs e)
        {
            String json = File.ReadAllText(txtTestSuitePath.Text);
            testSuite = JsonConvert.DeserializeObject<TestSuite>(json);

            beginTime = DateTime.Now;

            watch.Start();
            watch.Interval = 200;
            watch.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            watch.Enabled = true;

            int iterations = Convert.ToInt32(txtIterations.Text);
            int users = Convert.ToInt32(txtUsers.Text);

            for (int i = 0; i < users; i++)
            {
                var worker = new BackgroundWorker();
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
                var worker = sender as BackgroundWorker;

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
                    Validate(bot, userId, test.request, test.custom_request, test.response);
                }

                for (int i = 0; i < iterations; i++)
                {
                    foreach (Looptest looptest in testSuite.looptest)
                    {
                        Validate(bot, userId, looptest.request, looptest.custom_request, looptest.response);
                    }
                }
            }
            catch (ConnectException ex)
            {
                //Debug.WriteLine("Exception");

                //MessageBox.Show(ex.ToString() + ex.Message);

                //foreach (BackgroundWorker backgroundWorker in backgroundWorkers)
                //{
                //    backgroundWorker.CancelAsync();
                //}
                LogDetail(ex.Message);

                numOfTimeouts++;
                UpdateUI();
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
                //txtActualIteration.Text = actualIteration.ToString();

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

                if (data.activities.Length != parameters.Length)
                {
                    CopyToClipboard(JsonConvert.SerializeObject(data));
                    throw new StateException(string.Format("Activities length doesn't match.\n\nReceived: {0}\nExpected: {1}", data.activities.Length, parameters.Length));
                }

                if (!TextUtils.Clean(activity.text).Equals(TextUtils.Clean(parameters[index])))
                {
                    CopyToClipboard(JsonConvert.SerializeObject(data));
                    throw new StateException(string.Format("Text doesn't match.\n\nReceived: {0}\nExpected: {1}", activity.text, parameters[index]));
                }

                index++;
            }

            UpdateUI();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtTestSuitePath.Text = openFileDialog.FileName;
            }
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