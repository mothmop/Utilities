using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace cplist
{
    class Program
    {
        static void Main(string[] args)
        {
            string inList;
            string destPath;
            string inPath;

            if (args.Length == 3)
            {
                inList = args[0];
                destPath = args[2];
                inPath = args[1];

                if (!System.IO.Directory.Exists(destPath))
                {
                    System.IO.Directory.CreateDirectory(args[2]);
                }
                if (!File.Exists(inList))
                {
                    Console.WriteLine("List file {0} not found\n");
                }
                else
                {
                    string[] lines = System.IO.File.ReadAllLines(inList);
                    foreach (string line in lines)
                    {
                        string thepath = System.IO.Path.GetDirectoryName(line);
                        if (thepath=="")
                        {
                            thepath = inPath;
                        }
                        string linebase = System.IO.Path.GetFileName(line)+"*";
                        string[] files = System.IO.Directory.GetFiles(thepath,linebase,SearchOption.AllDirectories);
                        foreach (string file in files)
                        {
                            string fileName = System.IO.Path.GetFileName(file);
                            string destFile = System.IO.Path.Combine(destPath, fileName);
                            if (System.IO.File.Exists(file))
                            {
                                System.IO.File.Copy(file, destFile, true);
                                Console.WriteLine("\tCopied " + fileName + " to " + destPath);
                            }
                            else
                            {
                                Console.WriteLine("\tError: FileNotFound " + fileName);
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Usage: cplist <list file> <input path> <output path>\n");
            }
            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
