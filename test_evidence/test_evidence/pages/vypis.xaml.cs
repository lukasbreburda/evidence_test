using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
using test_evidence.pages;

namespace test_evidence
{
    /// <summary>
    /// Interaction logic for vypis.xaml
    /// </summary>
    public partial class vypis : Page
    {
       public static int prechod = 0;
        public static int id_cole;
      public static ObservableCollection<auto> itemsFromDb;

        public vypis()
        {
            InitializeComponent();
            itemsFromDb = new ObservableCollection<auto>(Data.GetItemsNotDoneAsync().Result);

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            Debug.WriteLine(itemsFromDb.Count);
            foreach (auto todoItem in itemsFromDb)
            {
                Debug.WriteLine(todoItem);
            }

            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");
            Debug.WriteLine("                             ");

            ListView.ItemsSource = itemsFromDb;
        }

      

        private void new_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.framePublic.Source = new Uri("pages/news.xaml", UriKind.Relative); //změna source Page
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

        public void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListView.SelectedItems.Count > 0)
            {

                auto todoItem = (auto)ListView.SelectedItems[0];
                MainWindow.todo = todoItem;
                id_cole = itemsFromDb.IndexOf(todoItem);
                prechod = 1;
                MainWindow.framePublic.Source = new Uri("pages/news.xaml", UriKind.Relative); //změna source Page
                

            }
        }
    }
}
