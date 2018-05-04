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
        //To get all information, a StreamReader is initialized. The file has been put in the Debug folder.
        StreamReader source = new StreamReader(@"..\Debug\Names.csv");

        //Two array are made, one to hold all names that are just as is, and another to hold split up names for searching.
        string[] names = new string[5000];
        PersonName[] splitNames = new PersonName[5000];

        //Bool for making sure the names are sorted before any searching is done.
        bool sort = false;

        private void frmMain_Load(object sender, EventArgs e)
        {       //Code for when the form first loads.

            //First half of timer for loading. All actions will contain one of these.
            DateTime start = DateTime.Now;

            //While loop to ensure everything is added to the "names" array, and then is cut up to be just the names, and that's added
            //to the "splitNames" array.
            int index = 0;
            while (!source.EndOfStream && index < names.Length)
            {
                names[index] = source.ReadLine().ToString();
                //All names in the file are formatted like so: "Lastname, FirstName", hence what's being done below.
                string[] nameSplit = names[index].Split(',');
                splitNames[index] = new PersonName(nameSplit[0], nameSplit[1].TrimStart(' '));

                lbNameList.Items.Add(splitNames[index]);
                index++;
            }

            //End of the timer, and how long the entire operation took.
            DateTime end = DateTime.Now;
            TimeSpan length = end - start;

            //The length of the operation is displayed in the TimeRecords box. Every operation will do the same as this.
            string time = "Loading the form took " + length.Milliseconds + " milliseconds.";
            lbTimeRecords.Items.Add(time);

        }



        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {       //Code for the Sort button.
            try
            {
                DateTime startTime = DateTime.Now;
                //Variables for the following for loops.
                int minIndex;
                PersonName minValue;

                    for (int start = 0; start < splitNames.Length - 1; start++)
                    {
                        //minIndex functions as what is the smallest index in a continuously-shrinking set of names, starting with
                        //the entire list, and lessening by 1 on each iteration. minValue is the value located at said index.
                        minIndex = start;
                        minValue = splitNames[start];


                        for (int index = start + 1; index < splitNames.Length; index++)
                        {
                                //If the last names are the same between the two names being checked...
                            if (String.Compare(splitNames[index].ToString(0), minValue.ToString(0), true) == 0)
                            {
                                //...it then checks the first names. If the first name being checked is less than the first name in what
                                //is currently believed to be the smallest, the smallest name is then made the currently checked name.
                                if (String.Compare(minValue.ToString(1), splitNames[index].ToString(1), true) == 1)
                                {
                                    minValue = splitNames[index];
                                    minIndex = index;
                                }
                            }
                            //Same thing, but if the last names are out of order instead.
                            else if (String.Compare(minValue.ToString(0), splitNames[index].ToString(0), true) == 1)
                            {
                                minValue = splitNames[index];
                                minIndex = index;
                            }

                        }
                        //The positions of the names are then swapped, using a function I made farther down.
                        Swap(ref splitNames[minIndex], ref splitNames[start]);



                    }
                
                    //List of unsorted names is then cleared.
                lbNameList.Items.Clear();

                //List of sorted names is then put into the name list box.
                for (int index = 0; index <= splitNames.Length - 1; index++)
                {
                    lbNameList.Items.Add(splitNames[index]);
                }

                DateTime endTime = DateTime.Now;
                TimeSpan finalTime = endTime - startTime;

                    //Message is displayed saying how long it took.
                    string time = "Sorting the names took " + finalTime.Seconds + " seconds and " + finalTime.Milliseconds + " milliseconds.";
                    lbTimeRecords.Items.Add(time);

                //Makes it so if somehow there are enough time records to make the list box have to scroll, it will automatically go to the
                //bottom. Also sets bool to true so the search function will be allowed.
                lbTimeRecords.TopIndex = lbTimeRecords.Items.Count - 1;
                sort = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {       //Code for the Search button.
            try
            {       //Makes it so the name list has to be sorted before any searching.
                if (sort == false)
                {
                    throw new Exception("Please sort the names first.");
                }
                else
                {
                    DateTime timeStart = DateTime.Now;

                    //All of the different variables that may be needed are declared.
                    string searchTerm = txtNameSearch.Text;
                    int min = 0;
                    int middle;
                    int max = splitNames.Length - 1;
                    bool match = false;
                    int location = -1;
                    List<PersonName> matches = new List<PersonName> { };

                    //Gets rid of any extraneous spaces or commas at the end of any names.
                    if (searchTerm.EndsWith(" "))
                    {
                        searchTerm.TrimEnd(' ');
                    }

                    if (searchTerm.EndsWith(","))
                    {
                        searchTerm.TrimEnd(',');
                    }

                    //If the name is set up so it'd (assumedly) be in the format "FirstName LastName", this code executes.
                    if (searchTerm.Length > 1 && searchTerm.Contains(" ") && !searchTerm.Contains(","))
                    {
                        //User input is turned into a PersonName object.
                        string[] nameSplit = searchTerm.Split(' ');
                        PersonName search = new PersonName(nameSplit[1], nameSplit[0]);

                        //Binary search to find if the name matches any names.
                        while (min <= max && !match)
                        {
                            middle = (min + max) / 2;

                            if (string.Compare(splitNames[middle].ToString(), search.ToString(), true) == 0)
                            {
                                //If there's a match, while loop is broken (with match), program knows that it found a match (with location), the
                                //matching name is highlighted, and the results are added to the Search Matches list box.
                                match = true;
                                location = middle;
                                lbNameList.SetSelected(middle, true);
                                lbSearchMatches.Items.Add("The name " + splitNames[location].ToString(2) + " was found on line " + (location + 1) + ".");
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
                    //If the name is set up so it'd (assumedly) be in the format "Lastname, FirstName", this code executes.
                    else if (searchTerm.Length > 1 && searchTerm.Contains(" ") && searchTerm.Contains(","))
                    {
                        //More or less the same as the above method.
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
                                lbNameList.SetSelected(middle, true);

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

                    //If the name is set up so it'd (assumedly) be in the format "Firstname" or the format "Lastname", this code executes.
                    else if (searchTerm.Length > 1 && !searchTerm.Contains(" ") && !searchTerm.Contains(","))
                    {


                        //A sequential search is used, going through all of the names and seeing if any of them match.
                        for (int start = 0; start < splitNames.Length; start++)
                        {


                            //This is if the last name matches.
                            if (String.Compare(splitNames[start].ToString(0), searchTerm, true) == 0)
                            {

                                match = true;
                                location = start;
                                lbSearchMatches.Items.Add("The name " + splitNames[start].ToString(2) + " was found on line " + (start + 1) + ".");

                            }
                            //This is if the first name matches.
                            else if (String.Compare(searchTerm, splitNames[start].ToString(1), true) == 0)
                            {
                                match = true;
                                location = start;
                                lbSearchMatches.Items.Add("The name " + splitNames[start].ToString(2) + " was found on line " + (start + 1) + ".");

                            }

                        }


                        //This option has the ability to display multiple results, due to using the sequential search method, which is nice.


                    }
                    //If the "name" is set up so it'd (assumedly) be in the format "F" or "L" (first letter of either name), 
                    //this code executes.
                    else if (searchTerm.Length == 1)
                    {

                        //The binary search method is used for this.
                        while (min <= max && !match)
                        {
                            middle = (min + max) / 2;

                            //Checks if either the first or last name starts with the letter that was put in.
                            if (splitNames[middle].ToString(0).StartsWith(searchTerm) || splitNames[middle].ToString(1).StartsWith(searchTerm))
                            {
                                location = middle;
                                lbNameList.SetSelected(middle, true);
                                lbSearchMatches.Items.Add("The name " + splitNames[location].ToString(2) + " was found on line " + (location + 1) + ".");
                                match = true;
                            }
                            //If it doesn't, it'll search at first based on how the search relates to the last name...
                            else if (string.Compare(splitNames[middle].ToString(0).Substring(0, 1), searchTerm.ToString(), true) > 0)
                            {
                                max = middle - 1;
                            }
                            else if (string.Compare(splitNames[middle].ToString(0).Substring(0, 1), searchTerm.ToString(), true) < 0)
                            {
                                min = middle + 1;
                            }
                            //...and then the first name.
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


                    //If nothing is found, location should still be -1, so an Exception is thrown.
                    if (location == -1)
                    {
                        throw new Exception("Unable to find the search term in the list of names.");
                    }

                    DateTime timeEnd = DateTime.Now;
                    TimeSpan totalTime = timeEnd - timeStart;
                    string time = "Searching for this name took " + totalTime.Milliseconds + " milliseconds.";
                    lbTimeRecords.Items.Add(time);

                    //Moves both time records and search matches to bottom.
                    lbSearchMatches.TopIndex = lbSearchMatches.Items.Count - 1;
                    lbTimeRecords.TopIndex = lbTimeRecords.Items.Count - 1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public class PersonName
        {   //This is the code for the PersonName class.

            //It essentially just stores two strings in a single value.
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
            {   //ToString with nothing in the parantheses returns name in this format.
                return last + ", " + first;
            }

            public string ToString(int which)
            {       //ToString with a number in the parantheses returns one of these, depending on the number.
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
        {   //Swap method used for the Sort button.
            PersonName placeholder = a;
            a = b;
            b = placeholder;

        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {       //This is the code for the Export button.
            try
            {
                if (sort == false)
                {
                    throw new Exception("The names must be sorted before they can be exported. Exporting before such would be pointless.");
                }
                else
                {
                    DateTime start = DateTime.Now;

                    //All of the PersonName type names are turned into strings and put into the original array that was used to hold the names.
                    for (int index = 0; index < splitNames.Length; index++)
                    {
                        names[index] = splitNames[index].ToString();
                    }

                    //All names in the now-organized are written to a file created in the Debug folder.
                    File.WriteAllLines(@"..\Debug\SortedNames.csv", names);

                    DateTime end = DateTime.Now;
                    TimeSpan length = end - start;
                    string time = "Exporting the names took " + length.Milliseconds + " milliseconds.";
                    lbTimeRecords.Items.Add(time);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchMatchesToolStripMenuItem_Click(object sender, EventArgs e)
        {       //Code for the button that clears the Search Matches list box.
            lbSearchMatches.Items.Clear();
        }

        private void timeRecordsToolStripMenuItem_Click(object sender, EventArgs e)
        {       //Code for the button that clears the Time Records list box.
            lbTimeRecords.Items.Clear();
        }
    }
}
