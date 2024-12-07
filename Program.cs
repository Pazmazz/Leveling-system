class Unit
{
    Random rnd = new Random();

    public int hp = 20;
    public int atk = 5;
    public int def = 3;

    public int exp = 0;
    public int totalExp = 0;
    int requiredExp = 0;
    public readonly int maxLvl = 20;
    public int lvl = 1;

    public int GetRequiredExp(int lvl)
    {
        requiredExp = (int)Math.Pow(lvl, 4) + 14;
        return requiredExp;
    }

    public void GainExp(int num)
    {
        totalExp += num;
        exp += num;

        if (exp >= requiredExp)
        {
            while (exp >= requiredExp)
            {
                exp -= requiredExp;
                LevelUp();
            }
        }
    }

    public void CalculateRequiredExp()
    {
        requiredExp = GetRequiredExp(lvl);
    }

    public void LevelUp()
    {
        int randomHp = rnd.Next(4, 7);
        int randomAtk = rnd.Next(1, 4);
        int randomDef = rnd.Next(1, 4);

        hp += randomHp;
        atk += randomAtk;
        def += randomDef;
        lvl++;

        Console.WriteLine("You leveled up!\nYou are now level " + lvl);
        //Console.WriteLine("Hp increased by " + randomHp + "!\nHP: " + hp);
        //Console.WriteLine("Attack increased by " + randomAtk + "!\nAttack: " + atk);
        //Console.WriteLine("Defense increased by " + randomDef + "!\nDefense: " + def);
    }
}

class Program
{
    static void Yeild()
    {
        Console.ReadLine();
    }
    
    static void Main(string[] args)
    {
        Unit unit = new Unit();
        
        while (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            unit.CalculateRequiredExp();

            if (unit.lvl == unit.maxLvl)
            {
                Console.WriteLine("You maxed out!");
                break;
            }
            
            unit.GainExp(15);
            Console.WriteLine("Level " + unit.lvl);
            Console.WriteLine("Experience Points: " + unit.totalExp);
            Console.WriteLine("");
        }

    }
}
