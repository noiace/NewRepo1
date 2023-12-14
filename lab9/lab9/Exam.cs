using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab7
{
    class Exam
    {
        public string Subject { get; set; }
        public int Mark { get; set; }
        public DateTime Date { get; set; }
        public Exam()
        {
            Subject = "Math";
            Mark = 5;
            Date = new DateTime(2023, 05, 21);
        }
        public Exam(string Subject, int Mark, DateTime Date)
        {
            this.Subject = Subject;
            this.Mark = Mark;
            this.Date = Date;
        }
        public override string ToString()
        {
            string info = $"{Subject} {Mark} {Date}";
            return info;
        }
    }
}
