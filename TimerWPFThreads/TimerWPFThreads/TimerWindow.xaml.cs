using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace TimerWPFThreads
{
    public partial class TimerWindow : Window
    {
        Stopwatch stopWatch;
        volatile bool isTimerRun;

        public TimerWindow()
        {
            InitializeComponent();
            stopWatch = new Stopwatch();
        }

        void setTextInvoke(string text)
        {
            if (!CheckAccess())
                Dispatcher.BeginInvoke((Action<string>)setTextInvoke, text);
            else
                this.timerTextBlock.Text = text;
        }

        void runTimer()
        {
            while (isTimerRun)
            {
                string timerText = stopWatch.Elapsed.ToString();
                timerText = timerText.Substring(0, 10);

                setTextInvoke(timerText);
                Thread.Sleep(100);
            }
        }

        void startTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerRun)
            {
                stopWatch.Restart();
                isTimerRun = true;

                new Thread(runTimer).Start();
            }

        }

        void stopTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (isTimerRun)
            {
                stopWatch.Stop();
                isTimerRun = false;
            }
        }
    }
}
