using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class Document
    {

    }

    /*
    public interface IMachine
    {
        void Print(Document d);
        void Scan(Document d);
        void Fax(Document d);
    }

    
    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            // perform fax
        }

        public void Print(Document d)
        {
            // perform print
        }

        public void Scan(Document d)
        {
            // perform scan
        }
    }

    // This printer only need Print function.
    public class OldFashionPrinter : IMachine
    {
        public void Fax(Document d)
        {
            throw new NotImplementedException();
        }

        public void Print(Document d)
        {
            // peform print
        }

        public void Scan(Document d)
        {
            throw new NotImplementedException();
        }
    }
    */

    public interface IPrinter
    {
        void Print(Document d);
    }
    public interface IScanner
    {
        void Scan(Document d);
    }
    public interface IFax
    {
        void Fax(Document d);
    }
    public interface ILagerPrinter
    {
        void LagerPrint(Document d);
    }


    public interface IMultiFunctionDevice : IPrinter, IScanner, IFax, ILagerPrinter
    {
        
    }

    public class OldFashoinPrinter : IPrinter
    {
        public void Print(Document d)
        {
            // perform print
        }
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document d)
        {
            // perform print
        }

        public void Scan(Document d)
        {
            // perform Scan
        }
    }

    public class MultiFunctionPrinter : IMultiFunctionDevice
    {
        public void Fax(Document d)
        {
            // perform fax
        }

        public void LagerPrint(Document d)
        {
            // perform lagerPrint
        }

        public void Print(Document d)
        {
            // perform print
        }

        public void Scan(Document d)
        {
            // perform Scan
        }
    }

    public class ISP
    {
        static void Main(string[] args)
        {

        }
    }
}
