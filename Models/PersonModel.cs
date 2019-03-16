using System;

namespace Beridze_2.Models
{
    class Person
    {
        #region Fields
        private string _name;
        private string _surName;
        private string _email;
        private DateTime _dateBirth;
        private int _age;

        private readonly bool _isAdult;
        private readonly string _zodiac;
        private readonly string _chinese;
        private readonly bool _isBirthday;
        #endregion

        #region Constructors
        public Person(string name, string surName, string email, DateTime dateBirth)
        {
            _name = name;
            _surName = surName;
            _email = email;
            _dateBirth = dateBirth;

            _isAdult = CheckAdult();
            _chinese = ChineseC();
            _zodiac = ZodiacC();
            _isBirthday = IsBirthDay();
        }

        public Person(string name, string surName, string email) : this(name, surName, email, DateTime.MaxValue) { }
        public Person(string name, string surName, DateTime birthDate) : this(name, surName, null, birthDate) { }
        #endregion

        #region Getters and Setters
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _surName;
            }
            set
            {
                _surName = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public string Age
        {
            get
            {
                return $"{_age}";
            }
        }

        public string Zodiac
        {
            get
            {
                return _zodiac;
            }
        }

        public string Chinese
        {
            get
            {
                return _chinese;
            }
        }

        public bool IsAdult
        {
            get
            {
                return CheckAdult();
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateBirth; }
            set
            {
                _dateBirth = value;
                Update();
            }
        }
        #endregion

        #region Calculates
        private void Update()
        {
            int days = (DateTime.Today - _dateBirth).Days;
            var age = days / 365;

            _age = age;
            
        }
       
        public bool CheckAdult()
        {
            Update();
            if (_age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private bool IsBirthDay()
        {
            if (DateTime.Today.DayOfYear == _dateBirth.DayOfYear) {
                return true;
            } else return false;
            
        }

        private string ChineseC()
        {
            switch ((_dateBirth.Year - 4) % 12)
            {
                case 0:
                    return "Rat";

                case 1:
                    return "Ox";

                case 2:
                    return "Tiger";

                case 3:
                    return "Rabbit";

                case 4:
                    return "Dragon";

                case 5:
                    return "Snake";

                case 6:
                    return "Horse";

                case 7:
                    return "Goat";

                case 8:
                    return "Monkey";

                case 9:
                    return "Rooster";

                case 10:
                    return "Dog";

                case 11:
                    return "Pig";

                default:
                    return " ";

            }

        }
        private string ZodiacC()
        {
            switch (_dateBirth.Month)
            {
                case 1:
                    if (_dateBirth.Day <= 20)
                        return "Your zodiac sign is Capricorn";
                    else
                        return "Your zodiac sign is Aquarius";

                case 2:
                    if (_dateBirth.Day <= 19)
                        return "Your zodiac sign is Aquarius";
                    else
                        return "Your zodiac sign is Pisces";

                case 3:
                    if (_dateBirth.Day <= 20)
                        return "Your zodiac sign is Pisces";
                    else
                        return "Your zodiac sign is Aries";

                case 4:
                    if (_dateBirth.Day <= 20)
                        return "Your zodiac sign is Aries";
                    else
                        return "Your zodiac sign is Taurus";

                case 5:
                    if (_dateBirth.Day <= 21)
                        return "Your zodiac sign is Taurus";
                    else
                        return "Your zodiac sign is Gemini";

                case 6:
                    if (_dateBirth.Day <= 22)
                        return "Your zodiac sign is Gemini";
                    else
                        return "Your zodiac sign is Cancer";

                case 7:
                    if (_dateBirth.Day <= 22)
                        return "Your zodiac sign is Cancer";
                    else
                        return "Your zodiac sign is Leo";

                case 8:
                    if (_dateBirth.Day <= 23)
                        return "Your zodiac sign is Leo";
                    else
                        return "Your zodiac sign is Virgo";

                case 9:
                    if (_dateBirth.Day <= 23)
                        return "Your zodiac sign is Virgo";
                    else
                        return "Your zodiac sign is Libra";

                case 10:
                    if (_dateBirth.Day <= 23)
                        return "Your zodiac sign is Libra";
                    else
                        return "Your zodiac sign is Scorpio";

                case 11:
                    if (_dateBirth.Day <= 22)
                        return "Your zodiac sign is Scorpio";
                    else
                        return "Your zodiac sign is Sagittarius";

                case 12:
                    if (_dateBirth.Day <= 21)
                        return "Your zodiac sign is Sagittarius";
                    else
                        return "Your zodiac sign is Capricorn";
                default:
                    return "Your zodiac sign was not found! Please try again!";
            }
        }
        #endregion
    }
}