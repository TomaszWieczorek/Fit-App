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
    public sealed partial class BMR : Page
    {
        private SolidColorBrush niebieski = new SolidColorBrush(Colors.LightBlue);
        private SolidColorBrush rozowy = new SolidColorBrush(Colors.LightPink);
        private SolidColorBrush bialy = new SolidColorBrush(Colors.White);

        private char plec;
        private double waga, wzrost;
        private int wiek,aktywnosc;
        private double tdee,bmr,tea,epoc,tef,neat;
        private double bialkoG, weglowodanyG, tluszczeG; //w gramach
        private double bialkoKCAL, weglowodanyKCAL, tluszczeKCAL; // w kaloriach

        public BMR()
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
                //kolor niebieski dla faceta
                textBoxWaga.Background = niebieski;
                textBoxWzrost.Background = niebieski;
                textBoxWiek.Background = niebieski;
                comboBoxAktywnosc.Background = niebieski;
                plec = 'M';
                //po wyborze plci aktywuja sie przyciski 
                textBoxWaga.IsEnabled = true;
                textBoxWzrost.IsEnabled = true;
                textBoxWiek.IsEnabled = true;
                comboBoxAktywnosc.IsEnabled = true;
                btnOblicz.IsEnabled = true;
            }
            else if (comboBoxPlec.SelectedIndex == 1)
            {
                //kolor rozowy dla kobiety
                textBoxWaga.Background = rozowy;
                textBoxWzrost.Background = rozowy;
                textBoxWiek.Background = rozowy;
                comboBoxAktywnosc.Background = rozowy;
                plec = 'K';
                //po wyborze plci aktywuja sie przyciski 
                textBoxWaga.IsEnabled = true;
                textBoxWzrost.IsEnabled = true;
                textBoxWiek.IsEnabled = true;
                comboBoxAktywnosc.IsEnabled = true;
                btnOblicz.IsEnabled = true;
            }
        }
        private void comboBoxAktywnosc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            aktywnosc = comboBoxAktywnosc.SelectedIndex;
        }
        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
        private async void btnBMR_Click(object sender, RoutedEventArgs e)
        {
            //okienko dialogowe z informacja o BMR
            MessageDialog msgbox;
            msgbox = new MessageDialog("Współczynnik ten określa minimalną ilość kalorii niezbędnych do zachowania podstawowych funkcji organizmu. "
                + "\n\nKalkulator dodatkowo określa niezbędną ilość kalorii i składników pożywienia przy określeniu poziomu Twojej aktywności fizycznej."
                + " Podany udział procentowy składników pożywienia zapewnia zdrowy i bezpieczny sposób odżywiania."
                + "\n\nZalecane tempo utraty masy ciała w wypadku nadwagi i otyłości wynosi ok 2 - 4kg na miesiąc (wyłączając specjalne wskazania medyczne). "
                + "Przekroczenie tego progu może pociagać za sobą niekorzystne zmiany metaboliczne, niedobory niezbędnych składników odżywczych i zwiększa ryzyko wystąpienia tzw. efektu jojo.");
            await msgbox.ShowAsync();
        }

        private async void btnOblicz_Click(object sender, RoutedEventArgs e)
        {
            //jesli nie podal danych wszystkich
            if (textBoxWaga.Text == "" || textBoxWzrost.Text == "" || textBoxWiek.Text == "" || comboBoxAktywnosc.SelectedIndex==-1)
            {
                MessageDialog msgbox;
                msgbox = new MessageDialog("Podaj wszystkie dane!");
                await msgbox.ShowAsync();
            }
            else
            {
                waga = Convert.ToDouble(textBoxWaga.Text);
                wzrost = Convert.ToDouble(textBoxWzrost.Text);
                wiek = Convert.ToInt32(textBoxWiek.Text);
                int aktywnoscIlosc = 0;
                //ilosc dni treningów według tego co zostało wybrane
                switch (aktywnosc)
                {
                    case 0:
                        {
                            aktywnoscIlosc = 0;
                            break;
                        }
                    case 1:
                        {
                            aktywnoscIlosc = 1;
                            break;
                        }
                    case 2:
                        {
                            aktywnoscIlosc = 2;
                            break;
                        }
                    case 3:
                        {
                            aktywnoscIlosc = 4;
                            break;
                        }
                    case 4:
                        {
                            aktywnoscIlosc = 6;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                //rozny wzor dla kobiety i mezczyzny
                if (plec == 'K')
                {
                    bmr = (9.99 * waga) + (6.25 * wzrost) - (4.92 * wiek) - 161;
                }
                else if (plec == 'M')
                {
                    bmr = (9.99 * waga) + (6.25 * wzrost) - (4.92 * wiek) + 5;
                }
                epoc = aktywnoscIlosc * (0.07 * bmr); //Kalorie spalone po wysiłku
                tea = (8 * (60 * aktywnoscIlosc)) + epoc; //Kalorie spalone ze względu na naszą tygodniową aktywność fizyczną
                tea = tea / 7; //poniewaz 7 dni tygodnia, a obliczamy na jeden dzień
                neat = 550; //kalorie, spalane przez na organizm na bieżąco, podczas zwykłych czynności życiowych
                tef = 0.08 * (bmr + tea + neat); // efekt termiczny pożywienia
                tdee = Math.Round(bmr + tea + tef + neat,2); // dzienne zapotrzebowanie kaloryczne, zaokraglamy do 2 meijsce po przecinku

                //obliczamy mikroskladniki
                bialkoG = 2 * waga;
                bialkoKCAL = bialkoG * 4;
                tluszczeG = waga;
                tluszczeKCAL = 9 * tluszczeG;
                weglowodanyKCAL = tdee - (bialkoKCAL + tluszczeKCAL);
                weglowodanyG = Math.Round(weglowodanyKCAL / 4,2);


                //wyswietlamy textBlock w ktorym jest wynik
                textBlockWynik.Visibility = Visibility.Visible;
                textBlockWynik.Text = "Twój wskaźnik BMR wynosi: " + bmr
                    + "\nTwoje dzienne zapotrzebowanie kalorii, aby utrzymać wagę wynosi: " + tdee.ToString()
                    + "\n\nAby utrzymać wagę potrzebujesz " + tdee + " kcal, w tym:"
                    + "\n Białko: " + bialkoG + "g (" + bialkoKCAL + " kcal),"
                    + "\n Tłuszcze: " + tluszczeG + "g (" + tluszczeKCAL + " kcal),"
                    + "\n Węglowodany: " + weglowodanyG + "g (" + weglowodanyKCAL + " kcal).";
                    

                btnReset.Visibility = Visibility.Visible;

            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            //wylaczanie buttonow
            btnOblicz.IsEnabled = false;
            btnReset.Visibility = Visibility.Collapsed;

            //zerowanie danych
            textBoxWaga.IsEnabled = false;
            textBoxWaga.Background = bialy;
            textBoxWaga.Text = "";
            textBoxWzrost.IsEnabled = false;
            textBoxWzrost.Background = bialy;
            textBoxWzrost.Text = "";
            textBoxWiek.IsEnabled = false;
            textBoxWiek.Background = bialy;
            textBoxWiek.Text = "";
            comboBoxPlec.SelectedIndex = -1;
            comboBoxAktywnosc.SelectedIndex = -1;
            comboBoxAktywnosc.IsEnabled = false;
            textBlockWynik.Text = "";
            textBlockWynik.Visibility = Visibility.Collapsed;
            textBlockWynikSlowo.Visibility = Visibility.Collapsed;
        }
    }
}
