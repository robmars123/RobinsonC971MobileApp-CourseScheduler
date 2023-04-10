using RobinsonC971MobileApp.Models;
using RobinsonC971MobileApp.Services;
using RobinsonC971MobileApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Plugin.LocalNotifications;

namespace RobinsonC971MobileApp
{
    public partial class MainPage : ContentPage
    {
        public bool NotificationAlerts = true;
        public MainPage()
        {
            InitializeComponent();
            termListView.ItemTapped += new EventHandler<ItemTappedEventArgs>(Term_Clicked);
        }
        protected override async void OnAppearing()
        {
            List<Term> termList = new List<Term>();
            List<Course> courses = new List<Course>();
            List<Assessment> assessmentList = new List<Assessment>();
            termList = App.AppDB.GetTermList().Result;
            courses = App.AppDB.CourseList().Result;
            assessmentList = App.AppDB.AssessmentList().Result;

            if (NotificationAlerts == true)
            {
                NotificationAlerts = false;
                int courseId = 0;

                foreach (Course course in courses)
                {
                    courseId++;
                    if (course.Notifications == 1)
                    {
                        if (course.StartDate == DateTime.Today)
                            CrossLocalNotifications.Current.Show("Reminder", $"{course.Name} begins today!", courseId);
                        if (course.EndDate == DateTime.Today)
                            CrossLocalNotifications.Current.Show("Reminder", $"{course.Name} ends today!", courseId);
                    }
                }

                int assessmentId = courseId;
                foreach (Assessment assessment in assessmentList)
                {
                    assessmentId++;
                    if (assessment.Notifications)
                    {
                        if (assessment.StartDate == DateTime.Today)
                            CrossLocalNotifications.Current.Show("Reminder", $"{assessment.Name} begins today!", assessmentId);
                        if (assessment.EndDate == DateTime.Today)
                            CrossLocalNotifications.Current.Show("Reminder", $"{assessment.Name} ends today!", assessmentId);
                    }
                }
            }

            termListView.ItemsSource = termList;
        }
        async private void Term_Clicked(object sender, ItemTappedEventArgs e)
        {
            Term term = (Term)e.Item;
            await Navigation.PushModalAsync(new TermDetails(term));
        }

        private void OnButtonClickAddTerm(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddTerm(this));
        }
    }
}

