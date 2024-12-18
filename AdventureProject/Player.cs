using CsProject;
using System;
using System.Numerics;

public class Player
{
    //items
    public List<Item> inventory = new List<Item>();
    public int gold;
    public int keys = 0;
    //basic stats
    public int armor;
    public int health;
    public int maxHealth;
    //xp and levels
    public int xp;
    public int xpToLevelUp;
    public int level;
    public string name = "Box"; // Don't name yourself and you'll be called box.
    //combat 
    private bool dodge = false;
    public int damageModify;

    public void Battle(Enemy enemy)
    {
        if (enemy != null)
        {
            Console.WriteLine("Battle started between you and " + enemy.name);
            while (enemy.health > 0 && health > 0)
            {
                Console.WriteLine("Player's turn to attack:");
                ChooseAttack(enemy);
                Console.WriteLine("Enemy health after player's attack: " + enemy.health);

                Console.WriteLine("Enemy's turn to attack:");

                EnemyAttack(enemy);
                Console.WriteLine("Player health after enemy's attack: " + health);
            }
            if (health <= 0)
            {
                Program.Instance.YouLose();
            }
            if (enemy.health <= 0)
            {
                WinFight(enemy);
            }
        }
    }

    public void Resting(int healthRestored)
    {
        health += healthRestored;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        else if (health <= 0)
        {
            Program.Instance.YouLose();
        }
    }

    public void EnemyAttack(Enemy enemy)
    {
        int enemyDamage = enemy.Attack() - armor;
        if (enemyDamage < 0) enemyDamage = 0;
        if (dodge)
        {
            enemyDamage = 0;
            Console.WriteLine("You have dodged the attack and the enemy did not hit you!");
        }
        dodge = false;
        health -= enemyDamage;
    }
    public void WinFight(Enemy enemy)
    {
        Console.WriteLine("You won the battle !");
        AddXP(enemy.xpWorth);
        gold += enemy.goldWorth;
    }

    public void AddXP(int gainedXp)
    {
        xp += gainedXp;
        Console.WriteLine("You gained " + gainedXp + " amount of XP");
        if (xp > xpToLevelUp)
        {
            level++;
            Console.WriteLine("You have leveled up !");
            xp -= xpToLevelUp;
            xpToLevelUp += 30;
            if (xp < 0)
            {
                xp = 0;
            }
            LevelUp();
        }
    }
    public void ViewStats()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Level: " + level);
        Console.WriteLine("Current health: " + health + " Max health: " + maxHealth);
        Console.WriteLine("XP: " + xp);
        Console.WriteLine("XP needed to level up: " + xpToLevelUp);
        Console.WriteLine("Your current armor: " + armor + " Note that every armor score is a damage reduction");
        Console.WriteLine("Your current damage modify: " + damageModify);
        Console.WriteLine("Gold: " + gold);
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        if (item.Name == "Sharpening tool")
        {
            damageModify++;
        }
        if (item.Name == "Advanced Sharpening Tool")
        {
            damageModify += 3;
        }
        if (item.Name == "Protective Amulet")
        {
            armor += 5;
        }
        if (item.Name == "Magical Ring")
        {
            damageModify += 3;
        }
        if (item.Name == "Amulet of Aegis")
        {
            armor += 5;
        }
    }

    public void SellItem(Player player, Item item, Shop shop)
    {
        player.gold += item.SellValue;
        shop.itemsInShop.Add(item);
        player.inventory.Remove(item);
    }
    public void RemoveItem(string givenItemName)
    {
        Item itemToRemove = null;
        foreach (Item item in inventory)
        {
            if (item.Name.Equals(givenItemName, StringComparison.OrdinalIgnoreCase))
            {
                itemToRemove = item;
                break;
            }
        }

        if (itemToRemove != null)
        {
            inventory.Remove(itemToRemove);
            if (itemToRemove.Name == "Sharpening tool")
            {
                damageModify--;
            }
            if (itemToRemove.Name == "Advanced Sharpening Tool")
            {
                damageModify -= 3;
            }
            if (itemToRemove.Name == "Protective Amulet")
            {
                armor -= 5;
            }
            if (itemToRemove.Name == "Magical Ring")
            {
                damageModify -= 3;
            }
            if (itemToRemove.Name == "Amulet of Aegis")
            {
                armor -= 5;
            }
            Console.WriteLine(givenItemName + " has been removed from your inventory.");
        }
        else
        {
            Console.WriteLine("We don't have this item on the list");
        }
    }

    public bool CheckForItem(string givenItemName)
    {
        foreach (Item item in inventory)
        {
            if (item.Name == givenItemName)
            {
                return true;
            }
        }
        return false;
    }

    public void DisplayItems()
    {
        foreach (Item item in inventory)
        {
            Console.WriteLine(item.Name + ", " + item.Description + " and can be sold at: " + item.SellValue + " gold pieces");
        }
    }

    public static void Attack(Enemy enemy, Weapon weapon)
    {
        int damage = weapon.AttackDamage();
        enemy.health -= damage;
        Console.WriteLine("You attacked " + enemy.name + " with " + weapon.Name + " dealing " + damage + " damage.");
        if (enemy.health <= 0)
        {
            Console.WriteLine("You have defeated the " + enemy.name + " !");
        }
    }

    public void UseScroll(Enemy enemy, Scroll scroll)
    {
        int damage = scroll.Damage();
        enemy.health -= damage;
        Console.WriteLine("You attacked " + enemy.name + " with " + scroll.Name + " dealing " + damage + " damage.");
        if (enemy.health <= 0)
        {
            Console.WriteLine("You have defeated the " + enemy.name + " !");
        }
        inventory.Remove(scroll);
    }
    public void ChoosePotion()
    {
        List<Choice> choices = new List<Choice>();
        while (true)
        {
            foreach (HealthPotion potion in inventory.OfType<HealthPotion>())
            {
                choices.Add(new Choice("Use: " + potion.Name, () => UsePotion(potion)));
            }
            if (choices.Count == 0)
            {
                Console.WriteLine("You don't have any potions to use at the momnent.");
            }
            choices.Add(new Choice("Return", () => { }));
            Program.Instance.SelectOptions(choices);
            break;
        }
    }
    public void UsePotion(HealthPotion potion)
    {
        int healingAmount = potion.UsePotion();
        health += healingAmount;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        Console.WriteLine("You used " + potion.Name + " healing yourself for " + healingAmount);
        inventory.Remove(potion);
    }

    private void Dodging()
    {
        dodge = true;
    }
    public void ChooseAttack(Enemy enemy)
    {
        if (enemy != null)
        {
            List<Choice> choices = new List<Choice>();

            foreach (Weapon weapon in inventory.OfType<Weapon>())
            {
                choices.Add(new Choice("Attack with " + weapon.Name, () => Attack(enemy, weapon)));
            }
            foreach (Scroll scroll in inventory.OfType<Scroll>())
            {
                choices.Add(new Choice("Use: " + scroll.Name, () => UseScroll(enemy, scroll)));
            }
            foreach (HealthPotion potion in inventory.OfType<HealthPotion>())
            {
                choices.Add(new Choice("Use: " + potion.Name, () => UsePotion(potion)));
            }
            choices.Add(new Choice("Dodge ", Dodging));
            Program.Instance.SelectOptions(choices);
        }
    }

    //leveling up attributes
    public void LevelUp()
    {
        Console.WriteLine("You have leveled up ! What benefit would you like to aquire?");
        List<Choice> choices = new List<Choice>()
        {
            new Choice("Add max and current health by 3", LevelUpIncreaseHealth),
            new Choice("Increase your overall damage by 1", LevelUpIncreaseDamage),
            new Choice("Improve your armor by 1", LevelUpIncreaseArmor)
        };
        Program.Instance.SelectOptions(choices);
    }

    private void LevelUpIncreaseArmor()
    {
        armor++;
    }
    private void LevelUpIncreaseDamage()
    {
        damageModify++;
    }
    private void LevelUpIncreaseHealth()
    {
        maxHealth += 4;
        health += 4;
    }
}