using MobileApp;
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
    public partial class EditCourse : ContentPage
    {
        private Course course;
        public EditCourse(Course _course)
        {
            course = _course;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            CourseName.Text = course.Name;
            CourseStatus.SelectedItem = course.Status.ToString();
            StartDate.Date = course.StartDate.Date;
            EndDate.Date = course.EndDate.Date;
            InstructorName.Text = course.InstructorName;
            InstructorPhoneNumber.Text = course.InstructorPhoneNumber;
            InstructorEmail.Text = course.InstructorEmailAddress;
            EnableNotifications.On = course.Notifications == 1 ? true : false;
            Notes.Text = course.Notes;
            base.OnAppearing();
        }

        public async void SaveCourse(object sender, EventArgs e)
        {
            course.Name = CourseName.Text;
            course.Status = CourseStatus.SelectedItem.ToString();
            course.StartDate = StartDate.Date;
            course.EndDate = EndDate.Date;
            course.InstructorName = InstructorName.Text;
            course.InstructorPhoneNumber = InstructorPhoneNumber.Text;
            course.InstructorEmailAddress = InstructorEmail.Text;
            course.Notifications = EnableNotifications.On ? 1 : 0;
            course.Notes = Notes.Text;

            if (FieldCheck.IsNull(CourseName.Text) &&
                FieldCheck.IsNull(InstructorName.Text) &&
                FieldCheck.IsNull(InstructorPhoneNumber.Text))
            {
                if (FieldCheck.IsValidEmail(InstructorEmail.Text))
                {
                    if (course.EndDate > course.StartDate)
                    {
                        App.AppDB.UpdateCourse(course);
                        await Navigation.PopModalAsync();
                    }
                    else await DisplayAlert("Error.", "End date is earlier than Start Date.", "Ok");
                }
                else await DisplayAlert("Error.", "Please fill all required fields.", "Ok");
            }
            else await DisplayAlert("Error.", "Please enter a valid email address.", "Ok");
        }
    }
}