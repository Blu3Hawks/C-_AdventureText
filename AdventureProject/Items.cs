using System;

public class Item
{
    private string name;
    private string description;
    private int sellValue;

    public string Name { get { return name; } }
    public string Description { get { return description; } }
    public int SellValue { get { return sellValue; } }

    public Item(string setName, string setDescription, int value)
    {
        name = setName;
        description = setDescription;
        sellValue = value;
    }
}

public class HealthPotion : Item
{
    private int minHeal;
    private int maxHeal;
    private int healAmountMod;
    public HealthPotion(string setName, string setDescription, int value, int minHealAmount, int maxHealAmount, int amountMod)
: base(setName, setDescription, value) 
    {
        minHeal = minHealAmount;
        maxHeal = maxHealAmount;
        healAmountMod = amountMod;
    }
    public int UsePotion()
    {
        Random rng = new Random();
        int healAmount = rng.Next(minHeal, maxHeal) + healAmountMod;
        return healAmount;
    }

}

public class Scroll : Item //one-time usable weapon/item
{
    private int minDamage;
    private int maxDamage;
    private int damageModify;

    public Scroll(string setName, string setDescription, int value, int minDamageAmount, int maxDamageAmount, int damageModAmount)
    : base(setName, setDescription, value)
    {
        minDamage = minDamageAmount;
        maxDamage = maxDamageAmount;
        damageModify = damageModAmount;
    }

    public int Damage()
    {
        Random rng = new Random();
        int damage = rng.Next(minDamage, maxDamage + 1);
        return damage;
    }
}

public class Weapon : Item
{
    private int minDamage;
    private int maxDamage;
    private int damageModify;
    public int MinDamageAmount { get { return minDamage; } }
    public int MaxDamageAmount { get { return maxDamage; } }

    public Weapon(string setName, string setDescription, int value, int minDamageAmount, int maxDamageAmount, int damageModAmount)
    : base(setName, setDescription, value)
    {
        minDamage = minDamageAmount;
        maxDamage = maxDamageAmount;
        damageModify = damageModAmount;
    }

    public int AttackDamage()
    {
        Random rng = new Random();
        int damage = rng.Next(minDamage, maxDamage + 1);
        return damage;
    }
}
