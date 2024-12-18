using CsProject;
using System;
using System.Security.Cryptography;

public interface IAttacking
{
    int Attack();
}

public class Attacks
{
    Random rng = new Random();

    public int FlipTable()
    {
        int damage = rng.Next(2, 6);
        return damage;
    }
    public int ThrowPunch()
    {
        int damage = rng.Next(1, 4);
        return damage;
    }
    public int ThrowABox()
    {
        int damage = rng.Next(3, 4);
        return damage;
    }
    public int ShadowStrike()
    {
        int damage = rng.Next(3, 6);
        return damage;
    }

    public int NecroticTouch()
    {
        int damage = rng.Next(4, 10);
        return damage;
    }
    public int Roar()
    {
        int damage = rng.Next(2, 4);
        return damage;
    }
    public int Slash()
    {
        int damage = rng.Next(3, 7);
        return damage;
    }

    public int Charge()
    {
        int damage = rng.Next(4, 6);
        return damage;
    }
    public int Stab()
    {
        int damage = rng.Next(4, 6);
        return damage;
    }
    public int ClawAttack()
    {
        int damage = rng.Next(2, 5);
        return damage;
    }
    public int BodySlam()
    {
        int damage = rng.Next(1, 7);
        return damage;
    }
    public int AcidBreathe()
    {
        int damage = rng.Next(2, 9);
        return damage;
    }
    public int TailWhip()
    {
        int damage = rng.Next(1, 9);
        return damage;
    }
    public int Fireball()
    {
        int damage = rng.Next(2, 6);
        return damage;
    }

    public int LightningBolt()
    {
        int damage = rng.Next(1, 9);
        return damage;
    }
    public int IceBlast()
    {
        int damage = rng.Next(2, 6);
        return damage;
    }
    public int DarkCurse()
    {
        int damage = rng.Next(3, 7);
        return damage;
    }
    public int ArcaneBlast()
    {
        int damage = rng.Next(4, 8);
        return damage;
    }
    public int SoulDrain()
    {
        int damage = rng.Next(5, 10);
        return damage;
    }

    public int DeathlyGaze()
    {
        int damage = rng.Next(6, 12);
        return damage;
    }
    public int ExecutionersStrike()
    {
        int damage = rng.Next(5, 10);
        return damage;
    }
    public int BladeDance()
    {
        int damage = rng.Next(4, 12);
        return damage;
    }
    public int Slice()
    {
        int damage = rng.Next(2, 11);
        return damage;
    }
    public int NecroticWave()
    {
        int damage = rng.Next(5, 15);
        return damage;
    }
    public int DeathlyAura()
    {
        int damage = rng.Next(2, 8);
        return damage;
    }
    public int SpectralSlash()
    {
        int damage = rng.Next(2, 12);
        return damage;
    }
    public int SoulShatter()
    {
        int damage = rng.Next(5, 14);
        return damage;
    }
}

public class Enemy : IAttacking
{
    public virtual int Attack() { return 2; }
    public int health;
    public string name;
    public int armor;
    public int xpWorth;
    public int goldWorth;

    public Enemy(int setHealth, string setName, int setArmor, int setXpWorth, int setGoldWorth)
    {
        health = setHealth;
        name = setName;
        armor = setArmor;
        xpWorth = setXpWorth;
        goldWorth = setGoldWorth;
    }
}

public class Braum : Enemy
{
    Attacks attacks = new Attacks();
    public Braum(int health, string name, int armor, int xpWorth, int goldWorth)
   : base(health, name, armor, xpWorth, goldWorth) { }

    Random rng = new Random();
    public override int Attack()
    {
        int damage = 0;
        int attackTypes = rng.Next(1, 3);
        switch (attackTypes)
        {
            case 1:
                damage += attacks.FlipTable();
                Console.WriteLine("Braum flipped a table at you and dealt " + damage + " amount of damage");
                break;
            case 2:
                damage += attacks.ThrowPunch();
                Console.WriteLine("Braum threw a punch at you and dealt " + damage + " amount of damage");
                break;
            case 3:
                damage += attacks.ThrowABox();
                Console.WriteLine("Braum threw a box at you and dealt " + damage + " points of damage");
                break;
        }
        return damage;
    }
}

public class Minotaur : Enemy    //skeletons will also have a damage modifier
{
    Attacks attacks = new Attacks();
    Random rng = new Random();
    public Minotaur(int health, string name, int armor, int xpWorth, int goldWorth)
    : base(health, name, armor, xpWorth, goldWorth) { }
    int damageModify; //the modifier will add up some damage
    public override int Attack()
    {
        damageModify = rng.Next(2, 5);// damage will be added randomly between 2 and 4
        int attackTypes = rng.Next(1, 5);
        int damage = damageModify;
        switch (attackTypes)
        {
            case 1:
                damage += attacks.Slash();
                Console.WriteLine("The Minotaur has slashed you and dealt " + damage + " amount of damage");
                break;
            case 2:
                damage += attacks.Charge();
                Console.WriteLine("The Minotaur has headbutted you and dealt " + damage + " amount of damage");
                break;
            case 3:
                damage += attacks.ThrowABox();
                Console.WriteLine("The Minotaur threw a box at you and dealt " + damage + " points of damage");
                break;
            case 4:
                damage += attacks.Roar();
                Console.WriteLine("The Minotaur has roared to the air, dealing you" + damage + " points of damage");
                break;
        }
        return damage;
    }
}

public class BasicHumanoid : Enemy    //skeletons will also have a damage modifier
{
    Attacks attacks = new Attacks();
    Random rng = new Random();
    public BasicHumanoid(int health, string name, int armor, int xpWorth, int goldWorth)
    : base(health, name, armor, xpWorth, goldWorth) { }
    int damageModify; //the modifier will add up some damage
    public override int Attack()
    {
        damageModify = rng.Next(0, 3);// damage will be added randomly between 0 and 2
        int attackTypes = rng.Next(1, 4);
        int damage = damageModify;
        switch (attackTypes)
        {
            case 1:
                damage += attacks.Slash();
                Console.WriteLine("The enemy has slashed you and dealt " + damage + " amount of damage");
                break;
            case 2:
                damage += attacks.Stab();
                Console.WriteLine("The enemy has stabbed you and dealt " + damage + " amount of damage");
                break;
            case 3:
                damage += attacks.ThrowABox();
                Console.WriteLine("The enemy threw a box at you and dealt " + damage + " points of damage");
                break;
        }
        return damage;
    }
}

public class Manticore : Enemy
{
    Attacks attacks = new Attacks();
    Random rng = new Random();

    public Manticore(int health, string name, int armor, int xpWorth, int goldWorth)
    : base(health, name, armor, xpWorth, goldWorth) { }

    public override int Attack()
    {
        int attackTypes = rng.Next(1, 6);
        int damage = 0;

        switch (attackTypes)
        {
            case 1:
                damage = attacks.ClawAttack();
                Console.WriteLine("The Manticore attacked you with its claw and dealt " + damage + " points of damage");
                break;
            case 2:
                damage = attacks.TailWhip();
                Console.WriteLine("The Manticore launched its tail at you and dealt " + damage + " points of damage");
                break;
            case 3:
                damage = attacks.ThrowABox();
                Console.WriteLine("The Manticore threw a box at you and dealt " + damage + " points of damage");
                break;
            case 4:
                damage = attacks.BodySlam();
                Console.WriteLine("The Manticore slammed its body against you and hit you for " + damage + " points of damage");
                break;
            case 5:
                damage = attacks.AcidBreathe();
                Console.WriteLine("The Manticore launched a acid breathe on you, dealing " + damage + " points of damage");
                break;
        }
        return damage;
    }

}
public class OldKing : Enemy
{
    Attacks attacks = new Attacks();
    Random rng = new Random();
    int damageModify;
    public OldKing(int health, string name, int armor, int xpWorth, int goldWorth)
    : base(health, name, armor, xpWorth, goldWorth) { }

    public override int Attack()
    {
        damageModify = rng.Next(1, 5);
        int attackTypes = rng.Next(1, 11);
        int damage = 0;

        switch (attackTypes)
        {
            case 1:
                damage = attacks.NecroticTouch();
                Console.WriteLine("The Old King attacked you with Necrotic Touch and dealt " + damage + " points of damage");
                break;
            case 2:
                damage = attacks.NecroticWave();
                Console.WriteLine("The Old King unleashes a necrotic wave, dealing " + damage + " points of damage");
                break;
            case 3:
                damage = attacks.ThrowABox();
                Console.WriteLine("The Old King threw a box at you and dealt " + damage + " points of damage");
                break;
            case 4:
                damage = attacks.Slash();
                Console.WriteLine("The Old King slashed you with his sword and hit you for " + damage + " points of damage");
                break;
            case 5:
                damage = attacks.DeathlyAura();
                Console.WriteLine("The Old King's deathly aura deals " + damage + " points of damage");
                break;
            case 6:
                damage = attacks.SpectralSlash();
                Console.WriteLine("The Old King slashes with his spectral sword, dealing " + damage + " points of damage");
                break;
            case 7:
                damage = attacks.SoulShatter();
                Console.WriteLine("The Old King casts Soul Shatter, dealing " + damage + " points of massive damage");
                break;
            case 8:
                damage += attacks.DarkCurse();
                Console.WriteLine("The Old King casted Dark Curse on you, dealing " + damage + " points of damage");
                break;
            case 9:
                damage += attacks.BladeDance();
                Console.WriteLine("The Old King used Blade Dance and caused you to lose " + damage + " amount of damage");
                break;
            case 10:
                damage += attacks.Slice();
                Console.WriteLine("The Old King had sliced you, deaking " + damage + " amounts of damage");
                break;
        }
        return damage;
    }
}

public class NewKing : Enemy
{
    Attacks attacks = new Attacks();
    Random rng = new Random();

    public NewKing(int health, string name, int armor, int xpWorth, int goldWorth)
    : base(health, name, armor, xpWorth, goldWorth) { }

    public override int Attack()
    {
        int attackTypes = rng.Next(1, 8);
        int damageModify = rng.Next(1, 5);
        int damage = damageModify;

        switch (attackTypes)
        {
            case 1:
                damage += attacks.BladeDance(); 
                Console.WriteLine("The New King attacked you with its fiercing blade and dealt " + damage + " points of damage");
                break;
            case 2:
                damage += attacks.Slice();
                Console.WriteLine("The New King slices you with its sword and dealt " + damage + " points of damage");
                break;
            case 3:
                damage += attacks.Stab();
                Console.WriteLine("The New King stabbed you and dealt " + damage + " points of damage");
                break;
            case 4:
                damage += attacks.Charge();
                Console.WriteLine("The New King slammed its body against you and hit you for " + damage + " points of damage");
                break;
            case 5:
                damage += attacks.DeathlyAura();
                Console.WriteLine("The New King summoned death aura around him, dealing " + damage + " points of damage");
                break;
            case 6:
                damage += attacks.SoulShatter();
                Console.WriteLine("The New King Launches an attack, shattering your soul dealing " + damage + " points of damage");
                break;
            case 7:
                damage += attacks.ThrowABox();
                Console.WriteLine("The New King threw a box at you, dealing " + damage + " points of damage");
                break;
            case 8:
                damage += attacks.ExecutionersStrike();
                Console.WriteLine("The New King has swiped you with its Executioners Strike dealing " + damage + " amount of damage");
                break;
            case 9:
                damage += attacks.SpectralSlash();
                Console.WriteLine("The New King casted dark shadow on its sword, using Spectral Slash, dealing " + damage + " amount of damage");
                break;
            case 10:
                damage = attacks.NecroticWave();
                Console.WriteLine("The New King unleashes a necrotic wave, dealing " + damage + " points of damage");
                break;
            case 11:
                damage = attacks.DeathlyGaze();
                Console.WriteLine("The New King stared at your soul through your body, forcing some of your soul to exit, dealing " + damage + " points of damage");
                break;
            case 12:
                damage += attacks.DarkCurse();
                Console.WriteLine("The New King casted Dark Curse on you, dealing " + damage + " points of damage");
                break;
        }
        return damage;
    }
}
public class BasicWizard : Enemy
{
    Attacks attacks = new Attacks();
    Random rng = new Random();

    public BasicWizard(int health, string name, int armor, int xpWorth, int goldWorth)
        : base(health, name, armor, xpWorth, goldWorth) { }

    public override int Attack()
    {
        int attackTypes = rng.Next(1, 4);
        int damage = 0;

        switch (attackTypes)
        {
            case 1:
                damage = attacks.Fireball();
                Console.WriteLine("The wizard threw a fireball at you and dealt " + damage + " points of damage");
                break;
            case 2:
                damage = attacks.LightningBolt();
                Console.WriteLine("The wizard threw a lightning bolt at you and dealt " + damage + " points of damage");
                break;
            case 3:
                damage = attacks.ThrowABox();
                Console.WriteLine("The wizard threw a box at you and dealt " + damage + " points of damage");
                break;
        }
        return damage;
    }
}
public class StrongWizard : Enemy
{
    Attacks attacks = new Attacks();
    Random rng = new Random();

    public StrongWizard(int health, string name, int armor, int xpWorth, int goldWorth)
        : base(health, name, armor, xpWorth, goldWorth) { }

    public override int Attack()
    {
        int attackTypes = rng.Next(1, 7);
        int damage = 0;

        switch (attackTypes)
        {
            case 1:
                damage = attacks.Fireball();
                Console.WriteLine("The wizard threw a fireball at you and dealt " + damage + " points of damage");
                break;
            case 2:
                damage = attacks.LightningBolt();
                Console.WriteLine("The wizard threw a lightning bolt at you and dealt " + damage + " points of damage");
                break;
            case 3:
                damage = attacks.ThrowABox();
                Console.WriteLine("The wizard threw a box at you and dealt " + damage + " points of damage");
                break;
            case 4:
                damage = attacks.IceBlast();
                Console.WriteLine("The wizard cast an ice blast at you and dealt " + damage + " points of damage");
                break;
            case 5:
                damage = attacks.DarkCurse();
                Console.WriteLine("The wizard cast a dark curse on you and dealt " + damage + " points of damage");
                break;
            case 6:
                damage = attacks.ArcaneBlast();
                Console.WriteLine("The wizard unleashed an arcane blast at you and dealt " + damage + " points of damage");
                break;
        }
        return damage;
    }
}
public class Lich : Enemy
{
    Attacks attacks = new Attacks();

    Random rng = new Random();

    public Lich(int health, string name, int armor, int xpWorth, int goldWorth)
        : base(health, name, armor, xpWorth, goldWorth) { }

    public override int Attack()
    {
        int attackTypes = rng.Next(1, 11);
        int damage = 0;

        switch (attackTypes)
        {
            case 1:
                damage = attacks.Fireball();
                Console.WriteLine("The Lich threw a fireball at you and dealt " + damage + " points of damage");
                break;
            case 2:
                damage = attacks.LightningBolt();
                Console.WriteLine("The Lich threw a lightning bolt at you and dealt " + damage + " points of damage");
                break;
            case 3:
                damage = attacks.ThrowABox();
                Console.WriteLine("The Lich threw a box at you and dealt " + damage + " points of damage");
                break;
            case 4:
                damage = attacks.IceBlast();
                Console.WriteLine("The Lich cast an ice blast at you and dealt " + damage + " points of damage");
                break;
            case 5:
                damage = attacks.DarkCurse();
                Console.WriteLine("The Lich cast a dark curse on you and dealt " + damage + " points of damage");
                break;
            case 6:
                damage = attacks.ArcaneBlast();
                Console.WriteLine("The Lich unleashed an arcane blast at you and dealt " + damage + " points of damage");
                break;
            case 7:
                damage = attacks.SoulDrain();
                Console.WriteLine("The Lich casted Soul Drain, forcing your life to reduce by " + damage + " points of damage");
                break;
            case 8:
                damage = attacks.DeathlyGaze();
                Console.WriteLine("The lich stared at your soul through your body, forcing some of your soul to exit, dealing " + damage + " points of damage");
                break;
            case 9:
                damage = attacks.ShadowStrike();
                Console.WriteLine("The lich attacked you with a shadow strike and dealt " + damage + " points of damage");
                break;
            case 10:
                damage = attacks.NecroticTouch();
                Console.WriteLine("The lich touched you with necrotic energy and dealt " + damage + " points of damage");
                break;
        }
        return damage;
    }
}