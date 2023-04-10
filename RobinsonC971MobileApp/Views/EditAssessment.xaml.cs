using RobinsonC971MobileApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RobinsonC971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAssessment : ContentPage
    {
        private Assessment assessment;
        public EditAssessment(Assessment _assessment)
        {
            assessment = _assessment;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            AssessmentName.Text = assessment.Name;
            StartDate.Date = assessment.StartDate;
            EndDate.Date = assessment.EndDate;
            EnableNotifications.On = assessment.Notifications == true ? true : false;
            base.OnAppearing();
        }

        public async void SaveAssessment(object sender, EventArgs e)
        {
            assessment.Notifications = EnableNotifications.On ? true : false;
            assessment.Name = AssessmentName.Text;
            assessment.StartDate = StartDate.Date;
            assessment.EndDate = EndDate.Date;

            App.AppDB.UpdateAssessment(assessment);
            await Navigation.PopModalAsync();
        }

    }
}