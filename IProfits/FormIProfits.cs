using System;
using System.IO;
using System.Windows.Forms;

namespace IProfits
{
    public partial class FormIProfits : Form
    {
        public FormIProfits()
        {
            InitializeComponent();
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            string line = "";

            string path = Application.StartupPath + @"\profit.txt";
            StreamReader streamReader = new StreamReader(path);

            bool finished = false;

            while (!finished)
            {
                line = streamReader.ReadLine();

                if (line == null)
                {
                    finished = true;
                }
                else
                {
                    TxtResult.Text += Calculate(line) + Environment.NewLine;
                }
            }
        }

        private double Calculate(string input)
        {
            double minProfit = Convert.ToInt32(input);

            //Copies needed to be sold for the min profit.
            double copies = minProfit / (0.99 - (0.99 * 0.30));

            if (copies == 0)
            {
                copies = 0;
            }
            //If copies are between 1 and 1000.
            else if (copies / 1000 <= 1)
            {
                copies = 1000;
            }
            //If copies are more than 1000.
            else if (copies / 1000 > 1)
            {
                copies = 1000 + 1000 * (int)(copies / 1000);
            }

            return copies;
        }
    }
}
