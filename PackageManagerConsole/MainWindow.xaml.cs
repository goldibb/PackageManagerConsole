using System.Diagnostics;
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

namespace PackageManagerConsole;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }


    private void InputKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            var p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c " +InputTextBox.Text;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;
            p.Start();
            string strOutput = "Command: " +p.StandardOutput.ReadToEnd();
            string strError = "Error: " + p.StandardError.ReadToEnd();
            p.WaitForExit();
            if (p.HasExited)
            {
                if (strError == "")
                {
                    OutputTextBox.Text += strOutput;
                }
                else
                {
                    OutputTextBox.Text += strError;
                    OutputTextBox.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
            
        }
        
    }
    

}
