using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Clock2
{
    public partial class Form1 : Form
    {
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            label1.Text = DateTime.Now.ToString("hh:mm:ss");
            label2.Text = DateTime.Now.ToString("d");
            label3.Text = DateTime.Now.ToString("dddd");
            //Current();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("d");
            label3.Text = DateTime.Now.ToString("dddd");
            switch (i)
            {
                case int n when (n < 20)://Current time
                    label1.Text = DateTime.Now.ToString("hh:mm:ss");
                    break;

                case int n when (n < 30)://Time to end of day
                    DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 00, 0);
                    TimeSpan timeLeft = end - DateTime.Now;
                    if (timeLeft.Seconds < 0)
                    {
                        label1.Text = "End Of Day";
                    }
                    else
                    {
                        label1.Text = (timeLeft.ToString(@"hh\:mm\:ss") + System.Environment.NewLine + " to go");
                    }
                    break;

                case int n when (n < 40)://Time to end of week
                    DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
                    DateTime endOfWeek = today.AddDays((DayOfWeek.Friday - today.DayOfWeek + 7) % 7);
                    TimeSpan timeleft = endOfWeek - DateTime.Now;

                    if (timeleft.Seconds < 0)
                    {
                        label1.Text = "End Of Week";
                    }
                    else
                    {
                        label1.Text = (timeleft.Days + " days and " + timeleft.ToString(@"hh\:mm\:ss") + " to go");
                    }
                    break;

                case int n when (n < 50)://Time to next Holiday
                    break;

                case int n when (n >= 50):
                    label1.Text = DateTime.Now.ToString("hh:mm:ss");
                    i = 0;
                    break;
            }

            i++;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
