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
using test_evidence.classes;

namespace test_evidence.pages
{
  
    public partial class news : Page
    {
        public news()
        {
            InitializeComponent();
        }

       
        private void add_Click(object sender, RoutedEventArgs e)
        {

            MainWindow.framePublic.Source = new Uri("pages/vypis.xaml", UriKind.Relative); //změna source Page

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            clear_textbox();
            MainWindow.framePublic.Source = new Uri("pages/vypis.xaml", UriKind.Relative); //změna source Page
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
            item.znacka = zn.Text;

        }
    }
}
