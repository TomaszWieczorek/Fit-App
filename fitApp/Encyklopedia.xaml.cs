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
    public sealed partial class Encyklopedia : Page
    {
        
        private SolidColorBrush bialy = new SolidColorBrush(Colors.White);
        private int kategoria, produktNumer,i,j,k;

        string[,,] produkt = new string[3, 6, 5];
        //3 kategorie (fast food, slodycze, alkohol), mex 6 produktow, dane o rpodukcie(nazwa, bialko, weglowodany, tluszcz,kalorie)

        public Encyklopedia()
        {
            this.InitializeComponent();
            #region Produkty
            for (i = 0; i <= 2; i++)
                for (j = 0; j <= 5; j++)
                    for (k = 0; k <5; k++)
                        produkt[i, j, k] = "";
            //kategoria fast food
                //1 produkt
                    produkt[0, 0, 0] = "Pizza Ristorante Mozzarella - Dr. Oetker"; //nazwa
                    produkt[0, 0, 1] = "10 g"; //bialko
                    produkt[0, 0, 2] = "28 g"; //weglowodany
                    produkt[0, 0, 3] = "11.4 g"; //tluszcz
                    produkt[0, 0, 4] = "254.6 \n   kcal/100g"; //kalorie
                //2 produkt
                    produkt[0, 1, 0] = "McDouble - McDonald's"; //nazwa
                    produkt[0, 1, 1] = "24 g"; //bialko
                    produkt[0, 1, 2] = "30 g"; //weglowodany
                    produkt[0, 1, 3] = "20 g"; //tluszcz
                    produkt[0, 1, 4] = "396 \n   kcal/100g"; //kalorie
                //3 produkt
                    produkt[0, 2, 0] = "Shake truskawkowy 400 ml - McDonald's"; //nazwa
                    produkt[0, 2, 1] = "9 g"; //bialko
                    produkt[0, 2, 2] = "58 g"; //weglowodany
                    produkt[0, 2, 3] = "9 g"; //tluszcz
                    produkt[0, 2, 4] = "349 \n   kcal/100g"; //kalorie
                //4 produkt
                    produkt[0, 3, 0] = "Makaron z zupki Chińskiej VIFON"; //nazwa
                    produkt[0, 3, 1] = "1.3 g"; //bialko
                    produkt[0, 3, 2] = "9.1 g"; //weglowodany
                    produkt[0, 3, 3] = "3.3 g"; //tluszcz
                    produkt[0, 3, 4] = "71.3 \n   kcal/100g"; //kalorie
                //5 produkt
                    produkt[0, 4, 0] = "Chipsy Lay's - zielona cebulka (MEGAPAKA)"; //nazwa
                    produkt[0, 4, 1] = "6.2 g"; //bialko
                    produkt[0, 4, 2] = "58 g"; //weglowodany
                    produkt[0, 4, 3] = "31.5 g"; //tluszcz
                    produkt[0, 4, 4] = "540.3 \n   kcal/100g"; //kalorie
                //6 produkt
                    produkt[0, 5, 0] = "Quritto - KFC"; //nazwa
                    produkt[0, 5, 1] = "15 g"; //bialko
                    produkt[0, 5, 2] = "26 g"; //weglowodany
                    produkt[0, 5, 3] = "14 g"; //tluszcz
                    produkt[0, 5, 4] = "290 \n   kcal/100g"; //kalorie
            //kategoria słodycze
                //1 produkt
                    produkt[1, 0, 0] = "Prince Polo mleczne - Olza"; //nazwa
                    produkt[1, 0, 1] = "6 g"; //bialko
                    produkt[1, 0, 2] = "61 g"; //weglowodany
                    produkt[1, 0, 3] = "28 g"; //tluszcz
                    produkt[1, 0, 4] = "520 \n   kcal/100g"; //kalorie
                //2 produkt
                    produkt[1, 1, 0] = "Baton Cini Minis - Nestle"; //nazwa
                    produkt[1, 1, 1] = "6.7 g"; //bialko
                    produkt[1, 1, 2] = "63.8 g"; //weglowodany
                    produkt[1, 1, 3] = "13.2 g"; //tluszcz
                    produkt[1, 1, 4] = "400.8 \n   kcal/100g"; //kalorie
                //3 produkt
                    produkt[1, 2, 0] = "PryncyPałki"; //nazwa
                    produkt[1, 2, 1] = "5.3 g"; //bialko
                    produkt[1, 2, 2] = "60 g"; //weglowodany
                    produkt[1, 2, 3] = "32.4 g"; //tluszcz
                    produkt[1, 2, 4] = "552.8 \n   kcal/100g"; //kalorie
            //kategoria alkohole
                //1 produkt
                    produkt[2, 0, 0] = "Grzaniec"; //nazwa
                    produkt[2, 0, 1] = "0.5 g"; //bialko
                    produkt[2, 0, 2] = "17.5 g"; //weglowodany
                    produkt[2, 0, 3] = "0.3 g"; //tluszcz
                    produkt[2, 0, 4] = "74.3 \n   kcal/100g"; //kalorie
                //2 produkt
                    produkt[2, 1, 0] = "Piwo Somersby blackberry cider (100ml)"; //nazwa
                    produkt[2, 1, 1] = "0 g"; //bialko
                    produkt[2, 1, 2] = "15 g"; //weglowodany
                    produkt[2, 1, 3] = "0 g"; //tluszcz
                    produkt[2, 1, 4] = "60 \n   kcal/100g"; //kalorie
                //3 produkt
                    produkt[2, 2, 0] = "Piwo Tyskie (na 100ml)"; //nazwa
                    produkt[2, 2, 1] = "0.5 g"; //bialko
                    produkt[2, 2, 2] = "2.8 g"; //weglowodany
                    produkt[2, 2, 3] = "0 g"; //tluszcz
                    produkt[2, 2, 4] = "13.2 \n   kcal/100g"; //kalorie
            #endregion
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private async void btnEncyklopedia_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog msgbox;
            msgbox = new MessageDialog("Encyklopedia produktów spożywczych oraz ilości ich mikroelementów.");
            await msgbox.ShowAsync();
        }

        private void btnMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void comboBoxKategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboBoxProdukt.Items.Clear();
            comboBoxProdukt.SelectedIndex = -1;
            textBlockNazwa.Text = "";
            textBlockBialko.Text = "";
            textBlockWeglowodany.Text = "";
            textBlockTluszcze.Text = "";
            textBlockKalorie.Text = "";

            comboBoxKategoria.Background = bialy;
            comboBoxProdukt.Background.Opacity = 0;
            kategoria = comboBoxKategoria.SelectedIndex;
            for(i=0;i<6;i++)
            {
                if (produkt[kategoria, i, 0] != "")
                {
                    comboBoxProdukt.Items.Add(produkt[kategoria, i, 0]);
                }
            }
        }

        private void comboBoxProdukt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxProdukt.SelectedIndex != -1)
            {
                comboBoxProdukt.Background.Opacity = 100;
                produktNumer = comboBoxProdukt.SelectedIndex;
                textBlockNazwa.Text = produkt[kategoria, produktNumer, 0];
                textBlockBialko.Text = produkt[kategoria, produktNumer, 1];
                textBlockWeglowodany.Text = produkt[kategoria, produktNumer, 2];
                textBlockTluszcze.Text = produkt[kategoria, produktNumer, 3];
                textBlockKalorie.Text = produkt[kategoria, produktNumer, 4];
            }
        }
    }
}
