using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Lab8_2
{
    public partial class EventForm : Form
    {
        public EventForm(string eventText)
        {
            InitializeComponent();
            richTextBox1.Text = eventText;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            int tenMinutes = 1000 * 60 * 10;

            await Task.Delay(tenMinutes);

            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "Calendar")
                {
                    this.Close();
                    break;
                }
                
                CalendarForm form1 = new CalendarForm();
                this.Close();

                break;
            }
        }
    }
}
