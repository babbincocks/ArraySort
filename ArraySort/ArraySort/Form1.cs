using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ArraySort
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        StreamReader source = new StreamReader(@"..\Debug\Names.csv");
        string[] names = new string[5000];


        private void frmMain_Load(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            int index = 0;
            while (!source.EndOfStream && index < names.Length)
            {
                names[index] = source.ReadLine().ToString();
                lbNameList.Items.Add(names[index]);
                index++;
            }
            DateTime end = DateTime.Now;
            TimeSpan length = end - start;

            string time = "Loading the form took " + length.Milliseconds + " milliseconds.";
            lbTimeRecords.Items.Add(time);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startTime = DateTime.Now;

                int minIndex;
                string minValue;

                for (int start = 0; start < names.Length - 1; start++)
                {

                    minIndex = start;
                    minValue = names[start];


                    for (int index = start + 1; index < names.Length; index++)
                    {
                        if (String.Compare(minValue, names[index], true) == 1)
                        {
                            minValue = names[index];
                            minIndex = index;
                        }

                    }

                    Swap(ref names[minIndex], ref names[start]);


                }

                lbNameList.Items.Clear();

                for (int index = 0; index <= names.Length - 1; index++)
                {
                    lbNameList.Items.Add(names[index]);
                }

                DateTime endTime = DateTime.Now;
                TimeSpan finalTime = endTime - startTime;
                if (finalTime.Milliseconds >= 1000)
                {
                    string time = "Sorting the names took " + finalTime.Seconds + " seconds and " + finalTime.Milliseconds + " milliseconds.";
                    lbTimeRecords.Items.Add(time);
                }
                else if (finalTime.Milliseconds < 1000)
                {
                    string time = "Sorting the names took " + finalTime.Milliseconds + " milliseconds.";
                    lbTimeRecords.Items.Add(time);
                }

                lbTimeRecords.TopIndex = lbTimeRecords.Items.Count - 1;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Swap(ref string a, ref string b)
        {
            string placeholder = a;
            a = b;
            b = placeholder;

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;
                //int index = 0;
                //StreamWriter output = new StreamWriter(@"..\Debug\SortedNames.csv");
                File.WriteAllLines(@"..\Debug\SortedNames.csv", names);
                //while (index < names.Length)
                //{
                //    output.WriteLine(names[index].ToString());
                //    index++;
                //}
                DateTime end = DateTime.Now;
                TimeSpan length = end - start;

                string time = "Exporting the names took " + length.Milliseconds + " milliseconds.";
                lbTimeRecords.Items.Add(time);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
