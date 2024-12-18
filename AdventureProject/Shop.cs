using CsProject;
using System;

public class Shop
{
    public List<Item> itemsInShop = new List<Item>();

    public void EnteringShop(Player player, string description, Action method) //the method will be the returning point of the player to exit the shop
    {
        Console.WriteLine(description);
        Console.WriteLine("The shop owner greets you, 'I used to be an adventurer like you, but then I got an error in my knee."); //a direct reference and easter egg to skyrim
        //when you were about to visit past-adventurers or some locals, this is the line they were making. It became a huge meme back then, supposed to be arrow but it's error cuz its code
        Console.WriteLine("How can I help you today?' he asks");
        DisplayItems(player, method);
        method();
    }
    public void DisplayItems(Player player, Action method)
    {
        Console.WriteLine("You currently have: " + player.gold + " amount of gold.");
        List<Choice> choices = new List<Choice>()
        {
            new Choice("Would you like to buy anything?",() => DisplayItemsToBuy(player, method)),
            new Choice("Would you like to sell anything?",() => DisplayItemsToSell(player, method))
        };
        choices.Add(new Choice("Exit the shop", () => method()));
        Program.Instance.SelectOptions(choices);
    }
    public void DisplayItemsToSell(Player player, Action method)
    {
        List<Choice> choices = new List<Choice>();
        Console.WriteLine("You currently have: " + player.gold + " amount of gold.");

        foreach (var item in player.inventory)
        {
            choices.Add(new Choice(item.Name + ", " + item.Description + ", valued at: " + item.SellValue, () =>
            {
                player.SellItem(player, item, this);
                DisplayItemsToSell(player, method);
            }));
        }
        choices.Add(new Choice("Go back", () => DisplayItems(player, method)));
        Program.Instance.SelectOptions(choices);
    }
    public void DisplayItemsToBuy(Player player, Action method)
    {
        List<Choice> choices = new List<Choice>();
        Console.WriteLine("You currently have: " + player.gold + " amount of gold.");
        foreach (var item in itemsInShop)
        {
            choices.Add(new Choice(item.Name + ", " + item.Description + ", valued at: " + item.SellValue, () =>
            {
                PurchaseItem(player, item);
                DisplayItemsToBuy(player, method);
            }));
        }
        int armorCost = player.armor * 20;
        choices.Add(new Choice("Upgrade your armor for: " + armorCost, () =>
        {
            UpgradeArmor(player);
            DisplayItemsToBuy(player, method);
        }));
        choices.Add(new Choice("Go back", () => DisplayItems(player, method))); //change the method that is being delivered here.
        Program.Instance.SelectOptions(choices);
    }
    public void UpgradeArmor(Player player)
    {
        int cost = player.armor * 20;
        if (player.gold > cost)
        {
            //will upgrade the armor
            player.armor++;
            player.gold -= cost;
        }
        else
        {
            Console.WriteLine("You don't have enough gold to upgrade your armor");
        }
    }
    public void PurchaseItem(Player player, Item item)
    {
        if (player.gold > item.SellValue)
        {
            player.gold -= item.SellValue;
            player.AddItem(item);
            itemsInShop.Remove(item);
        }
        else
        {
            Console.WriteLine("You don't have enough gold to buy this!");
        }
    }
    //shop 1 will have basic items
    //shop 2 will have more advances
    //shop 3 will have unique items
    //shop 4 will be diverse
    //shop 5 will have legenedary items
}
