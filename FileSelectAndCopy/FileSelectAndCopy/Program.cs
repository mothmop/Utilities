using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FileSelectAndCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            string srcPath = ".";
            if (args.Length > 0)
            {
                if (System.IO.Directory.Exists(args[0]))
                {
                    srcPath = args[0];
                }
                else
                {
                    Console.WriteLine("{0} not found; using current directory:",
                        args[0]);
                }
            }


            if (System.IO.Directory.Exists(srcPath))
            {
                string targetPath = @".\O2data";
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                string[] SctO2files = System.IO.Directory.GetFiles(srcPath, "SctO2-*.csv");
                string[] StO2files = System.IO.Directory.GetFiles(srcPath, "StO2-*.csv");
                string[] SctO2redo;
                string[] StO2redo;

                if (File.Exists(srcPath+@"\SctO2.txt"))
                {
                    SctO2redo = System.IO.File.ReadAllLines(srcPath+@"\SctO2.txt");
                    foreach (string patID in SctO2redo)
                    {
                        Console.WriteLine("\t" + patID);
                        string sPattern = @".*SctO2-\d{7}" + patID + @"\.csv";
                        foreach (string file in SctO2files)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(file, sPattern))
                            {
                                System.Console.WriteLine(patID + " " + file);

                                string fileName = System.IO.Path.GetFileName(file);
                                string destFile = System.IO.Path.Combine(targetPath, fileName);
                                System.IO.File.Copy(file, destFile, true);
                            }
                        }
                    }
                }

                if (File.Exists(srcPath + @"\StO2.txt"))
                {
                    StO2redo = System.IO.File.ReadAllLines(srcPath + @"\StO2.txt");
                    foreach (string patID in StO2redo)
                    {
                        Console.WriteLine("\t" + patID);
                        string sPattern = @".*StO2-\d{7}" + patID + @"\.csv";
                        foreach (string file in StO2files)
                        {
                            if (System.Text.RegularExpressions.Regex.IsMatch(file, sPattern))
                            {
                                System.Console.WriteLine(patID + " " + file);
                                string fileName = System.IO.Path.GetFileName(file);
                                string destFile = System.IO.Path.Combine(targetPath, fileName);
                                System.IO.File.Copy(file, destFile, true);
                            }
                        }
                    }
                }




                // Keep console window open in debug mode.
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();

            }

        }
    }
}
