using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int count = 0;
        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }
        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal journal, string filePath, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filePath))
                File.WriteAllText(filePath, journal.ToString());
        }
    }

    public class SRP
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            journal.AddEntry("I cried today");
            journal.AddEntry("I ate a bug");
            journal.AddEntry("I kiss my gf");
            Console.WriteLine(journal);

            Persistence persistence = new Persistence();
            string filePath = @"C:\Users\shuvo\Desktop\code\journal.txt";
            persistence.SaveToFile(journal, filePath, true);
            Process.Start(filePath);
        }
    }
}
