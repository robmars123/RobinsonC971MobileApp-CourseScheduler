using RobinsonC971MobileApp.Models;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RobinsonC971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Assessments : ContentPage
    {
        private Course course;
        private Assessment assessment;
        public Assessments(Course _course)
        {
            course = _course;
            assessment = new Assessment();
            InitializeComponent();
            AssessmentsView.ItemTapped += new EventHandler<ItemTappedEventArgs>(Assessment_Clicked);
        }
        protected override async void OnAppearing()
        {
            AssessmentsView.ItemsSource = App.AppDB.GetAssessments(course.Id);
        }
        async private void Assessment_Clicked(object sender, ItemTappedEventArgs e)
        {
            assessment = (Assessment)e.Item;
            await Navigation.PushModalAsync(new AssessmentDetails(assessment));
        }
        public void AddAssessment(object sender, EventArgs e)
        {
            assessment.CourseID = course.Id;
            Navigation.PushModalAsync(new AddAssessment(assessment));
        }

    }
}