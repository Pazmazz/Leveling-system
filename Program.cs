class Unit
{
    Random rnd = new Random();
    
    public int hp = 20;
    public int atk = 5;
    public int def = 3;

    public int exp = 0;
    public int lvl = 1;

    public void LevelUp()
    {
        int randomHp = rnd.Next(4, 7);
        int randomAtk = rnd.Next(1, 4);
        int randomDef = rnd.Next(1, 4);

        hp += randomHp;
        atk += randomAtk;
        def += randomDef;
        lvl += 1;

        Console.WriteLine("You levled up!\nYou are now level " + lvl);
        Console.WriteLine("Hp increased by " + randomHp + "!\nHP: " + hp);
        Console.WriteLine("Attack increased by " + randomAtk + "!\nAttack: " + atk);
        Console.WriteLine("Defense increased by " + randomDef + "!\nDefense: " + def);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Unit unit = new Unit();
        
        while (Console.ReadKey().Key == ConsoleKey.Enter)
        {
            Console.WriteLine("Level " + unit.lvl);
            unit.exp += 1;
            Console.WriteLine("Experience Points: " + unit.exp);
            Console.WriteLine("");
            
            if (unit.exp % 5 == 0)
            {
                unit.LevelUp();
            }
        }

    }
}
