using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace LabTest.ViewModel
{
    public class Q2_ViewModel : BindableObject
    {
        private string _phone;
        private string _password;
        private bool _isTermsAndConditionsChecked;
        private string _phoneErrorMessage;
        private string _passwordErrorMessage;

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
                ValidateInputs();
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
                ValidateInputs();
            }
        }

        public bool IsTermsAndConditionsChecked
        {
            get { return _isTermsAndConditionsChecked; }
            set
            {
                _isTermsAndConditionsChecked = value;
                OnPropertyChanged();
                ValidateInputs();
            }
        }

        public string PhoneErrorMessage
        {
            get { return _phoneErrorMessage; }
            set
            {
                _phoneErrorMessage = value;
                OnPropertyChanged();
            }
        }

        public string PasswordErrorMessage
        {
            get { return _passwordErrorMessage; }
            set
            {
                _passwordErrorMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsRegisterButtonEnabled => string.IsNullOrEmpty(PhoneErrorMessage) && string.IsNullOrEmpty(PasswordErrorMessage) && IsTermsAndConditionsChecked;

        public ICommand RegisterCommand { get; private set; }

        public Q2_ViewModel()
        {
            RegisterCommand = new Command(OnRegisterButtonClicked);
        }

        private void ValidateInputs()
        {
            PhoneErrorMessage = IsPhoneNumberValid(Phone) ? string.Empty : "Invalid Phone number";
            PasswordErrorMessage = IsPasswordValid(Password) ? string.Empty : "Password length should be greater than 5";

            OnPropertyChanged(nameof(IsRegisterButtonEnabled));
        }

        private bool IsPhoneNumberValid(string phoneNumber)
        {
            // Check if the phone number contains only numeric characters without any additional signs
            return !string.IsNullOrEmpty(phoneNumber) && phoneNumber.All(char.IsDigit);
        }

        private bool IsPasswordValid(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 5;
        }

        private void OnRegisterButtonClicked()
        {
            // Handle registration logic
            // For example, navigate to the next page or perform registration actions
            Console.WriteLine("Registration button clicked!");
        }
    }
}
