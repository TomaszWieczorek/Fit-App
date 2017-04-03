using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace fitApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BMI : Page
    {
        private SolidColorBrush niebieski = new SolidColorBrush(Colors.LightBlue);
        private SolidColorBrush rozowy = new SolidColorBrush(Colors.LightPink);
        private SolidColorBrush bialy = new SolidColorBrush(Colors.White);
        
        private double waga;
        private int wzrost;
        private double bmiWynik;
        public BMI()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void comboBoxPlec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxPlec.SelectedIndex == 0)
            {
                textBoxWaga.Background = niebieski;
                textBoxWzrost.Background = niebieski;
                textBoxWaga.IsEnabled = true;
                textBoxWzrost.IsEnabled = true;
                btnOblicz.IsEnabled = true;
            }
            else if (comboBoxPlec.SelectedIndex == 1)
            {
                textBoxWaga.Background = rozowy;
                textBoxWzrost.Background = rozowy;
                textBoxWaga.IsEnabled = true;
                textBoxWzrost.IsEnabled = true;
                btnOblicz.IsEnabled = true;
            }
        }

        private async void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgbox;
            msgbox = new MessageDialog("Opis wyników BMI: \n do 16: wygłodzenie \n od 16 do 17: wychudzenie \n od 17 do 18.5: niedowaga"
                + "\n od 18.5 do 25: wartość prawidłowa \n od 25 do 30: nadwaga \n od 30 do 35: I stopień otyłości"
                + "\n od 35 do 40: II stopień otyłości \n powyżej 40: III stopień otyłości");
            await msgbox.ShowAsync();
        }

        private async void btnOblicz_Click_1(object sender, RoutedEventArgs e)
        {
            if (textBoxWaga.Text == "" || textBoxWzrost.Text == "")
            {
                MessageDialog msgbox;
                msgbox = new MessageDialog("Podaj wszystkie dane!");
                await msgbox.ShowAsync();
            }
            else
            {
                string wynikCaly;
                string opis = "";
                waga = Convert.ToInt32(textBoxWaga.Text);
                wzrost = Convert.ToInt32(textBoxWzrost.Text);
                double wzrostM;
                wzrostM = wzrost * 0.01;
                bmiWynik = waga / (wzrostM * wzrostM);
                bmiWynik = Math.Round(bmiWynik, 1);
                if (bmiWynik <= 16.0)
                    opis = "do 16: wygłodzenie";
                else if (bmiWynik <= 17)
                    opis = "od 16 do 17: wychudzenie";
                else if (bmiWynik <= 18.5)
                    opis = "od 17 do 18.5: niedowaga";
                else if (bmiWynik <= 25)
                    opis = "od 18.5 do 25: wartość prawidłowa";
                else if (bmiWynik <= 30)
                    opis = "od 25 do 30: nadwaga";
                else if (bmiWynik <= 35)
                    opis = "od 30 do 35: I stopień otyłości";
                else if (bmiWynik <= 40)
                    opis = "od 35 do 40: II stopień otyłości";
                else if (bmiWynik > 40)
                    opis = "powyżej 40: III stopień otyłości";
                wynikCaly = "Twój współczynnik BMI wynosi: \n" + bmiWynik.ToString()
                    + ".\n" + opis;

                textBlockWynikSlowo.Visibility = Visibility.Visible;
                textBlockWynik.Text = wynikCaly;
                btnPomoc.Visibility = Visibility.Visible;
                btnReset.Visibility = Visibility.Visible;
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            btnOblicz.IsEnabled = false;
            btnPomoc.Visibility = Visibility.Collapsed;
            btnReset.Visibility = Visibility.Collapsed;
            textBoxWaga.IsEnabled = false;
            textBoxWaga.Background = bialy;
            textBoxWaga.Text = "";
            textBoxWzrost.IsEnabled = false;
            textBoxWzrost.Background = bialy;
            textBoxWzrost.Text = "";
            comboBoxPlec.SelectedIndex = -1;
            textBlockWynik.Text = "";
            textBlockWynikSlowo.Visibility = Visibility.Collapsed;

        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private async void btnBMI_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgbox;
            msgbox = new MessageDialog("Według Światowej Organizacji Zdrowia prawidłowy BMI oscyluje pomiędzy 18,6 – 24,9. " 
                + "\n\nOznaczanie wskaźnika masy ciała ma znaczenie w ocenie zagrożenia chorobami związanymi z nadwagą i otyłością, "
                + "np. cukrzycą, chorobą niedokrwienną serca, miażdżycą. "
                + "\n\nPodwyższona wartość BMI związana jest ze zwiększonym ryzykiem wystąpienia takich chorób.");
            await msgbox.ShowAsync();
        }
    }
}
