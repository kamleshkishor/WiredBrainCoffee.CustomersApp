﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Base;

namespace WiredBrainCoffee.CustomersApp.Model
{
    public class Customer : Observable
    {
        private string _firstName;
        private string _lastName;
        private bool _isDeveloper;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public bool IsDeveloper
        {
            get => _isDeveloper;
            set
            {
                _isDeveloper = value;
                OnPropertyChanged();
            }
        }
    }
}
