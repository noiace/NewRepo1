using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//var 2
namespace lab7
{
    class Person
    {
        private string _name;
        private string _lastName;
        private DateTime _birthDay;

        public Person(string name, string LastName, DateTime BirthDay)
        {
            this._name = name;
            this._lastName = LastName;
            this._birthDay = BirthDay;
        }

        public Person()
        {
            this._name = "Adel";
            this._lastName = "Galimov";
            this._birthDay = new DateTime(2004, 09, 14);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime BirthDay
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }
        public int BirthDayYear
        {
            get { return BirthDay.Year; }
            set { BirthDay = new DateTime(value, BirthDay.Month, BirthDay.Day); }
        }
        public override string ToString()
        {
            string info = $"{Name} {LastName} {BirthDay}";
            return info;
        }
        public virtual string ToShortString()
        {
            string info = $"{Name} {LastName}";
            return info;
        }
        /*public virtual bool Equals()
        {
            return true;
        }
        public static Person operator !=(Person _name, Person _lastname)
        {

        }
        public static Person operator ==(Person _name, Person _lastname)
        {

        }*/
    }
}
