using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
namespace MyProg
{
    // STUDENT_ANSWER
    public class Person
    {
        private string _firstName = String.Empty;
        private string _familyName = String.Empty;
        private int _age;
        public string FirstName
        {
            get => _firstName;
            protected set
            {
                if (checkNames(value.Trim()))
                {
                    string temp = "";
                    string val = value.Trim();
                    temp += char.ToUpper(val[0]);
                    for (int i = 1; i < val.Length; i++)
                    {
                        if (val[i] == ' ') continue;
                        temp += char.ToLower(val[i]);
                    }
                    _firstName = temp;
                }
                else throw new ArgumentException("Wrong name!");
            }
        }
        public string FamilyName
        {
            get => _familyName;
            protected set
            {
                if (checkNames(value.Trim()))
                {
                    string temp = "";
                    string val = value.Trim();
                    temp += char.ToUpper(val[0]);
                    for (int i = 1; i < val.Length; i++)
                    {
                        if (val[i] == ' ') continue;
                        temp += char.ToLower(val[i]);
                    }
                    _familyName = temp;
                }
                else throw new ArgumentException("Wrong name!");
            }
        }
        public int Age
        {
            get => _age;
            protected set
            {
                if (value < 0) throw new ArgumentException("Age must be positive!");
                _age = value;
            }
        }
        public Person(string familyName, string firstName, int age)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
        }
        public override string ToString() => $"{FirstName} {FamilyName} ({Age})";
        private bool checkNames(string name)
        {
            if (name == "" || !name.All(c => (char.IsLetter(c)) || c == ' ')) return false;
            return true;
        }
        public void modifyFirstName(string firstName)
        {
            FirstName = firstName;
        }
        public void modifyFamilyName(string familyName)
        {
            FamilyName = familyName;
        }
        public virtual void modifyAge(int age)
        {
            Age = age;
        }
    }
    public class Child : Person
    {
        private Person _mother;
        private Person _father;
        public int ChildAge
        {
            get => base.Age;
            private set
            {
                if (value > 15) throw new ArgumentException("Child’s age must be less than 15!");
                base.Age = value;
            }
        }
        public Child(string familyName, string firstName, int age) : base(familyName, firstName, age)
        {
            ChildAge = age;
            _mother = null;
            _father = null;
        }
        public Child(string familyName, string firstName, int age, Person mother = null, Person father = null) : this(familyName, firstName, age)
        {
            _mother = mother;
            _father = father;
        }
        public override void modifyAge(int age)
        {
            ChildAge = age;
        }
        public override string ToString()
        {
            string output = "";
            output += base.ToString() + "\n";
            if (_mother != null) output += $"mother: {_mother.FirstName} {_mother.FamilyName} ({_mother.Age})\n";
            else output += "mother: No data\n";
            if (_father != null) output += $"father: {_father.FirstName} {_father.FamilyName} ({_father.Age})";
            else output += "father: No data";
            return output;
        }
    }
    public class Program
    {
        public static int Main(string[] args)
        {
            //TEST.testcode
            try
            {
                Person p = new Person(familyName: "Molenda", firstName: "Krzysztof", age: 18);
                Console.WriteLine(p);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return 0;
        }
    }
}