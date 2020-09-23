using mcpugo.CurrencyTest.Shared.Model;
using System;
using System.Collections.Generic;
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
        public CurrencyExchangeRateDetailViewModel ViewModel { get; private set; } = new CurrencyExchangeRateDetailViewModel();

        public CurrencyExchangeRateDetail()
        {
            InitializeComponent();
            DataContext = ViewModel;
            txtAmount.Text = "1";
            txtAmount.TextChanged += txtAmountChanged;
        }

        public void LoadCurrencyExchange(CurrencyExchangeResponse selection)
        {
            ViewModel.CurrencyExchange = selection;
            lvwRateList.ItemsSource = selection.Rates;
            txtAmount.Text = "1";
            UpdateRates();
        }

        private void txtAmountChanged(object sender, TextChangedEventArgs args)
        {
            if (sender as TextBox != null)
            {
                UpdateRates();
            }
        }

        private void UpdateRates()
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                foreach (var rate in ViewModel.CurrencyExchange.Rates)
                {
                    rate.ConvertedAmount = rate.Rate * amount;
                }
            }

            lvwRateList.Items.Refresh();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}