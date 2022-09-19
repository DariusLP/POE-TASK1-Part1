using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcs
{
    public class Calculations
    {
        //calculates total self-study hours
        public static double selfStudyHoursCalc(double numOfCredits, double classHours, double numOfWeeks)
        {
            return Math.Round(((numOfCredits * 10) / numOfWeeks) - classHours);
        }

        //calculates remaining self-study hours
        public static double remainingSelfStudyHours(double numOfHours, double selfStudyHours)
        {
            return Math.Round(selfStudyHours - numOfHours);
        }
    }

    public class Modules
    {
        //parameterized constructor
        public Modules(string modCode, string modName, double numOfCredits, double hoursPerWeek)
        {
            ModCode = modCode;
            ModName = modName;
            NumOfCredits = numOfCredits;
            HoursPerWeek = hoursPerWeek;
        }

        //default constructor
        public Modules()
        {

        }

        //variables
        public string ModCode { get; set; }
        public string ModName { get; set; }
        public double NumOfCredits { get; set; }
        public double HoursPerWeek { get; set; }
        public List<Modules> mods { get; set; }

    }

    public class SelfStudy
    {
        //parameterized constructor
        public SelfStudy(DateTime studyDate, double hoursSpentStudying, DateTime startDate
            , double numOfWeeks, double selfStudyHoursPerWeek, double remainingSelfStudyHours)
        {
            StudyDate = studyDate;
            HoursSpentStudying = hoursSpentStudying;
            StartDate = startDate;
            NumOfWeeks = numOfWeeks;
            SelfStudyHoursPerWeek = selfStudyHoursPerWeek;
            RemainingSelfStudyHours = remainingSelfStudyHours;
        }

        //default constructor
        public SelfStudy()
        {

        }

        //variables
        public DateTime StartDate { get; set; }
        public double NumOfWeeks { get; set; }
        public DateTime StudyDate { get; set; }
        public double HoursSpentStudying { get; set; }
        public double SelfStudyHoursPerWeek { get; set; }
        public double RemainingSelfStudyHours { get; set; }

        //display method
        //takes variables as parameters to display
        public static string displaySelfStudy(DateTime StudyDate, double HoursSpentStudying
            , double SelfStudyHoursPerWeek, double RemainingSelfStudyHours, string ModuleName)
        {
            return "You have studied " + ModuleName + " on the " + StudyDate + " for " + HoursSpentStudying + " hours."
                + "\nFor " + ModuleName + " you have a total of " + SelfStudyHoursPerWeek + " hours of self studying to do." +
                "\nAfter studying you now have " + RemainingSelfStudyHours + " hours left of studying to do.";
        }
    }
}
