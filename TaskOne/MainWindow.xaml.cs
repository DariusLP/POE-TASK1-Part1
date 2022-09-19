using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Calcs;

namespace TaskOne
{
    public partial class MainWindow : Window
    {
        //global variables and list declaration
        public List<Modules> info = new List<Modules>();
        List<Modules> filtered;
        public Modules temp = new Modules();
        public SelfStudy stud = new SelfStudy();
        string modCode;
        string modName;
        double hours;
        double credits;
        string mName;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //clears items in datagrid
            dg.Items.Clear();

            ComboBoxItem cbi = (ComboBoxItem)combob1.SelectedItem;

            //validates if the user selected a filter
            if (combob1.SelectedItem != null)
            {
                //gets filter choice from combobox
                string option = cbi.Content.ToString();

                //filters the list according to the user's selected filter
                switch (option)
                {
                    //1st filter
                    case "Ascending Order by Module Name":
                        filtered = info.OrderBy(fn => fn.ModName).ToList();

                        filtered = (from f in info
                                    orderby f.ModName
                                    select f).ToList();

                        foreach (Modules mod in filtered)
                        {
                            dg.Items.Add(mod);
                        }
                        break;
                    
                    //2nd filter
                    case "Descending Order by hours per week":
                        filtered = info.OrderBy(fd => fd.HoursPerWeek).ToList();

                        filtered = (from f in info
                                    orderby f.HoursPerWeek descending
                                    select f).ToList();

                        foreach (Modules mod in filtered)
                        {
                            dg.Items.Add(mod);
                        }
                        break;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //clears items in the grid
            dg.Items.Clear();

            //validates if there are values in the textboxes
            if (tbName.Text.Length == 0 ||
                tbCode.Text.Length == 0 || tbCred.Text.Length == 0)
            {
                MessageBox.Show("Fields cannot be left blank >>>>");
            }
            else
            {
                //confirm if entry is correct before sending to the DG
                if (MessageBox.Show("Is the entry correct?", "Confirm Entry", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    //saves info to variables in class library
                    modName = tbName.Text;
                    temp.ModName = modName;
                    modCode = tbCode.Text;
                    temp.ModCode = modCode;
                    credits = Convert.ToDouble(tbCred.Text);
                    temp.NumOfCredits = credits;
                    hours = Convert.ToDouble(tbHour.Text);
                    temp.HoursPerWeek = hours;

                    //add values to list
                    info.Add(new Modules(modCode, modName, credits, hours));
                    temp.mods = info;

                    //display values in datagrid
                    foreach (Modules mod in temp.mods)
                    {
                        dg.Items.Add(mod);
                    }

                    //add module names to the combobox
                    cbModName.Items.Add(modName);
                }
            }
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            //insert values into variables in SelfStudy class
            dpStart.SelectedDateFormat = DatePickerFormat.Short;
            stud.StartDate = Convert.ToDateTime(dpStart.Text);
            
            dpStudyDate.SelectedDateFormat = DatePickerFormat.Short;
            stud.StudyDate = Convert.ToDateTime(dpStudyDate.Text);

            stud.HoursSpentStudying = Convert.ToDouble(tbStudyHours.Text);

            //insert values into local variables
            double numOfWeeks = Convert.ToDouble(tbWeeks.Text);
            double studyHours = Convert.ToDouble(tbStudyHours.Text);

            //call methods from class library and variables as parameters
            double study = Calculations.selfStudyHoursCalc(temp.NumOfCredits,temp.HoursPerWeek, numOfWeeks);
            double remain = Calculations.remainingSelfStudyHours(studyHours, study);

            //displays the information in a label
            lbInfoDisplay.Content = SelfStudy.displaySelfStudy(stud.StartDate, stud.HoursSpentStudying, study, remain, mName);
        }

        //this happens when user changes this combobox
        private void cbModName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //code to get the name of selected module
            mName = cbModName.SelectedValue.ToString();

            //validates if user has made a selection
            if (cbModName.SelectedItem == null)
            {
                MessageBox.Show("Please select a module first");
            }
            else
            {
                //gets all infomation related to specific module
                var filters =
                    from value in temp.mods
                    where value.ModName.Equals(mName)
                    select value;

                filtered = filters.ToList(); //save the info in a list
            }
            
        }
    }
}
