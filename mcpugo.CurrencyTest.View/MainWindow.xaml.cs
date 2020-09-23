using mcpugo.CurrencyTest.Service.CurrencyExchange;
using mcpugo.CurrencyTest.Shared.Model;
using mcpugo.CurrencyTest.Shared.Request;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace mcpugo.CurrencyTest.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; private set; } = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModel;
            Loaded += LoadData;
        }

        async void LoadData(object sender, RoutedEventArgs e)
        {
            foreach (var item in await new CurrencyService().GetCurrencyList()) ViewModel.CurrencyList.Add(item);
            lvwCurrencyList.ItemsSource = ViewModel.CurrencyList;
        }

        async void lvwCurrencyList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                var selectedCurrency = (CurrencyResponse)item.DataContext;
                try
                {

                    var selectedCurrencyExchange = ViewModel.CurrencyExchangeList.FirstOrDefault(x => x.Code == selectedCurrency.Code);

                    if (selectedCurrencyExchange == null)
                    {
                        selectedCurrencyExchange = await new CurrencyExchangeService().GetExchangeRates(new CurrencyExchangeRequest
                        {
                            Base = selectedCurrency.Code
                        });

                        ViewModel.CurrencyExchangeList.Add(selectedCurrencyExchange);
                    }

                    ctlCurrencyExchangeRateDetail.LoadCurrencyExchange(selectedCurrencyExchange);
                }
                catch
                {
                    MessageBox.Show($"The currency rates for {selectedCurrency.Code} could not be loaded", "CEC APP", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
