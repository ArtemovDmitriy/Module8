namespace Task1
{
    internal class Program
    {
        //Напишите программу, которая чистит нужную нам папку от файлов  и папок, 
        //которые не использовались более 30 минут
        static void Main(string[] args)
        {
            int minutes = 30;
            string dirPath = @"C:\Users\Алла\source\repos\Module8\Module8\FolderForTask1\TestFolder";

            DirectoryInfo directory = new DirectoryInfo(dirPath);
            DeleteInFolder(directory, minutes);

        }

        static void DeleteInFolder(DirectoryInfo directory, int minutes)
        {
            if (directory.Exists)
            {
                if (DateTime.Now - directory.LastAccessTime > TimeSpan.FromMinutes(minutes))
                {
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    Console.WriteLine("Все файлы удалены");
                    foreach (DirectoryInfo dir in directory.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Console.WriteLine("Все папки удалены");
                }
                else
                {
                    Console.WriteLine($"Время последнего доступа меньше {minutes} минут");
                }
            }
            else
            {
                Console.WriteLine("Папки не существует");
            }
        }
    }
}
    
        
