using RobinsonC971MobileApp.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RobinsonC971MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTerm : ContentPage
    {
        private Term term;
        public EditTerm(Term _term)
        {
            term = _term;
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            TermTitle.Text = term.Title;
            startDate.Date = term.StartDate;
            endDate.Date = term.EndDate;
            base.OnAppearing();
        }

        private async void SaveTerm(object sender, EventArgs e)
        {
            term.Title= TermTitle.Text;
            term.StartDate = startDate.Date;
            term.EndDate = endDate.Date;
            App.AppDB.EditTerm(term);

            await Navigation.PopModalAsync();
        }
    }
}