// JasonCRUD.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JasonLibrary
{
    public class JasonCRUD
    {
        private List<JasonStudentInfo> Info = new List<JasonStudentInfo>();
        private int nextRoll = 1;
        private string filePath = "students.json";

        public JasonCRUD()
        {
            LoadData();
            if (Info.Any())
                nextRoll = Info.Max(x => x.Rollno) + 1;
        }

        // CREATE
        public void AddJason(string name, int age, int standard)
        {
            var student = new JasonStudentInfo
            {
                Rollno = nextRoll++,
                Name = name,
                Age = age,
                Standard = standard
            };
            Info.Add(student);
            SaveData();
        }

        // READ
        public List<JasonStudentInfo> GetAll()
        {
            return Info;
        }

        // UPDATE
        public bool UpdateJason(int rollno, string newName, int newAge, int newStandard)
        {
            var student = Info.FirstOrDefault(x => x.Rollno == rollno);
            if (student != null)
            {
                student.Name = newName;
                student.Age = newAge;
                student.Standard = newStandard;
                SaveData();
                return true;
            }
            return false;
        }

        // DELETE
        public bool DeleteJason(int rollno)
        {
            var student = Info.FirstOrDefault(x => x.Rollno == rollno);
            if (student != null)
            {
                Info.Remove(student);
                SaveData();
                return true;
            }
            return false;
        }

        // SEARCH
        public List<JasonStudentInfo> SearchByName(string keyword)
        {
            return Info.Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // JSON Persistence
        private void SaveData()
        {
            var json = JsonSerializer.Serialize(Info, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        private void LoadData()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                Info = JsonSerializer.Deserialize<List<JasonStudentInfo>>(json) ?? new List<JasonStudentInfo>();
            }
            else
            {
                Info = new List<JasonStudentInfo>();
            }
        }
    }
}
