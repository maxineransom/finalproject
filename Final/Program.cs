using System;
using System.IO;
using System.Collections.Generic;

// Class for ingredients
public class Ingredient
{
    public string Gredient { get; set; }

    public Ingredient(string ingredient)
    {
        Gredient = ingredient;
    }
}

// Class for recipes
public class Recipe
{
    public string Gredient { get; set; }
    public string Item { get; set; }
    public string Instructions { get; set; }

    public Recipe(string item, string ingredient, string instructions)
    {
        Item = item;
        Gredient = ingredient;
        Instructions = instructions;
    }

    public string ToCsv()
    {
        return $"{Item},{Gredient},{Instructions}";
    }
}

public class Program
{
    private static List<Ingredient> ingredients = new List<Ingredient>(); 
    private static List<Recipe> recipes = new List<Recipe>();

    public static void Main(string[] args) //Main method
    {
        while (true)
        {
            Console.WriteLine("Please input the number that corresponds with your need:");
            Console.WriteLine("1: Display all recipes");
            Console.WriteLine("2: Search a recipe");
            Console.WriteLine("3: Add a recipe to the database");
            Console.WriteLine("4: Add a new ingredient to the list");
            Console.WriteLine("5: Leave Program");

            string response = Console.ReadLine().ToUpper();

            switch (response)
            {
                case "1":
                    DisplayRecipes();
                    break;
                case "2":
                    SearchRecipe();
                    break;
                case "3":
                    AddRecipe();
                    break;
                case "4":
                    AddIngredient();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Please put a number propted!!!");
                    break;
            }
        }
    }

    static void DisplayRecipes()
    {
        Console.WriteLine("\nList of Recipes:");
        foreach (var recipe in recipes)
        {
            Console.WriteLine(recipe.ToCsv());
        }
    }

    static void SearchRecipe()
{
    Console.WriteLine("Enter recipe:");
    string searchQuery = Console.ReadLine();
    var foundRecipe = recipes.Find(r => r.Item.ToLower() == searchQuery.ToLower());
    if (foundRecipe != null)
    {
        Console.WriteLine(foundRecipe.ToCsv());
    }
    else
    {
        Console.WriteLine("Recipe not found.");
    }
}

    static void AddRecipe()
    {
        Console.WriteLine("First, what are you making?");
        string item = Console.ReadLine();
        Console.WriteLine("Please input all ingredients used in this recipe.");
        string ingredient = Console.ReadLine();
        Console.WriteLine("Please provide instructions.");
        string instructions = Console.ReadLine();

        recipes.Add(new Recipe(item, ingredient, instructions));
        Console.WriteLine("Recipe added successfully!");
    }

    static void AddIngredient() //Tends to compile errors, lacking source code
    {
        Console.WriteLine("What are you adding to the ingredient database?");

            string ingredientGredient = Console.ReadLine();
            ingredients.Add(new Ingredient(ingredientGredient));

        Console.WriteLine("Ingredient added successfully!");
    }
}