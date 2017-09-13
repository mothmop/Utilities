using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FixLSIFilenames
{
    class Program
    {
        static void Main(string[] args)
        {
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
                string targetPath = @".\LSIFiles";
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                string[] files = System.IO.Directory.GetFiles(srcPath, "*.tif*");

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    string inFile = fileName;

                    string[] fileNameArray = fileName.Split('-');
                    string[] subArray1 = fileNameArray[4].Split('.');
                    
                    string timeCode = subArray1[0];
                    switch (timeCode.Length)
                    {
                        case 1:
                        timeCode = "000" + timeCode;
                            break;
                        case 2:
                            timeCode = "00" + timeCode;
                            break;
                        case 3:
                            timeCode = "0" + timeCode;
                            break;
                        case 4:
                        default:
                            break;
                    
                    }

                    subArray1[0] = timeCode;
                    //put it back together
                    fileNameArray[4] = String.Join(".", subArray1);
                    fileName = String.Join("-", fileNameArray);

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
