using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Practices.Prism.Commands;

namespace UControls
{
	public class Header : UControl
	{
		# region Closer visibility property
		private static readonly DependencyProperty CloserVisibilityProperty = DependencyProperty.Register("CloserVisibility",
			typeof(bool), typeof(Header), new UIPropertyMetadata(true, CloserVisibilityChanged));

		public bool CloserVisibility
		{
			get { return (bool)GetValue(CloserVisibilityProperty); }
			set { SetValue(CloserVisibilityProperty, value); }
		}

		private static void CloserVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			((Header)d).CloserVisibility = (bool)e.NewValue;
		}
		#endregion

		#region Close command

		private static readonly DependencyProperty CloseCommandProperty = DependencyProperty.Register("CloseCommand",
			typeof(ICommand), typeof(Header));

		private ICommand _closeCommand;

		public ICommand CloseCommand
		{
			get { return _closeCommand ?? (_closeCommand = new DelegateCommand(() => Visibility = Visibility.Collapsed)); }
			set { _closeCommand = value; }
		}
		#endregion


		static Header()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Header), new FrameworkPropertyMetadata(typeof(Header)));
		}

		public Header()
		{
			Content = "Caption";
			FontFamily = SystemFonts.CaptionFontFamily;
			FontSize = 15;
			FontStretch = FontStretches.Normal;
			FontStyle = FontStyles.Normal;
			FontWeight = FontWeights.Bold;
			Foreground = Brushes.White;
			Background = Brushes.Orange;
		}
	}
}
