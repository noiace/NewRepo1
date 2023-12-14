using System;
using System.Collections.Generic;
using System.Data;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab7
{
    class Student
    {
        private Person _person;
        private Education _education;
        private int _group;
        private Exam[] _exams;

        public Person Person { get => _person; set => _person = value; }
        public Education Education { get => _education; set => _education = value; }
        public int Group { get => _group; set => _group = value; }
        public Exam[] Exams { get => _exams; set => _exams = value; }

        public Student(Person person, Education education, int group)
        {
            _person = person;
            _education = education;
            _group = group;
            _exams = new Exam[0];
        }
        public Student()
        {
            _person = new Person();
            _education = Education.Specialist;
            _group = 0;
            _exams = new Exam[0];
        }
        public double Avg
        {
            get
            {
                if (this._exams.Length != 0)
                {
                    double avg = 0;
                    foreach (var element in _exams)
                    {
                        avg += element.Mark;
                    }
                    return avg / _exams.Length;
                }
                return 0;
            }
            set { }
        }
        public bool this[Education education]
        {
            get
            {
                return _education == education;
            }
        }
        public void AddExams(params Exam[] exams)
        {
            int exams_length = _exams.Length;
            Array.Resize(ref _exams, _exams.Length + exams.Length);

            for (int j = 0; j + exams_length < _exams.Length; j++)
            {
                _exams[j + exams_length] = exams[j];
            }
        }
        public override string ToString()
        {
            string exams = "";
            
            for (int k = 0; k < _exams.Length; k++)
            {
                exams += _exams[k].ToString() + " ";
            }
            string info1 = $"{_person}, {_education}, {_group}, {exams}";
            return info1;
        }
        public virtual string ToShortString()
        {
            string info2 = $"{_person}, {_education}, {_group}, {Avg}";
            return info2;
        }



    }
}
