using LabTest.ViewModel;
using Microsoft.Maui.Controls;

namespace LabTest.View
{
    public partial class Q1 : ContentPage
    {
        public Q1()
        {
            InitializeComponent();
            BindingContext = new Q1_ViewModel();
        }
    }
}
