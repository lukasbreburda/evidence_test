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

namespace test_evidence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame framePublic; //vytvoří veřejný frame 
        public static auto todo;
        public MainWindow()
        {
            InitializeComponent();
            framePublic = frame; //definice veřejného framu na klasický 

            MainWindow.framePublic.Source = new Uri("pages/vypis.xaml", UriKind.Relative); //uprava source framu na danou Page
        }
    }
}
