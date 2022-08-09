using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock2
{
    public partial class ConfigWindow : Form
    {
        public ConfigWindow()
        {
            InitializeComponent();
            timeBox.Text = ConfigurationManager.AppSettings.Get("EOD");
            locationBox.Text = ConfigurationManager.AppSettings.Get("Location");
            codeBox.Text = ConfigurationManager.AppSettings.Get("WCode");
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            // Updates the end of day time, weather location and Open Weather Code in the config file
            string EOD = timeBox.Text;
            string location = locationBox.Text;
            string wCode = codeBox.Text;

            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;

            if (Regex.IsMatch(EOD, @"^[0-2][0-9]:[0-5][0-9]"))
            {
                settings["EOD"].Value = EOD;
            }
            else
            {
                MessageBox.Show("Date must be in 24 hour HH:MM format. \n Ex. 03:33 or 22:00");
            }

            if (Regex.IsMatch(location, @"^[A-Za-z\s]*$"))
            {
                settings["Location"].Value = location;
            }
            else
            {
                MessageBox.Show("Location name must not contain numbers or symbols");
            }

            if (Regex.IsMatch(wCode, "^[A-Za-z0-9]*$"))
            {
                settings["WCode"].Value = wCode;
            }
            else
            {
                MessageBox.Show("Open Weather api code can not contain sybols or spaces");
            }

            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }

        private void dataBtn_Click(object sender, EventArgs e)
        {
            //adds to the SQLite Database that holds the Holiday information
            HolidayModel holiday = new HolidayModel();

            string name = holNameBox.Text;
            string day = holDateBox.Text;

            if(Regex.IsMatch(name, @"^[A-Za-z0-9\s]*$"))
            {
                if(Regex.IsMatch(day, @"^[0-9]{4}-[0-9]{2}-[0-9]{2}$"))
                {
                    holiday.date = day;
                    holiday.name = name;

                    SqliteDataAccess.SaveDay(holiday);
                }
                else
                {
                    MessageBox.Show("Holiday day must be in yyyy-mm-dd format \n Ex. 2022-12-25");
                }
            }
            else
            {
                MessageBox.Show("Holiday name can not have symbols in it");
            }
        }
    }
}
