using System;

class Character
{
    public string Name { get; set; }
    public int Health { get; set; }

    public virtual void Attack()
    {
        Console.WriteLine($"{Name} attacks!");
    }
}

class Warrior : Character
{
    public override void Attack()
    {
        Console.WriteLine($"{Name} swings a sword!");
    }
}

class Mage : Character
{
    public override void Attack()
    {
        Console.WriteLine($"{Name} casts a fireball!");
    }
}

class Archer : Character
{
    public override void Attack()
    {
        Console.WriteLine($"{Name} shoots an arrow!");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Character c1 = new Warrior { Name = "Thor", Health = 100 };
        Character c2 = new Mage { Name = "Merlin", Health = 80 };

        c1.Attack();
        c2.Attack();
    }
}