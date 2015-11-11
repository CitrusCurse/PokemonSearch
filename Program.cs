using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variable Decalration
            string input;
            char response;
            FileStream infile = new FileStream("pkmnList.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(infile);
            string[] pokemonNames = new string[722];
            #endregion

            #region Stream Reader: Array
            for (int i = 0; i < pokemonNames.Length; i++)
                pokemonNames[i] = reader.ReadLine();
            #endregion

            do
            {
                #region Program Loop
                Console.WriteLine("Welcome to the PokemonSearch Console App!\nAre you searching by Pokemon name or by Pokemon dex number? (name or dex)");
                input = Console.ReadLine();
                input = input.ToLower();

                if (input != "name" && input != "dex")
                {
                    Console.WriteLine("Are you searching by name or dex number? (name or dex) ");
                    input = Console.ReadLine();
                    input = input.ToLower();
                }

                if (input == "name")
                    SearchByName(pokemonNames);

                if (input == "dex")
                    SearchByDex(pokemonNames);

                Console.WriteLine();
                Console.Write("Would you like to run another search? (y or n) ");
                response = char.ToLower(Convert.ToChar(Console.ReadLine()[0]));
                Console.WriteLine();
                #endregion

            } while (response == 'y');

            #region Credits and Closing the Stream
            Console.WriteLine("This application was coded by Kristina Powell");
            reader.Close();
            infile.Close();
            #endregion
        }

        static void SearchByDex(string [] pokemonNames)
        {
            #region Dex Code
            int dexSearch;

            Console.Write("Please enter a Pokedex number. ");
            dexSearch = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < pokemonNames.Length; i++)
            {
                if (dexSearch == i)
                {
                    Console.WriteLine("The Pokemon at Pokedex entry {0} is {1}.", i, pokemonNames[i]);
                }

                if (i > pokemonNames.Length || dexSearch == 0)
                {
                    Console.WriteLine("I'm sorry, a matching entry could not be found.");
                    break;
                }
            }
            #endregion
        }

        static void SearchByName(string [] pokemonNames)
        {
            #region Name Code
            string nameSearch;
            char firstChar;

            Console.Write("Please enter a Pokemon name. ");
            #region All Lower -> First Upper & Rest Lower Conversion
            nameSearch = Console.ReadLine();
            nameSearch = nameSearch.ToLower();
            firstChar = char.ToUpper(nameSearch[0]);
            nameSearch = nameSearch.Substring(1);
            nameSearch = firstChar + nameSearch;
            #endregion

            for (int i = 1; i < pokemonNames.Length; i++)
            {
                if (nameSearch == pokemonNames[i])
                {
                    Console.WriteLine("{0}'s Pokedex number is {1}.", nameSearch, i);
                }

                if (!(pokemonNames.Contains(nameSearch)) || nameSearch == "Void")
                {
                    Console.WriteLine("I'm sorry, a matching entry could not be found.");
                    break;
                }
            }
            #endregion
        }
    }
}
