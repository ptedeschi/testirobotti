
using System.Windows.Forms;

namespace BotTester.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLog1 = new System.Windows.Forms.TextBox();
            this.txtTestSuitePath = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.txtUsers = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelThread = new System.Windows.Forms.Label();
            this.txtThreads = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTimeouts = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRequestTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.Time = new System.Windows.Forms.Label();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtErrorDetail = new System.Windows.Forms.TextBox();
            this.txtActualIteration = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog1
            // 
            this.txtLog1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtLog1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLog1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtLog1.Location = new System.Drawing.Point(34, 106);
            this.txtLog1.Multiline = true;
            this.txtLog1.Name = "txtLog1";
            this.txtLog1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog1.Size = new System.Drawing.Size(1011, 298);
            this.txtLog1.TabIndex = 0;
            // 
            // txtTestSuitePath
            // 
            this.txtTestSuitePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtTestSuitePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTestSuitePath.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestSuitePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtTestSuitePath.Location = new System.Drawing.Point(101, 31);
            this.txtTestSuitePath.Name = "txtTestSuitePath";
            this.txtTestSuitePath.Size = new System.Drawing.Size(758, 23);
            this.txtTestSuitePath.TabIndex = 1;
            // 
            // btnExecute
            // 
            this.btnExecute.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.ForeColor = System.Drawing.Color.White;
            this.btnExecute.Location = new System.Drawing.Point(1052, 29);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Padding = new System.Windows.Forms.Padding(5);
            this.btnExecute.Size = new System.Drawing.Size(140, 34);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(31, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Test Suite";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label2.Location = new System.Drawing.Point(31, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Iterations";
            // 
            // txtIterations
            // 
            this.txtIterations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtIterations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIterations.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIterations.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtIterations.Location = new System.Drawing.Point(99, 65);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(44, 23);
            this.txtIterations.TabIndex = 8;
            this.txtIterations.Text = "1";
            // 
            // txtUsers
            // 
            this.txtUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsers.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtUsers.Location = new System.Drawing.Point(194, 65);
            this.txtUsers.Name = "txtUsers";
            this.txtUsers.Size = new System.Drawing.Size(42, 23);
            this.txtUsers.TabIndex = 10;
            this.txtUsers.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label4.Location = new System.Drawing.Point(149, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Users";
            // 
            // labelThread
            // 
            this.labelThread.AutoSize = true;
            this.labelThread.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelThread.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.labelThread.Location = new System.Drawing.Point(31, 530);
            this.labelThread.Name = "labelThread";
            this.labelThread.Size = new System.Drawing.Size(0, 16);
            this.labelThread.TabIndex = 11;
            // 
            // txtThreads
            // 
            this.txtThreads.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtThreads.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtThreads.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThreads.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtThreads.Location = new System.Drawing.Point(1062, 126);
            this.txtThreads.Name = "txtThreads";
            this.txtThreads.Size = new System.Drawing.Size(148, 23);
            this.txtThreads.TabIndex = 13;
            this.txtThreads.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label3.Location = new System.Drawing.Point(1059, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Running";
            // 
            // txtTimeouts
            // 
            this.txtTimeouts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtTimeouts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimeouts.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeouts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtTimeouts.Location = new System.Drawing.Point(1062, 236);
            this.txtTimeouts.Name = "txtTimeouts";
            this.txtTimeouts.Size = new System.Drawing.Size(148, 23);
            this.txtTimeouts.TabIndex = 15;
            this.txtTimeouts.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label5.Location = new System.Drawing.Point(1062, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Timeouts";
            // 
            // txtErrors
            // 
            this.txtErrors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtErrors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtErrors.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtErrors.Location = new System.Drawing.Point(1062, 291);
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.Size = new System.Drawing.Size(148, 23);
            this.txtErrors.TabIndex = 17;
            this.txtErrors.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label6.Location = new System.Drawing.Point(1059, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Errors";
            // 
            // txtRequestTime
            // 
            this.txtRequestTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtRequestTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequestTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequestTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtRequestTime.Location = new System.Drawing.Point(1062, 344);
            this.txtRequestTime.Name = "txtRequestTime";
            this.txtRequestTime.Size = new System.Drawing.Size(148, 23);
            this.txtRequestTime.TabIndex = 19;
            this.txtRequestTime.Text = "1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label7.Location = new System.Drawing.Point(1061, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Avg Request";
            // 
            // txtDone
            // 
            this.txtDone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtDone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtDone.Location = new System.Drawing.Point(1062, 184);
            this.txtDone.Name = "txtDone";
            this.txtDone.Size = new System.Drawing.Size(148, 23);
            this.txtDone.TabIndex = 21;
            this.txtDone.Text = "1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label8.Location = new System.Drawing.Point(1061, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Done";
            // 
            // txtTime
            // 
            this.txtTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtTime.Location = new System.Drawing.Point(1065, 502);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(145, 23);
            this.txtTime.TabIndex = 23;
            this.txtTime.Text = "1";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.Time.Location = new System.Drawing.Point(1062, 483);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(87, 16);
            this.Time.TabIndex = 22;
            this.Time.Text = "Running Time";
            // 
            // txtDetail
            // 
            this.txtDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtDetail.Location = new System.Drawing.Point(34, 410);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDetail.Size = new System.Drawing.Size(500, 115);
            this.txtDetail.TabIndex = 26;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.ForeColor = System.Drawing.Color.White;
            this.buttonLoad.Location = new System.Drawing.Point(865, 31);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Padding = new System.Windows.Forms.Padding(5);
            this.buttonLoad.Size = new System.Drawing.Size(140, 32);
            this.buttonLoad.TabIndex = 27;
            this.buttonLoad.Text = "Load...";
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1222, 24);
            this.menuStrip1.TabIndex = 28;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // txtErrorDetail
            // 
            this.txtErrorDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtErrorDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtErrorDetail.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrorDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtErrorDetail.Location = new System.Drawing.Point(545, 409);
            this.txtErrorDetail.Multiline = true;
            this.txtErrorDetail.Name = "txtErrorDetail";
            this.txtErrorDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtErrorDetail.Size = new System.Drawing.Size(500, 115);
            this.txtErrorDetail.TabIndex = 29;
            // 
            // txtActualIteration
            // 
            this.txtActualIteration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtActualIteration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActualIteration.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActualIteration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtActualIteration.Location = new System.Drawing.Point(1062, 457);
            this.txtActualIteration.Name = "txtActualIteration";
            this.txtActualIteration.Size = new System.Drawing.Size(148, 23);
            this.txtActualIteration.TabIndex = 31;
            this.txtActualIteration.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label9.Location = new System.Drawing.Point(1061, 438);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 16);
            this.label9.TabIndex = 30;
            this.label9.Text = "Current iteration";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1222, 552);
            this.Controls.Add(this.txtActualIteration);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtErrorDetail);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.txtDetail);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.txtDone);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRequestTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtErrors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTimeouts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtThreads);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelThread);
            this.Controls.Add(this.txtUsers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIterations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.txtTestSuitePath);
            this.Controls.Add(this.txtLog1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Testi Robotti";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtLog1;
        private TextBox txtTestSuitePath;
        private Button btnExecute;
        private Label label1;
        private Label label2;
        private TextBox txtIterations;
        private TextBox txtUsers;
        private Label label4;
        private Label labelThread;
        private TextBox txtThreads;
        private Label label3;
        private TextBox txtTimeouts;
        private Label label5;
        private TextBox txtErrors;
        private Label label6;
        private TextBox txtRequestTime;
        private Label label7;
        private TextBox txtDone;
        private Label label8;
        private TextBox txtTime;
        private Label Time;
        private Label Label1;
        private TextBox txtDetail;
        private Button buttonLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private TextBox txtErrorDetail;
        private TextBox txtActualIteration;
        private Label label9;
    }
}

