using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Helpers
{
    public class FileUtils
    {
        public const string FileNameSeparator = "_____";

        public static string CopyFileToNewDirectory(string FilePath, string DirectoryPath, bool DeleteFileAfterCopying = true)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                return null;
            }
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            string text = (!File.Exists(FilePath)) ? HttpContext.Current.Server.MapPath(FilePath) : FilePath;
            string text2 = Path.Combine(DirectoryPath, Path.GetFileName(text));
            if (!File.Exists(text))
            {
                return Path.GetFileName(text);
            }
            if (text != text2)
            {
                if (File.Exists(text2))
                {
                    text2 = text2 + Path.GetFileNameWithoutExtension(text2) + Guid.NewGuid().ToString() + Path.GetExtension(text2);
                }
                new FileInfo(text).CopyTo(text2, overwrite: true);
                if (DeleteFileAfterCopying)
                {
                    try
                    {
                        File.Delete(text);
                    }
                    catch
                    {
                    }
                }
            }
            return Path.GetFileName(text2);
        }

        public static string CopyFileToNewFile(string FilePath, string NewFilePath, bool DeleteFileAfterCopying = true)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                return null;
            }
            string text = (!File.Exists(FilePath)) ? HttpContext.Current.Server.MapPath(FilePath) : FilePath;
            if (!File.Exists(text))
            {
                return Path.GetFileName(text);
            }
            if (text != NewFilePath)
            {
                if (File.Exists(NewFilePath))
                {
                    NewFilePath = NewFilePath + Path.GetFileNameWithoutExtension(NewFilePath) + Guid.NewGuid().ToString() + Path.GetExtension(NewFilePath);
                }
                new FileInfo(text).CopyTo(NewFilePath, overwrite: true);
                if (DeleteFileAfterCopying)
                {
                    try
                    {
                        File.Delete(text);
                    }
                    catch
                    {
                    }
                }
            }
            return Path.GetFileName(NewFilePath);
        }

        public static string GenerateNewFileName(string fileNameOrPath)
        {
            string path = RemoveInvalidFileNameChars(fileNameOrPath.Replace("\"", ""));
            return Path.GetFileNameWithoutExtension(path) + "_____" + Guid.NewGuid().ToString() + Path.GetExtension(path);
        }

        public static string RemoveInvalidFileNameChars(string fileName)
        {
            string newValue = "_";
            char[] value = Path.GetInvalidFileNameChars().Concat(Path.GetInvalidPathChars()).ToArray();
            return new Regex($"[{Regex.Escape(new string(value))}]", RegexOptions.Compiled).Replace(fileName, "_").Replace("&amp;", newValue).Replace("&", newValue);
        }

        public static void CopyDirectory(string sourceDirectoryPath, string destDirectoryPath, bool copyFilesOnParentDirectory = true, bool copySubDirectories = true)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirectoryPath);
            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirectoryPath);
            }
            if (!Directory.Exists(destDirectoryPath))
            {
                Directory.CreateDirectory(destDirectoryPath);
            }
            if (copyFilesOnParentDirectory)
            {
                FileInfo[] files = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in files)
                {
                    string destFileName = Path.Combine(destDirectoryPath, fileInfo.Name);
                    fileInfo.CopyTo(destFileName, overwrite: false);
                }
            }
            if (copySubDirectories)
            {
                DirectoryInfo[] directories = directoryInfo.GetDirectories();
                foreach (DirectoryInfo directoryInfo2 in directories)
                {
                    string destDirectoryPath2 = Path.Combine(destDirectoryPath, directoryInfo2.Name);
                    CopySubDirectory(directoryInfo2.FullName, destDirectoryPath2);
                }
            }
        }

        private static void CopySubDirectory(string sourceDirectoryPath, string destDirectoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sourceDirectoryPath);
            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirectoryPath);
            }
            if (Directory.Exists(destDirectoryPath))
            {
                DeleteAllFilesInDirectory(destDirectoryPath);
            }
            else
            {
                Directory.CreateDirectory(destDirectoryPath);
            }
            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo fileInfo in files)
            {
                string destFileName = Path.Combine(destDirectoryPath, fileInfo.Name);
                fileInfo.CopyTo(destFileName, overwrite: false);
            }
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            foreach (DirectoryInfo directoryInfo2 in directories)
            {
                string destDirectoryPath2 = Path.Combine(destDirectoryPath, directoryInfo2.Name);
                CopySubDirectory(directoryInfo2.FullName, destDirectoryPath2);
            }
        }

        private static void DeleteAllFilesInDirectory(string destDirectoryPath)
        {
            foreach (FileInfo item in new DirectoryInfo(destDirectoryPath).EnumerateFiles())
            {
                item.Delete();
            }
        }

        public static string SaveFile(HttpPostedFileBase file, string contentDirectory,string folder)
        {
            if (file == null && file.ContentLength > 0)
            {
                string filename = $"{Guid.NewGuid().ToString()}.{Path.GetExtension(file.FileName)}";
                string fullname = $"{contentDirectory}/{filename}";
                file.SaveAs(fullname);
                return $@"{folder}/{filename}";
            }
            else
            {
                return null;
            }
        }     
    }
}
