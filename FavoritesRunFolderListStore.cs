using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Image4glass
{
    internal class FavoritesRunFolderListStore
    {
        private System.Collections.Specialized.StringCollection RunFoldersCollection;

        public FavoritesRunFolderListStore(System.Collections.Specialized.StringCollection stringCol)
        {
            // Якщо initialCollection є null, створюємо новий екземпляр StringCollection
            // В іншому випадку присвоюємо вже існуючий initialCollection
            RunFoldersCollection = stringCol ?? new System.Collections.Specialized.StringCollection();
        }

        /// <summary>
        /// Метод, яки добавляє в колекціяю нову папку, якщо така вже була, то видаляє попереднє включення і добавляє в початок стрічки
        /// </summary>
        /// <param name="newRunFolder"></param>
        public void AddNewRunFolder(string newRunFolder)
        {
            if (RunFoldersCollection.Contains(newRunFolder))
            {
                this.RunFoldersCollection.RemoveAt(RunFoldersCollection.IndexOf(newRunFolder));
            }
            this.RunFoldersCollection.Insert(0, newRunFolder);

            // Залишити лише перші 10 елементів
            while (RunFoldersCollection.Count > 10) // можна if
            {
                RunFoldersCollection.RemoveAt(10);
            }
        }

        /// <summary>
        /// Метод, який повертає StringCollection для збереження списку після виходу з програми
        /// </summary>
        /// <returns></returns>
        public System.Collections.Specialized.StringCollection ReturnList()
        {
            return RunFoldersCollection;
        }

        /// <summary>
        /// Метод, який повертає список рядків для ініціалізації ListBox
        /// </summary>
        /// <returns></returns>
        public List<string> GetListBoxItems()
        {
            List<string> listBoxItems = new List<string>();
            StringEnumerator myEnumerator = RunFoldersCollection.GetEnumerator();
            while (myEnumerator.MoveNext())
            {
                if (myEnumerator.Current != null)
                {
                    listBoxItems.Add(myEnumerator.Current);
                }
            }
            return listBoxItems;
        }
    }
}
