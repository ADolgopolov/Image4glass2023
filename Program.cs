using System.Windows.Forms;

namespace Image4glass
{
    
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string filePath;
            if (args.Length > 0)
            {
                if (args.Length == 1)
                {
                    filePath = args[0];
                    if (File.Exists(filePath))
                    {
                        if(filePath.Contains("Run"))
                        {
                            Application.Run(new Image4lass(filePath));
                        }
                        else
                        {
                            Image image = Image.FromFile(filePath);
                            ZoomImageForm zoomImage = new ZoomImageForm(image);
                            zoomImage.Text = filePath;
                            Application.Run(zoomImage);
                        }
                        
                    }
                }
            }
            else
            {
                // Якщо немає параметрів командного рядка, відображаємо головне вікно
                Application.Run(new Image4lass());
            }
        }
    }
}