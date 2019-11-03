using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    public class PrinterEventArgs : EventArgs
    {
        public readonly string Paper;
        public PrinterEventArgs(string paperType)
        {
            Paper = paperType;
        }
    }
    public class Printer
    {
        public string Name { get { return "My Printer"; } }
        public event EventHandler<PrinterEventArgs> PageOver = null;
        private int pageCount = 20;
        private void handlePageOver()
        {
            //if (PageOver != null) PageOver();
            PageOver?.Invoke(this, new PrinterEventArgs("A4"));
        }
        public void Print(int pages)
        {
            if (pages <= pageCount) pageCount -= pages;
            else { pageCount = 0; handlePageOver(); }
        }
    }
}
