using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace FanDuel.Classes.Converters
{
    #region AnswerStateToColorValueConverter
    public class AnswerStateToColorValueConverter : IValueConverter
    {
        private Color[] _colors = new Color[] { Color.Transparent, Color.Green, Color.Red };

        #region IValueConverter
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var index = (int)value;
            return _colors[index];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
    #endregion
}
