using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson5
{
    public class Printer2
    {
        public event PrintEventHandler PageOver = null;
        private int pageCount = 20;
        private void handlePageOver()
        {
            //if (PageOver != null) PageOver();
            PageOver?.Invoke();
        }
        public void Print(int pages)
        {
            if (pages <= pageCount) pageCount -= pages;
            else { pageCount = 0; handlePageOver(); }
        }
    }
}
