using NotesXamarinForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NotesXamarinForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryPage : ContentPage
    {
        public NoteEntryPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClick(object sender, EventArgs args)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }

        private async void OnDeleteButtonClick(object sender, EventArgs args)
        {
            var note = BindingContext as Note;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}