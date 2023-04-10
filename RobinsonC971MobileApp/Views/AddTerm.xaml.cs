using RobinsonC971MobileApp.Models;
using RobinsonC971MobileApp.Services;
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
    public partial class AddTerm : ContentPage
    {
        private MainPage mainPage;
        private Service service;
        public AddTerm(MainPage _mainPage)
        {
            mainPage = _mainPage;
            InitializeComponent();
        }

        private async void OnButtonClickAddTerm(object sender, EventArgs e)
        {
            Term term = new Term();
            term.Title = TermTitle.Text;
            term.StartDate = startDate.Date;
            term.EndDate = endDate.Date;

            App.AppDB.AddTerm(term);
            await Navigation.PopModalAsync();
        }
    }
}