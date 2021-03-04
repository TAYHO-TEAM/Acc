using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using AppWFGenProject.Extensions;

namespace AppWFGenProject.FrameWork
{
    public class FileHelper
    {
        public string ReplaceFileName(string path, GenOB GenOB)
        {
            return path.Replace("{Entity}", GenOB.Entity).Replace("{version}", GenOB.version).Replace("version", GenOB.version).Replace("Entity", GenOB.Entity);
        }
        public bool ReplaceLine(string txtFile, Dictionary<string, string> dicGenOB)
        {

            //    StreamReader reader = new StreamReader(directory + fileName);
            //    string input = reader.ReadToEnd();

            //    using (StreamWriter writer = new StreamWriter(directory + saveFileName, true))
            //    {
            //        {
            //            string output = input.Replace(word, replacement);
            //            writer.Write(output);
            //        }
            //        writer.Close();
            //    }

            if (File.Exists(txtFile))
            {
                using (var sourceFile = File.OpenText(txtFile))
                {
                    // Open a stream for the temporary file
                    using (var tempFileStream = new StreamWriter(txtFile))
                    {
                        string line;
                        // read lines while the file has them
                        while ((line = sourceFile.ReadLine()) != null)
                        {
                            foreach (var item in dicGenOB)
                            {
                                // Do the word replacement
                                line = line.Replace(item.Key, item.Value);
                            }
                            // Write the modified line to the new file
                            tempFileStream.WriteLine(line);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CreateFileFrom(string txtFileOld, string txtFileNew, Dictionary<string, string> dicGenOB)
        {
            createPath(txtFileNew);
            if (File.Exists(txtFileOld))
            {
                if (File.Exists(txtFileNew))
                {
                    File.Delete(txtFileNew);
                }
                using (var sourceFile = File.OpenText(txtFileOld))
                {
                    // Open a stream for the temporary file
                    using (var tempFileStream = new StreamWriter(txtFileNew))
                    {
                        string line;
                        // read lines while the file has them
                        while ((line = sourceFile.ReadLine()) != null)
                        {
                            foreach (var item in dicGenOB)
                            {
                                // Do the word replacement
                                line = line.Replace(item.Key, item.Value);
                            }
                            // Write the modified line to the new file
                            tempFileStream.WriteLine(line);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ReplaceLine(string txtFile, string sourcetxt, string destxt)
        {
            //createPath(destxt);
            if (File.Exists(txtFile))
            {
                using (var sourceFile = File.OpenText(txtFile))
                {
                    // Open a stream for the temporary file
                    using (var tempFileStream = new StreamWriter(txtFile))
                    {
                        string line;
                        // read lines while the file has them
                        while ((line = sourceFile.ReadLine()) != null)
                        {
                            // Do the word replacement
                            line = line.Replace(sourcetxt, destxt);
                            // Write the modified line to the new file
                            tempFileStream.WriteLine(line);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ChangeTxtToCS(string txtFile, int typeCreate)
        {
            if (File.Exists(txtFile))
            {
                try
                {
                    Guid g = Guid.NewGuid();
                    // Create a FileInfo  
                    FileInfo fi = new FileInfo(txtFile);
                    // Check if file is there  
                    if (fi.Exists)
                    {
                        if(typeCreate == 1)
                        {
                            // Move file with a new name. Hence renamed.  
                            fi.MoveTo(fi.FullName.Replace(".txt", ".cs"));
                        } 
                        else if(typeCreate == 2)
                        {
                            if (File.Exists(txtFile.Replace(".txt", ".cs")))
                            {
                                string fileNameCS = fi.FullName.Replace(".txt", "_" + g.ToString() + ".cs");
                                // Move file with a new name. Hence renamed.  
                                fi.MoveTo(fileNameCS);
                            }
                            else
                            {
                                // Move file with a new name. Hence renamed.  
                                fi.MoveTo(fi.FullName.Replace(".txt", ".cs"));
                            }
                        }
                        else if (typeCreate == 3)
                        {
                            if (File.Exists(txtFile.Replace(".txt", ".cs")))
                            {
                                FileInfo fiCSExists = new FileInfo(txtFile.Replace(".txt", ".cs"));
                                string fileNameCS = fiCSExists.FullName.Replace("cs", "_bak_" + g.ToString()+".cs");

                                // Move file with a new name. Hence renamed.  
                                fiCSExists.MoveTo(fileNameCS);
                                fi.MoveTo(fi.FullName.Replace(".txt", ".cs"));
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool CompileFile(string txtFile, string sourceFile, string desfile)
        {
            Path.Combine(txtFile, txtFile.Replace(sourceFile, desfile));
            return true;
        }
        public bool CreateTxt(string txtFile, string content)
        {
            if (DestroyFile(txtFile))
            {
                //File.Create(txtFile);
                try
                {
                    // Create a FileInfo  
                    FileInfo fi = new FileInfo(txtFile);
                    // Check if file is there  
                    if (!fi.Exists)
                    {
                        using (StreamWriter sw = File.CreateText(txtFile))
                        {
                            sw.Write(content);
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ImportLine(string[] Lines, string path)
        {
            if (DestroyFile(path))
            {
                try
                {
                    File.Create(path);
                    using (TextWriter tw = new StreamWriter(path))
                    {
                        foreach (string line in Lines)
                            tw.WriteLine(tw);
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void ChangeFileTemp(string pathOld, string pathNew)
        {
            if (File.Exists(pathOld))
            {
                File.Delete(pathOld);
            }

            File.Move(pathOld, pathNew);
        }
        private static bool DestroyFile(string path)
        {
            try
            {

                if (File.Exists(path))
                {
                    // no error
                    File.Delete(path);

                }
                // but still exists
                if (File.Exists(path))
                {
                    return false;
                    //throw new IOException(string.Format("Failed to delete file: '{0}'.", path));
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
                //throw ex;
            }
        }
        public string[] getFiles(string rootdir, bool Dir)
        {
            // get list of files or get list of directories
            return Dir == true ? Directory.GetDirectories(rootdir) : Directory.GetFiles(rootdir);
        }
        public string[] getAllFiles(string rootdir, bool Dir)
        {
            // get list of files or get list of directories
            return Dir == true ? Directory.GetDirectories(rootdir, "*", SearchOption.AllDirectories) : Directory.GetFiles(rootdir, "*", SearchOption.AllDirectories);
        }
        public IEnumerable<string> getEnumAllFiles(string rootdir, bool Dir)
        {
            return Dir == true ? Directory.EnumerateFiles(rootdir, "*", SearchOption.AllDirectories) : Directory.EnumerateDirectories(rootdir, "*", SearchOption.AllDirectories);
        }
        public IEnumerable<string> getEnumAllFilesTail(string rootdir,string tail, bool Dir)
        {
            return Dir == true ? Directory.EnumerateFiles(rootdir, "*."+ tail, SearchOption.AllDirectories) : Directory.EnumerateDirectories(rootdir, "*", SearchOption.AllDirectories);
        }
        public IEnumerable<string> getFileSys(string rootdir)
        {
            // get list of files or get list of directories
            return Directory.GetFileSystemEntries(rootdir, "*", SearchOption.AllDirectories);
        }
        public List<string> getFileName(string rootdir, bool all, List<string> FilesName)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(rootdir))
                {
                    FilesName.AddRange(Directory.GetFiles(d).Select(Path.GetFileName).ToArray());
                    if (!all) break;
                    getFileName(d, all, FilesName);
                }

            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            return FilesName;
        }
        public void createPath(string files)
        {
            int indexOf = (files.LastIndexOf("\\"));
            try
            {
                Directory.CreateDirectory(files.Substring(0, indexOf +1));
            }
            catch (Exception ex)
            {
                // handle them here
            }
        }
    }
}
