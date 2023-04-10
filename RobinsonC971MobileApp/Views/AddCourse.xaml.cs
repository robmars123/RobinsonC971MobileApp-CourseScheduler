using MobileApp;
using RobinsonC971MobileApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RobinsonC971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCourse : ContentPage
    {
        private Term term;
        public AddCourse(Term _term)
        {
            term = _term;
            InitializeComponent();
        }

        private async void SaveCourse(object sender, EventArgs e)
        {
            Course course = new Course();
            course.Name = CourseName.Text;
            course.Status = CourseStatus.SelectedItem.ToString();
            course.StartDate = StartDate.Date;
            course.EndDate = EndDate.Date;
            course.InstructorName = InstructorName.Text;
            course.InstructorPhoneNumber = InstructorPhoneNumber.Text;
            course.InstructorEmailAddress = InstructorEmailAddress.Text;
            course.Notifications = EnableNotifications.On == true ? 1 : 0;
            course.Notes = Notes.Text;
            course.TermId = term.Id;

            if (FieldCheck.IsNull(CourseName.Text) &&
                    FieldCheck.IsNull(InstructorName.Text) &&
                    FieldCheck.IsNull(InstructorPhoneNumber.Text))
            {
                if (FieldCheck.IsValidEmail(InstructorEmailAddress.Text))
                {
                    if (course.EndDate > course.StartDate)
                    {
                        App.AppDB.AddCourse(course);
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