using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Recipe> recipes = new List<Recipe>();

        Recipe recipe1 = new Recipe("", "", "");
        Recipe recipe2 = new Recipe("", "", "");

        Console.WriteLine("Enter details for recipe 1: ");
        recipe1.CreateRecipe();
        recipes.Add(recipe1);

        Console.WriteLine("Enter details for recipe 2: ");
        recipe2.CreateRecipe();
        recipes.Add(recipe2);

        string filePath = "recipes.csv";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("item, ingredient, instructions");
            foreach (Recipe recipe in recipes)
            {
                writer.WriteLine(recipe.ToCsv());
            }
        }
    }
}