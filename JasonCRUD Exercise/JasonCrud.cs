using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Excersice_MVC.Models;

namespace JasonLibrary
{
    public class JasonCRUD
    {
        private readonly string filePath = "students.json";

        private List<StudentInfo> LoadStudents()
        {
            if (!File.Exists(filePath))
                return new List<StudentInfo>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<StudentInfo>>(json) ?? new List<StudentInfo>();
        }

        private void SaveStudents(List<StudentInfo> students)
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AddJason(StudentInfo student)
        {
            var students = LoadStudents();
            students.Add(student);
            SaveStudents(students);
        }

        public List<StudentInfo> ReadJason()
        {
            return LoadStudents();
        }

        public bool UpdateJason(int roll, string name, int age, long mobile)
        {
            var students = LoadStudents();
            var student = students.FirstOrDefault(s => s.Rollno == roll);

            if (student == null)
                return false;

            student.Name = name;
            student.Age = age;
            student.Mobileno = mobile;
            SaveStudents(students);
            return true;
        }

        public bool DeleteJason(int roll)
        {
            var students = LoadStudents();
            var student = students.FirstOrDefault(s => s.Rollno == roll);

            if (student == null)
                return false;

            students.Remove(student);
            SaveStudents(students);
            return true;
        }

        public List<StudentInfo> SearchByName(string name)
        {
            var students = LoadStudents();
            return students.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public StudentInfo SearchByRollNo(int roll)
        {
            var students = LoadStudents();
            return students.FirstOrDefault(s => s.Rollno == roll);
        }

        public StudentInfo SearchByMobile(long mobile)
        {
            var students = LoadStudents();
            return students.FirstOrDefault(s => s.Mobileno == mobile);
        }
    }
}
