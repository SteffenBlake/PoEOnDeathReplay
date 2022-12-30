using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowsInput;

namespace OnDeathReplay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource CTS { get; }
        public MainWindow()
        {
            InitializeComponent();
            CTS = new CancellationTokenSource();
            new Thread(() => ListenLogs(CTS.Token)).Start();
        }

        private void ListenLogs(CancellationToken token)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("AppSettings.json", false)
                .Build()
                .Get<OnDeathReplayConfiguration>();

            var simulator = new InputSimulator();
            using var fs = new FileStream(config.LogFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete);
            using var reader = new StreamReader(fs);
            _ = reader.ReadToEnd();

            while (!token.IsCancellationRequested)
            {
                var line = reader.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    Thread.Sleep(100);
                    continue;
                }
                if (!line.Contains("] :"))
                {
                    continue;
                }

                if (!line.EndsWith("has been slain."))
                {
                    continue;
                }

                Thread.Sleep(config.Delay_ms);

                _ = simulator.Keyboard.ModifiedKeyStroke(config.KeyModifiers, config.Keys);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CTS.Cancel();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
