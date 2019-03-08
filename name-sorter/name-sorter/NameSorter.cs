using System;
using System.Linq;
using Helpers;

namespace name_sorter
{
    public class NameSorter : SortInterface
    {
        public string[] sortNames(string[] unsorted_names, bool isAscending)
        {
            if (isAscending)
            {
                // Order by ascending
                return unsorted_names.OrderBy(name => getLastOtherNames(name)).ToArray();
            }
            else
            {
                // Order by descending
                return unsorted_names.OrderByDescending(name => getLastOtherNames(name)).ToArray();
            }
        }

        private string getLastOtherNames(string full_name)
        {
            // This assumes the name is of the form 'Janet Parsons', where the last name is the last in the string
            string[] full_names = full_name.Split(' ');

            // The requirement is for there to be up to 4 names in a person's full name
            if (String.IsNullOrWhiteSpace(full_name) || full_names.Length == 0 || full_names.Length > 4)
            {
                Console.Error.WriteLine("Invalid name found: '" + full_name + "'");
                return null;
            }

            // get last name
            string last_name = full_names.Last();

            // get other names
            string other_names = String.Join(" ", full_names.Take(full_names.Length - 1).ToArray());

            // return the concatenation
            return last_name + " " + other_names;
        }
    }
}
