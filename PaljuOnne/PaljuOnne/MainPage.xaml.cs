using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace PaljuOnne
{
    public partial class MainPage : ContentPage
    {
        List<string> friends, mail, number, greets;
        public MainPage()
        {
            friends = new List<string>() { "Lev", "Oleg", "Nikolas" };
            number = new List<string>() { "6587345873", "456843563", "98674098567" };
            mail = new List<string> { "Lev@gmail.com", "Oleg@gmail.com", "Nikolas@gmail.com" };
            greets = new List<string> { "С днем рождения!", "С праздником!", "Ты стал взрослее на один год!", "Счастья здоровья!", "С 18ти летием!" };
            InitializeComponent();
            friendPicker.ItemsSource = friends;
            friendPicker.SelectedIndexChanged += FriendPicker_SelectedIndexChanged;
            congratmail.Clicked += Congratmail_Clicked;
            congratsms.Clicked += Congratsms_Clicked;
        }

        private async void Congratsms_Clicked(object sender, EventArgs e)
        {
            Random ranGreet = new Random();
            int rand = ranGreet.Next(5);
            await Sms.ComposeAsync(new SmsMessage { Body = greets[rand], Recipients = new List<string> { number[friendPicker.SelectedIndex] } });
        }

        private async void Congratmail_Clicked(object sender, EventArgs e)
        {
            Random ranGreet = new Random();
            int rand = ranGreet.Next(5);
            await Email.ComposeAsync("Поздравление", greets[rand], mail[friendPicker.SelectedIndex]);

        }
        private void FriendPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            maill.Text = mail[friendPicker.SelectedIndex];
            num.Text = number[friendPicker.SelectedIndex];
        }
    }
}
