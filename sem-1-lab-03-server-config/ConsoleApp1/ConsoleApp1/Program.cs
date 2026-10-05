namespace lab3;

public class Program
{
    public static void Main()
    {
        string[] lines = File.ReadAllLines("event_server.txt");
        Console.WriteLine(BuildReport(lines));
    }
    public static string BuildReport(string[] lines)
    {
        bool Iventstart = false;
        DateTime timeivent;
        int warnings = 0;
        int errors = 0;
        string report = "";
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("Событие началось:"))
            {
                Iventstart = true;
                string datetext = lines[i].Substring(0, 23);
                timeivent = DateTime.Parse(datetext);
                report += "Дата: " + datetext + "\n";
            }
            if (Iventstart && lines[i].Contains("Reward") && lines[i].Contains("победителями события"))
            {
                int startteam = lines[i].IndexOf("] ") + 2;
                int winnerend = lines[i].IndexOf(" объявлены победителями");
                string winner = lines[i].Substring(startteam, winnerend - startteam);
                report += "Победитель: " + winner + "\n";
            }
            if (Iventstart && lines[i].Contains("Reward") && lines[i].Contains("Ночные совы получили "))
            {
                string starttext = "Ночные совы получили ";
                int startexp = lines[i].IndexOf(starttext) + starttext.Length;
                int expend = lines[i].IndexOf(" очков", startexp);
                string exp = lines[i].Substring(startexp, expend - startexp);
                report += "Очки победителя: " + exp + "\n";
            }
            if (Iventstart && lines[i].Contains("Loot") && lines[i].Contains("ивентовый предмет"))
            {
                string startloottext = "Ночные совы получили ивентовый предмет:";
                int startloot = lines[i].IndexOf(startloottext) + startloottext.Length;
                string loot = lines[i].Substring(startloot);
                report += "Ивентовый предмет:" + loot + "\n";
            }
            if (Iventstart && lines[i].Contains("Reward") && lines[i].Contains("утешительную награду:"))
            {
                int startreward = lines[i].IndexOf("утешительную награду:") + "утешительную награду:".Length;
                string reward = lines[i].Substring(startreward);
                report += "Утешительная награда Железных волков:" + reward + "\n";
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
        report += "Предупрежденя: " + warnings + "\n";
        report += "Ошибкия: " + errors + "\n";
        return report;
    }
}