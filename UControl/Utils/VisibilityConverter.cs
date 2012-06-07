using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UControls.Utils
{
	public class VisibilityConverter : IValueConverter
	{
		public object Convert(object value, System.Type targetType, object parameter, CultureInfo culture)
		{
			var visibility = (bool)value;
			var result = Visibility.Collapsed;
			if (visibility)
				result = Visibility.Visible;
			return result;
		}

		public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo culture)
		{
			var visibility = (Visibility)value;
			return visibility == Visibility.Visible;
		}

		public Visibility Convert(bool value)
		{
			return (Visibility)Convert(value, typeof(Visibility), null, CultureInfo.CurrentCulture);
		}
		public bool ConvertBack(Visibility value)
		{
			return (bool)ConvertBack(value, typeof(bool), null, CultureInfo.CurrentCulture);
		}
	}
}
