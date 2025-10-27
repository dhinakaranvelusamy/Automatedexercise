using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using JasonLibrary;
using StudentinFormation;
using Models;

namespace StudentInformation
{
    public class StudentsRepository
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "students.json");
        private List<StudentInfo> students;
        

        public StudentsRepository()
        {
            LoadData();
            var stud = new StudentInfoss();
            stud.List();
        }

        private void LoadData()
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllText(filePath, "[]");
            }
            var json = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<StudentInfo>>(json) ?? new List<StudentInfo>();
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<StudentInfo> GetStudents() => students;

        public StudentInfo GetStudentByID(int id) => students.FirstOrDefault(s => s.Id == id);

        public bool AddStudent(StudentInfo student)
        {
            students.Add(student);
            SaveData();
            return true;
        }

        public bool UpdateStudent(StudentInfo student)
        {
            var existing = GetStudentByID(student.Id);
            if (existing == null) return false;

            existing.Name = student.Name;
            existing.Rollno = student.Rollno;
            existing.Age = student.Age;
            existing.Mobileno = student.Mobileno;
            SaveData();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = GetStudentByID(id);
            if (student == null) return false;

            students.Remove(student);
            SaveData();
            return true;
        }

        public List<StudentInfo> SearchStudentsByName(string name)
        {
            return students
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }

}
