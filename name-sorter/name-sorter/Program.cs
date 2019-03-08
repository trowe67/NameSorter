using System;
using Helpers;


namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Check the arguments...
            if (args.Length == 0)
            {
                // No argument found, so give the user a clue
                System.Console.WriteLine("name-sorter : No file name argument found");
                System.Console.WriteLine("name-sorter command format: name-sorter.exe <file-to-be-sorted>");
                Environment.Exit(-1);
            }

            // First argument is expected to be the file name. See if it exists...
            if (System.IO.File.Exists(args[0]))
            {
                string file_name = args[0];

                // Create a read interface
                ReadInterface name_source = new FileRead();

                // Get the names from the input file
                string[] names = name_source.getNames(file_name);

                // Create a sort interface
                SortInterface sorter = new NameSorter();

                // Sort the names (in ascending order)
                string[] sorted_names = sorter.sortNames(names, true);

                // Write the sorted names to the screen
                System.Console.WriteLine(String.Join("\r\n", sorted_names));

                // Wrute the sorted names to the required file
                System.IO.File.WriteAllLines(@"sorted-names-list.txt", sorted_names);
            }
            else
            {
                // File doesn't exist, so tell the user
                string message = "name-sorter : The file '" + args[0] + "' was not found!";
                System.Console.WriteLine(message);
                Environment.Exit(-1);
            }
            Environment.Exit(0);
        }
    }
}
