/****************************************
** Events and Delegates
** @author: Sophie M Greene
** @date: 30/11/2015
** 
****************************************/
using System;
using System.Collections.Generic;
using System.Windows;

namespace Mod_9_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Student> stList;
        private int currRecord;
        public MainWindow()
        {
            InitializeComponent();
            StList = new List<Student>();
           /* stList.Add(new Student("a", "al", "ac"));
            stList.Add(new Student("b", "bl", "bc"));
            stList.Add(new Student("c", "cl", "cc"));*/
            currRecord = -1;
        }

        internal List<Student> StList {
            get {return stList; }
            set {stList = value;}
        }

        /* Grading Criteria 1:
         * Event handler created for the Create Student button
        */
        private void btnCreateStudent_Click(object sender, RoutedEventArgs e) {
            if(txtFirstName.Text.Length>0 && 
                txtLastName.Text.Length>0 &&
                txtCity.Text.Length>0) {

                /* Grading Criteria 2:
                 * Event handler creates a Student object using values 
                 * from the text boxes on the form
                 */
                Student st = new Student(txtFirstName.Text, txtLastName.Text, txtCity.Text);
                
                /* Grading Criteria 4:
                * Event handler adds a Student object to the List< T >
                */
                StList.Add(st);

                //update to keep track of the current record being displayed
                //i.e the last record added to the student array
                currRecord = StList.Count;
               
                //challenge
                /*if (currRecord<=1) {
                    btnNext.IsEnabled = false;
                } else {
                    btnPrevious.IsEnabled = true;
                    btnNext.IsEnabled = true;
                }*/
                MessageBox.Show
                    (txtFirstName.Text + " " + txtLastName.Text + " from " +
                    txtCity.Text+" was addedd to Students Record","Congratulations");
            } else {
                
                MessageBox.Show("One or more empty entries!!!\n\n Please fill all the fields","Error!!");
                
            }

            /* Grading Criteria 3:
             *  Textbox values are cleared
             */
            clearText();
        }

        /* Grading Criteria 3: implementation of clearText()*/   
        private void clearText() {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtCity.Clear();
        }
        /* Grading Criteria 6:
         * Previous button displays each student's information in the text boxes
         */
        private void btnPrevious_Click(object sender, RoutedEventArgs e) {
            currRecord= currRecord -1;
            if (StList.Count <= 0)
                MessageBox.Show("No Records Exists !!!", "Warning!");
            //when the first record is reached 
            //goto the last record for the next time 
            //this button is clicked
            if (currRecord < 0) { 
                clearText();
                currRecord = stList.Count;
                //btnPrevious.IsEnabled = false;
            }
            else 
                displayRecord(currRecord);
           // btnNext.IsEnabled = true;
        }

        /* Grading Criteria 6,5:
         * display a student record from List<Student>
        */
        private void displayRecord(int v) {
           if(v>=0 && v< StList.Count && StList[v]!=null) {
                txtFirstName.Text = StList[v].FirstName;
                txtLastName.Text = StList[v].LastName;
                txtCity.Text = StList[v].City;
            }
        }
        /* Grading Criteria 5:
         * Next button displays each student's information in the text boxes
         */
        private void btnNext_Click(object sender, RoutedEventArgs e) {
            currRecord = currRecord + 1;
            if (StList.Count <= 0)
                MessageBox.Show("No Records Exists|!!!", "Warning!");
            if(currRecord >=stList.Count) { 
                clearText();
                currRecord = -1;
               // btnNext.IsEnabled = false;
            }
            else displayRecord(currRecord);
               // btnPrevious.IsEnabled = true;
        }     
        
    }
    class Student : IComparable<Student>
    {
        //properties
        private string _firstName;
        private string _lastName;
        private string _city;

   
        #region props
        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string City {
            get { return _city; }
            set { _city = value; }
        }
        #endregion

        public Student(string first, string last, string ciy) {
            this.FirstName = first;
            this.LastName = last;
            this.City = ciy;
        }
        int IComparable<Student>.CompareTo(Student other) {
            if (this.FirstName.CompareTo(other.FirstName) == 0)
                return this.LastName.CompareTo(other.LastName);
            return FirstName.CompareTo(other.FirstName);
        }
    }
}
