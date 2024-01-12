using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace LabTest.ViewModel
{
    public class Q1_ViewModel : BindableObject
    {
        private double _sliderValue;
        private string _label1Text;
        private string _label2Text;
        private Color _label2TextColor;

        public double SliderValue
        {
            get { return _sliderValue; }
            set
            {
                _sliderValue = value;
                OnPropertyChanged();
                UpdateLabels();
            }
        }

        public string Label1Text
        {
            get { return _label1Text; }
            set
            {
                _label1Text = value;
                OnPropertyChanged();
            }
        }

        public string Label2Text
        {
            get { return _label2Text; }
            set
            {
                _label2Text = value;
                OnPropertyChanged();
            }
        }

        public Color Label2TextColor
        {
            get { return _label2TextColor; }
            set
            {
                _label2TextColor = value;
                OnPropertyChanged();
            }
        }

        public Q1_ViewModel()
        {
            // Initialize properties or set default values if needed
            SliderValue = 0;
        }

        private void UpdateLabels()
        {
            // Update Label1Text
            Label1Text = SliderValue.ToString("F0"); // Display value without decimal place

            // Update Label2Text and Label2TextColor based on SliderValue
            if (SliderValue >= 0 && SliderValue <= 39)
            {
                Label2Text = "Failed";
                Label2TextColor = Colors.Red;
            }
            else if (SliderValue >= 40 && SliderValue <= 79)
            {
                Label2Text = "Passed";
                Label2TextColor = Colors.Black;
            }
            else
            {
                Label2Text = "Excellent";
                Label2TextColor = Colors.Green;
            }
        }
    }
}
