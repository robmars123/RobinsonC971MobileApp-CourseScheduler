using RobinsonC971MobileApp.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RobinsonC971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermDetails : ContentPage
    {
        private Term term;
        public TermDetails(Term _term)
        {
            term = _term;
            InitializeComponent();
            coursesListView.ItemTapped += new EventHandler<ItemTappedEventArgs>(Course_Clicked);
        }

        protected override async void OnAppearing()
        {
            TermTitle.Text = term.Title;
            TermStartDate.Text = term.StartDate.ToString();
            TermEndDate.Text = term.EndDate.ToString();
            
            coursesListView.ItemsSource = App.AppDB.GetCourses(term);
        }
        private async void Course_Clicked(object sender, ItemTappedEventArgs e)
        {
            Course course = (Course)e.Item;
            await Navigation.PushModalAsync(new CourseDetails(course));
        }

        private void EditTerm(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new EditTerm(term));
        }

        private void AddCourse(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddCourse(term));
        }
        private async void DropTerm(object sender, EventArgs e)
        {
            App.AppDB.DeleteTerm(term);
            await Navigation.PopModalAsync();
        }
    }
}
