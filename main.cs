using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;

class MainClass {
//Methods

  public static void Main (string[] args) {

		//Objects to initialize
		Random random = new Random();

    //Variables
    List<string> inven = new List<string>();
		inven.Add("earth");
		inven.Add("fire");
		inven.Add("air");
		inven.Add("water");

		SortedList<string, string> combosAndRecipes = new SortedList<string, string>();
			//Initializing the main variable that stores all of the unlockable items and their correspoding recipes

		string[] combosAndRecipesArray = new [] {
			"fire+fire", "energy", "land+land", "continent", "solarsystem+solarsystem", "galaxy", "aminoacids+energy", "life",
			"earth+earth", "dirt",	"continent+continent", "globe", "galaxy+galaxy", "*universe*", "life+dirt", "plant",
			"earth+energy", "earthquake", "globe+atmosphere", "planet", "sun+pressure", "*blackhole*", "plant+fire", "ash",
			"water+earth", "mud", "water+water", "ocean", "wind+wind", "*tornado*", "ash+pressure", "coal",
			"water+dirt", "mud",	"dust+dust", "minerals", "clay+fire", "brick", "coal+pressure", "diamond",
			"mud+fire", "clay",	"fire+planet", "sun", "brick+brick", "wall", "plant+dirt", "tree",
			"energy+air", "wind", "sun+cloud", "sky", "wall+wall", "home", "tree+human", "wood",
			"wind+earth", "dust", "ocean+minerals", "aminoacids", "home+home", "village", "wood+human", "tool",
			"fire+water", "steam", "aminoacids+sun", "life", "village+village" + "city", "rock+human", "tool",
			"water+air", "mist", "water+land", "river", "city+city", "metropolis", "wood+wood", "home", 
			"steam+air", "cloud", "water+continent", "ocean", "metropolis+metropolis", "population", "tool+fish", "*sushi*",
			"fire+air", "pressure", "energy+cloud", "storm", "rock+water", "sand", "tool+bird", "*fried chicken*",
			"earth+air", "dust", "storm+energy", "lightning", "life+land", "animal", "tool+planet", "rocket ship",
			"dirt+dirt", "land", "cloud+water", "rain", "animal+clay", "human", "rain+rock", "dust",
			"air+air", "atmosphere", "lava+water", "rock", "aniaml+fire", "*phoenix*", "rain+earth", "mud",
			"earthquake+earth", "mountain", "wind+rock", "dust", "aniaml+water", "fish", "lava+air", "obsidian",
			"earth+fire", "lava", "water+dust", "cloud", "animal+air", "bird", "diamond+wood", "diamond pickaxe",
			"lava+mountain", "volcano", "planet+sun", "solar system", "human+human", "family", 
			"volcano+pressure", "eruption", "planet+planet", "solar system", "family+brick", "home",
			"diamondpickaxe+obsidian", "*nether portal*", "ocean+energy", "*hurricane*", "ocean+wind", "hurricane",
			"continent+energy", "earthquake", "fire+wood", "fire", "lava+wood", "fire", "planet+plant", "earth","earth+rock","*moon*",
			"river+animal", "frog", "frog+tool", "*frog legs*", "sand+sand", "beach", "beech+tree", "*palm tree*",
			"sand+fire", "glass", "glass+glass", "glasses", "glass+earth", "*terrarium*", "glass+water", "*aquarium*",
			"rock+tool", "metal", "metal+glass", "microscope", "microscope+life", "bacteria", "bacteria+animal", "disease", 
			"bacteria+human", "disease", "disease+human", "death", "disease+animal", "death", "death+rock", "tomstone", 
		};
			//A collection of the actual recipes, but in an array to help add these objects into combosAndRecipes SortedList
		
		//Converting the array to the SortedList
		string prevKey = "";
		string prevValue = "";
		bool hasPrevKey = false;
		bool hasPrevValue = false;
		foreach(string recipeItem in combosAndRecipesArray) {
			if (recipeItem.Contains("+")) {
				prevKey = recipeItem;
				hasPrevKey = true;
			} else {
				prevValue = recipeItem;
				hasPrevValue = true;
			}
			if (hasPrevKey && hasPrevValue) {
				combosAndRecipes.Add(prevKey, prevValue);
				hasPrevKey = false;
				hasPrevValue = false;
			}
		}

		int numRepeats = 0;
		IList<string> allValue = combosAndRecipes.Values;
		
		numRepeats = allValue.Count() - allValue.Distinct().Count();


    bool running = true;
		bool runIntro = true;

    //Variables containing arrays of possible inputs
    string[] possExitCodes = new string[5] {"exit", "leave", "quit", "q", "e"}; 
			//Possible input codes for quiting the game

    string[] possInvenCodes = new string[4] {"inventory", "inven", "backpack", "i"};
			//Possible input codes for accessing the inventory menu

    string[] possCraftCodes = new string[3] {"c", "crafting", "craft"};
			//Possible input codes for accessing the crafting menu

		string[] possHelpCodes = new string[2] {"help", "h"};
			//Possible input codes for accessing the help menu

		string[] possShortCutCodes = new string[3] {"shortcuts", "s", "shorts"};
			//Possible input codes for accessing the shortcuts menu
		
		string[] possHintCodes = new [] {"hint", "stuck", "idea"};
			//Possible input codes for accessing the hint menu

		//Varaibles contataing arrays of possible repsonses
		string[] possUIRps = new string[4] 
			{"Um, I don't know that", "Error Error. Cannot compute input", "Ha! Try again!", "Uh... nice try!"};
				//Possible repsonses if player inputed unknown input

		//Last minute clean up before player starts playing
		Console.Clear();

		//Conducting the into to the game
		Console.WriteLine("Welcome to the wonderful game of crafting! \nWould you like to know how to play? (Y / N)");
		while (runIntro) {
			Console.Write(">> ");
			string input = Console.ReadLine().ToLower();
			input = input.Replace(">> ", "");

			if (input == "n") {
				runIntro = false;
				Console.WriteLine("Okay! Good luck, and have fun!\n");
			} else if (input == "y") {
				Console.WriteLine("As you may already know, this is a game where you combine two items together to craft, or discover, another item. This new item can possibly be an ingredient for another crafting recipe. \nIf an item has an astrisk (*) by their name, that means that it isn't an ingredient for another recipe. \n\nYou can access different menus that provide different information. For instance, type \"inven\" (without the quotes), and you can see the items you have discovered. The menu you will spend most of you time with will be the crafting menu, you can access it by typing \"craft\". If you have any questions, just type \"help\" to see the full list of possible inputs. \nIf you ever get stuck, don't worry! Type \"hint\" to access the hint menu.\nPress the ENTER key to begin.");
				Console.ReadLine();
				Console.WriteLine("Good luck, and have fun!\n");
				runIntro = false;
			} else {
				Console.WriteLine("(Y / N)");
			}
		}
    //Main loop for the game
    while (running)
    {
			Console.WriteLine("What would you like to do? Type \"help\" if you ever need it (without the quotes).");
			Console.Write(">> ");
      string input = Console.ReadLine().ToLower().Replace(">> ", "").Replace(" ", "");

      if (possExitCodes.Contains(input)) {
        running = false;
        break;

      } else if (possCraftCodes.Contains(input)) { //The Crating Center
					Console.WriteLine("Give two ingredients you want to craft with:\n");
					Console.Write("Ingredient 1: ");
					string firstIngredientInput = Console.ReadLine().ToLower().Replace("Ingredient 1: ", "").Replace(" ", "");
					
					Console.Write("Ingredient 2: ");
					string secondIngredientInput = Console.ReadLine().ToLower().Replace("Ingredient 2: ", "").Replace(" ", "");
					Console.WriteLine("");

					bool hasIngredOne = false;
					bool hasIngredTwo = false;

					string[] tempInven = inven.ToArray();

					foreach(string invenItem in tempInven) {
						tempInven[Array.IndexOf(tempInven, invenItem)] = tempInven[Array.IndexOf(tempInven, invenItem)].Replace(" ", "");
					}

					if (tempInven.Contains(firstIngredientInput)) {
						hasIngredOne = true;
					} else {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("You don't have " + firstIngredientInput);
						Console.ResetColor();
					}
					if (tempInven.Contains(secondIngredientInput)) {
						hasIngredTwo = true;
					} else {
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("You don't have " + secondIngredientInput);
						Console.ResetColor();
					}

					if (hasIngredOne && hasIngredTwo) {
						string combinedIngredOne = firstIngredientInput + "+" + secondIngredientInput;
						string combinedIngredTwo = secondIngredientInput + "+" + firstIngredientInput;

						if (combosAndRecipes.ContainsKey(combinedIngredOne) || combosAndRecipes.ContainsKey(combinedIngredTwo)) {
							string trueIngredCombo;
							if (combosAndRecipes.ContainsKey(combinedIngredOne)) {
								trueIngredCombo = combinedIngredOne;
							} else {
								trueIngredCombo = combinedIngredTwo;
							}
							if (inven.Contains(combosAndRecipes[trueIngredCombo])) {
								Console.ForegroundColor = ConsoleColor.Red;
								Console.WriteLine("You have already discovered " + combosAndRecipes[trueIngredCombo].ToUpper());
								Console.ResetColor();
							} else {
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine("You have discovered " + combosAndRecipes[trueIngredCombo].ToUpper() + "!");
								inven.Add(combosAndRecipes[trueIngredCombo]);
								Console.ResetColor();
								Console.Write("\nPress ENTER to continue");
								Console.ReadLine();
							}
						} else {
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Unknown combination");
							Console.ResetColor();
						}
					}
			} else if (possInvenCodes.Contains(input))	{ //The Inventory Center
					
					Console.WriteLine("Welcome to the inventory menu. You have:\n");
				
					if (inven.Count == 0) {
							Console.WriteLine("Nothing...:\\n");
					} else {
						Console.ForegroundColor = ConsoleColor.Yellow;
						foreach(string invenItem in inven) {
							Console.Write("[" + invenItem.ToUpper() + "] ");
						}
						Console.ResetColor();
					}
					Console.WriteLine("\n\n** You have discovered " + inven.Count + "/" + (combosAndRecipes.Count + 4 - numRepeats) + " of all items **");
					Console.Write("\nPress ENTER to continue");
					Console.ReadLine();
			} else if (possHelpCodes.Contains(input)) { //The Help Center
					Console.WriteLine("Welcome to the help center! Here, you can find specific inputs, and their following effects.");
					Console.WriteLine("\nINPUT\t\t\tEFFECT\n\ncraft\t\t\tOpens the crafting menu\ninventory\t\tOpens the crafting menu, where most of the game takes place\nhelp\t\t\tOpens this help menu\nclear\t\t\tClears the screen of previous inputs (NOT UNDOABLE!)\nshortcuts\t\tOpens the shortcuts menu\nexit\t\t\tQuits the game (please don't leave me alone D;)\nhint\t\t\tOpens the hint menu whenever you get stuck.");

					Console.Write("\nPress ENTER to continue");
					Console.ReadLine();

			} else if (possShortCutCodes.Contains(input)) { //Shortcut center
				Console.WriteLine("Welcome to the help center! Here, you can find variations of specific inputs.");
				Console.WriteLine("\nINPUT\t\t\tSHORTCUT\n\ncraft\t\t\tc, crafting\ninventory\t\ti, inven, backback\nhelp\t\t\th\nshortcuts\t\ts, shorts\nhint\t\t\tstuck, idea");
			
			} else if (input == "clear") {
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Are you sure? (Y / N)");
				Console.Write(">> ");
      	input = Console.ReadLine().ToLower().Replace(">> ", "").Replace(" ", "");

				if (input == "y") {
					Console.Clear();
				}
				Console.ResetColor();
			} else if (possHintCodes.Contains(input)) { //The Hint Center
				Console.WriteLine("Welcome to the hint center! Whenever you get stuck, just come here!");
				
				IList<string> allPossItems = combosAndRecipes.Values;
				string[] invenArray = inven.ToArray();
				string hint;

				do {
					hint = allPossItems[random.Next(allPossItems.Count)];
				} while (invenArray.Contains(hint));
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("\nTry to get the item: " + hint.ToUpper());
				Console.ResetColor();

				Console.Write("\nPress ENTER to continue");
				Console.ReadLine();
			} else {
				Console.ForegroundColor = ConsoleColor.Red;
				int randInt = random.Next(possUIRps.Length);
				Console.WriteLine(possUIRps[randInt]);
				Console.ResetColor();
			}
			Console.Write("\n");
    }

    Console.WriteLine("Successfully shut down");

  }
}