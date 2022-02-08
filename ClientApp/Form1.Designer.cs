namespace ClientApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.labelError1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSendDataToServer = new System.Windows.Forms.Button();
            this.textBoxDors = new System.Windows.Forms.TextBox();
            this.textBoxEngine = new System.Windows.Forms.TextBox();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxBrend = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxGetForId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelError1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.buttonSendDataToServer);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxDors);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxEngine);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxYear);
            this.splitContainer1.Panel1.Controls.Add(this.textBoxBrend);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelData);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxGetForId);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Size = new System.Drawing.Size(984, 611);
            this.splitContainer1.SplitterDistance = 387;
            this.splitContainer1.TabIndex = 0;
            // 
            // labelError1
            // 
            this.labelError1.ForeColor = System.Drawing.Color.Black;
            this.labelError1.Location = new System.Drawing.Point(10, 432);
            this.labelError1.Name = "labelError1";
            this.labelError1.Size = new System.Drawing.Size(370, 168);
            this.labelError1.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(10, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(281, 170);
            this.label6.TabIndex = 10;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // buttonSendDataToServer
            // 
            this.buttonSendDataToServer.Location = new System.Drawing.Point(266, 202);
            this.buttonSendDataToServer.Name = "buttonSendDataToServer";
            this.buttonSendDataToServer.Size = new System.Drawing.Size(87, 23);
            this.buttonSendDataToServer.TabIndex = 9;
            this.buttonSendDataToServer.Text = "Отправить";
            this.buttonSendDataToServer.UseVisualStyleBackColor = true;
            this.buttonSendDataToServer.Click += new System.EventHandler(this.buttonSendDataToServer_Click);
            // 
            // textBoxDors
            // 
            this.textBoxDors.Location = new System.Drawing.Point(144, 173);
            this.textBoxDors.Name = "textBoxDors";
            this.textBoxDors.Size = new System.Drawing.Size(209, 23);
            this.textBoxDors.TabIndex = 8;
            // 
            // textBoxEngine
            // 
            this.textBoxEngine.Location = new System.Drawing.Point(144, 136);
            this.textBoxEngine.Name = "textBoxEngine";
            this.textBoxEngine.Size = new System.Drawing.Size(209, 23);
            this.textBoxEngine.TabIndex = 7;
            // 
            // textBoxYear
            // 
            this.textBoxYear.Location = new System.Drawing.Point(144, 98);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(209, 23);
            this.textBoxYear.TabIndex = 6;
            // 
            // textBoxBrend
            // 
            this.textBoxBrend.Location = new System.Drawing.Point(144, 63);
            this.textBoxBrend.Name = "textBoxBrend";
            this.textBoxBrend.Size = new System.Drawing.Size(209, 23);
            this.textBoxBrend.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(10, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Число дверей:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(10, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Объем двигателя:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(10, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Год выпуска:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Марка:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Для отправки данных на сервер заполните все поля \r\nи нажмите \"Отправить\"";
            // 
            // labelData
            // 
            this.labelData.BackColor = System.Drawing.SystemColors.Info;
            this.labelData.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelData.Location = new System.Drawing.Point(12, 136);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(567, 464);
            this.labelData.TabIndex = 15;
            this.labelData.Text = "Ожидание запроса...";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(215, 96);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Отправить";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(12, 98);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 17);
            this.label9.TabIndex = 13;
            this.label9.Text = "Получить все данные:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(215, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Отправить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBoxGetForId
            // 
            this.textBoxGetForId.Location = new System.Drawing.Point(108, 63);
            this.textBoxGetForId.Name = "textBoxGetForId";
            this.textBoxGetForId.Size = new System.Drawing.Size(92, 23);
            this.textBoxGetForId.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(12, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Запрос по id:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(12, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Получение данных:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Client";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBoxDors;
        private TextBox textBoxEngine;
        private TextBox textBoxYear;
        private TextBox textBoxBrend;
        private Label label6;
        private Button buttonSendDataToServer;
        private Button button3;
        private Label label9;
        private Button button2;
        private TextBox textBoxGetForId;
        private Label label8;
        private Label label7;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label labelData;
        private Label labelError1;
    }
}