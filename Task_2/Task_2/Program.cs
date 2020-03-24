using System;
using System.IO;
using System.Xml.Serialization;
using Task_2.Model;

namespace Task_2
{
    
    public class Program
    {
        public static void Main(string[] args)
        {

            var path = @"Log\log.txt";

            //Cleaning log.tct
            File.WriteAllText(path, String.Empty);
            

            var draft = @"Data\data.csv";
            var file = new FileInfo(draft);
            if (!file.Exists) {
                File.AppendAllText(path, "File does not exist!");
                Console.Error.Write("File does not exist!");
                Environment.Exit(1);
                throw new FileNotFoundException();
            }

            FileStream writer = new FileStream(@"Result.xml", FileMode.Create);
            University u = new University()
            {
                Date = DateTime.Now.ToString("d"),
                Author = "Viktoriia Skorokhod"

            };

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("","");
            XmlSerializer serializer = new XmlSerializer(typeof(University));

            int numberOfStudents0 = 0;
            int numberOfStudents1 = 0;
            int others = 0;

            using (var stream = new StreamReader(file.OpenRead()))
            {
                String line = null;


                while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    bool switching = true;
                    while (switching)
                    {
                        for (int i = 0; i < student.Length; i++)
                        {
                            
                            if (string.IsNullOrEmpty(student[i]))
                            {
                                string error = "Empty value found: " + line + Environment.NewLine;
                                File.AppendAllText(path, error);
                                break;
                            }
                        }

                        var s0 = new Studies
                        {
                            Faculty = student[2],
                            Mode = student[3]
                        };
                        var s = new Student
                        {
                            Name = student[0],
                            Surname = student[1],
                            Index = student[4],
                            Birthdate = DateTime.Parse(student[5]).ToString("dd MMMM yyyy hh:mm:ss tt"),
                            Email = student[6],
                            MothersName = student[7],
                            FathersName = student[8],
                            studies = s0
                        };

                        if (!u.students.Add(s))
                        {
                            string error = "Dublicate found: " + line + Environment.NewLine;
                            File.AppendAllText(path, error);
                        }
                        else
                        {
                            u.students.Add(s);

                            if (s0.Faculty.StartsWith("Informatyka"))
                            {
                                numberOfStudents0++;
                            }
                            else if (s0.Faculty.StartsWith("Sztuka"))
                            {
                                numberOfStudents1++;
                            }
                            else
                            {
                                others++;
                            }
                        }
                       
                        break;

                    }
                }
            }

            ActiveStudies a0 = new ActiveStudies
            {
                Name = "Computer Science",
                Count = numberOfStudents0
            };

            ActiveStudies a1 = new ActiveStudies 
            {
                Name = "New Media Art",
                Count = numberOfStudents1
            };

            ActiveStudies a2 = new ActiveStudies
            {
                Name = "Other",
                Count = others
            };

            u.activeStudies.Add(a0);
            u.activeStudies.Add(a1);
            u.activeStudies.Add(a2);

         //Console.WriteLine(u.students.Count);
        serializer.Serialize(writer, u, ns);
            Console.WriteLine("log.txt -> ...\\bin\\Debug\\netcoreapp3.1\\Log\\log.txt" + "\n" + "Result.xml -> ... \\bin\\Debug\\netcoreapp3.1\\Result.xml");
            Console.WriteLine("\nPROJECT SPONSOR: https://www.youtube.com/watch?v=8DMChMWAcCk");
        }
    }
}
