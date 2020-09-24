using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mcpugo.CurrencyTest.View.UserPreferences
{
    public static class UserPreferences
    {
        private static List<string> _favoriteCurrencyList;
        private static List<string> FavoriteCurrencyList
        {
            get
            {
                if (_favoriteCurrencyList == null)
                {

                    _favoriteCurrencyList = Properties.Settings.Default.CurrencyFavoriteList
                        .Split(',')
                        .Where(x => !string.IsNullOrEmpty(x))
                        .ToList();
                }

                return _favoriteCurrencyList;
            }
        }

        public static void AddRemoveFromFavorites(string code)
        {
            if (FavoriteCurrencyList.Contains(code)) FavoriteCurrencyList.Remove(code);
            else FavoriteCurrencyList.Add(code);
            Properties.Settings.Default.Save();
        }

        public static bool IsFavorite(string code)
        {
            return FavoriteCurrencyList.Contains(code);
        }
    }
}
