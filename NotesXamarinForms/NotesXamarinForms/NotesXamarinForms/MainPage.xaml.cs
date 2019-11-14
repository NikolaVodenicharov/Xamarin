using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NotesXamarinForms
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly string fileName = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "notes.txt");

        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(this.fileName))
            {
                editor.Text = File.ReadAllText(this.fileName);
            }
        }

        private void OnSaveButtonClick(object sender, EventArgs args)
        {
            File.WriteAllText(this.fileName, editor.Text);
        }

        private void OnDeleteButtonClick(object sender, EventArgs args)
        {
            if (File.Exists(this.fileName))
            {
                File.Delete(this.fileName);
            }

            editor.Text = string.Empty;
        }
    }
}
