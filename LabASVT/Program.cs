using System;
using System.Threading;

class Program
{
    // Метод для имитации скачивания файла
    static void DownloadFile(object fileNumber)
    {
        int fileNum = (int)fileNumber;
        Console.WriteLine($"[Поток-{Thread.CurrentThread.ManagedThreadId}] Начало скачивания файла {fileNum}");
        Random rnd = new Random();
        int downloadTime = rnd.Next(2000, 5000); // Время скачивания от 2 до 5 секунд
        Thread.Sleep(downloadTime);
        Console.WriteLine($"[Поток-{Thread.CurrentThread.ManagedThreadId}] Файл {fileNum} скачан за {downloadTime / 1000} секунд");
    }

    static void Main(string[] args)
    {
        int numFiles = 5;
        Thread[] threads = new Thread[numFiles];

        // Создаем и запускаем потоки
        for (int i = 0; i < numFiles; i++)
        {
            threads[i] = new Thread(DownloadFile);
            threads[i].Start(i + 1);
        }

        // Ожидаем завершения всех потоков
        foreach (var thread in threads)
        {
            thread.Join();
        }

        Console.WriteLine("Все файлы успешно скачаны.");
    }
}