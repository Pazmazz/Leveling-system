/* 
     All the number here are ajustable for testing purposes 
*/

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

    /* 
     This function checks the exp required in order to get to the next level
     */
    public int GetRequiredExp(int lvl)
    {
        requiredExp = (int)Math.Pow(lvl, 4) + 14;
        return requiredExp;
    }

    /* 
    This function addes the gained exp to the exp and the totalExp variables
     
    The exp variable is for tracking the required exp to level up
     
    The totalExp varibale is for tracking the total about exp gained across all levels
     */
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

    /* 
     This function is called to calculate the exp that is required to level up
     */
    public void CalculateRequiredExp()
    {
        requiredExp = GetRequiredExp(lvl);
    }

    /* 
     This handles all of the things that happen when you level up such as stat increases and all that jazz
     */
    public void LevelUp()
    {
        /* 
        Please ignore all the random stat stuff i was testing something
        */
        //int randomHp = rnd.Next(4, 7);
        //int randomAtk = rnd.Next(1, 4);
        //int randomDef = rnd.Next(1, 4);

        //hp += randomHp;
        //atk += randomAtk;
        //def += randomDef;
        
        lvl++;

        Console.WriteLine("You leveled up!\nYou are now level " + lvl);

        //Console.WriteLine("Hp increased by " + randomHp + "!\nHP: " + hp);
        //Console.WriteLine("Attack increased by " + randomAtk + "!\nAttack: " + atk);
        //Console.WriteLine("Defense increased by " + randomDef + "!\nDefense: " + def);
    }
}

class Program
{
    /* 
     This is for yeilding text and dialouge
     */
    static void Yeild()
    {
        Console.ReadLine();
    }
    
    static void Main(string[] args)
    {
        Unit unit = new Unit();

        /* 
        When you press enter, you gain exp (adjustable in the GainExp() call) and displayes your level and total exp

        Once you reach level 20, you max out
        */
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
