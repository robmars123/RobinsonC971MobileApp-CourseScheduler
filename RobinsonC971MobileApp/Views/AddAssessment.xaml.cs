using RobinsonC971MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RobinsonC971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAssessment : ContentPage
    {
        private Assessment assessment;
        public AddAssessment(Assessment _assessment)
        {
            assessment = _assessment;
            InitializeComponent();
        }
        public async void SaveAssessment(object sender, EventArgs e)
        {
            assessment.AssessmentType = AssessmentType.SelectedItem.ToString();
            assessment.Name = AssessmentName.Text;
            assessment.Notifications = EnableNotifications.IsEnabled ? true : false;
            assessment.StartDate = StartDate.Date;
            assessment.EndDate = EndDate.Date;

            App.AppDB.AddAssessment(assessment);
            await Navigation.PopModalAsync();
        }
    }
}