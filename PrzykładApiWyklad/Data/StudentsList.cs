using PrzykładApiWyklad.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;

namespace PrzykładApiWyklad.Data
{
    public class StudentsList
    {
        public List<Student> Studenci = new List<Student>();
        private string path = @"data\baza.csv";
        public StudentsList()
        {

            try
            {
                using (var reader = new StreamReader(path))
                {
                    // List<string> listA = new List<string>();
                    // List<string> listB = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        // listA.Add(values[0]);
                        // listB.Add(values[1]);
                        Student s1 = new Student
                        {
                            FirstName = values[0],
                            LastName = values[1]
                        };
                        Studenci.Add(s1); // dopisać obsługę gdy lista jest pusta
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                File.Create(path).Close();

            }
        }
        public void AddStudent(Student st)
        {
            
            List<string> newLines = new List<string>();
            newLines.Add(st.FirstName+";"+st.LastName);
          
            File.AppendAllLines(path, newLines);
            Studenci.Add(st);
        }

        public int RemoveStudent(Student sDel)
        {
            // 1. usuń z kolekcji
             List<Student> StudToDel = new List<Student>();
            int counter = 0;
                foreach (Student s in Studenci)
                    {
                    if ((s.FirstName.Equals(sDel.FirstName)) && (s.LastName.Equals(sDel.LastName) == true))
                {
                    StudToDel.Add(s);
                }
                    }
                
                foreach (Student s in StudToDel)
                    {
                        Studenci.Remove(s);
                    counter++;
                    }
            StudToDel.Clear();
            PrepeareFile();
            return counter;
           // 2. wygeneruj plik na nowo
        }
        internal void PrepeareFile()
        {

            File.Delete(path);
             File.Create(path).Close();

            using (TextWriter tw = new StreamWriter(path)) 
            {
                foreach (Student s in Studenci)

                    tw.WriteLine(s.FirstName + ";" + s.LastName);
            }
            
        }


    }
}
