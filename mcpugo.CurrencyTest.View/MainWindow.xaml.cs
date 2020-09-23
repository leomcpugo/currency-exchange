using mcpugo.CurrencyTest.Service.CurrencyExchange;
using mcpugo.CurrencyTest.Shared.Model;
using mcpugo.CurrencyTest.Shared.Request;
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

namespace mcpugo.CurrencyTest.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICollection<CurrencyResponse> currencyList;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += LoadData;
        }

        void LoadData(object sender, RoutedEventArgs e)
        {
            currencyList = new CurrencyService().GetCurrencyList();
            cmbCurrencyList.ItemsSource = currencyList;
            cmbCurrencyList.DisplayMemberPath = "Code";
            cmbCurrencyList.SelectedValuePath = "Code";
            cmbCurrencyList.Text = "Choose a Currency";
            cmbCurrencyList.SelectionChanged += OnCurrencySelection;
        }

        void OnCurrencySelection(object sender, EventArgs e)
        {
            if (cmbCurrencyList.SelectedItem != null)
            {

            }
        }
    }
}
