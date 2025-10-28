using System;
using System.Collections.Generic;
using System.Linq;
using StudentLibrary;
using JasonLibrary; // Assuming StudentInfo is defined here

namespace JasonCRUD_Exercise
{
    public class StudentManage
    {
        public List<StudentInfo> students = new List<StudentInfo>();
        public StudentManage()
        {

            students.Add(new StudentInfo { Rollno = 101, Name = "Arun", Age = 20, Mobileno = 9876543210 });
            students.Add(new StudentInfo { Rollno = 102, Name = "Bala", Age = 21, Mobileno = 9876501234 });
            students.Add(new StudentInfo { Rollno = 103, Name = "Chitra", Age = 19, Mobileno = 9876005678 });
        }

        //  Search by Roll Number
        public StudentInfo SearchByRollNo(int rollNo)
        {
            return students.FirstOrDefault(s => s.Rollno == rollNo);
        }

        //  Search by Mobile Number
        public StudentInfo SearchByMobile(long mobile)
        {
            return students.FirstOrDefault(s => s.Rollno == mobile);
        }

        // Search by Name 
        public List<StudentInfo> SearchByName(string name)
        {
            return students
                .Where(s => s.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
