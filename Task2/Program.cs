namespace Task2
{
    internal class Program
    {
        //Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами).
        //На вход метод принимает URL директории, в ответ — размер в байтах.
       
        static void Main(string[] args)
        {
            string dirPath = @"C:\Users\Алла\source\repos\Module8\Task2\FolderForTask2\TestFolder";

            DirectorySize(dirPath);
        }

        static void DirectorySize(string dirPath)
        {
            DirectoryInfo directory = new DirectoryInfo(dirPath);
            if (directory.Exists)
            {
                Console.WriteLine($"Размер папки: {DirectoryAndFileSize(directory)} байт");
            }
            else
            {
                Console.WriteLine("Папки не существует");
            }
        }

        static long DirectoryAndFileSize(DirectoryInfo directory)
        {
            long dirSize = 0;
            foreach (FileInfo file in directory.GetFiles())
            {
                dirSize += file.Length;
            }
            foreach (DirectoryInfo subDirectory in directory.GetDirectories())
            {
                dirSize += DirectoryAndFileSize(subDirectory);
            }
            return dirSize;
        }
    }
}

