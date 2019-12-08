using AdapterPattern.AssignmentPen;
using AdapterPattern.PointLine;
using System;

namespace AdapterPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            /* Line point example.
             * 
            Line line = new Line(1, 1, 5, 10);
            //printer.PrintPoint(line); // Hence we need an Adapter that can make things work.
            LineToPoint_Adapter lineToPoint_Adapter = new LineToPoint_Adapter(line);
            lineToPoint_Adapter.print();
            */

            /* Pen example */
            AssignmentWork aw = new AssignmentWork();

            //PrivatePen pp = new PrivatePen();
            //aw.setPen(pp); // not compatible with pen. hence we adapter.

            aw.setPen(new PenAdapter());
            
            aw.WriteAssignment("This is an EEE assignment to write");

        }
    }
}
