using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AddAToFilename
{
    class Program
    {
        public static void Main(String[] args)
        {
            string extStr = ".avi";

            string srcPath = ".";
            string dstPath = ".";
            if (args.Length > 0)
            {
                if (System.IO.Directory.Exists(args[0]))
                {
                    srcPath = args[0];
                    if (args.Length > 1)
                    {
                        dstPath = args[1];
                    }
                    else
                    {
                        dstPath = srcPath + @"\AFiles";
                    }
                }
                else
                {
                    Console.WriteLine("{0} not found; using current directory:",
                        args[0]);
                }
            }

            string fileName = "";
            if (System.IO.Directory.Exists(srcPath))
            {
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(dstPath))
                {
                    System.IO.Directory.CreateDirectory(dstPath);
                }

                string[] files = System.IO.Directory.GetFiles(srcPath, "*" + extStr);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    string inFile = fileName;

                    try
                    {
                        //Remove the extension
                        string[] fileNameArray = fileName.Split('.');
                        fileName = fileNameArray[0];


                        //put it back together
                        fileName = fileName + "a" + extStr;

                        string destFile = System.IO.Path.Combine(dstPath, fileName);
                        System.IO.File.Copy(s, destFile,true);
                        
                        Console.WriteLine("In:\t {0} \nOut:\t {1}\n", inFile, fileName);
                    }
                    catch
                    {
                    }
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        
        }
    }
}
