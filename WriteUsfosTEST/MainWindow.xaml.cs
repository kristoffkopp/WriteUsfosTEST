using System.Collections.Generic;
using System.Windows;

namespace WriteUsfosTEST
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void button_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
		{
			var dummyData = new GenerateDummyInputData();
			UsfosFileWriter fileWriter = new UsfosFileWriter(@"C:\Users\Kristoffer\Documents\Visual Studio 2015\usfos_test_file_write_focus.usf", dummyData.UsfosDataSet);
			fileWriter.writeFile();
		}
	}
}
