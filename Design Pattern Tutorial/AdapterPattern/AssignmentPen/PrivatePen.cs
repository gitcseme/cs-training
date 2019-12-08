using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern.AssignmentPen
{
    public class PrivatePen
    {
        public void Scratch(string text)
        {
            /*
             * Inaccessible code
             *
             */

            Console.WriteLine(text);
        }
    }
}
