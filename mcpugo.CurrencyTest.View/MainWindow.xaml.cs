using mcpugo.CurrencyTest.Service.CurrencyExchange;
using mcpugo.CurrencyTest.Shared.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        /// <summary>
        /// Loading of the View Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void LoadData(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrencyList = new ObservableCollection<CurrencyResponse>(await new CurrencyService().GetCurrencyList());
            OrderCurrencyList();

            if (!string.IsNullOrEmpty(Properties.Settings.Default.CurrencyCodeLastUsed))
            {
                SelectCurrency(Properties.Settings.Default.CurrencyCodeLastUsed);
            }
        }

        /// <summary>
        /// Select and load the Rates for the Currency selected
        /// </summary>
        /// <param name="code">The code of the currency</param>
        private async void SelectCurrency(string code)
        {
            try
            {
                ViewModel.CurrencyExchangeSelected = await new CurrencyExchangeService().GetExchangeRates(code); ;
                ctlCurrencyExchangeRateDetail.SetCurrencyExchange(ViewModel.CurrencyExchangeSelected);
            }
            catch
            {
                MessageBox.Show($"The currency rates for {code} could not be loaded", "CEC APP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Order the currency list using the Favorite feature
        /// </summary>
        void OrderCurrencyList()
        {
            var favoriteCurrencyList = Properties.Settings.Default.CurrencyFavoriteList.Split(',').ToList();

            lvwCurrencyList.ItemsSource = ViewModel.CurrencyList
                .OrderByDescending(x => UserPreferences.UserPreferences.IsFavorite(x.Code))
                .ThenBy(x => x.Code)
                .ToList();
        }


        // UI Events

        /// <summary>
        /// Helper used to store the last checked currency to use it as a default on next startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Helper method that adds or removes a Favorite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void addRemoveFavorite_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as MenuItem)?.DataContext as CurrencyResponse;
            if (item != null)
            {
                UserPreferences.UserPreferences.AddRemoveFromFavorites(item.Code);
                OrderCurrencyList();
                ctlCurrencyExchangeRateDetail.SetCurrencyExchange(ViewModel.CurrencyExchangeSelected, false);
            }
        }
    }
}
