namespace laba2;

class Program
{
    static void Main()
    {
        Console.WriteLine("============================================");
        Console.WriteLine("Cостояние сервера fucking server dota2:");
        Console.WriteLine("============================================");
        int numPlayers = 35153;
        int maxplayerstoday = 42867;
        double hightping = 1100.31;
        double lowping = 2.712;
        float srping = 50.14f;
        bool serverwork = true;
        string versiongame = "7.41e";

        Console.WriteLine("-------------Status-------------");
        Console.WriteLine($"кол-во человек на сервере:{numPlayers}");
        Console.WriteLine($"максимальный онлайн за сегодня:{maxplayerstoday}");
        Console.WriteLine($"самый высокий пинг игрока:{hightping}");
        Console.WriteLine($"самый низкий пинг игрока:{lowping}");
        Console.WriteLine($"средний пинг игроков{srping}");
        Console.WriteLine($"сервер работает?{serverwork}");
        Console.WriteLine($"версия игры:{versiongame}");
    }

}