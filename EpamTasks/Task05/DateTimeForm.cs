using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task05
{
    public partial class DateTimeForm : Form
    {
        Dictionary<string, HistoryFile> HistoryFiles;
        public Dictionary<string, FileHistoryPart> listHistories = new Dictionary<string, FileHistoryPart>();

        public DateTimeForm(Dictionary<string, HistoryFile> historyFiles)
        {
            InitializeComponent();
            HistoryFiles = historyFiles;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            DateTime time = new DateTime();

            DateTime final;

            if (DateTime.TryParse(maskedTextBox1.Text, out time))
            {
                final = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 59);

                

                foreach (KeyValuePair<string, HistoryFile> hf in HistoryFiles)
                {
                    FileHistoryPart history = hf.Value.ExtractByDate(final);
                    listHistories.Add(hf.Key, history);
                }
            }

            DialogResult = DialogResult.OK;
        }
    }
}
