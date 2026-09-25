namespace lab2;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Проверка конфигурации сервера ===");

        Console.Write("Введите максимальное количество игроков: ");
        int players = int.Parse(Console.ReadLine());

        Console.Write("Введите выделенную оперативную память (ГБ): ");
        int RAM = int.Parse(Console.ReadLine());

        Console.Write("Введите максимально допустимую оперативную память (ГБ): ");
        int RAMSERVERMAX = int.Parse(Console.ReadLine());

        Console.Write("Резервное копирование включено? (true/false): ");
        bool backup = bool.Parse(Console.ReadLine());

        bool serverCanStart = true;

        if (players > 10000)
        {
            Console.WriteLine("Сервер не выдержит столько людей.");
            serverCanStart = false;
        }
        else
        {
            Console.WriteLine("Количество игроков в норме.");
        }

        if (RAM > RAMSERVERMAX)
        {
            Console.WriteLine("Сервер не выдержит такую нагрузку.");
            serverCanStart = false;
        }
        else
        {
            Console.WriteLine("Оперативной памяти достаточно.");
        }

        if (backup == true)
        {
            Console.WriteLine("Облачные копии есть, можно не бояться.");
        }
        else
        {
            Console.WriteLine("Внимание: резервные копии отсутствуют.");
        }

        Console.WriteLine("Готовы ли вы запустить сервер?");
        Console.ReadLine();

        Console.WriteLine("Вы уверены? Сервер может работать некорректно");
        Console.ReadLine();

        if (serverCanStart)
        {
            Console.WriteLine("Сервер успешно запущен.");
        }
        else
        {
            Console.WriteLine("Запуск сервера невозможен.");
        }
    }
}