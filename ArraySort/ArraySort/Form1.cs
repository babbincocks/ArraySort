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
                splitNames[index] = new PersonName(nameSplit[0], nameSplit[1].TrimStart(' '));

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
                    DateTime timeStart = DateTime.Now;

                    string searchTerm = txtNameSearch.Text;
                    int min = 0; 
                    int middle;
                    int max = splitNames.Length - 1;
                    bool match = false;
                    int location = -1;
                    List<string> matches = new List<string> { };


                    if (searchTerm.EndsWith(" "))
                    {
                        searchTerm.TrimEnd(' ');
                    }

                    if (searchTerm.EndsWith(","))
                    {
                        searchTerm.TrimEnd(',');
                    }


                    if (searchTerm.Length > 1 && searchTerm.Contains(" ") && !searchTerm.Contains(","))
                    {

                        string[] nameSplit = searchTerm.Split(' ');
                        PersonName search = new PersonName(nameSplit[1], nameSplit[0]); 

                        while (min <= max && !match)
                        {
                            middle = (min + max) / 2;

                            if (string.Compare(splitNames[middle].ToString(), search.ToString(), true) == 0)
                            {
                                match = true;
                                location = middle;
                                lbSearchMatches.Items.Add("The name " + splitNames[location].ToString(2) + " was found on line " + (location + 1) + ".");
                                DateTime timeEnd = DateTime.Now;
                                TimeSpan totalTime = timeEnd - timeStart;
                                string time = "Searching for this name took " + totalTime.Milliseconds + " milliseconds.";
                                lbTimeRecords.Items.Add(time);
                            }
                            else if (string.Compare(splitNames[middle].ToString(), search.ToString(), true) > 0)
                            {
                                max = middle - 1;
                            }
                            else if (string.Compare(splitNames[middle].ToString(), search.ToString(), true) < 0)
                            {
                                min = middle + 1;
                            }

                        }
                    }
                    else if (searchTerm.Length > 1 && searchTerm.Contains(" ") && searchTerm.Contains(","))
                    {
                        string[] nameSplit = searchTerm.Split(',');
                        PersonName search = new PersonName(nameSplit[0], nameSplit[1].TrimStart(' '));
                        while (min <= max && !match)
                        {
                            middle = (min + max) / 2;

                            if (string.Compare(splitNames[middle].ToString(), search.ToString(), true) == 0)
                            {
                                match = true;
                                location = middle;
                                lbSearchMatches.Items.Add("The name " + splitNames[location].ToString(2) + " was found on line " + (location + 1) + ".");
                                DateTime timeEnd = DateTime.Now;
                                TimeSpan totalTime = timeEnd - timeStart;
                                string time = "Searching for this name took " + totalTime.Milliseconds + " milliseconds.";
                                lbTimeRecords.Items.Add(time);
                            }

                            else if (string.Compare(splitNames[middle].ToString(), search.ToString(), true) > 0)
                            {
                                max = middle - 1;
                            }
                            else if (string.Compare(splitNames[middle].ToString(), search.ToString(), true) < 0)
                            {
                                min = middle + 1;
                            }

                        }
                    }

                    else if (searchTerm.Length > 1 && !searchTerm.Contains(" ") && !searchTerm.Contains(","))
                    {
                        int matchIndex;
                        string minValue;

                        for (int start = 0; start < splitNames.Length - 1; start++)
                        {

                            matchIndex = start;
                            minValue = splitNames[start].ToString();



                                if (String.Compare(splitNames[index].ToString(0), minValue.ToString(), true) == 0)
                                {
                                    match = true;

                                    lbSearchMatches.Items.Add("The name " + splitNames[index].ToString(2) + " was found on line " + (index + 1) + ".");
                                    DateTime timeEnd = DateTime.Now;
                                    TimeSpan totalTime = timeEnd - timeStart;
                                    string time = "Searching for this name took " + totalTime.Milliseconds + " milliseconds.";
                                    lbTimeRecords.Items.Add(time);

                                }
                                else if (String.Compare(minValue.ToString(), splitNames[index].ToString(0), true) == 0)
                                {
                                    minValue = splitNames[index].ToString();
                                    matchIndex = index;
                                }

                            }

                            



                        
                    }

                    else if (searchTerm.Length == 1)
                    {
                        

                        while (min <= max && !match)
                        {
                            middle = (min + max) / 2;

                            if (splitNames[middle].ToString(0).StartsWith(searchTerm) || splitNames[middle].ToString(1).StartsWith(searchTerm))
                            {
                                location = middle;
                                
                                lbSearchMatches.Items.Add("The name " + splitNames[location].ToString(2) + " was found on line " + (location + 1) + ".");
                                match = true;
                            }
                            else if (string.Compare(splitNames[middle].ToString(0).Substring(0,1), searchTerm.ToString(), true) > 0)
                            {
                                max = middle - 1;
                            }
                            else if (string.Compare(splitNames[middle].ToString(0).Substring(0, 1), searchTerm.ToString(), true) < 0)
                            {
                                min = middle + 1;
                            }
                            else if (string.Compare(splitNames[middle].ToString(1).Substring(0, 1), searchTerm.ToString(), true) > 0)
                            {
                                max = middle - 1;
                            }
                            else if (string.Compare(splitNames[middle].ToString(1).Substring(0, 1), searchTerm.ToString(), true) < 0)
                            {
                                min = middle + 1;
                            }

                        }

                        }

                    if (location == -1)
                    {
                        throw new Exception("Unable to find the search term in the list of names.");
                    }


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
                return last + ", " + first;
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
                    return first + ' ' + last;
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

        private void searchMatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbSearchMatches.Items.Clear();
        }

        private void timeRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lbTimeRecords.Items.Clear();
        }
    }
}
