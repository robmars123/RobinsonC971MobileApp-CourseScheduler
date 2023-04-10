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
    public partial class AssessmentDetails : ContentPage
    {
        private Assessment assessment;
        public AssessmentDetails(Assessment _assessment)
        {
            assessment = _assessment;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            AssessmentName.Text = assessment.Name;
            AssessmentType.Text = assessment.AssessmentType;
            StartDate.Text = assessment.StartDate.ToString();
            EndDate.Text = assessment.EndDate.ToString();
            Notifications.Text = assessment.Notifications ? "Yes" : "No";
        }
        public void EditAssessment(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditAssessment(assessment));
        }

        public async void DeleteAssessment(object sender, EventArgs e)
        {
            App.AppDB.DeleteAssessment(assessment);
            await Navigation.PopModalAsync();
        }
    }
}