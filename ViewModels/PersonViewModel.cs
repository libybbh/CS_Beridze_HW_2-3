using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Beridze_2.Commands;
using Beridze_2.Models;

namespace Beridze_2.ViewModels

{
    class PersonViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _name;
        private string _surName;
        private string _email;

        private DateTime _dateBirth = DateTime.Today;
        private int _age;
        private string _zodiac;
        private string _chinese;
        #endregion

        private RelayCommand<object> _proceedCommand;

        #region Getters and Settters
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get
            {
                return _age;
            }
            set { _age = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateOfBirth
        {
            get
            {
                return (_dateBirth);
            }
            set
            {
                _dateBirth = value;
                OnPropertyChanged();
            }
        }
        
        public string Zodiac
        {
            get
            {
                return _zodiac;

            }
            set
            {
                _zodiac = value;
                OnPropertyChanged();
            }
        }

        public string Chinese
        {
            get
            {
                return _chinese;
            }
            set
            {
                _chinese = value;
                OnPropertyChanged();
            }
        }
#endregion

        //when button was clicked
        public RelayCommand<Object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(
                           o =>
                           {
                               int days = (DateTime.Today - _dateBirth).Days;
                               var age = days / 365;

                               _age = age;
                               if (_age >= 135)
                               {
                                   MessageBox.Show("Illegal date!");
                               }
                               else if (DateTime.Today.Year < _dateBirth.Year)
                               {
                                   MessageBox.Show("Your year of birth can`t be in future! Write down correct year!");
                               }
                               else if (_dateBirth.Year < 1800)
                               {
                                   MessageBox.Show("Sorry, you`re already dead!");
                               }
                               else if (!_email.Contains("@"))
                               {
                                   MessageBox.Show("Your email isn`t correct!");
                               }
                               else
                               {
                                   Person person = new Person(_name, _surName, _email, _dateBirth);

                                   MessageBox.Show(
                                                                       $"Your First name is: {person.Name}\n" +
                                                                       $"Your Surname is: {person.Surname}\n" +
                                                                       $"Your Email is: {person.Email}\n" +
                                                                       $"Your Age is: {person.Age}\n" +
                                                                       $"Your Date of birth is: {person.DateOfBirth}\n" +
                                                                       $"Are you an Adult: {person.IsAdult}\n" +
                                                                       $"Your SunSign is: {person.Zodiac}\n" +
                                                                       $"Your Chinese Sign is: {person.Chinese}\n" +
                                                                       $"{person}"
                                                                   );
                                   if (_dateBirth.Day == DateTime.Today.Day && _dateBirth.Month == DateTime.Today.Month)
                                   { MessageBox.Show("It`s your birthday! - " + $"{_age}"); }
                               }
                               
                           }, o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) && !string.IsNullOrWhiteSpace(_surName) && !string.IsNullOrWhiteSpace(_email);
            
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
