using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern.AssignmentPen
{
    public class PenAdapter : Pen
    {
        PrivatePen pp = new PrivatePen();

        public void Write(string text)
        {
            pp.Scratch(text);
        }
    }
}
