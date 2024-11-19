using System;
using System.Threading.Tasks;

class Program
{
    // Асинхронный метод для имитации скачивания файла
    static async Task DownloadFile(int fileNumber)
    {
        Console.WriteLine($"[Задача {fileNumber}] Начало скачивания файла {fileNumber}");
        Random rnd = new Random();
        int downloadTime = rnd.Next(2000, 5000); // Время скачивания от 2 до 5 секунд
        await Task.Delay(downloadTime);
        Console.WriteLine($"[Задача {fileNumber}] Файл {fileNumber} скачан за {downloadTime / 1000} секунд");
    }

    static async Task Main(string[] args)
    {
        int numFiles = 5;
        Task[] tasks = new Task[numFiles];

        // Создаем задачи для асинхронного выполнения
        for (int i = 0; i < numFiles; i++)
        {
            tasks[i] = DownloadFile(i + 1);
        }

        // Ожидаем завершения всех задач
        await Task.WhenAll(tasks);

        Console.WriteLine("Все файлы успешно скачаны.");
    }
}
