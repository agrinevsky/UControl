using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace UControls
{
	public class Form : UControl
	{
		# region Header property
		private static readonly DependencyProperty HeaderProperty = DependencyProperty.Register("Header",
			typeof(Header), typeof(Form));

		public Header Header
		{
			get { return (Header) GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}
		#endregion

		# region Body property
		private static readonly DependencyProperty BodyProperty = DependencyProperty.Register("Body",
			typeof(UControl), typeof(Form));

		public UControl Body
		{
			get { return (UControl)GetValue(BodyProperty); }
			set { SetValue(BodyProperty, value); }
		}
		#endregion

		#region Close command
		private ICommand _closeCommand;

		public ICommand CloseCommand
		{
			get { return _closeCommand ?? (_closeCommand = new DelegateCommand(() => Visibility = Visibility.Collapsed)); }
			set { _closeCommand = value; }
		}
		#endregion

		static Form()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(Form), new FrameworkPropertyMetadata(typeof(Form)));
		}

		public Form()
		{
			Header = new Header();
			Body = new UControl();
			BorderThickness = new Thickness(0);
			Padding = new Thickness(0);
		}

		protected override void OnInitialized(System.EventArgs e)
		{
			base.OnInitialized(e);
			var content = Content;
			Content = null;
			Body.Content = content;
		}
	}
}
