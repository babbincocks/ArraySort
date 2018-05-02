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
        PersonName[] splitNames = new PersonName[5000];
        bool sort = false;

        private void frmMain_Load(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            int index = 0;
            while (!source.EndOfStream && index < names.Length)
            {
                names[index] = source.ReadLine().ToString();
                string[] nameSplit = names[index].Split(',');
                splitNames[index] = new PersonName(nameSplit[0].ToString(), nameSplit[1].ToString());

                lbNameList.Items.Add(splitNames[index]);
                index++;
            }
            DateTime end = DateTime.Now;
            TimeSpan length = end - start;

            string time = "Loading the form took " + length.Milliseconds + " milliseconds.";
            lbTimeRecords.Items.Add(time);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (sort == false)
                {
                    throw new Exception("Please sort the names first.");
                }
                else
                {
                    string searchTerm = txtNameSearch.Text;


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime startTime = DateTime.Now;

                int minIndex;
                PersonName minValue;

                    for (int start = 0; start < splitNames.Length - 1; start++)
                    {

                        minIndex = start;
                        minValue = splitNames[start];


                        for (int index = start + 1; index < splitNames.Length; index++)
                        {
                            if (String.Compare(splitNames[index].ToString(0), minValue.ToString(0), true) == 0)
                            {

                                if (String.Compare(minValue.ToString(1), splitNames[index].ToString(1), true) == 1)
                                {
                                    minValue = splitNames[index];
                                    minIndex = index;
                                }
                            }
                            else if (String.Compare(minValue.ToString(0), splitNames[index].ToString(0), true) == 1)
                            {
                                minValue = splitNames[index];
                                minIndex = index;
                            }

                        }

                        Swap(ref splitNames[minIndex], ref splitNames[start]);



                    }
                

                lbNameList.Items.Clear();

                for (int index = 0; index <= splitNames.Length - 1; index++)
                {
                    lbNameList.Items.Add(splitNames[index]);
                }

                DateTime endTime = DateTime.Now;
                TimeSpan finalTime = endTime - startTime;

                    string time = "Sorting the names took " + finalTime.Seconds + " seconds and " + finalTime.Milliseconds + " milliseconds.";
                    lbTimeRecords.Items.Add(time);


                lbTimeRecords.TopIndex = lbTimeRecords.Items.Count - 1;
                sort = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public class PersonName
        {

            string firstName;
            string lastName;

            public PersonName(string last, string first)
            {
                lastName = last;
                firstName = first;
            }

            public string last
            {
                get { return lastName; }
                set { lastName = value; }
            }

            public string first
            {
                get { return firstName; }
                set { firstName = value; }
            }

            public override string ToString()
            {
                return last + "," + first;
            }

            public string ToString(int which)
            {
                if (which == 0)
                {
                    return last;
                }
                else if (which == 1)
                {
                    return first;
                }
                else
                {
                    return last + "," + first;
                }
            }

        }


        private void Swap(ref PersonName a, ref PersonName b)
        {
            PersonName placeholder = a;
            a = b;
            b = placeholder;

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime start = DateTime.Now;

                for(int index = 0; index < splitNames.Length; index++)
                {
                    names[index] = splitNames[index].ToString();
                }

                File.WriteAllLines(@"..\Debug\SortedNames.csv", names);

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
