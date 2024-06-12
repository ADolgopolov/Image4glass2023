using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Image4glass
{
    public class MainWindowUserSettings
    {
        public struct MianSettingsStruct
        {
            public Point WindowLocation;
            public Size WindowSize;
            public string BaseFolderPath;
            public System.Collections.Specialized.StringCollection FavoritesRunFolders;
            public bool ScrolingImageMode;
            public bool FixZoomChecked;
        }

        private MianSettingsStruct ss;

        public Point WindowLocation
        {
            get 
            {
                //чи належать координати видимій області головного екрану, і якщо ні, то присвоює значення (0, 0)
                return EnsureVisibleOnPrimaryScreen(ss.WindowLocation);
            }
            set { ss.WindowLocation = value; }
        }
        public Size WindowSize
        {
            get { return ss.WindowSize; }
            set { ss.WindowSize = value; }
        }

        public string BaseFolderPath
        {
            get { return ss.BaseFolderPath; }
            set { ss.BaseFolderPath = value; }
        }

        public System.Collections.Specialized.StringCollection FavoritesRunFolders
        {
            get { return ss.FavoritesRunFolders; }
            set { ss.FavoritesRunFolders = value; }
        }

        public bool ScrolingImageMode
        {
            get { return ss.ScrolingImageMode; }
            set { ss.ScrolingImageMode = value; }
        }

        public bool FixZoomChecked
        {
            get { return ss.FixZoomChecked; }
            set { ss.FixZoomChecked = value; }
        }

        public MainWindowUserSettings()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(MianSettingsStruct));
            ss = new MianSettingsStruct(); // Ініціалізуємо ss, щоб уникнути можливості нульового значення

            string filePath = Path.Combine(Application.StartupPath, "MainWindowUserSettings.xml");

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    var deserialized = serializer.Deserialize(reader);
                    if (deserialized != null)
                    {
                        ss = (MianSettingsStruct)deserialized;
                    }
                    if (String.IsNullOrEmpty(ss.BaseFolderPath))
                        ss.BaseFolderPath = String.Empty;
                }
            }
        }

        public void SaveSettings()
        {
            // Шлях до файлу
            string filePath = Path.Combine(Application.StartupPath, "MainWindowUserSettings.xml");

            // Створити XmlSerializer для MySettings класу
            XmlSerializer serializer = new XmlSerializer(typeof(MianSettingsStruct));

            // Відкрити файл для запису
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Серіалізувати об'єкт та зберегти у файл
                serializer.Serialize(writer, ss);
            }
        }

        public Point EnsureVisibleOnPrimaryScreen(Point savedLocation)
        {
            foreach (var screen in Screen.AllScreens)
            {
                var screenWorkingArea = screen.WorkingArea;
                // Перевірити, чи координати належать робочій області
                if (screenWorkingArea.Contains(savedLocation))
                {
                    return savedLocation;
                }
            }
            return new Point(0, 0);
        }
    }
}
