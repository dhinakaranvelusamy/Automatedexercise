using Excersice_MVC.Models;
using System.Collections.Generic;

namespace Excersice_MVC.Services
{
    public interface IJasonCRUD
    {
        List<StudentInfo> ReadJason();
    }
}


namespace Excersice_MVC.Services

{ 
    public class JasonCRUD : IJasonCRUD
    {
        public List<StudentInfo> ReadJason()
        {
            // sample hard-coded data for demo
            return new List<StudentInfo>
            {
                new StudentInfo { Rollno = 1, Name = "Raja", Age = 20, Mobileno = 9876543210},
                new StudentInfo { Rollno = 2, Name = "Ravi", Age = 22, Mobileno = 9123456780},
                new StudentInfo { Rollno = 3, Name = "Kumar", Age = 21, Mobileno = 9000000000 }
            };
        }
    }
}
