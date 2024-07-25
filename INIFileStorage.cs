using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paint
{
    public class INIFileStorage
    {
        private const int MaxRecentFiles = 10;
        private readonly string filePath;

        public INIFileStorage(string directoryName = "PaintApp", string fileName = "settings.ini")
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string dirPath = Path.Combine(appDataPath, directoryName);
            Directory.CreateDirectory(dirPath); 
            filePath = Path.Combine(dirPath, fileName);
        }

        public void AddRecentFile(string file)
        {
            string fileName = Path.GetFileName(file);
            List<string> recentFiles = GetRecentFiles();
            string normalizedPath = Path.GetFullPath(file).ToLowerInvariant();

            recentFiles.RemoveAll(f => Path.GetFullPath(f).ToLowerInvariant() == normalizedPath);
            recentFiles.Insert(0, file);

            if (recentFiles.Count > MaxRecentFiles)
                recentFiles = recentFiles.Take(MaxRecentFiles).ToList();

            SaveRecentFiles(recentFiles);
        }

        public List<string> GetRecentFiles()
        {
            if (!File.Exists(filePath))
                return new List<string>();

            Dictionary<string, string> settings = ParseIniFile();
            var files = settings.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value).ToList();

            return files;
        }

        private void SaveRecentFiles(List<string> files)
        {
            var settings = new Dictionary<string, string>();
            for (int i = 0; i < files.Count; i++)
            {
                settings[$"File{i + 1}"] = files[i];
            }
            WriteIniFile(settings);
        }

        private void WriteIniFile(Dictionary<string, string> settings)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("[RecentFiles]");
                foreach (var setting in settings)
                {
                    sw.WriteLine($"{setting.Key}={setting.Value}");
                }
            }
        }

        private Dictionary<string, string> ParseIniFile()
        {
            var settings = new Dictionary<string, string>();
           
            foreach (var line in File.ReadAllLines(filePath))
            {
                string trimmedLine = line.Trim();

                if (!string.IsNullOrWhiteSpace(trimmedLine) && !trimmedLine.StartsWith(";"))
                {
                    var kvp = trimmedLine.Split(new char[] { '=' }, 2);
                    if (kvp.Length == 2)
                    {
                        settings[kvp[0].Trim()] = kvp[1].Trim();
                    }
                }
            }
            return settings;
        }
    }
}

