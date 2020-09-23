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
    /// Interaction logic for CurrencyExchangeRateItem.xaml
    /// </summary>
    public partial class CurrencyExchangeRateItem : UserControl
    {
        public CurrencyExchangeRateItem()
        {
            InitializeComponent();
        }

        public static DependencyProperty ExchangeRateItemProperty =
        DependencyProperty.Register("ExchangeRateItem", typeof(KeyValuePair<string, float>), typeof(CurrencyExchangeRateItem));

        public KeyValuePair<string, float> ExchangeRateItem
        {
            get { return (KeyValuePair<string, float>)GetValue(ExchangeRateItemProperty); }
            set { SetValue(ExchangeRateItemProperty, value); }
        }
    }
}
