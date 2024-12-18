using System.Collections.Generic;
using System.Text;

namespace CsProject
{
    class Program
    {
        private static Program instance;
        private Program() { }
        // in order to not repeat some methods and stuff
        //Smot place - 
        public bool visitedThePub = false;

        //Mice 
        bool exploreAlleys = false;
        bool talkedToGuard = false;
        bool firstEnteredStreets = false;
        bool exploreBuilding = false;

        //Spec
        bool visitedSpecInn = false;

        //Dirhal - end games
        bool fightLich = false;
        bool fightOldKing = false;
        bool fightNewKing = false;

        public static Program Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Program();
                }
                return instance;
            }
        }

        Player player = new Player();
        static void Main(string[] args)
        {
            Program program = Program.Instance;
            Console.WriteLine("Hello, and welcome.. to The Resurrected Reign adventure - an RPG text base, by Hen Sayag");
            program.Start();
        }

        private void Start()
        {
            SettingPlayer();
            CreateStartingItems();
            StoryIntroduction();
            PressAnyKeyToContinue();
            StoryTelling();
            PressAnyKeyToContinue();
            FirstDecision();
            PressAnyKeyToContinue();
            FirstAction();
        }

        private void StoryIntroduction()
        {
            TextUtils.PrintWithDelay("In the distant city of Smot, where medieval life meets ancient technology, ");
            TextUtils.PrintWithDelay("the land of Eskila faces a dark threat.");
            TextUtils.PrintWithDelay("Years ago, King Faith ruled with wisdom and justice,");
            TextUtils.PrintWithDelay("but his reign ended when his son, Graith, betrayed and murdered him to take over the throne.");
            TextUtils.PrintWithDelay("Now, Eskila suffers under Graith’s cruel rule and poor judgements, ");
            TextUtils.PrintWithDelay("leading the lands faith's into darkness.");
            Console.WriteLine();
            TextUtils.PrintWithDelay("Roswald, the late king’s former advisor, has discovered the forbidden art of necromancy. ");
            TextUtils.PrintWithDelay("His obsession has led him to attempt the resurrection of King Faith, ");
            TextUtils.PrintWithDelay("but twisted by dark magic, this resurrection threatens to unleash a vengeful force upon the world.");
            TextUtils.PrintWithDelay("You, a mysterious warrior, from Smot, set your adventure just as the ritual is nearing completion");
            TextUtils.PrintWithDelay("The choices you make will shape the future of Eskila. ");
            TextUtils.PrintWithDelay("Will you stop Roswald and prevent the rebirth of a wrathful king? ");
            TextUtils.PrintWithDelay("Will you join forces with the undead to overthrow Graith? ");
            TextUtils.PrintWithDelay("Or will you carve out your own path, seizing power for yourself? ");
            TextUtils.PrintWithDelay("The fate of the land lies in your hands.");
            Console.WriteLine();
        }
        private void CreateStartingItems()
        {
            Weapon basicSword = new Weapon("Basic Sword", "A metal sword, that deals 1D6 damage.", 10, 1, 6, 0);
            player.AddItem(basicSword);
            Item waterBottle = new Item("Water Bottle", "Standard water bottle, contains 3 liters of water. Rehydrate!", 5);
            player.AddItem(waterBottle);
            player.inventory.Add(new HealthPotion("Basic Health Potion", " will heal you for 2D6 health points", 30, 2, 12, 0));
            TextUtils.PrintWithDelay("");
        }
        private void SettingPlayer()
        {
            SetPlayerName();
            player.xp = 0;
            player.xpToLevelUp = 100;

            player.maxHealth = 30;
            player.health = player.maxHealth;

            player.gold = 100;
            player.level = 1;

            player.armor = 0;
            player.damageModify = 0;


            //if restarting
            visitedThePub = false;

            //Mice 
            exploreAlleys = false;
            talkedToGuard = false;
            firstEnteredStreets = false;
            exploreBuilding = false;

            //Spec
            visitedSpecInn = false;

            //Dirhal - end games
            fightLich = false;
            fightOldKing = false;
            fightNewKing = false;
        }
        public static void FirstDecision() //story-telling
        {
            TextUtils.PrintWithDelay("As you wander through the streets of Smot. The busy streets are hovering around your ears, ");
            TextUtils.PrintWithDelay("noises and good smells guided by lots of people in the busy city.");
            TextUtils.PrintWithDelay("As you are being guided by yourself through the city, you are walking yourself ");
            TextUtils.PrintWithDelay("in the merchants of the locals. The goods are clinking,");
            TextUtils.PrintWithDelay("and the lively city seems to have another day of business. ");
            TextUtils.PrintWithDelay("The bricks on the road are designed in beautiful marble color and the buildings are looking up ahead of you.");
            TextUtils.PrintWithDelay("The wind shifts away, and you focus on your mission that you have taken ");
            TextUtils.PrintWithDelay("upon yourself from your elders - you are yet to save this land from pure chaos,");
            TextUtils.PrintWithDelay("preventing it from becoming a lost land just like the ");
            TextUtils.PrintWithDelay("tales told you in your childhood about the lands over the seas.");
            TextUtils.PrintWithDelay("You are now standing in a path, which might seem clear -");
            TextUtils.PrintWithDelay("but where would you choose to navigate? Who's side would you take? Only time will tell...");
            TextUtils.PrintWithDelay("As for now, you see the area surrounding you. There's plenty of boxes ");
            TextUtils.PrintWithDelay("and crates coming in. Of course it is - it is a supply day.");
            TextUtils.PrintWithDelay("Not happening all too often, in this far-out city. In this city, ");
            TextUtils.PrintWithDelay("you after exploring it yet again for a while, knowing it since you were young, you can get in your way.");
            TextUtils.PrintWithDelay("Which direction would you go? You can exit the city, go to the ");
            TextUtils.PrintWithDelay("local blacksmith to purchase goods or to the pub - maybe get some information.");
        }

        private void FirstAction() //take first action in the city ! // CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("As you wander through the streets of Smot, you encounter various sights and sounds.");
            List<Choice> choices = new List<Choice>
            {
                new Choice("Exit the city", ExitCitySmot),
                new Choice("Go to the local blacksmith", SmotVisitBlacksmith),
            };
            if (!visitedThePub)
            {
                choices.Add(new Choice("Go to the pub", GoToPub));
            }
            SelectOptions(choices);
        }

        private void ExitSmotPathDecision()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("With a map within your hands, you see where each path will lead you to. ");
            TextUtils.PrintWithDelay("It seems endless, the options to explore right now in front of your eyes.");
            TextUtils.PrintWithDelay("The view is a breathtaking one, you always dreamt of wandering in this land - but never did.");
            List<Choice> choices = new List<Choice>
            {
                new Choice("Wander towards NarooLake", ExitSmot1ToNarooLake),
                new Choice("Path towards Or-Sor", ExitSmot2ToOrSor),
                new Choice("Exit towards Mice throught the hills", ExitSmot3NorthToMice),
                new Choice("Walk towards the deserts", ExitSmot4ToDesert)
            };
            SelectOptions(choices);
        }

        private void ExitSmot1ToNarooLake() // go to Narro Lake north-west of you// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You are walking towards the lake, and after a while you reach it.");
            TextUtils.PrintWithDelay("A bit, endless lake is being seen by your eyes. While it is relaxing to watch, what now?");
            TextUtils.PrintWithDelay("You decide it's nothing worth to spend too much time over - and have to get to your mission");
            TextUtils.PrintWithDelay("Without any further a due, you keep going up north alongside the lake.");
            PressAnyKeyToContinue();
            ExitSmot3NorthToMice();
        }

        private void ExitSmot2ToOrSor() // go to "Or-Sor" south-east of you// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You are pathing your way towards Or-Sor, a bit far-awayed village. You walk down the path guided, feeling self confidence");
            TextUtils.PrintWithDelay("and pure excitement runs through your blood. You walk a bit fast at first, but then allows yourself to chill out from");
            TextUtils.PrintWithDelay("the fast pace. After a while, in the hills, you find out that the ");
            TextUtils.PrintWithDelay("village is way too far away up ahead, but it's alright for now");
            TextUtils.PrintWithDelay("You spend another hour to walk the direction, but then a random figure comes in your way. ");
            TextUtils.PrintWithDelay("As he gets closer to you, you understand");
            TextUtils.PrintWithDelay("the view - an adult, seems to be in his 50's, tries to run. But... Is he bleeding?");
            TextUtils.PrintWithDelay("He shouts to you, asking for your help. Would you help him out?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Help the man", PathToOrSorHelpTheMan),
                new Choice("Attack the man", PathToOrSorKillTheMan)
            };
            SelectOptions(choices);
        }
        private void PathToOrSorHelpTheMan() // ADDED TO DRAW
        {
            TextUtils.PrintWithDelay("As the man gets closer, you draw yourself in a combat-ready, getting your sword out.");
            TextUtils.PrintWithDelay("'Hold up!' says the man, 'Wait sir! Please! And don't get too close to me!' he says, coughing");
            TextUtils.PrintWithDelay("'I am sick, but you can help me survive, only if you can do such a thing. Please good sir !'");
            TextUtils.PrintWithDelay("He asks for holy water, if you have such in your backpack. Do you have it?");
            List<Choice> choices = new List<Choice>()
            {
               new Choice("Say you don't have it, and that you are sorry.",PathToOrSorDoNotHelpTheMan),
               new Choice("Ignore the man and keep going to Or-Sor", PathToOrSorPart2)
            };
            if (player.CheckForItem("Holy Water"))
            {
                new Choice("Say you have one in your backpack, and hand it over", PathToOrSorHandHolyWaterToTheMan);
            }
            SelectOptions(choices);
        }
        private void PathToOrSorDoNotHelpTheMan() // CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The man, in despair and sour, shows his agony through a depressed face.");
            TextUtils.PrintWithDelay("'Ah, it's going to be my last day today', he screams to the sky. 'Perhaps, is there some sort of a medic?");
            TextUtils.PrintWithDelay("'A merchant even, that might have something to heal me?' He looks at you, sad and exhausted, asking for 40 gold");
            TextUtils.PrintWithDelay("that might help him to survive. Would you pay him that much?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Ignore his ask for help, and go to your way",PathToOrSorDontPayTheMan)
            };
            if (player.gold >= 40)
            {
                choices.Add(new Choice("Pay the man for a chance to find a cure", PathToOrSorPayTheMan));
            }
            else
            {
                TextUtils.PrintWithDelay("It seems you don't have enough money to give him");
            }
            SelectOptions(choices);
        }
        private void PathToOrSorPayTheMan() //CHECKED IN DRAW
        {
            player.gold -= 40;
            TextUtils.PrintWithDelay("You are paying him the gold he's asking for");
            TextUtils.PrintWithDelay("'Thank you so much kind soul! Here, I hope this will help you ahead !' he says, handing you something");
            TextUtils.PrintWithDelay("You look, and you see he leaves on the ground some keys and a weapon. 'This might not be much' he says");
            TextUtils.PrintWithDelay("'But that's what I have' he leaves it on the ground because of his disease - so you won't get in touch with him");
            player.keys += 2;
            Weapon dualSword = new Weapon("Dual Sword", " A dual sword, with two edges, that will deal 1D8 + 3 damage", 60, 1, 8, 3);
            player.inventory.Add(dualSword);
            player.AddXP(60);
            TextUtils.PrintWithDelay("After obtaining the gifts, he says: 'While, I know your path is towards Or-Sor - but I would advise you, and even");
            TextUtils.PrintWithDelay("push you back on your steps - Go this path and you shall die in a disease, just like almost happened to me.");
            TextUtils.PrintWithDelay("It's already doomed over there, and perhaps nothing left there at all. It's all chaos. If you want to stay");
            TextUtils.PrintWithDelay("alive, get back on your steps, head north to Mice and it will be fine. Farewell, stranger' says the man,");
            TextUtils.PrintWithDelay("pathing ways from you. You take some rest and head to the hills, north of the city, towards Mice");
            player.Resting(5);
            WalkingTheHillsToMice();
        }
        private void PathToOrSorDontPayTheMan() //CHECKED IN DRAW 
        {
            TextUtils.PrintWithDelay("You can see his face, the sadness and the soul of the man, almost fades out of his body.");
            TextUtils.PrintWithDelay("'Is this how I am going to end this life? It's wrong...' he mumbles to himself");
            TextUtils.PrintWithDelay("'Maybe if I keep going I will find some gold.. There has to be fate...' he says, walking up there.");
            TextUtils.PrintWithDelay("'Don't go there. It's too depressing, it's too far out, this mad world...' he keeps mumbling to himself");
            TextUtils.PrintWithDelay("It seems he has lost hope, and does not want you to go there. Would you listen to him, or go against his words?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Ignore the man's advise and go to Or-Sor", PathToOrSorPart2),
                new Choice("Listen to his call and go to Mice instead", WalkingTheHillsToMice)
            };
            SelectOptions(choices);
        }

        private void PathToOrSorPart2() // CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You take yourself to Or-Sor, keeping the pace. It's not so close, you think to yourself.");
            TextUtils.PrintWithDelay("As the afternoon hours comes closer, you see something - It is a path. A black path, shrouded and coated");
            TextUtils.PrintWithDelay("by dark bolts floating around it. It's dark magic - not much to know about it. It seems it's running fast");
            TextUtils.PrintWithDelay("towards you, no escape. As you try to move, you freeze - you have stepped way too far...");
            TextUtils.PrintWithDelay("It doesn't seem to have much to do - you try to fight but it's against your will, and too strong");
            TextUtils.PrintWithDelay("Slowly but surely, the fogs wrapping themselves around you, and what feels for eternity, you freeze");
            TextUtils.PrintWithDelay("Your adventure seems long from complete, and here you are... Freezing in the cold. Soon enough those winds");
            TextUtils.PrintWithDelay("will take your soul away, and leave your body to be still");
            YouLose();

        }
        private void PathToOrSorHandHolyWaterToTheMan() // CHECKED IN DRAW
        {
            player.RemoveItem("Holy Water");
            TextUtils.PrintWithDelay("'Thank you! Thank you so much!' says the man, drinking the water. As he does, you slowly see his wounds disappear");
            TextUtils.PrintWithDelay("and the disease fades away from him. After a while, he grants you a gift");
            TextUtils.PrintWithDelay("'It's not much, but this is what I can give you for your kindness' he says");
            player.armor += 2;
            TextUtils.PrintWithDelay("He grants you his only gift - a blessing, which will protect you furthermore in your adventures and adding your armor");
            TextUtils.PrintWithDelay("by 2. Check your stats if you'd like");
            TextUtils.PrintWithDelay("The man guides you back to the city, and telling you it is not safe up ahead and it's better to go the other direction");
            TextUtils.PrintWithDelay("You decide to listen to him and instead of it go up north to Mice - one of the options you had before");
            player.AddXP(60);
            ExitSmot3NorthToMice();
        }

        private void PathToOrSorKillTheMan() //CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to attack the man ! While screaming for help, you slay him, leaving him to have no chance to survive");
            TextUtils.PrintWithDelay("After killing him, you discover it - he was having a disease, a chickenpox!");
            TextUtils.PrintWithDelay("While being on its latest stages, and super strong, you start to cough up, ");
            TextUtils.PrintWithDelay("leaving you up to no chance. It is only matter of time");
            TextUtils.PrintWithDelay("until you will die out of it...");
            YouLose();
        }
        private void ExitSmot3NorthToMice() //Go to Mice through the hills up north// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You are starting off with walking towards the north exit. You leave the city behind you, and with one last glance");
            TextUtils.PrintWithDelay("you farewell a last goodbye. For now at least, you ask yourself ");
            TextUtils.PrintWithDelay("whether or not will you see this place you called home yet again");
            TextUtils.PrintWithDelay("With courage on your back, and faith guides your shoulders, you step forward, towards the hills that may look endless");
            TextUtils.PrintWithDelay("You venture fourth, and begin your walk. It seems so beautiful, you think to yourself. The greens, the wild, the amount of");
            TextUtils.PrintWithDelay("freedom you feel there is and the exploring potential is endless");
            TextUtils.PrintWithDelay("You walk for a while, up and down in the hills. It looks quite relaxing, all these views.");
            PressAnyKeyToContinue();
            WalkingTheHillsToMice();
        }

        private void WalkingTheHillsToMice()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("A scream breaks the silence - crows are flying up in the air, and some trees are moving with the air pushes them briefly.");
            TextUtils.PrintWithDelay("The scream sounds very wild-like as if somebody is fighting for his life.");
            TextUtils.PrintWithDelay("The sounds are coming from the west - towards the lake, not so far away from you.");
            TextUtils.PrintWithDelay("What would you like to do? The situation is quite umpacable and you are not sure whether ot not to go there.");
            TextUtils.PrintWithDelay("It could also be a trap - you might never know. Only way is to find out.");
            TextUtils.PrintWithDelay("It seems you are in a dilemma - you could very likely go around and see if you can help...");
            TextUtils.PrintWithDelay("But at the same time you could keep going and leave it to be.");
            PressAnyKeyToContinue();
            List<Choice> choices = new List<Choice>
            {
                new Choice("Leave the screams to be and keep going", LeaveScreamingAndGoToMice),
                new Choice("Go and explore the source of the screamings", ScreamingInHillsToMice)
            };
            SelectOptions(choices);
        }

        private void LeaveScreamingAndGoToMice() // CHECKED IN DRAW - need to add logic
        {
            HillsToMicePart2();
        }
        private void ScreamingInHillsToMice()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You take your path, quickly into the screaming scene. It seems there's not a lot of options other than help, is it?");
            TextUtils.PrintWithDelay("You get there as you pass the last hill. The screams are heard on a higher pitch, as you get closer to them");
            TextUtils.PrintWithDelay("And there, you spot it - a mere misconception, it seems.");
            TextUtils.PrintWithDelay("The scream is nothing but a... frog?");
            PressAnyKeyToContinue();
            ScreamingInHillsToMiceStory();
        }

        private void ScreamingInHillsToMiceStory()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("It seems the frog is the main issue here.. His screams are just like an adult. But why is that? You wonder");
            TextUtils.PrintWithDelay("You get closer to it and as you are next to it you then hear a tree collapses. Not too far away from you");
            TextUtils.PrintWithDelay("there is a tree falling over - by none other than a human-figured looking creature. It looks like a human,");
            TextUtils.PrintWithDelay("but a very disgusted one - ugly faced filled with green, it looks just like an abomination.");
            TextUtils.PrintWithDelay("It sees you with a smile behind the rob it wears, and it seems you activated a trap somehow.");
            TextUtils.PrintWithDelay("The figure doesn't look very harmful.. for now. It starts to walk towards you, and it looks as if it is whispering something");
            TextUtils.PrintWithDelay("'My... Flesh...Starve...' it sort of mumbling as you get closer to it.");
            PressAnyKeyToContinue();
            HillsToMiceCombat();
        }

        private void HillsToMiceCombat()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("Without you even knowing, the fellow creature has already gotten very close to you!");
            TextUtils.PrintWithDelay("With a staff in his hand it looks like he is capable of spells, and it looks quite driven to kill");
            TextUtils.PrintWithDelay("Would you fight it? Or rather try to run away?");
            BasicWizard wizard = new BasicWizard(6, "mutant", 1, 55, 10);
            List<Choice> choices = new List<Choice>
            {
                new Choice("Fight the abominated figure", () => FightInHillsToMice(wizard)),
                new Choice("Try to run and escape", EscapeInHillsToMice)
            };
            SelectOptions(choices);
        }

        private void FightInHillsToMice(Enemy enemy)// CHECKED IN DRAW
        {
            player.Battle(enemy);
            TextUtils.PrintWithDelay("After slaying off the monster, you are resetting your breathe, resting for a while");
            TextUtils.PrintWithDelay("As you sit down and eat, you recover yourself and first-aid yourself, treating yourself");
            player.Resting(5);
            TextUtils.PrintWithDelay("Your current health status is at: " + player.health.ToString() + " amount of health");
            HillsToMicePart2();
        }

        private void EscapeInHillsToMice()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You are taking off and start to run off. As you run, you get some distance. As you flee,");
            TextUtils.PrintWithDelay("You take a look back from time to time, making sure you have passed long ago the creature");
            TextUtils.PrintWithDelay("Taking rest after a while you've been running for, you check out your items as you rest");
            TextUtils.PrintWithDelay("You sense a there's a lightiness on your back and as you open up your backpack you see it");
            TextUtils.PrintWithDelay("There has been a hole in your pocket and as you count the money, you see there's been missing some!");
            player.gold -= 20;
            if (player.gold < 0)
            {
                player.gold = 0;
            }
            TextUtils.PrintWithDelay("Your current gold amount is: " + player.gold.ToString());
            PressAnyKeyToContinue();
            HillsToMicePart2();
        }

        private void HillsToMicePart2()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("After you have been walking for a while, you come across a small building. The building");
            TextUtils.PrintWithDelay("looks as if it was abandoned long and long ago, no sense for any livings in the house");
            TextUtils.PrintWithDelay("It seems the house was some sort of a big house - about two floors, big place with plenty of space in it");
            TextUtils.PrintWithDelay("");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Look inside the ruined house", LookInsideRuinedHouseHillsToMice),
                new Choice("Scout the area", ScoutTheRuinedHouseHillsToMice),
                new Choice("Ignore the house and keep going", PostHouseHillsToMice)
            };
            SelectOptions(choices);
        }


        private void LookInsideRuinedHouseHillsToMice() // going inside the house// CHECKED IN DRAW - need to add more logic
        {
            TextUtils.PrintWithDelay("You open up the door, made out of wood that is somehow is still");
            TextUtils.PrintWithDelay("attached to the door. There is a heavy sound on the door and a full big room is opened to your eyes");
            TextUtils.PrintWithDelay("As you get inside the dust gets into your lungs - you feel the heaviness of the place, making you cough");
            TextUtils.PrintWithDelay("The door then shuts right behind you as you cough one too many times, walking accidentaly on a brick. A trap!");
            TextUtils.PrintWithDelay("The cough makes you a bit less durable, forcing you to lose some health.");
            TextUtils.PrintWithDelay("As you keep coughing - you see there are two skeletons that have been rising up. It's not as abandoned as you thought!");
            FightSkeletonsInHouseHillsToMice();
            TextUtils.PrintWithDelay("Their summonings could have given some more ideas on what's happening with the old king.");
            TextUtils.PrintWithDelay("While recovering, you sense a bad aura fades away. It seems the necromancy that happened here");
            TextUtils.PrintWithDelay("did not just happen by a mere magic. It seems there's been a ritual. But you are not too knowledgable about that");
            TextUtils.PrintWithDelay("While exploring a bit the rest of the house, you encounter some gold, a new sword and a key");
            TextUtils.PrintWithDelay("While recovering and healing up a bit, you also find a health potion.");
            player.inventory.Add(new HealthPotion("Health Potion", " A healing potion that will heal you for 12 health points", 20, 12, 12, 0));
            player.inventory.Add(new Weapon("Big Bronze Sword", "A big sword, made of bronze, will deal 1D10 + 1 damage", 40, 1, 10, 1));
            player.gold += 30;
            player.keys++;
            PressAnyKeyToContinue();
            PostHouseHillsToMice();
        }

        private void FightSkeletonsInHouseHillsToMice()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You find yourself in a tight battle - you need to battle the two skeletons that have been risen in front of you");
            BasicHumanoid skeleton1 = new BasicHumanoid(12, "Dummy Skeleton", 0, 50, 20);
            player.Battle(skeleton1);
            TextUtils.PrintWithDelay("You have defeated one skeleton ! But need to fight the second one");
            BasicHumanoid skeleton2 = new BasicHumanoid(9, "Even Dummier Skeleton", 1, 55, 20);
            player.Battle(skeleton2);
            PressAnyKeyToContinue();
            TextUtils.PrintWithDelay("You have defeated the evil skeletons. You wonder on how or why they were here even at the first place...");
            PostHouseHillsToMice();
        }

        private void ScoutTheRuinedHouseHillsToMice() // scouting the house// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("While scouting the house from the outside, you sense there is something hidden. A bit of circling and you find");
            TextUtils.PrintWithDelay("there is indeed a hidden door leading downstairs. You go down, opening the cracked wooden door and getting down");
            TextUtils.PrintWithDelay("the ladder. As you walk in the somewhat dark area, you can see there is not much inside. You see another door, going");
            TextUtils.PrintWithDelay("up, and as you get to it you hear a cranky noise. You are not sure of its origin or what happened, but while you wait");
            TextUtils.PrintWithDelay("nothing really happens. You decide to have another look just to be sure, and explore a bit more.");
            TextUtils.PrintWithDelay("The exploration helps you find quite a few things - some gold, some keys, a new weapon and a note");
            player.keys += 2;
            player.gold += 35;
            player.inventory.Add(new Weapon("Mythic Sword", "A mythical sword, made out of glyphs and hard-harvested iron, will deal 2D6 + 2 damage", 100, 2, 12, 2));
            player.inventory.Add(new Item("Note1", "'The reviving spell contains secrets. As you might have been thinking of it, it might just appear. " +
                "While from another world, there is a direct connection to here", 10));
            TextUtils.PrintWithDelay("It looks like a beginning of a scroll, but you are not quite sure what more there is into it");
            PressAnyKeyToContinue();
            TextUtils.PrintWithDelay("You exit the small shelter, going up from the hidden room you found. You see some bones and skeleton left overs");
            TextUtils.PrintWithDelay("but not sure what are those. You carefully get out of their way and keep going. You then see it - there has been a trap !");
            TextUtils.PrintWithDelay("Luckily for you, you don't have to encounter them or fight them, although you can search them after...");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Alert and fight the skeletons", FightSkeletonsInHouseHillsToMice),
                new Choice("Leave the house and keep going", PostHouseHillsToMice)
            };
            SelectOptions(choices);
        }

        private void ExitSmot4ToDesert()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("As you wonder through, you reach out to the sands quickly. It seems there's plenty of heat in these summer days");
            TextUtils.PrintWithDelay("and you are not sure how prepared you are into this kind of quest between the dry sands with your feet only.");
            TextUtils.PrintWithDelay("You keep progress but thirst attacks you hard, and it will be better to rehydrate. Do you have water in your backpack?");
            PressAnyKeyToContinue();
            if (player.CheckForItem("Water Bottle"))
            {
                TextUtils.PrintWithDelay("You have got a water bottle and using it to rehydrate.");
                TextUtils.PrintWithDelay("Using item: water bottle");
                player.RemoveItem("Water Bottle");
                WalkingInDesert1();
            }
            else
            {
                YouLose();
            }
        }

        private void WalkingInDesert1()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You are hydrating yourself and keep walking. After long two days it seems ");
            TextUtils.PrintWithDelay("there's no where to keep going and you feel as if you were");
            TextUtils.PrintWithDelay("circling your own self. You can still track back your steps and get to the city, ");
            TextUtils.PrintWithDelay("or walk down the desert in hope of finding something");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Get back to the city", ExitSmotPathDecision),
                new Choice("Keep walking the desert", WalkFurtherToTheDesert)
            };
            SelectOptions(choices);
        }

        private void WalkFurtherToTheDesert()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You keep walking the desert, feeling thirty. You survive for one more day - but the heat overtakes you.");
            TextUtils.PrintWithDelay("You lose control over your body, and fall. Your sighseeing gazes away, and blurs out.");
            YouLose();
        }

        public void YouLose()
        {
            TextUtils.PrintWithDelay("Unfortunately, you were not succesful on your mission and have vanished away from this world");
            TextUtils.PrintWithDelay("Would you dare to try again?");
            List<Choice> choices = new List<Choice>
            {
                new Choice("Restart the game", RestartGame),
                new Choice("Quit the game", QuitGame)
            };
            SelectOptions(choices);
        }

        private static void QuitGame()
        {
            TextUtils.PrintWithDelay("Thank you for playing!");
            Environment.Exit(0);
        }

        private void RestartGame()
        {
            TextUtils.PrintWithDelay("Restarting the game...");
            PressAnyKeyToContinue();
            Console.Clear();

            ResetGameState();
            instance = null;

            instance = Program.Instance;
            instance.Start();
        }
        private void ResetGameState()
        {
            SettingPlayer();
            visitedThePub = false;
            exploreAlleys = false;
            talkedToGuard = false;
            firstEnteredStreets = false;
            exploreBuilding = false;
            visitedSpecInn = false;
            fightLich = false;
            fightOldKing = false;
            fightNewKing = false;
        }

        private void ExitCitySmot()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You exit the city and venture into the wild.");
            TextUtils.PrintWithDelay("As you are exiting the gates, you see the wild setting across in front of you. ");
            PressAnyKeyToContinue();
            ExitSmotPathDecision();
        }

        private void SmotVisitBlacksmith() //CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You visit the blacksmith. The smells of metal enchancing on each other, the forge spits its magma over the floor");
            TextUtils.PrintWithDelay("The blacksmith stops and looking at you, giving a sall nod and smiles.");
            TextUtils.PrintWithDelay("'How can I help you my friend?' he asks.");
            TextUtils.PrintWithDelay("'Oh ! If it's not " + player.name + "! How can I help you?");
            Shop blackSmith = new Shop();
            blackSmith.itemsInShop.Add(new Weapon("Iron sword", " made of basic iron, deals 1D6 damage", 20, 1, 6, 0));
            blackSmith.itemsInShop.Add(new Weapon("Knuckles", " made of simple yet effective iron, deals 1D4 + 1 damage", 25, 2, 5, 0));
            blackSmith.itemsInShop.Add(new Item("Holy Water", " water that is supposed to be healing any cure", 30));
            blackSmith.EnteringShop(player, "You enter the blacksmith's shop", FirstAction);
            PressAnyKeyToContinue();
            TextUtils.PrintWithDelay("After finishing your business you can still visit the pub, or exit the city");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Exit the city", ExitCitySmot)
            };
            if (!visitedThePub)
            {
                choices.Add(new Choice("Go to the pub", GoToPub));
            }
            SelectOptions(choices);
        }

        private void GoToPub() // CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You go to the pub.");
            TextUtils.PrintWithDelay("As you enter you see some people that you know from the past");
            TextUtils.PrintWithDelay("Hey " + player.name + " an old friend waves to you");
            visitedThePub = true;
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Ask the bartender for information around",SmotPubAskBartender),
                new Choice("Ask a random person you see sitting alone", SmotPubRandomPerson),
                new Choice("Ask a barbaric-looking group at a table about recent events",SmotPubBarbaricGroup)
            };
            SelectOptions(choices);
        }
        private void SmotPubBarbaricGroup()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You approach the table, you see three fellas, humans, sitting around the squared table.");
            TextUtils.PrintWithDelay("It seems the group is fairly young - around their 20's or late 20's. You see they are covered in some scarfs,");
            TextUtils.PrintWithDelay("and some leather armor is hidden behind. It doesn't seem they are too aware of their surroundings");
            TextUtils.PrintWithDelay("perhaps from too much drinking. They look equipped, and fairly prepared group, but in such situation");
            TextUtils.PrintWithDelay("it's a wild guess that they know you are even next to them.");
            TextUtils.PrintWithDelay("You start talking, and they look at you, groomed smiles on their faces as if you ruined a bit their fun.");
            TextUtils.PrintWithDelay("'Ahoy!' says one of the guys, 'Welcome aboard to the.. *BURP* where are we even at?' he asks his friends");
            TextUtils.PrintWithDelay("'Ah you filth ! Stop drinking so much bastard!' says the other guy, 'You'd have to put up your muscles");
            TextUtils.PrintWithDelay("into him man?' he talk to you, looking at you with half an eye, his hair keeps to his shoulders, perhaps even confused");
            TextUtils.PrintWithDelay("The third guy, bald guy with big mustache, really big for a human being, interupts,");
            TextUtils.PrintWithDelay("'The strongest muscle is the... Hmm? What do you think is the strongest muscle?' he asks you");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("The heart !", SmotPubStrongestMuscleHeart), //
                new Choice("The mind probably", SmotPubStrongestMuscleMind),//
                new Choice("Has to be the biceps", SmotPubStrongestMuscleBicept), //
                new Choice("For you it must be the mustache!", SmotPubStrongestMuscleMustache) //
            };
            SelectOptions(choices);
        }

        private void SmotPubStrongestMuscleMustache()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("He looks at you a bit weirdly, and says 'Is it the moustache? Who knows?' and keeps drinking.");
            TextUtils.PrintWithDelay("It doesn't seem there's much more to keep talking that's too informative but you still sit around and");
            TextUtils.PrintWithDelay("after a while you decide it's time to leave.");
            player.AddXP(20);
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the blacksmith", SmotVisitBlacksmith),
                new Choice("Exit the city", ExitCitySmot)
            };
            SelectOptions(choices);
        }

        private void SmotPubStrongestMuscleHeart()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("As the first guy passes out, and the third keeps talking to you");
            TextUtils.PrintWithDelay("'The heart is the strongest muscle!' he smiles and cheers up. ");
            TextUtils.PrintWithDelay("It's not clear why or how, but it looks like he also has got a pet. A white rabbit-ish look like");
            TextUtils.PrintWithDelay("pretty small, with two horns and two big eyes. You look at him for a moment, and he catches your eye");
            TextUtils.PrintWithDelay("showing a big tongue. It seems to be pretty energetic");
            TextUtils.PrintWithDelay("'He smiles his tongue only because you answered properly !' says the man.");
            TextUtils.PrintWithDelay("As you sit down with him, with the first guy passed out already and the second one drops to his mug and fall");
            TextUtils.PrintWithDelay("asleep, you keep talking to him. Eventually he gives you a piece of note,");
            TextUtils.PrintWithDelay("'I am not sure why, but I feel like you will have more to do with it. Keep it' he says");
            player.inventory.Add(new Item("Note2", "When thinking of light, create darkness. While summoning life think of death. " +
                "While in a ritual...Pray for sacrifice. " +
                "It has to have the deepest connections between them", 20));
            player.AddXP(40);
            TextUtils.PrintWithDelay("You thank the man for his gift, not sure what to do with it, but gladly accepts it.");
            TextUtils.PrintWithDelay("'The darker the night, the brighter the stars' he adds, and farewells from you");
            TextUtils.PrintWithDelay("Would you like to visit the blacksmith or leave the city?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the blacksmith", SmotVisitBlacksmith),
                new Choice("Exit the city", ExitCitySmot)
            };
            SelectOptions(choices);
        }

        private void SmotPubStrongestMuscleMind()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("'Even heaviest door can be opened' he says, as a word of wisdom.");
            TextUtils.PrintWithDelay("After sittinf for a while, you chat with him and eventually get up.");
            TextUtils.PrintWithDelay("Where would you like to go next?");
            player.AddXP(25);
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the blacksmith", SmotVisitBlacksmith),
                new Choice("Exit the city", ExitCitySmot)
            };
            SelectOptions(choices);
        }

        private void SmotPubStrongestMuscleBicept()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The big guy looks at you and says, 'If they insist on a fight, I will oblige them' and raises a hand to punch you!");
            TextUtils.PrintWithDelay("It doesn't seem there's much to do - either fight or flight");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Fight the man", SmotPubFightTheMan),
                new Choice("Run as fast as you can", SmotPubRunAway)
            };
            SelectOptions(choices);
        }
        private void SmotPubRunAway()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You take your flight and run away from the pub - but got hit and lost some gold!");
            if (player.gold >= 20)
            {
                player.gold -= 20;
            }
            else
            {
                player.gold = 0;
            }
            player.Resting(-3);
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Fight the man", SmotPubFightTheMan),
                new Choice("Run as fast as you can", SmotPubRunAway)
            };
            SelectOptions(choices);
        }
        private void SmotPubFightTheMan()// CHECKED IN DRAW
        {
            Braum braum = new Braum(10, "Braum", 1, 65, 20);
            player.Battle(braum);
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the blacksmith", SmotVisitBlacksmith),
                new Choice("Exit the city", ExitCitySmot)
            };
            SelectOptions(choices);
        }

        private void SmotPubRandomPerson()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You come and approach him. Looking a bit silly in a clown clothes, a weird hat on his head");
            TextUtils.PrintWithDelay("'Heads or tails " + player.name + "? ' he asks. Before you even respond, he flips. 'Heads it is! How did you know?'");
            TextUtils.PrintWithDelay("He is clearly a clown, even a drunk one. Nothing intellegent will come out of him, you think to yourself");
            TextUtils.PrintWithDelay("After another chug of beer, he looks at you, 'I am Singleton! And who...' he says as he starts to snore.");
            TextUtils.PrintWithDelay("How buttom-like person can this guy be? Is he really that useless? Better to keep moving, not much will come");
            TextUtils.PrintWithDelay("out of him probably.");
            TextUtils.PrintWithDelay("Where would you like to go now?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the blacksmith", SmotVisitBlacksmith),
                new Choice("Exit the city", ExitCitySmot)
            };
            SelectOptions(choices);
        }

        private void SmotPubAskBartender()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The bartender, looks quite similar to you, looks at you and nods you to grab a sit.");
            TextUtils.PrintWithDelay("'What is that brings you here " + player.name + "?' he asks, polishing yet another glass");
            TextUtils.PrintWithDelay("As you begin to talk, he shuts you quickly. 'Don't bother, I ain't gonna bother,");
            TextUtils.PrintWithDelay("everyone here are on the same mission or something. Only advise? Don't go south-east of here.");
            TextUtils.PrintWithDelay("You won't find anything buy despair and death. You can try your luck, just take some holy water");
            TextUtils.PrintWithDelay("with you and don't stick around there for too long, aight pal?' he says");
            TextUtils.PrintWithDelay("You take his advice, and his free beer that he served you and you get going");
            player.AddXP(20);
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the blacksmith", SmotVisitBlacksmith),
                new Choice("Exit the city", ExitCitySmot)
            };
            SelectOptions(choices);
        }

        private static void PressAnyKeyToContinue()
        {
            Console.WriteLine();
            TextUtils.PrintWithDelay("Press any key to continue");
            Console.WriteLine();
            Console.ReadLine();
        }

        private void SetPlayerName()
        {
            TextUtils.PrintWithDelay("What is your name?");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                player.name = input;
            }
            else
            {
                TextUtils.PrintWithDelay("Are you sure you don't want to be named? You can still decide here: ");
                string input2 = Console.ReadLine();
                if (!string.IsNullOrEmpty(input2))
                {
                    player.name = input2;
                }
            }
            TextUtils.PrintWithDelay("Welcome " + player.name);
            PressAnyKeyToContinue();
        }

        private void StoryTelling()
        {
            TextUtils.PrintWithDelay("You are waking up, a warm morning. It is summer, as far as you are concerned. ");
            TextUtils.PrintWithDelay("You look at your house - a peaceful place, at least for now.");
            TextUtils.PrintWithDelay("The heavy weight laying on your shoulders are exhausting only in the thinking - ");
            TextUtils.PrintWithDelay("but you know that coming back here is more important than ever.");
            TextUtils.PrintWithDelay("Only way to do so - is to protect the land. After years of trainings and hard work ");
            TextUtils.PrintWithDelay("you took upon yourself quite an adventure - one you might not be back from.");
            TextUtils.PrintWithDelay("About 20 years ago, there was a king, named Faith, who used to rule the lands of Eskila - ");
            TextUtils.PrintWithDelay("a very successful land, filled with good economy, protections and wealth for everyone.");
            TextUtils.PrintWithDelay("As the king was very kind and good, his son turned to be the opposite - ");
            TextUtils.PrintWithDelay(" - willing to steal the crown, his son - Graith - assassinated his father, and took over.");
            TextUtils.PrintWithDelay("Faith's personal assistant, Roswald, had just discovered necromancy. ");
            TextUtils.PrintWithDelay("His obsession led him to follow after it, and after 20 years of research,");
            TextUtils.PrintWithDelay("he discovered how to resurrect the dead - and rumors have spread about him coming back to life.");
            TextUtils.PrintWithDelay("It is now pure chaos. Some places still have some sort of stability, ");
            TextUtils.PrintWithDelay("but the land is starting to collapse under Graith's ruling.");
            TextUtils.PrintWithDelay("Would you choose to stop the resurrection? Prevent Roswald from controlling him?");
            TextUtils.PrintWithDelay("Maybe the rumors are just lies, and you will decide to fight against Graith? Rule yourself?");
            TextUtils.PrintWithDelay("Only time will tell what side you will pick. For now, you are waking up filled with thoughts.");
            PressAnyKeyToContinue();
        }

        private void PostHouseHillsToMice() //after skipping the house, or exploring it// CHECKED IN DRAW
        {
            player.AddXP(50);
            TextUtils.PrintWithDelay("After a while you arrive to Mice. A big city up ahead of you, and it looks giant");
            TextUtils.PrintWithDelay("You pass inside after the guards have checked you, and while it might seem you have plenty of time");
            TextUtils.PrintWithDelay("It already looks too dark. You have a few options - you could spend the night, go to a local shop");
            TextUtils.PrintWithDelay("or even try to look around. What would you do?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Go and spend the night to recover", MiceSleepingInTavern),
                new Choice("Find a local shop", MiceGoToShop),
                new Choice("Explore the city at night", MiceExploreAtNight)
            };
            SelectOptions(choices);
        }
        private void MiceExploreAtNight()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("While exploring at night, you do feel tired and losing a bit of health for extending your awake");
            player.Resting(-2);
            TextUtils.PrintWithDelay("You got spotted by a guard - 'What are your doings out here at such hour?' he asks");
            TextUtils.PrintWithDelay("Before you even notice, he draws his sword, and attack you !");
            BasicHumanoid soldier = new BasicHumanoid(13, "Soldier", 2, 85, 30);
            player.Battle(soldier);
            MiceExploringTheCity();
        }

        private void MiceExploringTheCity()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The sun is rising, and the city is getting awake in a rapid rate.");
            TextUtils.PrintWithDelay("Searching through the city, you find some leftovers - some gold coins, and a piece of letter.");
            TextUtils.PrintWithDelay("While it looks quite strange, it seems a middle part of a scroll.");
            player.inventory.Add(new Item("Note3", "If not for this dagger, I don't know how would I be " +
                "resurrecting them but you can't ever know what would you find", 20));
            player.gold += 20;
            TextUtils.PrintWithDelay("You wonder what are those, but who can ever know? You keep walking through the streets");
            TextUtils.PrintWithDelay("and take a moment for yourself to check out your options");
            MiceKeepExploringTheCity();
        }
        private void ExitMice()//CHECKED IN DRAW -- TO ADD LOGIC
        {
            TextUtils.PrintWithDelay("Leaving Mice behind you and its adventures, you keep going forward towards the next city - Spec");
            TextUtils.PrintWithDelay("Remembering your destination is Dirhal, where the king is now at, and where the rumors of the");
            TextUtils.PrintWithDelay("resurrected king is also heading - you take a deep breathe and keep going forward. The fields and views are incredible");
            TextUtils.PrintWithDelay("and as long as they are still green, as long as the ground is still beautiful - you have faith in you");
            TextUtils.PrintWithDelay("that you can save this land.");
            TextUtils.PrintWithDelay("You take a moment to rest and as soon as you do - a giant pair of wings fly over your head.");
            TextUtils.PrintWithDelay("You panic, unsure of the thing that just flew over, and surely is after a moment - a predator.");
            TextUtils.PrintWithDelay("Nothing but a manticore is standing up in front of you! Battling it is the only option stands in your way");
            Manticore manticore = new Manticore(35, "Manticore", 2, 225, 200);
            player.Battle(manticore);
            TextUtils.PrintWithDelay("Slaying the beast, you feel relieved. It's been a while since you fought so hard!");
            TextUtils.PrintWithDelay("Taking your time to recover, you find a small pond to rest at");
            player.Resting(10);
            TextUtils.PrintWithDelay("The birds got back to yoink around and fly in the open sky. The pond seems so relaxing and you think if it'll be a good idea");
            TextUtils.PrintWithDelay("to take a bath and relax even more.");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Go to the pond and bath", PathToSpecBath),
                new Choice("Skip the idea and keep going", PathToSpecPostPond)
            };
            SelectOptions(choices);
        }

        private void PathToSpecPostPond() //
        {
            TextUtils.PrintWithDelay("Keeping your highs and hopes on top, you pass the pond.");
            TextUtils.PrintWithDelay("After a while you notice a few villagers. Heading from...");
            TextUtils.PrintWithDelay("'Help!' they scream. They are about 3 villagers, one man and two ladies. 'You must help us!' he shouts");
            TextUtils.PrintWithDelay("as they run towards you. 'There is a beheamoth ! Stole our things! We don't know..' he takes some air");
            TextUtils.PrintWithDelay("'Wh...Wha.. he asks questions!' he says. As they approach you, they ask for your help - their whole merchant");
            TextUtils.PrintWithDelay("is being held by it. Would you help them?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Help the villagers", PathToSpecHelpVillagers),
                new Choice("Ignore the villagers",PathToSpecPastVillagers)
            };
            SelectOptions(choices);
        }
        private void PathToSpecPastVillagers() // CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("After keeping walking for a little longer, you find yourself in a question - ");
            TextUtils.PrintWithDelay("do you want to get to the city? Or skip it through a small forest?");
            TextUtils.PrintWithDelay("In front of you lies the bustling city of Spec, known for its diverse market items.");
            TextUtils.PrintWithDelay("However, to the right, you see a narrow path leading into a small, dense forest. ");
            TextUtils.PrintWithDelay("It seems to offer a quicker route but might hold unknown dangers.");
            TextUtils.PrintWithDelay("What would you like to do?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Enter the city of Spec", EnterCityOfSpec),
                new Choice("Take the shortcut through the forest", PathToSpecEnterForestShortcut)
            };
            SelectOptions(choices);
        }

        private void PathToSpecEnterForestShortcut()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to take the shortcut through the forest, hoping to save some time.");
            TextUtils.PrintWithDelay("The path is narrow and the trees are thick, but you push forward. After a while, you start to hear strange noises.");
            TextUtils.PrintWithDelay("Do you want to investigate the noises or keep moving forward?");

            List<Choice> choices = new List<Choice>()
            {
                new Choice("Investigate the noises", SpecForestInvestigateNoises),
                new Choice("Ignore the noises and keep moving", SpecForestIgnoreNoises)
            };
            SelectOptions(choices);
        }
        private void SpecForestInvestigateNoises()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to investigate the noises. As you move closer, you realize they are coming from two bandits setting up an ambush!");
            TextUtils.PrintWithDelay("They notice you and prepare to attack. You have no choice but to fight.");
            BasicHumanoid bandit1 = new BasicHumanoid(12, "Bandit", 4, 80, 50);
            BasicHumanoid bandit2 = new BasicHumanoid(15, "Bandit", 2, 80, 50);
            player.Battle(bandit1);
            player.Battle(bandit2);
            TextUtils.PrintWithDelay("After defeating the bandits, you find some gold and a key in their tent.");
            player.keys++;
            TextUtils.PrintWithDelay("You continue through the forest, eventually reaching the other side and rejoining the main road.");
            TextUtils.PrintWithDelay("After resting for a little bit fromt he combat, you decide to keep going");
            PostSpec();
        }
        private void SpecForestIgnoreNoises()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to ignore the noises and keep moving. The forest is eerie, but you manage to stay on the path.");
            TextUtils.PrintWithDelay("After a while, you reach the other side and find yourself back on the main road, closer to your destination.");
            PostSpec();
        }
        private void EnterCityOfSpec()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You get into the city, unsure why it's called City in the first place, but who know? You pass the guard, and get inside");
            TextUtils.PrintWithDelay("The city is humbled with some big buildings and other smaller ones, small as tents. ");
            TextUtils.PrintWithDelay("Perhaps it's in the progress of building itself");
            TextUtils.PrintWithDelay("Where would you like to go to?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Head to the market", SpecMarket),
                new Choice("Scout the area a bit", SpecScouting),
                new Choice("Exit the city", PostSpec)
            };
            if (!visitedSpecInn)
            {
                choices.Add(new Choice("Go to the Inn to get some sleep", SpecInn));
            }
            SelectOptions(choices);
        }
        private void SpecScouting()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You scout around, and in a hidden alley, after a while, you find a chest!");
            TextUtils.PrintWithDelay("Do you have a key for it?");
            if (player.keys > 0)
            {
                player.keys--;
                TextUtils.PrintWithDelay("You open the chest and find something - another letter !");
                player.inventory.Add(new Item("Note4", "Any mythic weapon would do. But behold - every " +
                    "resurrection comes with deep connection. Every feel the revived one's feeling - you would feel as well", 40));
            }
            TextUtils.PrintWithDelay("The guards find you - and shortly after, you discover it was a secret treasure burried. You are getting kicked out of the");
            TextUtils.PrintWithDelay("city by the whole guard !");
            player.AddXP(70);
            PostSpec();
        }
        private void SpecMarket()// CHECKED IN DRAW
        {
            Shop advancedShop = new Shop();
            advancedShop.itemsInShop.Add(new HealthPotion("Superior Health Potion", " will heal you for 4D6 + 5 health points", 100, 4, 24, 5));
            advancedShop.itemsInShop.Add(new HealthPotion("Legendary Health Potion", " will heal you for 6D6 + 15 health points", 125, 5, 30, 5));
            advancedShop.itemsInShop.Add(new HealthPotion("Ultimate Health Potion", " will heal you for 5D6 + 10 health points", 150, 5, 30, 10));

            advancedShop.itemsInShop.Add(new Weapon("Mithril Sword", " made of mithril, will deal 3D10 damage", 200, 3, 30, 0));
            advancedShop.itemsInShop.Add(new Weapon("Dragon Slayer Axe", " a powerful axe that can slay dragons, will deal 2D12 + 5 damage", 220, 2, 24, 5));
            advancedShop.itemsInShop.Add(new Weapon("Enchanted Bow", " a bow with magical properties, will deal 3D8 + 3 damage", 180, 3, 24, 3));

            advancedShop.itemsInShop.Add(new Item("Advanced Sharpening Tool", " will increase your damage modify by 3", 170));
            advancedShop.itemsInShop.Add(new Item("Protective Amulet", " will increase your armor by 5", 250));

            advancedShop.itemsInShop.Add(new Scroll("Meteor Strike", " an advanced spell, will launch a meteor strike dealing 2D20 damage", 250, 2, 40, 0));
            advancedShop.itemsInShop.Add(new Scroll("Blizzard", " a powerful spell that conjures a blizzard, dealing 3D12 + 5 damage", 180, 3, 36, 5));
            advancedShop.itemsInShop.Add(new Scroll("Chain Lightning", " a spell that strikes multiple enemies with lightning, dealing 5D6 damage", 200, 5, 30, 0));
            advancedShop.itemsInShop.Add(new Scroll("Earthquake", " a spell that causes an earthquake, dealing 3D20 damage", 300, 3, 60, 0));
            advancedShop.itemsInShop.Add(new Scroll("Tsunami", " a spell that conjures a tsunami, dealing 4D12 damage", 240, 4, 48, 0));
            advancedShop.EnteringShop(player, "You enter the shop, filled with materials and items that are overwhelming", ExitTheShop);
            TextUtils.PrintWithDelay("Where would you like to go next?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Scout the area a bit", SpecScouting),
                new Choice("Exit the city", PostSpec)
            };
            if (!visitedSpecInn)
            {
                choices.Add(new Choice("Go to the Inn to get some sleep", SpecInn));
            }
            SelectOptions(choices);
        }
        private void SpecInn()// CHECKED IN DRAW
        {
            visitedSpecInn = true;
            TextUtils.PrintWithDelay("Entering the bustling tavern, you notice it's not so empty. There are groups of people,");
            TextUtils.PrintWithDelay("leaving not much room for empty places. The bartender looks at you, and signals that the place");
            TextUtils.PrintWithDelay("is already full. You could get some sleep, that does sound good. However it's again coming in");
            TextUtils.PrintWithDelay("a bunch of offers. Would you like a standard room for 25? Or the so-called expensive room for 45?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Decide it's too expensive and find a place to sleep outside",SpecSleepOutside)
            };
            if (player.gold >= 25)
            {
                choices.Add(new Choice("Get the standard room", SpecInnStandardRoom));
                if (player.gold >= 45)
                {
                    choices.Add(new Choice("Get the expensive room", SpecInnExpensiveRoom));
                }
            }
            SelectOptions(choices);
        }
        private void SpecInnExpensiveRoom()// CHECKED IN DRAW
        {
            player.gold -= 45;
            TextUtils.PrintWithDelay("You enter to the room, tired, and take your bath and rest. Resting really heals up your body and soul");
            TextUtils.PrintWithDelay("and makes you feel alive again. Clearly you needed this rest !");
            player.health = player.maxHealth;
            TextUtils.PrintWithDelay("While there is indeed extra chest in there, you open it up if you have the key");
            if (player.keys > 0)
            {
                player.keys--;
                player.gold += 200;
                HealthPotion healthPot = new HealthPotion("Greater Health Potion!", "Incredible health potion that " +
                    "will heal you to your maximum health!", 200, 0, 0, 200);
                player.inventory.Add(healthPot);
            }
            TextUtils.PrintWithDelay("Waking up, you feel great and alive. It is time to go out and keep your adventure");
            TextUtils.PrintWithDelay("Where would you head next?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Head to the market", SpecMarket),
                new Choice("Scout the area a bit", SpecScouting),
                new Choice("Exit the city", PostSpec)
            };
            SelectOptions(choices);
        }
        private void SpecInnStandardRoom()// CHECKED IN DRAW
        {
            player.gold -= 25;
            player.Resting(15);
            TextUtils.PrintWithDelay("While there is indeed extra chest in there, you open it up if you have the key");
            if (player.keys > 0)
            {
                player.keys--;
                player.gold += 100;
                HealthPotion healthPot = new HealthPotion("Solid Health Potion", "Incredible health potion that will heal your wounds up", 100, 4, 23, 0);
                player.inventory.Add(healthPot);
            }
            TextUtils.PrintWithDelay("Taking a nice rest at the place, it seems really nice and chill in the room");
            TextUtils.PrintWithDelay("While you make sure there's nothing suspicious, you take your sleep, going to recover.");

            TextUtils.PrintWithDelay("Where would you head next?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Head to the market", SpecMarket),
                new Choice("Scout the area a bit", SpecScouting),
                new Choice("Exit the city", PostSpec)
            };
            SelectOptions(choices);
        }
        private void SpecSleepOutside()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to find a comfort place outside in the streets. While the resting is not much, it's the least expensive option");
            player.Resting(5);
            TextUtils.PrintWithDelay("As you wake up, you feel a bit better than before, ready for a new day");
            TextUtils.PrintWithDelay("Where would you head next?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Head to the market", SpecMarket),
                new Choice("Scout the area a bit", SpecScouting),
                new Choice("Exit the city", PostSpec)
            };
            SelectOptions(choices);
        }
        private void PostSpec()//CHECKED IN DRAW // ADD MORE LOGIC !
        {
            TextUtils.PrintWithDelay("While getting out of the city, you notice - your destination is not so close, but its marks");
            TextUtils.PrintWithDelay("are surely leaving a mark in the skies. The destined sky is dark, filled with smoke - the marks of");
            TextUtils.PrintWithDelay("recreation. It's clear to you now  - the resurrection is happening and it's better to get there as soon as possible.");
            TextUtils.PrintWithDelay("You keep going and shortly get to the shores, and the beach sands are giving very nice breezes from time to time");
            TextUtils.PrintWithDelay("However, you are not sure if you want to go through the beach, but it might be the same time of arrival");
            TextUtils.PrintWithDelay("since the walk on sand is slower. Which path would you choose to walk through?");
            List<Choice> choices = new List<Choice>
            {
                new Choice("Get alongside the sea", PathToDirhalWalkingOnBeach),
                new Choice("Take the longer path on the road", PathToDirhalWalkingOnRoad)
            };
            SelectOptions(choices);
        }
        private void PathToDirhalWalkingOnRoad()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You keep walking on the path, while not much liveliness has seen around. It's quite obvious - but wouldn't you expect");
            TextUtils.PrintWithDelay("to see some people running away? You question yourself and keep walking.");
            TextUtils.PrintWithDelay("As you ask yourself, you see a merchant. Or is it?...");
            TextUtils.PrintWithDelay("The figure gets closer. It's a wizard. With a small cart. You really question yourself on this one");
            TextUtils.PrintWithDelay("'Hello there, " + player.name + ",' he says, 'I hope you don't head there. Ah, you already are. Well, that's on you");
            TextUtils.PrintWithDelay("my friend, don't expect to find allies over there. It's a lost case. All lost from this point onward. ");
            TextUtils.PrintWithDelay("And while you think you will find any valuables you will. But gotta fight those other creeps' he says.");
            TextUtils.PrintWithDelay("How does he know your name? Rumors must've been running around");
            TextUtils.PrintWithDelay("He doesn't seem to lie at all, but can you really trust him? 'Here, take this', he adds and brings you a note");
            player.inventory.Add(new Item("Note5", "Be careful on such a spell, thus he does not hold back " +
                "and no steps back can never happen once you have completed it", 50));
            TextUtils.PrintWithDelay("'Oh I hope you find it useful somehow' he adds. He greets you and keep walking to the other direction");
            player.AddXP(50);
            TextUtils.PrintWithDelay("After a while you take a bit more resting, and keep walking. After some an hour or so, ");
            TextUtils.PrintWithDelay("you see it - there's a big mansion and a river");
            TextUtils.PrintWithDelay("that blocks the path. Probably must go through this. But why is this mansion designed like a cave?");
            TextUtils.PrintWithDelay("Keep walking forward, you open the door - you can't just cross the river. What is this place...");
            TextUtils.PrintWithDelay("And just as you open it - you get knocked back in the air!");
            TextUtils.PrintWithDelay("Being thrown back, you recover quickly and see it - a Minotaur is standing, roaring in front of you!");
            TextUtils.PrintWithDelay("A big, strong minotaur is showing up its teeth - and he is not smiling. ");
            TextUtils.PrintWithDelay("He's holding a giant axe, and you better be ready for it!");
            player.Resting(-2);
            Minotaur minotaur = new Minotaur(50, "Minotaur", 4, 220, 240);
            player.Battle(minotaur);
            TextUtils.PrintWithDelay("After defeating the Minotaur you search the house and take its valuables.");
            TextUtils.PrintWithDelay("Now, you get through the mansion, as spooky as it might be, and keep going");
            TextUtils.PrintWithDelay("You are now entering a more hilled terrain, walking through the other fields of the wild");
            PathToDirhalWalkingHills();
        }

        private void EnteringDirhal()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You finally reach the ruins of Dirhal. It seems not much was left from the glorious city it once used to be.");
            TextUtils.PrintWithDelay("The air is thick with the smell of decay and the sky is darkened by ominous clouds.");
            TextUtils.PrintWithDelay("You know that this is the final leg of your journey. ");
            TextUtils.PrintWithDelay("The castle looms in the distance, but there are several areas you could explore first.");
            TextUtils.PrintWithDelay("Right before you make any decision, you re-organise your backpack, ");
            TextUtils.PrintWithDelay("and take a deep rest one last time before you enter the last push");
            TextUtils.PrintWithDelay("of your journey. One last step, you think to yourself. Right before that, you take an ease of the day and rest a bit");
            player.Resting(12);
            TextUtils.PrintWithDelay("As you walk through the streets, you see something falling off from the castle. It's a note!");
            player.inventory.Add(new Item("Note6", "A death would mean gambling your life in fron of the devil and god. You are oath to try it - but be wise.", 50));
            TextUtils.PrintWithDelay("Where would you like to go?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Explore the ancient library", DirhalExploreAncientLibrary),//
                new Choice("Visit the old armory", DirhalVisitOldArmory),//
                new Choice("Investigate the crumbling cathedral", DirhalInvestigateCrumblingCathedral)//
            };
            SelectOptions(choices);
        }

        private void DirhalExploreAncientLibrary()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You enter the ancient library, filled with dusty tomes and forgotten knowledge.");
            TextUtils.PrintWithDelay("The dirt and dust is insane, and there is fire that starts to burn, looks like it has already eaten half");
            TextUtils.PrintWithDelay("of what ever there was there. So much time spent on writing those books and knowledge that will go and disappear");
            TextUtils.PrintWithDelay("what a waste, what a shame. You decide to explore, see what you can save");
            TextUtils.PrintWithDelay("As you explore, you come across a hidden alcove with a powerful spellbook.");
            player.inventory.Add(new Scroll("Ultimate Blast", "A powerful spell that deals 4D20 damage.", 300, 4, 80, 0));
            TextUtils.PrintWithDelay("You take the spellbook, knowing it will be useful in the battles to come and exit right before the fire will come to you too");
            DirhalTriggerCrashEvent();
        }

        private void DirhalVisitOldArmory()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You visit the old armory, where rusted weapons and broken armor lie scattered. Not much left here, since it's all burnt down.");
            TextUtils.PrintWithDelay("Among the ruined leftovers of what used to be weapons, you find a pristine sword glowing with a magical aura.");
            player.inventory.Add(new Weapon("Ethereal Blade", "A sword that deals 3D12 + 5 damage and is made of unknown material.", 250, 3, 36, 5));
            TextUtils.PrintWithDelay("You take the sword, feeling its power course through you. You wonder how useful would that be in a battle.");
            TextUtils.PrintWithDelay("You exit the armory and get outside");
            DirhalTriggerCrashEvent();
        }

        private void DirhalInvestigateCrumblingCathedral()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You investigate the crumbling cathedral, where the air is thick with dark magic.");
            TextUtils.PrintWithDelay("You sense the citizens that flee from here, and those who had to tear this place down");
            TextUtils.PrintWithDelay("Going deeper, you explore the area, and see what chaos was caused here.");
            TextUtils.PrintWithDelay("In the altar, you find an amulet radiating a protective aura.");
            player.inventory.Add(new Item("Amulet of Aegis", "An amulet that increases your armor by 5.", 200));
            TextUtils.PrintWithDelay("You take the amulet, feeling its protection envelop you.");
            TextUtils.PrintWithDelay("Equipped with one more item that can help you for sure, you exit the cathedral");
            DirhalTriggerCrashEvent();
        }

        private void DirhalTriggerCrashEvent()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("Definetely an earthquake, you think at first. But then you see all the blood, ");
            TextUtils.PrintWithDelay("the bodies, the burnt ones... And those who tried to run");
            TextUtils.PrintWithDelay("The ones who could escape, it seems, ran to the boats and escape through the water. Makes sense, maybe in a differnet land");
            TextUtils.PrintWithDelay("there won't be as much as chaos as in here right now. It can only make sense now");
            TextUtils.PrintWithDelay("As you leave the area, the ground shakes and a deafening crash echoes through the ruins.");
            TextUtils.PrintWithDelay("You look towards the castle and see a massive section of the wall collapse, revealing a hidden passage.");
            TextUtils.PrintWithDelay("You know this is your only way forward. Steeling yourself, you head towards the castle.");
            DirhalNavigateToCastle();
        }
        private void DirhalNavigateToCastle() // CHECKED IN DRAW
        {
            // the old king - Faith
            // the new king - Graith
            // the lich - Roswald
            player.AddXP(100);
            TextUtils.PrintWithDelay("You navigate through the hidden passage, guiding yourself through the ruins and moving");
            TextUtils.PrintWithDelay("chunks of blocks and dirt from the collapsed building, you find yourself in the stairs room.");
            TextUtils.PrintWithDelay("It's going to take a while, you think. And you start climbing.");
            TextUtils.PrintWithDelay("After getting to halfway through, you find yourself hopeless - a skeleton stands in your way!");
            BasicHumanoid skeleton = new BasicHumanoid(40, "Skeleton", 3, 100, 50);
            player.Battle(skeleton);
            TextUtils.PrintWithDelay("kicking the leftovers of the skeleton, you keep passing through to the top, and how surprising - you find");
            TextUtils.PrintWithDelay("another guard towards the top. Wizard, non-the-less !");
            BasicWizard wizard = new BasicWizard(20, "Scholar Wizard", 0, 120, 50);
            player.Battle(wizard);
            TextUtils.PrintWithDelay("After kicking this wizard off, you enter the hallway - and march through.");
            TextUtils.PrintWithDelay("As you might have thought, it's too late. Or is it? The lich with the old king");
            TextUtils.PrintWithDelay("alongside the new king, are all gathered in the king's room");
            TextUtils.PrintWithDelay("'Ah ! Look who arrived!' says the lich.");
            TextUtils.PrintWithDelay("'As if it's not " + player.name + "! We have already have heard about you. But where does your heart guide you to?");
            TextUtils.PrintWithDelay("says the lich. 'Join me and we will get rid of that traitor!' shouts Roswald the lich.");
            TextUtils.PrintWithDelay("He has a point - the whole land of Eskila was shatterd and went to hell. His royalty was not guided");
            TextUtils.PrintWithDelay("and it doesn't seem like it's going in any good direction. 'Shut up and listen to me!' says Graith, the new king");
            TextUtils.PrintWithDelay("'I am the one in charge ! Besides, who would go after such an old king? And a lich? You must be making a fool");
            TextUtils.PrintWithDelay("out of yourselves. And this whole land! A dead king? Undead? What happened to him anyways? What is this sick trick?'");
            TextUtils.PrintWithDelay("You are unsure where to path now. But you have to decide !");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Battle the Old King Faith", BattleOldKing),//
                new Choice("Battle the new King Graith", BattleNewKing),//
                new Choice("Battle Roswald the Lich", BattleLich)//
            };
            SelectOptions(choices);
        }

        private void BattleOldKing() //CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You choose to face the resurrected old king, who stands tall and imposing.");
            TextUtils.PrintWithDelay("As you turn towards the old king, he slowly turns towards you. His already-dead face");
            TextUtils.PrintWithDelay("looks at you. It seems dead, yet filled of wildness. Something that was forgotten.");
            TextUtils.PrintWithDelay("The Lich inteferes - 'How stupid can this mortal be !' he shouts.");
            TextUtils.PrintWithDelay("'You think you can impose him? You must have lost your mind!' he laughs.");
            TextUtils.PrintWithDelay("'But, let us show you how REALLY lose your mind. Get him!'");
            TextUtils.PrintWithDelay("The living-dead figure of the old king, a long-retired king that used to rule the lands of Eskila");
            TextUtils.PrintWithDelay("that will no longer show true emotion. You prepare yourself - this fight is going to be tough.");
            OldKing oldKing = new OldKing(60, "Resurrected Old King", 5, 300, 500);
            player.Battle(oldKing);
            fightOldKing = true;
            TextUtils.PrintWithDelay("After a grueling battle, you finally defeat the old king. Peace is restored to the land.");
            //now need to check - if have a mythical sword
            List<Choice> choices = new List<Choice>();
            bool hasMythicSword = CheckForMythicItem();
            if (hasMythicSword || fightLich)
            {
                if (fightNewKing)
                {
                    PostFightEveryone();
                }
                else
                {
                    choices.Add(new Choice("Join forces with the New King", PostFightsJoinNewKing));
                    choices.Add(new Choice("Prepare yourself to fight the New King", BattleNewKing));
                }
            }
            else
            {
                choices.Add(new Choice("Stand for another battle with the Lich", BattleLich));
                choices.Add(new Choice("Prepare yourself to fight the New King", BattleNewKing));
            }
            SelectOptions(choices);
        }

        private void PostFightEveryone()
        {
            TextUtils.PrintWithDelay("You have defeated them all - and now, the crown stands to your hands only, and the throne is yours to rule.");
            EndGame();
        }

        private void BattleLich()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You choose to face the Lich, who cackles with dark energy.");
            TextUtils.PrintWithDelay("The Lich, a lean man, in his possibly late 60's, or perhaps it is all the dark magic");
            TextUtils.PrintWithDelay("that caused him to age this way. Not so sure what he has in his arsenal, you are sure");
            TextUtils.PrintWithDelay("that this fight is not going to be easy. The fate of Eskila is in your hands at this very moment");
            TextUtils.PrintWithDelay("You prepare yourself for one last effort.");
            TextUtils.PrintWithDelay("The lich opens his mouth - 'Your head will serve my furniture in hell!'");
            Lich lich = new Lich(125, "Lich", 2, 250, 400);
            player.Battle(lich);
            fightLich = true;
            TextUtils.PrintWithDelay("After a fierce battle, you destroy the lich. The dark magic fades from the land.");
            List<Choice> choices = new List<Choice>()
            {
                //new Choice("Embrace your wrath and duel the New King", PostLichBattleFightNewKing),
            };
            bool hasMythicSword = CheckForMythicItem();
            if (hasMythicSword)
            {
                if (fightNewKing)
                {
                    PostFightEveryone();
                }
                else
                {
                    choices.Add(new Choice("Finish what you started - kill off the New King", BattleNewKing));
                    choices.Add(new Choice("Talk with the New King - and join forces to rule again", PostFightsJoinNewKing));
                }
            }
            else
            {
                choices.Add(new Choice("Finish off the duo and fight the Old King", BattleOldKing));
            }
            SelectOptions(choices);
        }

        private void BattleNewKing()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You choose to face the new king, who glares at you with hatred.");
            TextUtils.PrintWithDelay("You watch the new king, a mere child you would only say - perhaps too young to rule.");
            TextUtils.PrintWithDelay("The New King, coated in armor, looks as if he could rip a mountain off its tail.");
            TextUtils.PrintWithDelay("Looking at you, he is way taller, majestic even you could say.");
            TextUtils.PrintWithDelay("'I am more than surprised that a peasant like you decided to face against me!'");
            TextUtils.PrintWithDelay("he says, drawing his sword and shield, prepared to battle you at all cost.");
            TextUtils.PrintWithDelay("'You will regret this!' he shouts again, as hard as he can from his longues");
            TextUtils.PrintWithDelay("You take your ambition to and courage to complete the mission and bring peace");
            TextUtils.PrintWithDelay("to this land. And while you are not sure how to fight him - you will surely do your best");
            NewKing newKing = new NewKing(120, "New King", 4, 350, 450);
            player.Battle(newKing);
            fightNewKing = true;
            TextUtils.PrintWithDelay("After an intense battle, you overthrow the new king. Justice is served.");
            TextUtils.PrintWithDelay("However you are still in a dilema - you could let the Old King and the Lich rule the lands...");
            TextUtils.PrintWithDelay("But would you decide to do so?");

            if (fightLich && fightOldKing)
            {
                PostFightEveryone();
            }
            else
            {
                List<Choice> choices = new List<Choice>()
                {
                    new Choice("Unleash your wrath against the Lich", PostNewKingBattleFightLich), //to fight the lich
                    new Choice("Raise your weapons againt the Old King", PostNewKingBattleFightOldKing),//to fight the old king
                    new Choice("Decide to talk with the Lich to allow them take the kingdom", PostNewKingBattleJoinForces) //perhaps join them
                };
                //after finishing the new king, can decide - or to fight one of the lich/old king - or to join them.
                //what if you already killed them both? PostFightEveryone.
                SelectOptions(choices);
            }
        }

        private bool CheckForMythicItem() //after fighting the lich need to check !
        {
            string mythicSword = "Mythical Sword";
            if (player.CheckForItem(mythicSword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //FIRST - POST FIGHTING THE NEW KING BattleNewKing
        private void PostNewKingBattleFightLich() // fight the lich next
        {
            BattleLich();
        }

        private void PostNewKingBattleFightOldKing()// fight the old king next
        {
            BattleOldKing();
        }

        private void PostNewKingBattleJoinForces() //decide to join forces and ally with the Lich and Old King to rule the lands
        {
            TextUtils.PrintWithDelay("Withdrawing your weapon, showing what you are capable of, showed a true interest in the Lich's eyes.");
            TextUtils.PrintWithDelay("'You truely showed you are worthy. Come with me, and we will join up to rule again this marvelous lands!");
            TextUtils.PrintWithDelay("I am happy to see that you have something functioning over there - you won't regret this.' he says smiling");
            TextUtils.PrintWithDelay("However this smile doesn't look promising. He gets closer, and before you notice anything, he's next to you.");
            TextUtils.PrintWithDelay("'Oh... You definetely won't regret it' he says as he clutches his hand against your chest with dark magic.");
            TextUtils.PrintWithDelay("You feel yourself trumbling, feeling your soul leaving your body. You scream of pain, but for no use.");
            TextUtils.PrintWithDelay("The Lich has already taken control over your body - and you will be forces to serve as his slave for eternity now.");
            TextUtils.PrintWithDelay("As he promised, you will definetely rule together - but under his command...");
            PressAnyKeyToContinue();
            EndGame();
        }

        private void PostFightsJoinNewKing()
        {
            TextUtils.PrintWithDelay("'I see your brain didn't rot next to this filthy animals. At last, somebody who is worht!'");
            TextUtils.PrintWithDelay("He seems to have his plans work out eventually - he can once again rule the lands.");
            TextUtils.PrintWithDelay("But, how good would that be? The land was already crashing down... It's not an easy task.");
            TextUtils.PrintWithDelay("'Don't worry " + player.name + ", you will rule next to me - just by my side. You will be given");
            TextUtils.PrintWithDelay("anything you ever dreamt of, and beyond that. This is only the beginning!");
            TextUtils.PrintWithDelay("He talks as if he read your mind. 'If it wasn't for these bastards, who kept ruining my plans and sending");
            TextUtils.PrintWithDelay("abominations and skeletons every time, this kingdom would already be at the top of its time.");
            TextUtils.PrintWithDelay("But not everything is pure gold. However, now is the time. NOW we will rise back up!'");
            TextUtils.PrintWithDelay("The old king laughs and you are unsure of whether or not this was a good decision to make.");
            TextUtils.PrintWithDelay("However, it's already been too late - you have crossed your paths with him, as for now you can no longer");
            TextUtils.PrintWithDelay("change your decided faith for the future to be.");
            EndGame();
        }

        //there will be a few battles - one for after the New King fight
        //one for after battling the Old King
        //and one for post Lich fight.
        //The lich and the old king will send you to fight the other unless you have a weapon according to the note
        //you will need a mythic weapon. There is only one you can buy at ScoutTheRuinedHouseHillsToMice
        //If you have this item, you won't need to fight the Lich or the Old king after defeating one of them.
        //Then you will be able to fight the New King - a weakened version of him.
        //long story short - Fight Old King > (if dont have mythical sword) fight Lich > fight New King
        //Fight Lich > (if dont have mythical sword) Fight Old King > fight New King
        //same goes for new king.

        private void PathToDirhalWalkingHills()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You keep pushing forward, hoping to find your destination.");
            TextUtils.PrintWithDelay("As you walk, you notice the landscape changing. The air becomes cooler and the trees thicker.");
            TextUtils.PrintWithDelay("There are quite a few things to explore - but which one would be the wisest? This land is weird.");
            List<Choice> choices = new List<Choice>()
            {
               new Choice("Continue on the main path", EnteringDirhal),//
               new Choice("Explore a cave you notice nearby", PathToDirhalExploreCave),//
               new Choice("Investigate a strange light in the distance", PathToDirhalInvestigateStrangeLight),//
               new Choice("Rest for a while between some trees", PathToDirhalRestInHills) //
            };
            SelectOptions(choices);
        }

        private void EndGame()
        {
            TextUtils.PrintWithDelay("Thank you for playing the game! You have come to and end, but is it the only one outcome?");
            TextUtils.PrintWithDelay("I hope you enjoyed the game - and feel free to play again!");
            TextUtils.PrintWithDelay("Oh and just before you leave - here are your stats just once again");
            player.ViewStats();
            TextUtils.PrintWithDelay("And your items as well -");
            player.DisplayItems();
            TextUtils.PrintWithDelay("Would you dare to try again?");
            List<Choice> choices = new List<Choice>
            {
                new Choice("Restart the game", RestartGame),
                new Choice("Quit the game", QuitGame)
            };
            SelectOptions(choices);
        }

        private void PathToDirhalRestInHills()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to rest for a while. The fresh air helps you regain some health.");
            TextUtils.PrintWithDelay("After resting for a while you decide it's time to keep pushing forwards");
            player.Resting(10);
            EnteringDirhal();
        }
        private void PathToDirhalDeclineFairyOffer()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decline the offer and explore the realm. You find some rare herbs that can be used for healing.");
            player.inventory.Add(new Item("Healing Herbs", "Herbs that can be used to create healing potions.", 50));
            EnteringDirhal();
        }

        private void PathToDirhalAcceptFairyOffer()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The fairy gives you a magical ring that increases your damage.");
            player.inventory.Add(new Item("Magical Ring", "A ring that increases your damage by 3.", 150));
            TextUtils.PrintWithDelay("'You won't regret this offer !' he says, and as you thank him he pushes you away to the portal!");
            EnteringDirhal();
        }

        private void PathToDirhalInvestigateStrangeLight()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to investigate the strange light. As you get closer, you realize it's coming from a magical portal.");
            TextUtils.PrintWithDelay("The portal seems to lead to another realm. Colors are vibrating around it, and it looks alive. Do you want to enter?");
            List<Choice> choices = new List<Choice>()
            {
               new Choice("Enter the portal", PathToDirhalEnterPortal),
               new Choice("Ignore the portal and keep walking", PathToDirhalIgnorePortal)
            };
            SelectOptions(choices);
        }
        private void PathToDirhalEnterPortal()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You step through the portal and find yourself in a mystical realm. The air is filled with magic and the landscape is unreal.");
            TextUtils.PrintWithDelay("Being shocked from the beauty of the unreal nature, a fairy comes in your way.");
            TextUtils.PrintWithDelay("The fairy speaks, and the one who offers you a magical item in exchange for some gold.");
            TextUtils.PrintWithDelay("He claims he has a very unique item, but can you truly trust him?");
            TextUtils.PrintWithDelay("'It will only cost you 50 gold!' he says with a smile as he's flying in front of you, in his green-ish look.");
            List<Choice> choices = new List<Choice>()
            {
               new Choice("Decline the offer and explore the realm", PathToDirhalDeclineFairyOffer)
            };
            if (player.gold >= 50)
            {
                player.gold -= 50;
                choices.Add(new Choice("Accept the offer", PathToDirhalAcceptFairyOffer));
            }
            SelectOptions(choices);
        }
        private void PathToDirhalIgnorePortal()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to ignore the portal and keep walking. The path ahead is long and you don't want to get sidetracked.");
            TextUtils.PrintWithDelay("The fairy look a bit disappointed, but gets back to his business");
            EnteringDirhal();
        }
        private void PathToDirhalExploreCave()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to explore the cave. As you enter, you hear the sound of dripping water and the flutter of bat wings.");
            TextUtils.PrintWithDelay("The cave is dark, but you can still see with the light that's coming from outside.");
            TextUtils.PrintWithDelay("Where would you like to go?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Go deeper into the cave", PathToDirhalGoDeeperIntoCave),//
                new Choice("Search for potential items and materials", PathToDirhalSearchForHiddenTreasures),//
                new Choice("Exit the cave", PathToDirhalExitCave)//
            };
            SelectOptions(choices);
        }

        private void PathToDirhalGoDeeperIntoCave()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You go deeper into the cave and there you see it - some lights from a torch and growling that sound disgusting.");
            TextUtils.PrintWithDelay("And then you see them as they spot you - goblins! Ew they're ugly. And not friendly at all with their swords!");
            BasicHumanoid goblin1 = new BasicHumanoid(12, "Goblin", 2, 65, 20);
            BasicHumanoid goblin2 = new BasicHumanoid(14, "Goblin", 2, 55, 25);
            player.Battle(goblin1);
            player.Battle(goblin2);
            TextUtils.PrintWithDelay("After defeating the goblins, you find some gold and a mysterious amulet.");
            player.gold += 50;
            player.inventory.Add(new Item("Mysterious Amulet", "An amulet with unknown properties. It might be valuable.", 100));
            TextUtils.PrintWithDelay("Grabbing them to your back, you head outside and keep your journey");
            EnteringDirhal();
        }

        private void PathToDirhalSearchForHiddenTreasures()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You search the cave and find a hidden chest. Do you have a key to open it?");
            if (player.keys > 0)
            {
                player.keys--;
                TextUtils.PrintWithDelay("You open the chest and find a rare gemstone and a health potion.");
                player.inventory.Add(new Item("Rare Gemstone", "A valuable gemstone. It can be sold for a high price.", 150));
                player.inventory.Add(new HealthPotion("Superior Health Potion", "A potion that heals you for 4D6 + 5 health points.", 100, 4, 24, 5));
            }
            else
            {
                TextUtils.PrintWithDelay("You don't have a key to open the chest.");
            }
            TextUtils.PrintWithDelay("You exit the cave slowly, making sure you don't make too much sound.");
            EnteringDirhal();
        }
        private void PathToDirhalExitCave()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to exit the cave and continue your journey. The fresh air outside feels better than the stinks inside the cave.");
            EnteringDirhal();
        }

        private void PathToDirhalWalkingOnBeach()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You walk to the side of the sea, and the breezes surely gives you some cool air to enjoy while walking the day");
            TextUtils.PrintWithDelay("You take your time, enjoy the views - and help yourself by grabbing a snack.");
            player.Resting(4);
            TextUtils.PrintWithDelay("While you keep going, the tides are changing and a collapse in the water is occuring?..");
            TextUtils.PrintWithDelay("You're not sure of what is going to happen but here it is - a shockwave in the sea. Not just a regular shockwave -");
            TextUtils.PrintWithDelay("but a massive Tsunami is rising up!");
            TextUtils.PrintWithDelay("You sense something is off, but right after that you see a wizard - coming down your path. 'You! An enemy of our land!'");
            TextUtils.PrintWithDelay("He shouts at you, throwing a firebolt that just misses !");
            StrongWizard strongWizard = new StrongWizard(40, "Strong Wizard", 0, 200, 250);
            player.Battle(strongWizard);
            TextUtils.PrintWithDelay("After killing the strong wizard, the tides calm down, and you assure yourself a nice rest");
            TextUtils.PrintWithDelay("and after doing so you keep walking until you reach the hills towards Dirhal");
            player.Resting(8);
            PathToDirhalWalkingHills();
        }
        private void PathToSpecHelpVillagers() //CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You are going to the direction they told you to go to - and while doing so, you feel a bit anxious. They wait for");
            TextUtils.PrintWithDelay("behind, hopefully regaining their merchant cart back. You get going and soon enough you see it - a Sphinx !");
            TextUtils.PrintWithDelay("A giant Sphinx is guarding them, and looks at you - as if it's expecting you");
            TextUtils.PrintWithDelay("'Ah, greetings mortal,' it says, 'I assume they asked your help?' it starts laughing");
            TextUtils.PrintWithDelay("You think it might want to attack, but doesn't seem like it - it's pretty calm for now.");
            TextUtils.PrintWithDelay("'If you want me to flee, you'd have to solve me this riddle - Only the smart can solve it.'");
            TextUtils.PrintWithDelay("You agree to try, and hear what it has to say.");
            TextUtils.PrintWithDelay("'I speak without a mouth and hear without ears. I have no body, but I come alive with wind.'");
            TextUtils.PrintWithDelay("What am I?' it asks, waiting for your reply");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("An Echo", PathToSpecCorrectRiddleAnswer),
                new Choice("A Shadow", PathToSpecIncorrectRiddleAnswer),
                new Choice("A Whisper", PathToSpecIncorrectRiddleAnswer)
            };
            SelectOptions(choices);
        }
        private void PathToSpecCorrectRiddleAnswer()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The Sphinx looks at you, impressed. 'Indeed, you are correct, " + player.name + "' it says. ");
            TextUtils.PrintWithDelay("'You may pass, and I shall leave these villagers be.'");
            TextUtils.PrintWithDelay("With that, the Sphinx flies away, and you help the villagers get their cart back.");
            player.AddXP(100);
            player.gold += 350;
            TextUtils.PrintWithDelay("The villagers thank you profusely and give you a small reward! ");
            TextUtils.PrintWithDelay("Their thanks is from their buttom of their hearts");
            TextUtils.PrintWithDelay("Thank you " + player.name + ", thank you so much!");
            PathToSpecPastVillagers();
        }

        private void PathToSpecIncorrectRiddleAnswer()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The Sphinx looks at you with disappointment. 'That is incorrect,' it says, 'and now you " +
                "must face my wrath " + player.name + " !'");
            Manticore sphinx = new Manticore(50, "Sphinx", 3, 225, 50);
            player.Battle(sphinx);
            PathToSpecPastVillagers();
        }
        private void PathToSpecBath()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You take your time to get inside and rest. As you get out you see a few racoons stealing your things!");
            TextUtils.PrintWithDelay("While you got there in time, a random item had disappeared of your back.");
            Random rng = new Random();
            int itemToRemove = rng.Next(0, player.inventory.Count);

            Item removedItem = player.inventory[itemToRemove];
            player.inventory.RemoveAt(itemToRemove);
            player.Resting(10);
            TextUtils.PrintWithDelay("A bit more relaxed but annoyed by the item that was stolen you keep going forward");
            PathToSpecPostPond();
        }
        private void MiceKeepExploringTheCity() //CHECKED IN DRAW
        {
            if (!firstEnteredStreets)
            {
                TextUtils.PrintWithDelay("You decide to keep exploring the city of Mice. The streets are filled ");
                TextUtils.PrintWithDelay("with activity as merchants sell their goods and people go about their daily lives.");
                firstEnteredStreets = true;
            }
            TextUtils.PrintWithDelay("Where would you like to go?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the marketplace", MiceGoToShop),
                new Choice("Leave the city", ExitMice)
            };
            if (!exploreBuilding)
            {
                choices.Add(new Choice("Enter a mysterious building", MiceExploreMysteriousBuilding));
            }
            if (!exploreAlleys)
            {
                choices.Add(new Choice("Explore the alleyways", MiceExploreAlleyways));
            }
            if (!talkedToGuard)
            {
                choices.Add(new Choice("Talk to a town guard", MiceTalkToTownGuard));
            }
            SelectOptions(choices);
        }
        private void MiceTalkToTownGuard()//CHECKED IN DRAW
        {
            talkedToGuard = true;
            TextUtils.PrintWithDelay("You approach a town guard standing on his guard.");
            TextUtils.PrintWithDelay("The guard looks at you with suspicion but eventually relaxes.");
            TextUtils.PrintWithDelay("'What brings you to Mice?' he asks, trying to figure out how can he fill his duty today. What would you tell him?");
            player.AddXP(20);
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Ask about recent events", MiceAskGuardAboutRecentEvents),
                new Choice("Ask for directions", MiceAskGuardForDirections),
                new Choice("Leave the guard", MiceKeepExploringTheCity)
            };
            SelectOptions(choices);
        }

        private void MiceAskGuardAboutRecentEvents()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The guard tells you about recent events in the city, including rumors ");
            TextUtils.PrintWithDelay("of a hidden treasure and strange occurrences at night.");
            TextUtils.PrintWithDelay("'Be careful if you're out late," + player.name + "' he warns. 'There have been reports of disappearances.'");
            player.AddXP(10);
            MiceKeepExploringTheCity();
        }

        private void MiceAskGuardForDirections()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("The guard gives you directions to various points of interest in the city, including the marketplace, ");
            TextUtils.PrintWithDelay("the inn, and a few hidden spots known only to locals.");
            player.AddXP(10);
            MiceKeepExploringTheCity();
        }
        private void MiceExploreMysteriousBuilding()//CHECKED IN DRAW
        {
            exploreBuilding = true;
            TextUtils.PrintWithDelay("You enter a mysterious building that seems to have been abandoned for a long time.");
            TextUtils.PrintWithDelay("As you explore the dusty rooms, you find a hidden trapdoor leading to a basement.");
            TextUtils.PrintWithDelay("In the basement, you find a treasure chest.");
            MiceOpenChestInBuilding();
        }
        private void MiceOpenChestInBuilding()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("Do you have a key by any chance? It looks quite valuable, but without a key, there's no worth to it!");
            if (player.keys > 0)
            {
                player.keys--;
                TextUtils.PrintWithDelay("You open the chest and find some valuable items inside.");
                player.inventory.Add(new Item("Ancient Artifact", "An artifact from a bygone era, valuable to collectors.", 100));
                player.inventory.Add(new Item("Healing Potion", "A potion that restores a significant amount of health.", 50));
                player.AddXP(50);
            }
            TextUtils.PrintWithDelay("Where would you want to head to?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the marketplace", MiceGoToShop),
                new Choice("Talk to a town guard", MiceTalkToTownGuard),
                new Choice("Leave the city", ExitMice)
            };
            SelectOptions(choices);
        }
        private void MiceExploreAlleyways()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You venture into the dark and narrow alleyways of the city. The atmosphere is eerie, ");
            TextUtils.PrintWithDelay("and you can't shake the feeling that you're being watched.");
            TextUtils.PrintWithDelay("Suddenly, a group of thugs appears and demands your money!");

            List<Choice> choices = new List<Choice>()
            {
              new Choice("Fight the thugs", MiceFightThugs),
              new Choice("Try to run away", MiceRunFromThugs)
            };
            SelectOptions(choices);
        }

        private void MiceFightThugs()//CHECKED IN DRAW
        {
            exploreAlleys = true;
            BasicHumanoid thug1 = new BasicHumanoid(10, "Thug 1", 0, 55, 15);
            player.Battle(thug1);
            BasicHumanoid thug2 = new BasicHumanoid(10, "Thug 2", 1, 60, 10);
            player.Battle(thug2);
            TextUtils.PrintWithDelay("After finishing those two thugs, you take some rest");
            player.Resting(6);
            TextUtils.PrintWithDelay("Where would you like to go next?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Visit the marketplace", MiceGoToShop),
                new Choice("Leave the city", ExitMice)
            };
            if (!exploreBuilding)
            {
                choices.Add(new Choice("Enter a mysterious building", MiceExploreMysteriousBuilding));
            }
            if (!exploreAlleys)
            {
                choices.Add(new Choice("Explore the alleyways", MiceExploreAlleyways));
            }
            if (!talkedToGuard)
            {
                choices.Add(new Choice("Talk to a town guard", MiceTalkToTownGuard));
            }
            SelectOptions(choices);
        }

        private void MiceRunFromThugs()//CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You decide to run away from the thugs, avoiding a fight you don't want part of.");
            TextUtils.PrintWithDelay("You run and escape, but not without losing some gold in the process - some gold slipped out!");
            player.gold -= 10;
            if (player.gold < 0) player.gold = 0;
            MiceKeepExploringTheCity();
        }
        private void MiceGoToShop()// CHECKED IN DRAW
        {
            Shop shop = new Shop();
            shop.itemsInShop.Add(new HealthPotion("Minor Health Potion", " will heal you for 1D6 health points", 25, 1, 6, 0));
            shop.itemsInShop.Add(new HealthPotion("Regular Health Potion", " will heal you for 2D6 health points", 45, 2, 12, 0));
            shop.itemsInShop.Add(new HealthPotion("Big Health Potion", " will heal you for 3D6 + 2 health points", 60, 3, 18, 2));
            shop.itemsInShop.Add(new Weapon("Great Iron Sword", " made of real iron, will deal 2D8 damage", 75, 2, 16, 0));
            shop.itemsInShop.Add(new Weapon("Dual Swords", " two blades that can sync with each other, will do 3D4 + 1 damage", 55, 3, 12, 1));
            shop.itemsInShop.Add(new Item("Sharpening tool", " will increase your damage modify by 1", 35));
            shop.itemsInShop.Add(new Scroll("Firebolt", " a simple yet effective spell, will launch firebolt and do 2D6 damage", 30, 2, 12, 0));
            shop.itemsInShop.Add(new Scroll("Fireball", " a more complex spell. Will launch a gigantic fireball at " +
                "enemy, will do 2D10 +2 damage", 55, 2, 20, 2));
            shop.itemsInShop.Add(new Scroll("Lightning Strike", " a more traditioned spell which will launch electricity at " +
                "enemies, deals 3D6 -1 damage", 40, 3, 18, -1));
            shop.itemsInShop.Add(new Scroll("Ice Shards", " will throw at enemies a few ice shards, deals 2D12 + 1 damage", 60, 2, 24, 1));
            shop.EnteringShop(player, "You enter the big shop, which seems to be well equipped", ExitTheShop);
            TextUtils.PrintWithDelay("Where would you go now?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Exit the city", ExitMice),
                new Choice("Keep exploring a bit more", MiceKeepExploringTheCity)
            };
            SelectOptions(choices);
        }
        private void ExitTheShop()
        {
            TextUtils.PrintWithDelay("You have exited the shop");
        }
        private void MiceSleepingInTavern()// CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You enter the tavern, see what you can get offered. The tavern's owner,");
            TextUtils.PrintWithDelay("a middle-aged man with elegant wear, looks at you. 'Hello " + player.name + "!' he greets you.");
            TextUtils.PrintWithDelay("How come he also knows your name? Such confusion.");
            TextUtils.PrintWithDelay("'A night on its own would cost you 30, but I assure you it's the best night you'll have. As for");
            TextUtils.PrintWithDelay("a least expensive one, you can also check out our less premium rooms, " +
                "which would cost 15. As for a meal, those");
            TextUtils.PrintWithDelay("are being made by our best cook. Those dishes are expensive but will revive your soul!' " +
                "he says. A meal will cost 25");
            TextUtils.PrintWithDelay("What would you like to do?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Get something to eat", MiceTavernEat),
            };
            if (player.gold >= 15)
            {
                choices.Add(new Choice("Get the cheap room to sleep at", MiceTavernPayCheap));
                if (player.gold >= 30)
                {
                    choices.Add(new Choice("Get the expensive room to sleep", MiceTavernPayExpensive));
                }
            }
            SelectOptions(choices);
        }
        private void MiceTavernEat() // CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You exit from the back of the tavern to a small unit, gettint to the room. There is a cook over there");
            TextUtils.PrintWithDelay("with a table prepared. You don't see anyone else there, just him. 'Well well what do we have here");
            TextUtils.PrintWithDelay("says the chef. He is equipped with a butcher's knife, in a kitchen, that seems to be quite big.");
            TextUtils.PrintWithDelay("If you thought you're getting dinner - think again. It's you who we will be cooking " + player.name + "!'");
            TextUtils.PrintWithDelay("He swings his butcher knife and comes to attack you. Prepare for a battle!");
            BasicHumanoid chef = new BasicHumanoid(12, "Cook", 2, 65, 30);
            player.Battle(chef);
            TextUtils.PrintWithDelay("After killing the violent chef, you notice a chest in the kitche. Do you have a key?");
            if (player.keys > 0)
            {
                player.keys--;
                player.inventory.Add(new HealthPotion("Basic Health Potion", " will heal you for 2D6 health points", 30, 2, 12, 0));
            }
            TextUtils.PrintWithDelay("You get back to the tavern, and it seems you passed out a test of some kind.");
            TextUtils.PrintWithDelay("The tavern owner looks at you impressed, and asks - which room would you take for free tonight?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Get the expensive room to sleep", MiceTavernExpensiveRoom),
                new Choice("Get the cheap room to sleep at", MiceTavernCheapRoom)
            };
            SelectOptions(choices);
        }
        private void MiceTavernPayCheap()//CHECKED IN DRAW
        {
            player.gold -= 15;
            MiceTavernCheapRoom();
        }

        private void MiceTavernPayExpensive()//CHECKED IN DRAW
        {
            player.gold -= 30;
            MiceTavernExpensiveRoom();
        }
        private void MiceTavernExpensiveRoom() //CHECKED IN DRAW
        {
            TextUtils.PrintWithDelay("You get to the room, quite big and filled with lots of carpets, a balcony, and other expensives");
            TextUtils.PrintWithDelay("You notice there is a chest - and you want to open it. Do you have a key?");
            if (player.keys > 0)
            {
                player.keys--;
                player.inventory.Add(new Weapon("Nimbus Dagger", " a ferocious dagger, made of titanium " +
                    "and magic, does 2D8 +3 damage", 60, 2, 16, 3));
            }
            TextUtils.PrintWithDelay("You get into your bed, exhausted from the day.");
            player.Resting(7);
            TextUtils.PrintWithDelay("When the morning rises, you take your steps out to the streets");
            TextUtils.PrintWithDelay("Where would you go now?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Exit the city", ExitMice),
                new Choice("Keep exploring a bit more", MiceKeepExploringTheCity)
            };
            SelectOptions(choices);
        }
        private void MiceTavernCheapRoom() //ADDED TO DRAW
        {
            TextUtils.PrintWithDelay("You enter the room, which isn't quite big but this will fit, you think to yourself.");
            TextUtils.PrintWithDelay("Leaving yourself to a good night's sleep, you take your time to rest and recover");
            player.Resting(5);

            TextUtils.PrintWithDelay("Where would you go now?");
            List<Choice> choices = new List<Choice>()
            {
                new Choice("Exit the city", ExitMice),
                new Choice("Keep exploring a bit more", MiceKeepExploringTheCity)
            };
            SelectOptions(choices);
        }
        public void SelectOptions(List<Choice> choices)
        {
            TextUtils.PrintWithDelay("You can press 'I' to view inventory, 'S' to view stats or 'P' to use potions at any time.");
            while (true)
            {
                TextUtils.PrintWithDelay("Choose an option:");

                for (int i = 0; i < choices.Count; i++)
                {
                    TextUtils.PrintWithDelay($"{i + 1}. {choices[i].Description}");
                }

                string input = Console.ReadLine();

                if (input.Equals("I", StringComparison.OrdinalIgnoreCase))
                {
                    player.DisplayItems();
                }
                else if (input.Equals("P", StringComparison.OrdinalIgnoreCase))
                {
                    player.ChoosePotion();
                }
                else if (input.Equals("S", StringComparison.OrdinalIgnoreCase))
                {
                    player.ViewStats();
                }
                else if (int.TryParse(input, out int choice) && choice >= 1 && choice <= choices.Count)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    choices[choice - 1].Method();
                    return;
                }
                else
                {
                    TextUtils.PrintWithDelay("Invalid choice. Please enter a valid option.");
                }
            }
        }

    }

    public class Choice
    {
        public string Description { get; set; }
        public Action Method { get; set; }
        public Choice(string description, Action method)
        {
            Description = description;
            Method = method;
        }
    }

    public class TextUtils
    {
        public static void PrintWithDelay(string text, int delay = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(delay);
            }
            Console.WriteLine();
        }
    }
}
/*
  Final project description: text-based RPG

  Concept: Players navigate a story through text prompts and user input.
  They encounter choices that affect the narrative and lead to different endings.

  level 0: Pre-defined story with multiple choice options (maximal grade: 60)
  level 1: Allow players to name their character, use that name in game prompts and introduce simple inventory management.
          Like obtaining keys to open certain doors (maximal grade: 80)
  level 2: Implement combat mechanics with basic math calculations for damage and health. (maximal grade: 100)
          Game will include combat encounters with selectable options for fighting.
          For example: "The goblin winds up for a big attack!" "options: 1) dodge 2) block 3) charge in!"

  Bounty hunts: 
      - Used a relevant design pattern - 10 points
      - Set character stats that effect the story - 10 points
      - Have static functions for the game (specific input to reset the game, show inventory etc.)  - 10 points
      - Basic and more in depth room descriptions given if the player stays or looks around - 10 points
      - Have at least 3 different items with different logic - 10 points
      - At least 2 easter eggs (if you turn left 4 times in a row or stay in the same room 3 times) - 10 points
 */


/* 1.1 The reviving spell contains secrets. As you might have been thinking of it, it might just appear. While from another world, 
there is a direct connection to here.1.1 2.2 When thinking of light, create darkness. While summoning life think of death. While in a ritual...
Pray for sacrifice. It has to have the deepest connections between them.2.2 3.3 If not for this dagger, I don't know how would I be resurrecting them
but you can't ever know what would you find.3.3 4.4  Any mythic weapon would do. But behold - every resurrection comes with deep connection. 
Every feel the revived one's feeling - you would feel as well.4.4 5.5  Be careful on such a spell, thus he does not hold back and no steps back can 
ever happen once you have completed it. 5.5 6.6 A death would mean gambling your life in fron of the devil and god. You are oath to try it - but be wise. 6.6
*/