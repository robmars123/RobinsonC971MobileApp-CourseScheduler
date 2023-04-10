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
    public partial class CourseDetails : ContentPage
    {
        private Course course;
        public CourseDetails(Course _course)
        {
            course = _course;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            Status.Text = course.Status;
            Name.Text = course.Name;
            StartDate.Text = course.StartDate.ToString();
            EndDate.Text = course.EndDate.ToString();
            InstructorName.Text = course.InstructorName;
            InstructorPhone.Text = course.InstructorPhoneNumber;
            InstructorEmail.Text = course.InstructorEmailAddress;
            Notifications.Text = course.Notifications == 1 ? "Yes" : "No";
            Notes.Text = course.Notes;
        }
        public void EditCourse(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditCourse(course));
        }

        public async void DropCourse(object sender, EventArgs e)
        {
            App.AppDB.DropCourse(course);
            await Navigation.PopModalAsync();
        }

        public void Assessments(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Assessments(course));
        }
    }
}