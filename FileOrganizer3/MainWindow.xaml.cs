using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace FileOrganizer3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (Equals(sender, btnOpenFile1))
            {
                var openFileDialog1 = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
                if (openFileDialog1.ShowDialog() == true)
                {
                    txtEditor1.Text = openFileDialog1.SelectedPath;
                }
            }
            else if (Equals(sender, btnOpenFile2))
            {
                var openFileDialog2 = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
                if (openFileDialog2.ShowDialog() == true)
                {
                    txtEditor2.Text = openFileDialog2.SelectedPath;
                }
            }
        }

        private void StartBtn(object sender, RoutedEventArgs e)
        {
            string sourceFolder = txtEditor1.Text;
            string destinationFolder = txtEditor2.Text;
            List<string> fileExt = GetFileExt();

            MoveFiles(sourceFolder, destinationFolder, fileExt);
        }

        //method determines what boxes are checked
        public List<string> GetFileExt()
        {
            List<string> fileExt = new List<string>();
            if (chkAll.IsChecked ?? false)
            {
                fileExt.Add("all");
                return fileExt;
            }

            if (chkImage.IsChecked ?? false)
            {
                fileExt.Add("image");
            }

            if (chkVideo.IsChecked ?? false)
            {
                fileExt.Add("video");
            }

            if (chkAudio.IsChecked ?? false)
            {
                fileExt.Add("audio");
            }

            if (chkData.IsChecked ?? false)
            {
                fileExt.Add("data");
            }

            if (chkExecute.IsChecked ?? false)
            {
                fileExt.Add("execute");
            }

            if (chkCompressed.IsChecked ?? false)
            {
                fileExt.Add("compress");
            }

            if (chkText.IsChecked ?? false)
            {
                fileExt.Add("text");
            }

            if (chkDisc.IsChecked ?? false)
            {
                fileExt.Add("disc");
            }

            return fileExt;
        }

        public void MoveFiles(string sourceFolder, string destinationFolder, List<string> ext)
        {

            List<string> getFiles = new List<string>();

            //All supported file extensions 
            string[] imageExt = { ".jpg", ".JPG", ".png", ".PNG", ".jpeg", ".JPEG", ".jfif", ".JFIF", ".tiff", ".TIFF", ".bmp", ".BMP", ".dib", ".DIB", ".jpeg-hdr", ".JPEG-HDR", ".heif", ".HEIF", ".heic", ".HEIC", ".bpg", ".BPG", ".bat", ".BAT", ".mng", "MNG", ".webp", ".WEBP", ".flif", ".FLIF" };
            string[] videoExt = { ".mp4", ".MP4", ".webm", ".WEBM", ".flv", ".FLV", ".vob", ".VOB", ".avi", ".AVI", ".MTS", ".M2TS", ".wvm", ".WVM", ".yuv", ".YUV", ".rm", ".RM", ".rmbv", ".RMBV", ".asf", ".ASF", ".m4p", ".M4P", ".mpg", ".MPG", ".mp2", ".MP2", ".mpeg", ".MPEG", ".mpe", ".MPE", ".mpv", ".MPV", ".m4v", "M4V", ".svi", ".SVI", "3gp", ".3GP", ".3g2", "3G2", ".flv", ".FLV", ".f4v", ".F4V", ".f4p", "F4P", ".f4a", ".F4A", ".f4b", "F4B", ".nsv", ".NSV", ".gif", ".GIF", ".apng", ".APNG" };
            string[] textExt = { ".doc", ".DOC", ".odt", ".ODT", ".pdf", ".PDF", ".rtf", ".RTF", ".tex", ".TEX", ".txt", ".TXT", ".wks", ".WKS", ".text", ".TEXT" };
            string[] discExt = { ".bin", ".BIN", ".dmg", ".DMG", ".iso", ".ISO", ".toast", ".TOAST", ".vcd", ".VCD" };
            string[] audioExt = { ".aif", ".AIF", ".cda", ".mid", ".CDA", ".MID", ".midi", ".MIDI", ".mp3", ".MP3", ".ogg", ".OGG", ".wav", ".WAV", ".wma", ".WMA", ".wpl", ".WPL" };
            string[] dataExt = { ".csv", ".CSV", ".dat", ".DAT", ".db", ".DB", ".dbf", ".DBF", ".log", ".LOG", ".mdb", ".MDB", ".sav", ".SAV", ".sql", ".SQL", ".tar", ".TAR", ".xml", ".XML", ".json", ".JSON" };
            string[] compressedExt = { ".7z", ".7Z", ".arj", ".ARJ", ".deb", ".pkg", ".DEB", ".PKG", ".rar", ".RAR", ".rpm", ".tar.gz", ".TAR.GZ", ".z", ".Z", ".zip", ".ZIP" };
            string[] executeExt = { ".apk", ".APK", ".bat", ".BAT", ".bin", ".BIN", ".cgi", ".CGI", ".pl", ".py", ".PL", ".PY", ".com", ".exe", ".EXE", ".gadget", ".jar", ".JAR", ".wsf", ".WSF" };

            if (ext.Contains("all"))
            {

                List<string> files = new List<string>(Directory.GetFiles(sourceFolder));
                foreach (string file in files)
                {
                    getFiles.Add(file);
                }
            }

            //Build list of all checked file types
            if (!ext.Contains("all"))
            {
                if (ext.Contains("image"))
                {
                    List<string> files = new List<string>(Directory
                        .GetFiles(sourceFolder, "*", SearchOption.AllDirectories)
                        .Where(i => imageExt.Contains(Path.GetExtension(i))));
                    foreach (string file in files)
                    {
                        getFiles.Add(file);
                    }
                }

                if (ext.Contains("video"))
                {
                    List<string> files = new List<string>(Directory
                        .GetFiles(sourceFolder, "*", SearchOption.AllDirectories)
                        .Where(i => videoExt.Contains(Path.GetExtension(i))));
                    foreach (string file in files)
                    {
                        getFiles?.Add(file);
                    }
                }

                if (ext.Contains("text"))
                {
                    List<string> files = new List<string>(Directory
                        .GetFiles(sourceFolder, "*", SearchOption.AllDirectories)
                        .Where(i => discExt.Contains(Path.GetExtension(i))));
                    foreach (string file in files)
                    {
                        getFiles?.Add(file);
                    }
                }

                if (ext.Contains("disc"))
                {
                    List<string> files = new List<string>(Directory
                        .GetFiles(sourceFolder, "*", SearchOption.AllDirectories)
                        .Where(i => textExt.Contains(Path.GetExtension(i))));
                    foreach (string file in files)
                    {
                        getFiles?.Add(file);
                    }
                }

                if (ext.Contains("audio"))
                {
                    List<string> files = new List<string>(Directory
                        .GetFiles(sourceFolder, "*", SearchOption.AllDirectories)
                        .Where(i => audioExt.Contains(Path.GetExtension(i))));
                    foreach (string file in files)
                    {
                        getFiles?.Add(file);
                    }
                }

                if (ext.Contains("execute"))
                {
                    List<string> files = new List<string>(Directory
                        .GetFiles(sourceFolder, "*", SearchOption.AllDirectories)
                        .Where(i => executeExt.Contains(Path.GetExtension(i))));
                    foreach (string file in files)
                    {
                        getFiles?.Add(file);
                    }
                }

                if (ext.Contains("data"))
                {
                    List<string> files = new List<string>(Directory
                        .GetFiles(sourceFolder, "*", SearchOption.AllDirectories)
                        .Where(i => dataExt.Contains(Path.GetExtension(i))));
                    foreach (string file in files)
                    {
                        getFiles?.Add(file);
                    }
                }

                if (ext.Contains("compress"))
                {
                    List<string> files = new List<string>(Directory
                        .GetFiles(sourceFolder, "*", SearchOption.AllDirectories)
                        .Where(i => compressedExt.Contains(Path.GetExtension(i))));
                    foreach (string file in files)
                    {
                        getFiles?.Add(file);
                    }
                }
            }

            List<string> duplicateList = new List<string>(Directory.GetFiles(destinationFolder));

            List<string> duplicateCheck = new List<string>();

            foreach (string du in duplicateList)
            {
                duplicateCheck.Add(Path.GetFileName(du));
            }


            //collects all duplicate files.  if list is not null after foreach loop, then method is called to handle the duplicates.
            List<string> duplicateObj = new List<string>();

            foreach (var getFile in getFiles)
            {
                //gets filename and extension without path
                string fileName = Path.GetFileName(getFile);

                //adds filename and extension to destination folder path so the file will have same name as before.  
                string destFile = Path.Combine(destinationFolder, fileName ?? throw new InvalidOperationException());

                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                try
                {
                    if (duplicateCheck.Contains(fileName))
                    {
                        duplicateObj.Add(fileName);

                    }
                    else
                    {
                        File.Move(getFile, destFile);
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine(e);
                }
            }

            if (duplicateObj.Count > 0)
            {
                DisplayDuplicateErrorBox(duplicateObj, sourceFolder, destinationFolder);
            }
        }

        public void DisplayDuplicateErrorBox(List<string> parameter, string sourceFolder, string destinationFolder)
        {
            foreach (string param in parameter)
            {

                MessageBoxResult result = MessageBox.Show($"The following file, {param}, is duplicated in the destination folder, {destinationFolder}. Would you like to delete this file from the source folder, {sourceFolder}? {parameter.IndexOf(param) + 1}/{parameter.Count}", "Duplicate File", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        bool deleteResult = DeleteFile(param, sourceFolder);
                        try
                        {
                            if (deleteResult)
                            {
                                MessageBox.Show($"The file, {param}, was successfully deleted from the source folder, {sourceFolder}.", "File Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }

                        break;
                    case MessageBoxResult.No:
                        MessageBox.Show($"File, {param}, will remain in the source folder, {sourceFolder}.", "File not deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case MessageBoxResult.Cancel:
                        break;

                }
            }

        }

        public bool DeleteFile(string fileName, string sourceFolder)
        {
            try
            {
                string path = $@"{sourceFolder}\{fileName}";
                File.Delete(path);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }

}