using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ExamTest
{

    class MyClass
    {
        int a;
        int b;
        public int A { get; set; }
        public int B { get; set; }
        public MyClass()
        {
            Console.WriteLine(this);
            Console.WriteLine("" + A + ";" + B);
            A = b = 2;
            Console.WriteLine(this);
            Console.WriteLine("" + A + ";" + B);
        }
        public override string ToString()
        {
            return string.Format("({0},{1})", a, b);
        }
    }

    class Student
    {
        public int StudentId { set; get; }
        public string StudentName { set; get; }
        public List<Course> Courses { set; get; }
    }

    class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

    class Program
    {
        static IEnumerable<IGrouping<int, Student>> Func1(List<Student> students)
        {
            return from s in students
                   where s.Courses != null && s.Courses.Count > 0
                   orderby s.Courses.Count
                   group s by s.Courses.Count;
        }
        static IEnumerable<IGrouping<int, Student>> Func2(List<Student> students)
        {
            return from s in students
                   where s.Courses != null && s.Courses.Count > 0
                   group s by s.Courses.Count into g
                   orderby g.Key
                   select g;
        }

        //static volatile Thread thread;
        static void Main(string[] args)
        {
            //List<int> list = new List<int>() { 1, 2, 3, 4 };
            //IEnumerable result1 = list.Where(x => x % 2 == 0);
            //List<int> result2 = list.FindAll(x => x % 2 == 0);
            //list[0] = 2;

            //foreach (var item in result1)
            //    Console.Write(item);

            //Console.WriteLine();
            //Console.WriteLine("---");

            //foreach (var item in result2)
            //    Console.Write(item);

            //MyClass myClass = new MyClass { A = 1, B = 1 };
            //Console.WriteLine(myClass);
            //Console.WriteLine("A=" + myClass.A + "; B=" + myClass.B);

            Thread th = new Thread(() => Console.WriteLine("T"));
            for (int i = 1; i <= 3; ++i) { th.Start(); th.Join(); }
            //BackgroundWorker worker = new BackgroundWorker();
            //worker.DoWork += (sender, ev) =>
            //{
            //    //thread = Thread.CurrentThread;
            //    Console.Write("Start");
            //    int progress = 0;
            //    while (!worker.CancellationPending)
            //    {
            //        Thread.Sleep(500);
            //        progress += (int)ev.Argument;
            //        try 
            //        {
            //            worker.ReportProgress(progress, "P");
            //        }
            //        catch (Exception e) { }
            //    }
            //    Thread.Sleep(500);
            //    Console.Write("Stop");
            //};
            //worker.WorkerReportsProgress = true;
            //worker.WorkerSupportsCancellation = true;
            //worker.ProgressChanged += (sender, ev) =>
            //{
            //    if (ev.ProgressPercentage > 100)
            //        worker.CancelAsync();
            //    else
            //        Console.Write(ev.UserState);
            //};
            //worker.RunWorkerCompleted += (sender, ev) => Console.Write("Completed");
            //Console.Write("Begin");
            //worker.RunWorkerAsync(40);
            ////while (thread == null) Thread.Sleep(10);
            ////Console.Write("Available");
            ////while (thread.ThreadState != ThreadState.Stopped) Thread.Sleep(100);
            //Thread.Sleep(2000);
            //worker.CancelAsync();
            //while (worker.IsBusy) Thread.Sleep(10);
            //Console.Write("End");
        }
    }
}
