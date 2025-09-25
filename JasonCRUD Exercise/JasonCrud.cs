using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace JasonLibrary
{
    public class JasonCRUD
    {
        public List<StudentInfo> Info = new List<StudentInfo>();
        public int nextRoll = 1;
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "data.json");

        public JasonCRUD()
        {
            LoadData();
            if (Info.Any())
                nextRoll = Info.Max(x => x.Rollno) + 1;
        }

        // CREATE STUDENT
        public void AddJason(StudentInfo info)
        {
            Info.Add(info);
            SaveData();
        }

        // READ STUDENT
        public List<StudentInfo> GetAll()
        {
            return Info;
        }

        // UPDATE STUDENT
        public bool UpdateJason(int rollno, string newname, int newage, int newmobile)
        {
            var student = Info.FirstOrDefault(x => x.Rollno == rollno);
            if (student != null)
            {
                student.Name = newname;
                student.Age = newage;
                student.Mobile = newmobile;
                SaveData();
                return true;
            }
            return false;
        }

        // DELETE STUDENT
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

        // SEARCH STUDENT
        public List<StudentInfo> SearchByName(string keyword)
        {
            return Info.Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // JSON  
        private void SaveData()
        {
            var json = JsonSerializer.Serialize(Info, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        private void LoadData()
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory("Data");
                File.WriteAllText(filePath, "[]");
            }
                var json = File.ReadAllText(filePath);
            Info = JsonSerializer.Deserialize<List<StudentInfo>>(json) ?? new List<StudentInfo>();        
        }
    }
}
