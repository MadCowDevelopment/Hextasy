﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Hextasy.Framework
{
    public class DoubleMultiplierConverter : IValueConverter
    {
        #region Public Methods

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dividend = (double) value;
            var divisor = double.Parse(parameter.ToString(), CultureInfo.InvariantCulture);
            return dividend*divisor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        #endregion Public Methods
    }
}