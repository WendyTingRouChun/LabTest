namespace LabTest.View;
using LabTest.ViewModel;  // Add the correct namespace here

public partial class Q2 : ContentPage
{
    public Q2()
    {
        InitializeComponent();
        BindingContext = new Q2_ViewModel();
    }
}
