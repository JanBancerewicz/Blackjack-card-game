using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Threading;

namespace gierunia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Karta> talia= new List<Karta>(); // talia 52 kart
        double cash = 1000;
        int punkty1=0;
        int punkty2=0;
        int nk1 = 0;
        int nk2 = 0;
        Karta hidn;

        //string strPath = "C://Users//skraf//source//repos//gierunia//zdjecia//";
        //string strPath = "E://.source//repos//gierunia//zdjecia//";
        //string strPath = "zdjecia//";
        static System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("../../../");

        string strPath = di.FullName+"zdjecia//";

        List<string> tab = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
                {
                for (int j = 1; j < 14; j++)
                    {
                        talia.Add(new Karta(i, j));
                    }
                }

            


            talia = talia.OrderBy(a => Guid.NewGuid()).ToList();
            
            //MessageBox.Show(talia[0].img);
        }

        private void randomcard_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            /*int val = rnd.Next(1,11);
            int col = rnd.Next(4);
            Karta k1 = new Karta(col, val);
            
            string msg= k1.znak + " " + k1.wartosc.ToString();*/

            int randomindex = rnd.Next(talia.Count());

            string msg = talia[randomindex].znak+" "+talia[randomindex].symbol;

            MessageBox.Show(msg,"Losowa karta z talii");
        }

        private void check_Click(object sender, RoutedEventArgs e)
        {
            string msg="";
            string msgtitle = "Liczba kart w talii: " + talia.Count().ToString();
            

            for (int i = 1; i < talia.Count()+1; i++)
                {
                msg +=talia[i-1].znak+" "+talia[i-1].symbol+" ";
                msg += "\n";
            }
            MessageBox.Show(msg, msgtitle);
        }

        private void shuffle_Click(object sender, RoutedEventArgs e)
        {
            talia=talia.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Start();

        }

        private void Start()
        {
            punkty1 = 0;
            punkty2 = 0;
            nk1 = 0;
            nk2 = 0;
            Zaklad.Text = "";
            Zaklad.IsEnabled = true;
            Punkty1.Text = "0";
            Punkty2.Text = "0";

            ID1.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID2.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID3.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID4.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID5.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID6.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID7.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID8.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID9.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID10.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID11.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID12.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID13.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID14.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID15.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));
            ID16.Source = new BitmapImage(new Uri(strPath + "WHITE.jpg", UriKind.Absolute));

            talia = talia.OrderBy(a => Guid.NewGuid()).ToList();
        }

        private void Info1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Autor aplikacji - Jan Bancerewicz", "Informacja o autorze", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Info2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Karty plik wektorowy utworzone przez macrovector - pl.freepik.com","https://pl.freepik.com/wektory/karty",MessageBoxButton.OK,MessageBoxImage.Information);
        }

        private void cash_Click(object sender, RoutedEventArgs e)
        {
            cash = 1000;
            Saldo.Text = cash.ToString();
        }
        
        private void zatwierdz_Check(object sender, RoutedEventArgs e)
        {
            Zatwierdz_Zaklad.IsEnabled = false;
            if (Zaklad.Text != "") { 
                if (Convert.ToInt32(Zaklad.Text) > Convert.ToInt32(Saldo.Text))
                {
                    Zatwierdz_Zaklad.IsEnabled = false;
                }
                if (Convert.ToInt32(Zaklad.Text) <= Convert.ToInt32(Saldo.Text))
                {
                    Zatwierdz_Zaklad.IsEnabled = true;
                }
            }
        }

        private void newdeck_Click(object sender, RoutedEventArgs e)
        {
            talia.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 14; j++)
                {
                    talia.Add(new Karta(i, j));
                }
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Zatwierdz_Zaklad_Click(object sender, RoutedEventArgs e)
        {
            Zaklad.IsEnabled = false;
            Zatwierdz_Zaklad.IsEnabled = false;
            Dobierz.IsEnabled = true;
            Pas.IsEnabled = true;
            cash -= Convert.ToInt32(Zaklad.Text);
            Saldo.Text = cash.ToString();
            if (Convert.ToInt32(Saldo.Text) >= Convert.ToInt32(Zaklad.Text))
            {
                Podwoj.IsEnabled = true;
            }
            else
            {
                Podwoj.IsEnabled = false;
            }

            if (talia.Count < 14)
            {
                talia.Clear();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 1; j < 14; j++)
                    {
                        talia.Add(new Karta(i, j));
                    }
                }
                talia = talia.OrderBy(a => Guid.NewGuid()).ToList();
            }
            ID1.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
            punkty1 += talia[0].wartosc;
            talia.RemoveAt(0);
            ID2.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
            punkty1 += talia[0].wartosc;
            talia.RemoveAt(0);
            ID9.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
            punkty2 += talia[0].wartosc;
            talia.RemoveAt(0);
            hidn = talia[0];
            ID10.Source = new BitmapImage(new Uri(strPath + "UNKNOWN.jpg", UriKind.Absolute));
            //ID10.Text = talia[0].symbol + " " + talia[0].znak;
            //punkty2 += talia[0].wartosc;
            talia.RemoveAt(0);

            Punkty1.Text = punkty1.ToString();
            Punkty2.Text = punkty2.ToString();

            nk1 += 2;
            nk2 += 2;

            if (punkty1 == 21)
            {
                win();
            }
        }

        private void Podwoj_Click(object sender, RoutedEventArgs e)
        {
            Podwoj.IsEnabled = false;
            Dobierz.IsEnabled = false;
            Pas.IsEnabled = false;
            cash -= Convert.ToInt32(Zaklad.Text);
            Saldo.Text = cash.ToString();
            Zaklad.Text = (Convert.ToInt32(Zaklad.Text) * 2).ToString();
            Zatwierdz_Zaklad.IsEnabled = false;


            nk1 += 1;
            ID3.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));

            punkty1 += talia[0].wartosc;
            talia.RemoveAt(0);

            Punkty1.Text = punkty1.ToString();


            ID10.Source = new BitmapImage(new Uri(strPath + hidn.img, UriKind.Absolute));
            punkty2 += hidn.wartosc;

            Punkty2.Text = punkty2.ToString();

            while (punkty2 < 17)
            {
                nk2 += 1;

                switch (nk2)
                {
                    case 3:
                        ID11.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 4:
                        ID12.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 5:
                        ID13.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 6:
                        ID14.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 7:
                        ID15.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 8:
                        ID16.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                }

                punkty2 += talia[0].wartosc;
                talia.RemoveAt(0);

                Punkty2.Text = punkty2.ToString();
            }

            if (punkty1 == 21)
            {
                win();
            }
            else
            { 
                if (punkty2 <= punkty1 && punkty1<=21)
                {
                    win();
                }
                else
                {
                    lose();
                }
            }

        }
        
        private void Dobierz_Click(object sender, RoutedEventArgs e)
        {
            Podwoj.IsEnabled = false;
            nk1 += 1;

            switch (nk1)
            {
                case 3:
                    ID3.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                    break;
                case 4:
                    ID4.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                    break;
                case 5:
                    ID5.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                    break;
                case 6:
                    ID6.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                    break;
                case 7:
                    ID7.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                    break;
                case 8:
                    ID8.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                    break;
            }

            punkty1 += talia[0].wartosc;
            talia.RemoveAt(0);

            Punkty1.Text = punkty1.ToString();

            if (punkty1 == 21)
            {
                win();
            }
            if (punkty1 > 21)
            {
                lose();
            }
        }
        
        private void Pas_Click(object sender, RoutedEventArgs e)
        {
            Podwoj.IsEnabled = false;
            Dobierz.IsEnabled = false;
            Pas.IsEnabled = false;

            ID10.Source = new BitmapImage(new Uri(strPath + hidn.img, UriKind.Absolute));
            punkty2 += hidn.wartosc;

            Punkty2.Text = punkty2.ToString();

            while (punkty2 < 17)
            {
                nk2 += 1;

                switch (nk2)
                {
                    case 3:
                        ID11.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 4:
                        ID12.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 5:
                        ID13.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 6:
                        ID14.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 7:
                        ID15.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                    case 8:
                        ID16.Source = new BitmapImage(new Uri(strPath + talia[0].img, UriKind.Absolute));
                        break;
                }

                punkty2 += talia[0].wartosc;
                talia.RemoveAt(0);
                
                Punkty2.Text = punkty2.ToString();
            }

            

            if (punkty2<=punkty1)
            {
                win();
            }
            else
            {
                lose();
            }
        }

        private void win()
        {

            Dobierz.IsEnabled = false;
            Pas.IsEnabled = false;
            cash += 2 * Convert.ToInt32(Zaklad.Text);
            Saldo.Text = cash.ToString();

            if (punkty1 == 21)
            {
                MessageBox.Show("Black Jack\nWygrałeś "+Zaklad.Text+" monet","Zwycięstwo");
            }
            else if(punkty1>=punkty2 && punkty1<=21)
            {
                MessageBox.Show("Wygrałeś "+Zaklad.Text+" monet","Zwycięstwo");
            }
            

            

            

            //Start();
        }

        private void lose()
        {
            Dobierz.IsEnabled = false;
            Pas.IsEnabled = false;

            if (punkty1>21)
            {
                MessageBox.Show("Przegrałeś.\n"+Punkty1.Text+" / 21 punktów", "Przegrana");
            }
            else if (punkty1 < 21 && punkty2 > punkty1)
            {
                MessageBox.Show("Przegrałeś.\n" + Punkty1.Text + " do "+Punkty2.Text+" punktów", "Przegrana");
            }

            

            //Start();
        }

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            /*string pth = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);*/
            /*string pth = System.IO.Directory.GetCurrentDirectory();*/
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo("../../../");

            string pth = di.FullName;

            MessageBox.Show(pth, "ziomus", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
