using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Clock2
{
    public partial class Form1 : Form
    {
        int i = 0;

        public Form1()
        {
            InitializeComponent();
            label1.Text = ("    " + DateTime.Now.ToString("hh:mm:ss"));
            label2.Text = DateTime.Now.ToString("d");
            label3.Text = DateTime.Now.ToString("dddd");
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
                    Current();
                    break;

                case int n when (n < 30)://Time to end of day
                    EOD();
                    break;

                case int n when (n < 40)://Time to end of week
                    EOW();
                    break;

                case int n when (n < 0)://Time to next Holiday
                    NextHoliday();
                    break;

                case int n when (n >= 5):
                    label1.Text = ("    " + DateTime.Now.ToString("hh:mm:ss"));
                    i = 0;
                    break;
            }

            i++;
        }

        private void Current()
        {
            label1.Text = ("    " + DateTime.Now.ToString("hh:mm:ss"));
        }

        private void EOD()
        {
            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 00, 0);
            TimeSpan timeLeft = end - DateTime.Now;
            if (timeLeft.Seconds < 0)
            {
                label1.Text = "End Of Day";
            }
            else
            {
                label1.Text = ("    " + timeLeft.ToString(@"hh\:mm\:ss") + System.Environment.NewLine + "Until end of day");
            }
        }

        private void EOW()
        {
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            DateTime endOfWeek = today.AddDays((DayOfWeek.Friday - today.DayOfWeek + 7) % 7);
            TimeSpan timeleft = endOfWeek - DateTime.Now;

            if (timeleft.Seconds < 0)
            {
                label1.Text = "    End Of Week";
            }
            else
            {
                label1.Text = ("    " + timeleft.Days + ":" + timeleft.ToString(@"hh\:mm\:ss") + System.Environment.NewLine + "Until the weekend");
            }
        }

        private void NextHoliday()
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
