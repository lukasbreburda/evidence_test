using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using test_evidence.classes;

namespace test_evidence.pages
{
  
    public partial class news : Page
    {
        int ID_dat;
        public news( auto x)
        {

            InitializeComponent();
            edit.Visibility = Visibility.Collapsed;
            smazat.Visibility = Visibility.Collapsed;

            if (vypis.prechod == 1)
            {
                zn.Text = x.znacka;
                mo.Text = x.model;
                ro.Text = x.rok_vyroby.ToString();
                ki.Text = x.stav_kilometru.ToString();
                vy.Text = x.vykon.ToString();
                ob.Text = x.objem.ToString();
                ID_dat = x.ID;
                pridat.Visibility = Visibility.Collapsed;
                edit.Visibility = Visibility.Visible;
                smazat.Visibility = Visibility.Visible;
                vypis.prechod = 0;
            }

          
        }

       

        


        private void pridat_Click(object sender, RoutedEventArgs e)
        {
            add();
            

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            clear_textbox();
            MainWindow.framePublic.Source = new Uri("pages/vypis.xaml", UriKind.Relative); //změna source Page
        }

        private static database _data;
        public static database Data
        {
            get
            {
                if (_data == null)
                {
                    var fileHelper = new FileHelper();
                    _data = new database(fileHelper.GetLocalFilePath("autaSQLite.db3"));
                }
                return _data;
            }
        }

        public void clear_textbox()
        {
            zn.Text = "";
            mo.Text = "";
            ro.Text = "";
            ki.Text = "";
            vy.Text = "";
            ob.Text = "";

        }
        public void add()
        {
            auto item = new auto();
            try
            {
                item.znacka = zn.Text;
                item.model = mo.Text;
                item.objem = Int32.Parse(ob.Text);
                item.vykon = Int32.Parse(vy.Text);
                item.rok_vyroby = Int32.Parse(ro.Text);
                item.stav_kilometru = Int32.Parse(ki.Text);

                Data.SaveItemAsync(item);
                vypis.itemsFromDb.Add(item);
                MainWindow.framePublic.Source = new Uri("pages/vypis.xaml", UriKind.Relative); //změna source Page
            }
            catch
            {
                error.Content = "ups.. chybička !";
                
            }


        }

        private void smazat_Click(object sender, RoutedEventArgs e)
        {
            delete();
            MainWindow.framePublic.Source = new Uri("pages/vypis.xaml", UriKind.Relative); //změna source Page

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            
            add();
            delete();
           
        }

        public void delete()
        {
            Data.DeleteItemAsync(ID_dat);
            clear_textbox();
        }
        private void num(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
