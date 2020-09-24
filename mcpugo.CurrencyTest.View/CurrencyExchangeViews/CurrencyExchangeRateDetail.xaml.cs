using mcpugo.CurrencyTest.Shared.Model;
using mcpugo.CurrencyTest.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mcpugo.CurrencyTest.View.CurrencyExchangeViews
{
    /// <summary>
    /// Interaction logic for CurrencyExchangeRateDetail.xaml
    /// </summary>
    public partial class CurrencyExchangeRateDetail : UserControl
    {
        public CurrencyExchangeRateDetailViewModel ViewModel { get { return DataContext as CurrencyExchangeRateDetailViewModel; } }

        public CurrencyExchangeRateDetail()
        {
            InitializeComponent();
            Loaded += LoadData;
        }

        /// <summary>
        /// Loading of the View Data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LoadData(object sender, RoutedEventArgs e)
        {
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
            txtAmount.Text = "1";
            txtAmount.TextChanged += txtAmount_Changed;
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CurrencyExchangeRateDetailViewModel.CurrencyExchange))
            {
                if (ViewModel?.CurrencyExchange?.Code == null) return;

                tblCurrencyCode.Text = ViewModel.CurrencyExchange.Code;
                txtAmount.Text = "1";

                lvwRateList.ItemsSource = ViewModel.CurrencyExchange.Rates
                    .OrderByDescending(x => UserPreferences.UserPreferences.IsFavorite(x.Code))
                    .ThenBy(x => x.Code)
                    .ToList();

                UpdateRates();
            }
        }


        /// <summary>
        /// Method that calculate the amount in every currency for the user input
        /// </summary>
        private void UpdateRates()
        {
            if (ViewModel?.CurrencyExchange?.Rates == null) return;

            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                foreach (var rate in ViewModel.CurrencyExchange.Rates)
                {
                    rate.ConvertedAmount = rate.Rate * amount;
                }
            }

            lvwRateList.Items.Refresh();
        }

        // UI Events

        /// <summary>
        /// Helper method that triggers the refresh of the calculated rates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void txtAmount_Changed(object sender, TextChangedEventArgs args)
        {
            if (sender as TextBox != null)
            {
                UpdateRates();
            }
        }

        /// <summary>
        /// Helper method that validates if the text is numeric
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}