using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FixNISfilenames
{
    class Program
    {
        public static void Main(String[] args)
        {
            string studyName = "nis";
            string tpToReplace1 = "0h";
            string tpSubstitute1 = "pre";
            string tpToReplace2 = "24h";
            string tpSubstitute2 = "post";
            string tpToReplace3 = "t0";

            string srcPath = ".";
            if (args.Length > 0)
            {
                if (File.Exists(args[0]))
                {
                    srcPath = args[0];
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
                string targetPath = @".\nisFiles";
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                string[] files = System.IO.Directory.GetFiles(srcPath,"*.avi");

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    string inFile = fileName;

                    string[] fileNameArray = fileName.Split('-');
                    //replace first instance with new study name
 
                    //put it back together
                    fileName = String.Join("-",fileNameArray[4],fileNameArray[5]);

                    string destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                    Console.WriteLine("In:\t {0} \nOut:\t {1}\n", inFile, fileName);
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
