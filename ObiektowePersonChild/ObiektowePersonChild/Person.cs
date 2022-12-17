using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObiektowePersonChild
{
    public class Person
    {
        private string _name;
        public string FirstName 
        {
            get => _name;
            protected set
            {
                value = value.Trim();
                value = value.ToUpper();
                _name = value;
            }
        }

        private string _lastName;
        public string FamilyName 
        {
            get => _lastName;
            protected set
            {
                value = value.Trim();

                _lastName = value;
            } 
        }

        public int Age { get; protected set; }

        public Person(string familyName, string firstName, int age)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
        }

        public override string ToString()
        {
            return $"{FirstName} {FamilyName} ({Age})";
        }
    }
}
