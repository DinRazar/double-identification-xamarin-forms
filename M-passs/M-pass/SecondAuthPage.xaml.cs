using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
namespace Mpass
{	
	public partial class SecondAuthPage : ContentPage
	{
        WebClient client = new WebClient();
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "file.txt");


        public SecondAuthPage ()
		{
			InitializeComponent ();
		}
        private void fotma_load(object sender, EventArgs e)
        {
            if (!File.Exists(_fileName))
            {
                Guid uniqid = Guid.NewGuid();
                File.WriteAllText(_fileName, uniqid.ToString());
                idinfo.Text = File.ReadAllText(_fileName);
                File.SetAttributes(_fileName, FileAttributes.Hidden);
            }
            else
            {
                idinfo.Text = File.ReadAllText(_fileName);
                
            }
        }

        private void infoclick(object sender, EventArgs e)
        {
            var hasText = Clipboard.HasText;
            Clipboard.SetTextAsync(idinfo.Text);

            //c55509d3-4a6f-462b-b9ab-c5e675998ce5 (android dev1)
            //1db86b50-4945-48f0-af69-56eb30bf93b1 (ios dev1)


        }
        private void Identification(object sender, EventArgs e)
        {
            if (idinfo == null)
            {
                Environment.Exit(1);
            }
            if (client.DownloadString("https://pastebin.com/RPWezEfq").Contains(idinfo.Text) || client.DownloadString("https://pastebin.com/FSTfXTta").Contains(idinfo.Text))
            {
                DisplayAlert("Welcome", "Have a nice day", "Ok");
                Navigation.PushAsync(new HomePage());
            }
            else
            {
                DisplayAlert("Ops..", "Contact support: sup@yandex.ru", "Bruh");
                Navigation.PushAsync(new HomePage());
            }
        }
    }
}

