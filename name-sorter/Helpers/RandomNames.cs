using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class RandomNames
    {
        private static String chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'";
        private static Random rand = new Random();

        // Create a random name of max_Length chars
        // Private only called from nameList()
        private static String createName(int max_length)
        {
            var created_name = new StringBuilder();
            int num_names = rand.Next(4) + 1; //1,2,3,4

            for (int name_count = 0; name_count < num_names; name_count++)
            {
                for (int char_count = 0; char_count < rand.Next(max_length); char_count++)
                {
                    created_name.Append(chars[rand.Next(chars.Length)]);
                }

                // We need to add a space between each name
                if (name_count < num_names)
                {
                    created_name.Append(" ");
                }
            }
            return created_name.ToString();
        }

        //Create a list of random names of num_names, each of max length max_length
        // Public - called by UnitTests

        public static string[] nameList(int num_names, int max_length)
        {
            var names = new string[num_names];
            for (int name_count = 0; name_count < num_names; name_count++)
            {
                names[name_count] = createName(max_length);
            }
            return names;
        }
    }
}
