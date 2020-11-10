using System;
using System.Collections.Generic;
using System.IO;

namespace Exercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> votes = new Dictionary<string, int>();
            
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        while (!reader.EndOfStream)
                        {
                            string[] vs = reader.ReadLine().Split(",");

                            if (!(votes.ContainsKey(vs[0])))
                            {
                                votes[vs[0]] = int.Parse(vs[1]);
                            }
                            else
                            {
                                votes[vs[0]] += int.Parse(vs[1]);
                            }
                        }
                    }
                }

                foreach(KeyValuePair<string, int> pair in votes)
                {
                    Console.WriteLine(pair.Key + ": " + pair.Value);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Unexpected error! " + e.Message);
            }
        }
    }
}
