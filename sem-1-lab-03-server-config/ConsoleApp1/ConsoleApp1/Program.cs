namespace lab3;

public class Program
{
    public static void Main()
    {
        bool Iventstart = false;
        DateTime timeivent;
        int warnings = 0;
        int errors = 0;
        string[] lines = File.ReadAllLines("event_server.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("Событие началось:"))
            {
                Iventstart = true;
                string datetext = lines[i].Substring(0, 23);
                timeivent = DateTime.Parse(datetext);
                Console.WriteLine("Дата начала события: " + datetext);
            }
            if (Iventstart)
            {
                //Console.WriteLine(lines[i]);
            }
            if (Iventstart && lines[i].Contains("Reward") && lines[i].Contains("победителями события"))
            {
                int startteam = lines[i].IndexOf("] ") + 2;
                int winnerend = lines[i].IndexOf(" объявлены победителями");
                string winner = lines[i].Substring(startteam, winnerend - startteam);
                Console.WriteLine("Победитель: " + winner);
            }
            if (Iventstart && lines[i].Contains("Reward") && lines[i].Contains("Ночные совы получили "))
            {
                string starttext = "Ночные совы получили ";
                int startexp = lines[i].IndexOf(starttext) + starttext.Length;
                int expend = lines[i].IndexOf(" очков", startexp);
                string exp = lines[i].Substring(startexp, expend - startexp);
                Console.WriteLine("Очки победителя: " + exp);
            }
            if (Iventstart && lines[i].Contains("Loot") && lines[i].Contains("ивентовый предмет"))
            {
                string startloottext = "Ночные совы получили ивентовый предмет:";
                int startloot = lines[i].IndexOf(startloottext) + startloottext.Length;
                string loot = lines[i].Substring(startloot);
                Console.WriteLine("Ивентовый предмет:" + loot);
            }
            if (Iventstart && lines[i].Contains("Reward") && lines[i].Contains("утешительную награду:"))
            {
                int startreward = lines[i].IndexOf("утешительную награду:") + "утешительную награду:".Length;
                string reward = lines[i].Substring(startreward);
                Console.WriteLine("Утешительная награда:" + reward);
            }
            if (Iventstart && lines[i].Contains("[Warning]"))
            {
                warnings++;
            }
            if (Iventstart && lines[i].Contains("[Error]"))
            {
                errors++;

            }
            if (lines[i].Contains("закрыто"))
            {
                Iventstart = false;
            }
        }
        Console.WriteLine("Предупреждения: " + warnings);
        Console.WriteLine("Ошибки: " + errors);
    }
}