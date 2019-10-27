using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM_Task12.Task2
{
    public class Counter
    {
        public Dictionary<string, int> WordCounter => dictionaryCounter;

        private readonly Dictionary<string, int> dictionaryCounter;

        public Counter() { }

        public Counter(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("File doesn't exist.");

            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(path);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }

            string[] words = streamReader.ReadToEnd().Split();

            dictionaryCounter = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (dictionaryCounter.ContainsKey(word))
                {
                    int counter;
                    dictionaryCounter.TryGetValue(word, out counter);
                    dictionaryCounter[word] = ++counter;
                }
                else
                    dictionaryCounter.Add(word, 1);
            }
        }
    }
}
