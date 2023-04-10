using RobinsonC971MobileApp.Models;
using RobinsonC971MobileApp.Services;
using RobinsonC971MobileApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Plugin.LocalNotifications;
using System.Linq;

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

            //Part 6 Requirements
            if (!termList.Any())
            {
                Term testTerm = new Term();
                testTerm.Title = "Term 1 - Spring";
                testTerm.StartDate = new DateTime(2023, 03, 01);
                testTerm.EndDate = new DateTime(2023, 08, 30);
                await App.AppDB.AddTerm(testTerm);
                termList.Add(testTerm);

                var testCourse = new Course();
                testCourse.Name = "Mobile Application - C971";
                testCourse.StartDate = new DateTime(2023, 03, 01);
                testCourse.StartDate = new DateTime(2023, 08, 30);
                testCourse.Status = "In-Progress";
                testCourse.InstructorName = "Lauren Provost";
                testCourse.InstructorPhoneNumber = "385-428-8921";
                testCourse.InstructorEmailAddress = "lauren.provost@wgu.edu";
                testCourse.Notifications = 1;
                testCourse.Notes = "This class is my first Android App!";
                testCourse.TermId = testTerm.Id;
                App.AppDB.AddCourse(testCourse);

                var dummyObjectiveAssessment = new Assessment();
                dummyObjectiveAssessment.Name = "Test Assessment 1";
                dummyObjectiveAssessment.StartDate = new DateTime(2023, 03, 01);
                dummyObjectiveAssessment.EndDate = new DateTime(2023, 08, 30);
                dummyObjectiveAssessment.CourseID = testCourse.Id;
                dummyObjectiveAssessment.AssessmentType = "Objective";
                dummyObjectiveAssessment.Notifications = true;
                App.AppDB.AddAssessment(dummyObjectiveAssessment);

                var dummyPerformanceAssessment = new Assessment();
                dummyObjectiveAssessment.Name = "Test Assessment 2";
                dummyObjectiveAssessment.StartDate = new DateTime(2023, 03, 01);
                dummyObjectiveAssessment.EndDate = new DateTime(2023, 08, 30);
                dummyObjectiveAssessment.CourseID = testCourse.Id;
                dummyObjectiveAssessment.AssessmentType = "Performance";
                dummyObjectiveAssessment.Notifications = true;
                App.AppDB.AddAssessment(dummyObjectiveAssessment);
            }

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

