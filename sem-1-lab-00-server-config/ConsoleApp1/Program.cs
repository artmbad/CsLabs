class program
{

    public static void Main()
    {
        Console.Write("введите имя своего персонажа:");
        string name = Console.ReadLine();
        Console.WriteLine($"приветствуем тебя, {name}!!!");
        Console.Write("какой класс ты выбираешь?");
        string characterclass = Console.ReadLine();
        Console.WriteLine("теперь прокачай 3 своих стата");
        Console.Write("сила:");
        string buffer1 = Console.ReadLine();
        int strenght = Convert.ToInt32(buffer1);

        Console.Write("ловкость:");
        string buffer2 = Console.ReadLine();
        int agility = Convert.ToInt32(buffer2);
        
        Console.Write("интелект:");
        string buffer3= Console.ReadLine();
        int intelligence= Convert.ToInt32(buffer3);

        Console.WriteLine($"поздравляем с созданием персонажа, твоё имя:{name}");
        Console.WriteLine("=============================================");
        Console.WriteLine($"сила:{strenght}, ловкость:{agility}, интелект:{intelligence}");
    }
}