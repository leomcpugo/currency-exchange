﻿using mcpugo.CurrencyTest.Shared.Model;
using mcpugo.CurrencyTest.View.ViewModel.CurrencyExchangeViews;
using System;
using System.Collections.Generic;
using System.Text;
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
        }

        public static DependencyProperty CurrencyExchangeProperty =
        DependencyProperty.Register("CurrencyExchange", typeof(CurrencyExchangeResponse), typeof(CurrencyExchangeRateDetail));
        public CurrencyExchangeResponse CurrencyExchange
        {
            get { return (CurrencyExchangeResponse)GetValue(CurrencyExchangeProperty); }
            set
            {
                SetValue(CurrencyExchangeProperty, value);
                ViewModel.CurrencyExchange = value;
            }
        }
    }
}