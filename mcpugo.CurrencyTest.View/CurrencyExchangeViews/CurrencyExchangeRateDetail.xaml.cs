﻿using mcpugo.CurrencyTest.Shared.Model;
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
        public CurrencyExchangeRateDetailViewModel ViewModel { get; private set; } = new CurrencyExchangeRateDetailViewModel();

        public CurrencyExchangeRateDetail()
        {
            InitializeComponent();
            DataContext = ViewModel;
            txtAmount.Text = "1";
            txtAmount.TextChanged += txtAmount_Changed;
        }

        /// <summary>
        /// Sets a new Currency Exchange Rate
        /// </summary>
        /// <param name="selection">The Curreny Exchange Rate</param>
        /// <param name="resetAmount">Parameter that determines if the amount should be reseted</param>
        public void SetCurrencyExchange(CurrencyExchangeResponse selection, bool resetAmount = true)
        {
            ViewModel.CurrencyExchange = selection;
            tblCurrencyCode.Text = selection.Code;
            if (resetAmount) txtAmount.Text = "1";

            lvwRateList.ItemsSource = selection.Rates
                .OrderByDescending(x => UserPreferences.UserPreferences.IsFavorite(x.Code))
                .ThenBy(x => x.Code)
                .ToList();

            UpdateRates();
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