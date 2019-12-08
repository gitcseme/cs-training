using System;
using System.Collections.Generic;
using System.Text;

namespace AdapterPattern.AssignmentPen
{
    public class AssignmentWork
    {
        private Pen p { get; set; }

        public void setPen(Pen pen)
        {
            p = pen;
        }

        public void WriteAssignment(string text)
        {
            p.Write(text);
        }
    }
}
