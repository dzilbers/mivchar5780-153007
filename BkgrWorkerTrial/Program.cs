using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BkgrWorkerTrial
{
    class Program
    {
        //private static BackgroundWorker worker = new BackgroundWorker();
        private static Thread thread;
        static void Main(string[] args)
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += (sender, e) =>
            {
                Console.WriteLine("Starting to do some work now...");
                thread = Thread.CurrentThread;
                int i;
                for (i = 1; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    worker.ReportProgress(Convert.ToInt32((100.0 * i) / 10));
                }

                e.Result = i;
            };
            worker.RunWorkerCompleted += (sender, e) =>
                Console.WriteLine($"Value Of i = {e.Result.ToString()}\nDone now...");
            worker.ProgressChanged += (sender, e) =>
                Console.WriteLine(e.ProgressPercentage.ToString());
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            Console.WriteLine("Starting Application...");
            worker.RunWorkerAsync(worker);
            while (thread == null) Thread.Sleep(10);
            Console.WriteLine("Waiting for finish");
            thread.Join();
            Console.WriteLine("Now really finished");
            Console.ReadKey();
        }
        private static void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine($"Value Of i = {e.Result.ToString()}\nDone now...");
        }
        private static void progressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage.ToString());
        }

        private static void doWorker(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = (BackgroundWorker)e.Argument;
            Console.WriteLine("Starting to do some work now...");
            int i;
            for (i = 1; i < 10; i++)
            {
                Thread.Sleep(1000);
                worker.ReportProgress(Convert.ToInt32((100.0 * i) / 10));
            }
            e.Result = i;
        }
    }
}
