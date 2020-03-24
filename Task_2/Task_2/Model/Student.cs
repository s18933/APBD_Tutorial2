using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Task_2.Model
{
    
    [XmlType( "university" )]
    public class University
    {
        private string _date;
        private string _name;
       [XmlAttribute( attributeName: "createdAt")]
        public string Date
        {
            get { return _date; }
            set { _date = value ; }
        }

        [XmlAttribute(attributeName: "author")]
        public string Author
        {
            get { return _name; }
            set { _name = value; }
        }


        public HashSet<Student> students = new HashSet<Student>(new Comparison());
        public HashSet<ActiveStudies> activeStudies = new HashSet<ActiveStudies>();
    }
   [XmlType( "student" )]
    public class Student
    {
        private string _name;
        private string _surname;
        private string _index;
        private string _birthDate;
        private string _email;
        private string _mothersName;
        private string _fathersName;

        [XmlAttribute(attributeName: "indexNumber")]
        public string Index
        {
            get { return _index; }
            set { _index = "S" + value; }
        }

        [XmlElement(elementName: "fname", Order = 1)]
        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        [XmlElement(elementName: "lname", Order = 2)]
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        [XmlElement(elementName: "birthdate", Order = 3)]
        public string Birthdate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        [XmlElement(elementName: "email", Order = 4)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [XmlElement(elementName: "mothersName", Order = 5)]
        public string MothersName
        {
            get { return _mothersName; }
            set { _mothersName = value; }
        }

        [XmlElement(elementName: "fathersName", Order = 6)]
        public string FathersName
        {
            get { return _fathersName; }
            set { _fathersName = value; }
        }

        [XmlElement(elementName: "studies", Order = 7)]
        public Studies studies = new Studies();
     }
    public class Studies {
        private string _faculty;
        private string _mode;
        
        [XmlElement(elementName: "name")]
        public string Faculty
        {
            get { return _faculty; }
            set { _faculty = value; }
        }

        [XmlElement(elementName: "mode")]
        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
    }

    [XmlType("studies")]
    public class ActiveStudies
    {

        [XmlAttribute(attributeName: "name")]
        public string Name { get; set; }

        [XmlAttribute(attributeName:"numberOfStudents")]
        public int  Count { get; set; }
    }
  }


