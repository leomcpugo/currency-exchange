using mcpugo.CurrencyTest.Service.CurrencyExchange;
using mcpugo.CurrencyTest.Shared.Model;
using mcpugo.CurrencyTest.Shared.ViewModel;
using System.Collections;
using System.Collections.Generic;
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
            OrderCurrencyList(await new CurrencyService().GetCurrencyList());

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
                ViewModel.CurrencyExchangeRateDetail.CurrencyExchange = await new CurrencyExchangeService().GetExchangeRates(code);
            }
            catch
            {
                MessageBox.Show($"The currency rates for {code} could not be loaded", "CEC APP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Order the currency list using the Favorite feature
        /// </summary>
        void OrderCurrencyList(ICollection<CurrencyModel> list)
        {
            var orderedList = list
                 .OrderByDescending(x => UserPreferences.UserPreferences.IsFavorite(x.Code))
                 .ThenBy(x => x.Code)
                 .ToList();

            ViewModel.CurrencyList.Clear();
            foreach (var item in orderedList) ViewModel.CurrencyList.Add(item);
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
                var code = ((CurrencyModel)item.DataContext).Code;
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
            var item = (sender as MenuItem)?.DataContext as CurrencyModel;
            if (item != null)
            {
                UserPreferences.UserPreferences.AddRemoveFromFavorites(item.Code);
                OrderCurrencyList(ViewModel.CurrencyList);
            }
        }
    }
}
