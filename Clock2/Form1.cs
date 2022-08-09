/*
 * Author: Ryan Richardson
 * 
 * Clock uses Open Weather to get weather data
 * API key for weather can be gotten from https://openweathermap.org/
 */
using Newtonsoft.Json;
using System;
using System.Net;
using System.Windows.Forms;
using System.Configuration;

namespace Clock2
{
    public partial class Form1 : Form
    {
        int i = 0;  // Used to switch between different countdowns and clocks
        int w = 0;  // Used to know when at least 10 mins have passed to check weather again

        public Form1()
        {
            // Initial setup of the clock and gets first check of the weather
            InitializeComponent();
            timeLab.Text = ("    " + DateTime.Now.ToString("hh:mm:ss"));
            dateLab.Text = DateTime.Now.ToString("d");
            dayLab.Text = DateTime.Now.ToString("dddd");
            getWeather();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // This Method is for cycling through the different clocks or countdowns
            // i is used as a timer for how long to stay on a clock or countdown
            dateLab.Text = DateTime.Now.ToString("d");
            dayLab.Text = DateTime.Now.ToString("dddd");

            switch (i)
            {
                case int n when (n < 20):// Current time
                    Current();
                    break;

                case int n when (n < 30):// Time to end of day
                    EOD();
                    break;

                case int n when (n < 40):// Time to end of week
                    EOW();
                    break;

                case int n when (n < 50):// Time to next Holiday
                    NextHoliday();
                    break;

                case int n when (n >= 5): // Used to reset to the begaining
                    timeLab.Text = ("    " + DateTime.Now.ToString("hh:mm:ss"));
                    i = 0;

                    // Weather API only updates weather every 10 minutes.
                    // So this checks if it has been atleast 10 minutes since last check
                    if(w >= 600)
                    {
                        getWeather();
                        w = 0;
                    }
                    break;
            }

            i++;
            w++;
        }

        private void Current()
        {
            // Method for current time
            timeLab.Text = ("    " + DateTime.Now.ToString("hh:mm:ss"));
        }

        private void EOD()
        {
            // Method for the end of day countdown
            DateTime end = DateTime.Now;

            try
            {
                end = DateTime.ParseExact(ConfigurationManager.AppSettings.Get("EOD"), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(Exception ex)
            {
                i = 31;
                MessageBox.Show(ex.Message);
            }

            TimeSpan timeLeft = end - DateTime.Now;

            if (timeLeft.Seconds < 0)
            {
                timeLab.Text = "End Of Day";
            }
            else
            {
                timeLab.Text = ("    " + timeLeft.ToString(@"hh\:mm\:ss") + "\nUntil end of day");
            }
        }

        private void EOW()
        {
            // Method for the end of the week countdown
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 20, 0, 0);
            DateTime endOfWeek = today.AddDays((DayOfWeek.Friday - today.DayOfWeek + 7) % 7);
            TimeSpan timeleft = endOfWeek - DateTime.Now;

            if (timeleft.Seconds < 0 || DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
            {
                timeLab.Text = "End Of Week";
            }
            else
            {
                timeLab.Text = ("    " + timeleft.Days + ":" + timeleft.ToString(@"hh\:mm\:ss") + System.Environment.NewLine + "Until the weekend");
            }
        }

        private void NextHoliday()
        {
            // Method for the next holiday countdown
            HolidayModel nextHoliday = SqliteDataAccess.getNext();

            DateTime d = DateTime.ParseExact(nextHoliday.date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            TimeSpan timeLeft = d - DateTime.Now;

            timeLab.Text = ("    " + timeLeft.Days + ":" + timeLeft.ToString(@"hh\:mm\:ss") + System.Environment.NewLine + "Until " + nextHoliday.name);
        }

        void getWeather()
        {
            // Method forupdating the weather
            using(WebClient web = new WebClient())
            {
                string location = ConfigurationManager.AppSettings.Get("Location");
                string wCode = ConfigurationManager.AppSettings.Get("WCode");
                string url = "https://api.openweathermap.org/data/2.5/weather?q=" + location + "&appid=" + wCode +"&units=imperial";

                try
                {
                    var json = web.DownloadString(url);
                    Weather.root Info = JsonConvert.DeserializeObject<Weather.root>(json);

                    int temp = Convert.ToInt32(Info.main.temp);
                    int high = Convert.ToInt32(Info.main.temp_max);
                    int low = Convert.ToInt32(Info.main.temp_min);

                    curTempLab.Text = temp.ToString() + "°";
                    highTempLab.Text = "High: " + high.ToString() + "°";
                    lowTempLab.Text = "Low: " + low.ToString() + "°";
                }
                catch(WebException e)
                {
                    MessageBox.Show(e.Message + "\n" + "If error 404 the location is probably wrong" + "\n" + "If error 401 the API code is probably wrong");

                }
            }
        }

        private void configBtn_Click(object sender, EventArgs e)
        {
            //Method for opening the window for configuring 
            ConfigWindow window = new ConfigWindow();
            window.ShowDialog();
        }
    }
}