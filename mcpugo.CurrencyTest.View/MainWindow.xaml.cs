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
            ViewModel.CurrencyList = new ObservableCollection<CurrencyResponse>(await new CurrencyService().GetCurrencyList());
            lvwCurrencyList.ItemsSource = ViewModel.CurrencyList;

            if (!string.IsNullOrEmpty(Properties.Settings.Default.CurrencyCodeLastUsed))
            {
                SelectCurrency(Properties.Settings.Default.CurrencyCodeLastUsed);
            }
        }

        private async void SelectCurrency(string code)
        {
            try
            {
                var selectedCurrencyExchange = ViewModel.CurrencyExchangeList.FirstOrDefault(x => x.Code == code);

                if (selectedCurrencyExchange == null)
                {
                    Properties.Settings.Default.CurrencyCodeLastUsed = code;
                    selectedCurrencyExchange = await new CurrencyExchangeService().GetExchangeRates(new CurrencyExchangeRequest
                    {
                        Base = code
                    });

                    ViewModel.CurrencyExchangeList.Add(selectedCurrencyExchange);
                }

                ctlCurrencyExchangeRateDetail.LoadCurrencyExchange(selectedCurrencyExchange);
            }
            catch
            {
                MessageBox.Show($"The currency rates for {code} could not be loaded", "CEC APP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void lvwCurrencyList_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var item = sender as ListViewItem;
            if (item != null)
            {
                var code = ((CurrencyResponse)item.DataContext).Code;
                SelectCurrency(code);
                Properties.Settings.Default.CurrencyCodeLastUsed = code;
                Properties.Settings.Default.Save();
            }
        }
    }
}
