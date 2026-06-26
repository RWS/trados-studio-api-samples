using System;
using System.Globalization;
using System.Windows.Data;

namespace TranslationStudioAutomationPlugin
{
	public class BooleanInverterConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool boolValue)
			{
				return !boolValue;
			}
			return value; // Return unchanged if not a bool
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is bool boolValue)
			{
				return !boolValue;
			}
			return value;
		}
	}
}
