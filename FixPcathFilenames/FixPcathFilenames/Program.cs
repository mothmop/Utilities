using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FixPcathFilenames
{
    class Program
    {
        public static void Main(String[] args)
        {
            string studyName = "Pcath";
            string timePoint = "T0";
            string siteName = "UAB";
            string extStr = ".avi";

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
                string targetPath = @".\PcathFiles";
                // To copy a folder's contents to a new location:
                // Create a new target folder, if necessary.
                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                string[] files = System.IO.Directory.GetFiles(srcPath, "*" + extStr);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    string inFile = fileName;
                    string patID;
                    //DateTime dt;
                    string dtString = "";
                    string scanNum = "0";

                    try
                    {
                        //Remove the .mp4 extension
                        string[] fileNameArray = fileName.Split('.');
                        fileName = fileNameArray[0];

                        //if (fileNameArray.Length == 3)
                        //{
                        //    fileName = fileNameArray[0];
                        //}
                        //else
                        //{
                        //    throw new System.FormatException();
                        //}

                        ////Get the PatientID, ScanNum and Date
                        fileNameArray = fileName.Split('_');
                        patID = fileNameArray[0];
                        if (fileNameArray.Length > 1)
                        {
                            scanNum = fileNameArray[1];
                            switch (scanNum)
                            {
                                case "A":
                                case "a":
                                    scanNum = "1";
                                    break;
                                case "B":
                                case "b":
                                    scanNum = "2";
                                    break;
                                case "C":
                                case "c":
                                    scanNum = "3";
                                    break;
                                case "D":
                                case "d":
                                    scanNum = "4";
                                    break;
                                case "E":
                                case "e":
                                    scanNum = "5";
                                    break;
                                case "F":
                                case "f":
                                    scanNum = "6";
                                    break;
                                case "G":
                                case "g":
                                    scanNum = "7";
                                    break;
                                case "H":
                                case "h":
                                    scanNum = "8";
                                    break;
                                default:
                                    scanNum = "0";
                                    break;
                            }
                        }
                        else
                            scanNum = "0";

                        scanNum = scanNum.Trim();



                        //if (fileNameArray.Length == 2)
                        //{
                        //    patID = fileNameArray[0];
                        //    dtString = fileNameArray[1];
                        //    fileNameArray = patID.Split('_');
                        //}
                        //else
                        //{
                        //    throw new System.FormatException();
                        //}

                        //if (fileNameArray.Length == 2)
                        //{
                        //    patID = fileNameArray[0];
                        //    scanNum = fileNameArray[1];
                        //    scanNum = scanNum.Trim();
                        //}
                        //else
                        //{
                        //    throw new System.FormatException();
                        //}


                        //dtString = dtString.Replace("_", ":");
                        //dt = Convert.ToDateTime(dtString);
                        //dtString = dt.ToString("yyyy-MM-dd-HH-mm-ss");


                        //put it back together
                        fileName = studyName + "-" + siteName + "-" + patID + "-" + timePoint + "--" + dtString + "-" + scanNum + extStr;

                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
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
