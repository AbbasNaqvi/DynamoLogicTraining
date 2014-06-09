namespace TaskTwo
{
    partial class Form1
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
            this.buttonStart=new System.Windows.Forms.Button();
            this.buttonPause=new System.Windows.Forms.Button();
            this.buttonExport=new System.Windows.Forms.Button();
            this.textBoxOutputFileName=new System.Windows.Forms.TextBox();
            this.progressBar1=new System.Windows.Forms.ProgressBar();
            this.numericUpDownThreadCount=new System.Windows.Forms.NumericUpDown();
            this.LabelTitle=new System.Windows.Forms.Label();
            this.panel1=new System.Windows.Forms.Panel();
            this.listView1=new System.Windows.Forms.ListView();
            this.t1=((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
            this.t2=((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
            this.t3=((System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader()));
            this.labelProgress=new System.Windows.Forms.Label();
            this.LabelActiveThread=new System.Windows.Forms.Label();
            this.panel2=new System.Windows.Forms.Panel();
            this.button1=new System.Windows.Forms.Button();
            this.label1=new System.Windows.Forms.Label();
            this.label4=new System.Windows.Forms.Label();
            this.numericUpDownMax=new System.Windows.Forms.NumericUpDown();
            this.label2=new System.Windows.Forms.Label();
            this.label3=new System.Windows.Forms.Label();
            this.numericUpDownLeast=new System.Windows.Forms.NumericUpDown();
            this.saveFileDialog1=new System.Windows.Forms.SaveFileDialog();
            this.textBoxList=new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownThreadCount)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownLeast)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location=new System.Drawing.Point(406,114);
            this.buttonStart.Name="buttonStart";
            this.buttonStart.Size=new System.Drawing.Size(107,39);
            this.buttonStart.TabIndex=0;
            this.buttonStart.Text="Start";
            this.buttonStart.UseVisualStyleBackColor=true;
            this.buttonStart.Click+=new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonPause
            // 
            this.buttonPause.Location=new System.Drawing.Point(538,114);
            this.buttonPause.Name="buttonPause";
            this.buttonPause.Size=new System.Drawing.Size(88,39);
            this.buttonPause.TabIndex=1;
            this.buttonPause.Text="Pause";
            this.buttonPause.UseVisualStyleBackColor=true;
            this.buttonPause.Click+=new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location=new System.Drawing.Point(646,114);
            this.buttonExport.Name="buttonExport";
            this.buttonExport.Size=new System.Drawing.Size(96,39);
            this.buttonExport.TabIndex=2;
            this.buttonExport.Text="Export";
            this.buttonExport.UseVisualStyleBackColor=true;
            this.buttonExport.Click+=new System.EventHandler(this.buttonExport_Click);
            // 
            // textBoxOutputFileName
            // 
            this.textBoxOutputFileName.Location=new System.Drawing.Point(334,11);
            this.textBoxOutputFileName.Name="textBoxOutputFileName";
            this.textBoxOutputFileName.ReadOnly=true;
            this.textBoxOutputFileName.Size=new System.Drawing.Size(350,20);
            this.textBoxOutputFileName.TabIndex=3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location=new System.Drawing.Point(19,233);
            this.progressBar1.Name="progressBar1";
            this.progressBar1.Size=new System.Drawing.Size(854,27);
            this.progressBar1.TabIndex=4;
            // 
            // numericUpDownThreadCount
            // 
            this.numericUpDownThreadCount.Location=new System.Drawing.Point(117,12);
            this.numericUpDownThreadCount.Name="numericUpDownThreadCount";
            this.numericUpDownThreadCount.Size=new System.Drawing.Size(120,20);
            this.numericUpDownThreadCount.TabIndex=5;
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize=true;
            this.LabelTitle.Font=new System.Drawing.Font("Modern No. 20",26.25F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte) (0)));
            this.LabelTitle.ForeColor=System.Drawing.SystemColors.ControlDarkDark;
            this.LabelTitle.Location=new System.Drawing.Point(3,0);
            this.LabelTitle.Name="LabelTitle";
            this.LabelTitle.Size=new System.Drawing.Size(210,36);
            this.LabelTitle.TabIndex=6;
            this.LabelTitle.Text="Zoopla Form";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxList);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.labelProgress);
            this.panel1.Controls.Add(this.LabelActiveThread);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.LabelTitle);
            this.panel1.Location=new System.Drawing.Point(12,12);
            this.panel1.Name="panel1";
            this.panel1.Size=new System.Drawing.Size(916,495);
            this.panel1.TabIndex=7;
            // 
            // listView1
            // 
            this.listView1.Alignment=System.Windows.Forms.ListViewAlignment.Default;
            this.listView1.AllowColumnReorder=true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.t1,
            this.t2,
            this.t3});
            this.listView1.Font=new System.Drawing.Font("Consolas",11.25F,System.Drawing.FontStyle.Italic,System.Drawing.GraphicsUnit.Point,((byte) (0)));
            this.listView1.Location=new System.Drawing.Point(32,280);
            this.listView1.Name="listView1";
            this.listView1.ShowGroups=false;
            this.listView1.ShowItemToolTips=true;
            this.listView1.Size=new System.Drawing.Size(409,189);
            this.listView1.TabIndex=18;
            this.listView1.TileSize=new System.Drawing.Size(40,40);
            this.listView1.UseCompatibleStateImageBehavior=false;
            this.listView1.View=System.Windows.Forms.View.Details;
            // 
            // t1
            // 
            this.t1.Text="Thread #";
            // 
            // t2
            // 
            this.t2.Text="Percentage";
            // 
            // t3
            // 
            this.t3.Text="link";
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize=true;
            this.labelProgress.Font=new System.Drawing.Font("Agency FB",8.25F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte) (0)));
            this.labelProgress.Location=new System.Drawing.Point(17,263);
            this.labelProgress.Name="labelProgress";
            this.labelProgress.Size=new System.Drawing.Size(18,14);
            this.labelProgress.TabIndex=16;
            this.labelProgress.Text="0%";
            // 
            // LabelActiveThread
            // 
            this.LabelActiveThread.AutoSize=true;
            this.LabelActiveThread.FlatStyle=System.Windows.Forms.FlatStyle.Flat;
            this.LabelActiveThread.Font=new System.Drawing.Font("Agency FB",11.25F,System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,((byte) (0)));
            this.LabelActiveThread.ForeColor=System.Drawing.Color.Green;
            this.LabelActiveThread.Location=new System.Drawing.Point(17,212);
            this.LabelActiveThread.Name="LabelActiveThread";
            this.LabelActiveThread.Size=new System.Drawing.Size(85,18);
            this.LabelActiveThread.TabIndex=15;
            this.LabelActiveThread.Text="Current Thread";
            this.LabelActiveThread.Visible=false;
            // 
            // panel2
            // 
            this.panel2.AutoSize=true;
            this.panel2.BackColor=System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle=System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonExport);
            this.panel2.Controls.Add(this.buttonStart);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.buttonPause);
            this.panel2.Controls.Add(this.numericUpDownMax);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.numericUpDownLeast);
            this.panel2.Controls.Add(this.numericUpDownThreadCount);
            this.panel2.Controls.Add(this.textBoxOutputFileName);
            this.panel2.Location=new System.Drawing.Point(58,39);
            this.panel2.Name="panel2";
            this.panel2.Size=new System.Drawing.Size(787,160);
            this.panel2.TabIndex=14;
            // 
            // button1
            // 
            this.button1.Location=new System.Drawing.Point(690,6);
            this.button1.Name="button1";
            this.button1.Size=new System.Drawing.Size(73,28);
            this.button1.TabIndex=13;
            this.button1.Text="Choose";
            this.button1.UseVisualStyleBackColor=true;
            this.button1.Click+=new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize=true;
            this.label1.ForeColor=System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location=new System.Drawing.Point(19,14);
            this.label1.Name="label1";
            this.label1.Size=new System.Drawing.Size(75,13);
            this.label1.TabIndex=7;
            this.label1.Text="Thread Count:";
            // 
            // label4
            // 
            this.label4.AutoSize=true;
            this.label4.ForeColor=System.Drawing.SystemColors.InactiveCaptionText;
            this.label4.Location=new System.Drawing.Point(270,14);
            this.label4.Name="label4";
            this.label4.Size=new System.Drawing.Size(58,13);
            this.label4.TabIndex=12;
            this.label4.Text="Output File";
            // 
            // numericUpDownMax
            // 
            this.numericUpDownMax.Location=new System.Drawing.Point(475,64);
            this.numericUpDownMax.Minimum=new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMax.Name="numericUpDownMax";
            this.numericUpDownMax.Size=new System.Drawing.Size(120,20);
            this.numericUpDownMax.TabIndex=8;
            this.numericUpDownMax.Value=new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize=true;
            this.label2.ForeColor=System.Drawing.SystemColors.InactiveCaptionText;
            this.label2.Location=new System.Drawing.Point(366,68);
            this.label2.Name="label2";
            this.label2.Size=new System.Drawing.Size(16,13);
            this.label2.TabIndex=10;
            this.label2.Text="to";
            // 
            // label3
            // 
            this.label3.AutoSize=true;
            this.label3.ForeColor=System.Drawing.SystemColors.InactiveCaptionText;
            this.label3.Location=new System.Drawing.Point(51,73);
            this.label3.Name="label3";
            this.label3.Size=new System.Drawing.Size(63,13);
            this.label3.TabIndex=11;
            this.label3.Text="Web Pages";
            // 
            // numericUpDownLeast
            // 
            this.numericUpDownLeast.Location=new System.Drawing.Point(179,66);
            this.numericUpDownLeast.Minimum=new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLeast.Name="numericUpDownLeast";
            this.numericUpDownLeast.Size=new System.Drawing.Size(120,20);
            this.numericUpDownLeast.TabIndex=9;
            this.numericUpDownLeast.Value=new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt="csv";
            this.saveFileDialog1.FileName="NewZoopla";
            // 
            // textBoxList
            // 
            this.textBoxList.Location=new System.Drawing.Point(448,280);
            this.textBoxList.Name="textBoxList";
            this.textBoxList.ReadOnly=true;
            this.textBoxList.Size=new System.Drawing.Size(456,189);
            this.textBoxList.TabIndex=19;
            this.textBoxList.Text="";
            // 
            // Form1
            // 
            this.AutoScaleDimensions=new System.Drawing.SizeF(6F,13F);
            this.AutoScaleMode=System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize=true;
            this.BackColor=System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize=new System.Drawing.Size(940,519);
            this.Controls.Add(this.panel1);
            this.Name="Form1";
            this.Text="Zoopla Practice Version";
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownThreadCount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numericUpDownLeast)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.TextBox textBoxOutputFileName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NumericUpDown numericUpDownThreadCount;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownLeast;
        private System.Windows.Forms.NumericUpDown numericUpDownMax;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.Label LabelActiveThread;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader t2;
        private System.Windows.Forms.ColumnHeader t3;
        private System.Windows.Forms.ColumnHeader t1;
        private System.Windows.Forms.RichTextBox textBoxList;

    }
}

