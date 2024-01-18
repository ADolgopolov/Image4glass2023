using System.IO;
using System.Text.RegularExpressions;

namespace Image4glass
{
    internal class FilePathBuilder
    {
        private bool isInitializated;
        private string part1;
        private string part2;
        private string part3;
        private string extension;

        public bool IsInitializated
        {
            get { return isInitializated; }
        }

        public string Part1
        {
            get { return part1; }
            set { 
                part1 = value; 
                isInitializated = true;
            }
        }

        public string Part2
        {
            get { return part2; }
            set 
            {
                if (value.Contains('|')) 
                {
                    part2 = value.Replace('|', '\\');
                } 
                else
                {
                    if (value.Contains('-'))
                    {
                        part2 = value.Replace('-', '\\');
                    }
                    else
                    {
                        part2 = value.Replace('_', '\\');
                    }
                }
            }
        }

        public string Part2_straight
        {
            get { return part2; }
            set { part2 = value; }
        }

        public string Part3
        {
            get { return part3; }
            set { part3 = value; }
        }

        public string FullImageFilePath
        {
            get
            {
                string filePath = Path.Combine(part1, part2, "Right\\" + part3 + extension);
                return filePath;
            }
        }
        
        public string RunFolderFullPath
        {
            get
            {
                string filePath = Path.Combine(part1, part2);
                return filePath;
            }
        }

        public FilePathBuilder()
        {
            isInitializated = false;
            part1 = string.Empty;
            part2 = string.Empty;
            part3 = string.Empty;
            extension = ".jpg";
            this.ReadData();
        }

        public void Reset()
        {
            isInitializated = false;
            part1 = string.Empty;
            part2 = string.Empty;
            part3 = string.Empty;
            extension = ".jpg";
        }

        private void ReadData()
        {
            string? data = Properties.Settings.Default.BaseFolderPath;

            if (String.IsNullOrEmpty(data))
            {
                part1 = String.Empty;
                isInitializated = false;
            }
            else
            {
                part1 = data;
                isInitializated = true;
            }
        }

        public bool initByFullPathFileName(string fullPathFileName) 
        {
            if (fullPathFileName.Contains(part1))
            {

                this.part2 = fullPathFileName.Replace(part1 + "\\", "");
                
                this.part2 = this.part2.Replace("\\Forward", "");
                this.part2 = this.part2.Replace("\\Rear", "");
                this.part2 = this.part2.Replace("\\Left", "");
                this.part2 = this.part2.Replace("\\Right", "");
                
                this.part2 = this.part2.Replace("\\" + Path.GetFileName(fullPathFileName), "");

                this.part3 = Path.GetFileNameWithoutExtension(fullPathFileName);

                return true; 
            }
            else
            {
                return false;
            }
        }
    }

}
