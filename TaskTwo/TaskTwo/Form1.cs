using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


/*DynamoLogic
 * Author :Abbas Naqvi
 * Created: 4th May,2014
 * Last Modified :6th May 2014
 */


namespace TaskTwo
{
    public partial class Form1 : Form
    {
        int totalThreadsCount = 0;
        BackgroundWorker[] workerThreads;
        static int PercentageCount = 0;
        static bool Thread_Lock = false;
        public Form1()
        {
            InitializeComponent();
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            CheckForIllegalCrossThreadCalls = false;

            ListsEncapsulation.Init();
        }


        private void buttonExport_Click(object sender, EventArgs e)
        {
            buttonExport.Enabled = false;
            LabelActiveThread.Text = "Exporting! All thread are paused";
            Thread_Lock = true;
            ScrapingWorker worker=null;
            buttonPause.Text = "Resume";
            try
            {
                worker=new ScrapingWorker(textBoxOutputFileName.Text,"http://www.zoopla.co.uk/for-sale/property/bl9/?include_retirement_homes=true&page_size=24&q=BL9&new_homes=include&include_shared_ownership=true&search_source=for-sale&radius=0&view_type=grid&pn=2");
            } catch (Exception w)
            { 
            
            }
                LabelActiveThread.Text = "List Exported at    " + DateTime.Now.ToString("h:mm:ss tt");
            try
            {
                worker.WriteTheList();
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message + "\n\tHow to Solve \n1)Check Your Task Manager if csv File is opened \n2)Check if it is used by another Program");


            }
            // Thread_Lock = false;                 *----> In case of auto resuming the Threads. 

        }

        private void buttonStart_Click(object sender,EventArgs e)
        {
            LabelActiveThread.Visible=true;
            workerThreads=null;
            GC.Collect();
            if (textBoxOutputFileName.Text.Trim().Length==0)
            {
                LabelActiveThread.Text="Kindly Choose the File name and Path";
                return;
            }
            ListsEncapsulation.DistributionLimit=(int) numericUpDownMax.Value-1;
            ListsEncapsulation.DistributedPages=(int) numericUpDownLeast.Value-1;
            if (ListsEncapsulation.DistributedPages>ListsEncapsulation.DistributionLimit)
            {
                LabelActiveThread.Text="Starting Page can not be greater than Ending page";
                return;

            }
            listView1.Items.Clear();
            LabelActiveThread.Text="Running";
            buttonStart.Enabled=false;
            progressBar1.Value=0;
            textBoxList.Text="";

            //Apply Mutex on totalThreadCount for two Lines

            int.TryParse(numericUpDownThreadCount.Value.ToString(),out totalThreadsCount);
            totalThreadsCount-=1;



            workerThreads=new BackgroundWorker[(totalThreadsCount+1)];

            for (int i=0; i<=totalThreadsCount; i++)
            {
                int copy_variable=i;
                lock (copy_variable as object)
                {
                    double total_percentage=100/(totalThreadsCount+1);
                    double new_percentage=0;

                    workerThreads[i]=new BackgroundWorker();
                    workerThreads[i].WorkerReportsProgress=true;
                    //--Functionality Not used  workerThreads[i].WorkerSupportsCancellation = true;
                    workerThreads[i].DoWork+=new DoWorkEventHandler((s1,e1) => Form1_DoWork(s1,e1,copy_variable));

                    ListViewItem item=new ListViewItem(new[] { "Thread"+(copy_variable+1),"","" });
                    item.SubItems.Add(item.Name);
                    listView1.Items.Add(item);
                    ChangeSubItem(i,1,"20%");

                    workerThreads[i].ProgressChanged+=new ProgressChangedEventHandler((s1,e1) => Form1_ProgressChanged(s1,e1,copy_variable));
                    new_percentage=(double) (0.2*total_percentage);
                    workerThreads[i].ReportProgress((int) (new_percentage));

                    workerThreads[i].RunWorkerAsync();

                    total_percentage-=new_percentage;
                    workerThreads[i].RunWorkerCompleted+=new RunWorkerCompletedEventHandler((s1,e1) => Form1_RunWorkerCompleted(s1,e1,copy_variable,total_percentage));

                }
            }
        }
   
        private void ChangeSubItem(int ThreadNumber, int columnNumber, string value)
        {
            listView1.Items[ThreadNumber].SubItems[columnNumber].Text = value;

        }
        void Form1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e, int i, double total_Percentage)
        {
            progressBar1.Value += (int)total_Percentage;
            labelProgress.Text = progressBar1.Value + " % ";
            listView1.Items[i].SubItems[1].Text = "100%";
            Form1.PercentageCount += 1;
            if (Form1.PercentageCount == (totalThreadsCount + 1))
            {
                progressBar1.Value = 100;
                labelProgress.Text = progressBar1.Value + "% ";
                LabelActiveThread.Text = "Completed";
                buttonStart.Enabled = true;
            }
            progressBar1.Refresh();
            textBoxList.Text += "\r\nThread# " + (i + 1) + " Finished its task";
          //  this.Dispose();
            workerThreads=null;


        }

        void Form1_ProgressChanged(object sender, ProgressChangedEventArgs e, int i)
        {
            progressBar1.Value += e.ProgressPercentage;
            progressBar1.Update();
            labelProgress.Text = progressBar1.Value + " % ";
        }

        void Form1_DoWork(object sender, DoWorkEventArgs e, int i)
        {
            ScrapingWorker worker;
            string Link;
           
            
            while (!String.IsNullOrEmpty(Link = ListsEncapsulation.IsAnyLeft()))
            {
                lock (Link)
                {
                    textBoxList.Text+="Thread # "+(i+1)+" is Opening \n";
                    textBoxList.SelectionStart=textBoxList.Text.Length;
                    textBoxList.Text+=Link+"\n";
                    textBoxList.SelectionLength=Link.Length;
                    textBoxList.SelectionColor=Color.Blue;
                }
                while (Thread_Lock)
                {
                    Thread.SpinWait(1000);
                }
                ChangeSubItem(i, 2, Link);
                ChangeSubItem(i, 1, "30%");
                while (Thread_Lock)
                {
                    Thread.SpinWait(1000);
                }
                
                
                //Critical Section--     worker can be replaced by another thread
                try
                {
                    lock (worker=new ScrapingWorker(textBoxOutputFileName.Text,Link))
                    {

                        worker.Maine();

                    }
                } catch (Exception w)
                {
                    MessageBox.Show("CanNot Resolve URL, Maybe Server is down or Connection Time out\n\bMore Details\b\n "+w.Message);
                
                }
                while (Thread_Lock)
                {
                    Thread.SpinWait(100);
                }

                ChangeSubItem(i, 1, "70%");

            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * Set Output File
             * 
             */

            saveFileDialog1.ShowDialog();
            saveFileDialog1.DefaultExt = ".csv";
            textBoxOutputFileName.Text = saveFileDialog1.FileName;

        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            if (buttonPause.Text == "Pause")
            {
                LabelActiveThread.Text = "Paused";
                Thread_Lock = true;
                buttonPause.Text = "Resume";

            }
            else
            {
                Thread_Lock = false;
                buttonPause.Text = "Pause";
                LabelActiveThread.Text = "Running";

            }

        }
    }
}
