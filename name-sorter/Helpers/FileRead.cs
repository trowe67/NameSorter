using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class FileRead : ReadInterface
    {
        public string[] getNames(string file_name)
        {
            if (System.IO.File.Exists(file_name))
            {
                // read in all the names
                string[] names = System.IO.File.ReadAllLines(file_name);
                return names;
            }
            else
            {
                return null;
            }
        }
    }
}
