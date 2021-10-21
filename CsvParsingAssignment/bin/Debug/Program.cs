/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Name :Abhishek Jayawantrao Patil 
//Profile : JULY 2021 INTERN
//    last edit :8/10/2021 12:00PM
//_________________________________________________________________________________________________________________
//   Assignment 3
//          1.List1 has surname, list2 has actual name, create a dictionary with both lists and display full names.
//                  
//_________________________________________________________________________________________________________________


using System;
using System.Collections.Generic;
using System.Linq;

namespace two_list_to_dict
{
    class Program1
    {
        static void Main(string[] args)
        {
            bool is_Success = false;
            try
            {
                List<string> keys = new List<string>() { "abhishek", "Ramesh", "Suresh" };
                List<string> values = new List<string>() { "Patil", "More", "Samba" };
                Console.WriteLine("First Names list:");
                Console.WriteLine();
                foreach (string var1 in keys)
                {
                    Console.WriteLine(var1);
                }
                Console.WriteLine();
                Console.WriteLine("Last Names list:");
                foreach (string var2 in values)
                {
                    Console.WriteLine(var2);
                }
                Console.WriteLine();
                Console.WriteLine();
                if (keys.Count == 0 || values.Count == 0)
                {
                    Console.WriteLine("\n no(keys): {0} and no(Values): {1} ,so either one of them is null or empty", keys.Count, values.Count);
                }
                else
                {
                    if (keys.Count != values.Count)
                    {
                        Console.WriteLine("\n no(keys): {0} and no(Values): {1} are not having equal length.", keys.Count, values.Count);
                    }
                    else
                    {
                        var dict = Enumerable.Range(0, keys.Count).ToDictionary(i => keys[i], i => values[i]);
                        foreach (KeyValuePair<string, string> dict_var in dict)
                        {
                            Console.WriteLine("\nFull Name:{0} {1}", dict_var.Key, dict_var.Value);
                        }
                        is_Success = true;
                    }
                }                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (is_Success)
                {
                    Console.WriteLine("\nPROGRAM SUCCESSFULLY EXECUTED");
                }
                else
                {
                    Console.WriteLine("\nPROGRAM NOT* SUCCESSFULLY EXECUTED");
                }
                Console.ReadKey();
            }
        }
    }
}
