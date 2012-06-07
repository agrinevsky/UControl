using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UControls
{
	public class UControl : ContentControl, INotifyPropertyChanged
	{
		#region INotifyPropertyChanged members
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion

		static UControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(UControl), new FrameworkPropertyMetadata(typeof(UControl)));
		}

		public UControl()
		{
			Padding = new Thickness(3);
			BorderBrush = Brushes.Black;
			BorderThickness = new Thickness(1);
		}
	}
}
