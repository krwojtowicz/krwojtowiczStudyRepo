using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Threading.Tasks.Sources;
using System.Reflection.Metadata.Ecma335;

namespace oopPlayer
{
    internal class Player
    {
        private string _name;
        private string _password;
        private decimal _avgscore;

        private List<int> _scores = new List<int>();
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                Regex rx = new Regex(@"^[a-zA-Z0-9]*$");
                string temp = value;
                temp = temp.Trim();
                string[] chars = temp.Split();
                string withoutSpace = "";
                foreach(var elem in chars)
                {
                    withoutSpace += elem;
                }
                temp = withoutSpace;
                if (temp == null || temp.Length < 4 || !rx.IsMatch(temp))
                {
                    throw new ArgumentException("Wrong name!");
                }
                temp = temp.ToLower();
                _name = temp;   
            }
        }

        private string Password 
        {
            get
            {
                return _password;
            }
            set
            {
                Regex rx = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");

                if(value == null || value.Trim().Length < 8 || value.Trim().Length > 16 || !rx.IsMatch(value.Trim()))
                {
                    throw new ArgumentException("Wrong password!");
                }
                else
                {
                    _password = value;
                }
                
            } 
        }

        public int BestScore { get; private set; }

        public int LastScore { get; private set; }

        public decimal AvgScore 
        { 
            get
            {
                return Math.Round(_avgscore, 1);
            } 
            private set
            {
                _avgscore = value;
            } 
        }

        public Player(string name, string password)
        {
            Name = name;
            Password = password;
            BestScore = 0;
            LastScore = 0;
            AvgScore = 0;
        }
        public void AddScore(int currentScore)
        {

            if (currentScore < 0 || currentScore > 100)
            {
                throw new ArgumentOutOfRangeException("Wrong value!");
            }
            else
            {
                LastScore = currentScore;
                _scores.Add(currentScore);

                int sum = 0;
                int best = LastScore;

                
                foreach (var score in _scores)
                {
                    if(score > best)
                    {
                        best = score;
                    }
                    sum += score;
                }
                AvgScore = (decimal)sum / (_scores.Count);
                BestScore = best;
            }
        }
        public bool TryAddScore(int currentScore)
        {
            if (currentScore < 0 || currentScore > 100)
            {
                return false;
            }
            else
            {
                
                LastScore = currentScore;
                _scores.Add(currentScore);
                int sum = 0;
                int best = LastScore;
                
                foreach (var score in _scores)
                {
                    if (score > best)
                    {
                        best = score;
                    }
                    sum += score;
                }
                AvgScore = (decimal)sum / (_scores.Count);
                BestScore = best;
            }

            return true;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            Regex rx = new Regex(@"[a-z]+[A-Z]+[0-9]+[\p{P}\d]+");
            string temp = newPassword;
            temp.Trim();
            if (oldPassword != Password || temp.Length < 8 || temp.Length > 16 || !rx.IsMatch(temp))
            { 
                return false;
            }
            else
            {
                _password = temp;
                return true;
            }
        }

        public bool VerifyPassword(string password)
        {
            if(password == null) return false;
            if (Password == password)
            {
                return true;
            }
            else 
                return false;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Score: last={LastScore}, best={BestScore}, avg={AvgScore}";
        }

    }
}
