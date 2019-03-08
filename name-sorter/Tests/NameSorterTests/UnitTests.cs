using System;
using name_sorter;
using Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NameSorterTests
{
    [TestClass]
    public class UnitTests
    {
        private readonly NameSorter _nameSorter;

        public UnitTests()
        {
            _nameSorter = new NameSorter();
            
        }

        [TestMethod]
        public void SortTestAscending()
        {
            string[] names = { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter" };
            Assert.AreEqual("Marin Alvarez,Adonis Julius Archer,Beau Tristan Bentley,Hunter Uriah Mathew Clarke,Leo Gardner,Vaughn Lewis,London Lindsey,Mikayla Lopez,Janet Parsons,Frankie Conner Ritter,Shelby Nathan Yoder", String.Join(",", _nameSorter.sortNames(names, true)));

        }

        [TestMethod]
        public void SortTestDescending()
        {
            string[] names = { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter" };
            Assert.AreEqual("Shelby Nathan Yoder,Frankie Conner Ritter,Janet Parsons,Mikayla Lopez,London Lindsey,Vaughn Lewis,Leo Gardner,Hunter Uriah Mathew Clarke,Beau Tristan Bentley,Adonis Julius Archer,Marin Alvarez", String.Join(",", _nameSorter.sortNames(names, false)));

        }

        [TestMethod]
        public void SortTestNothing()
        {
            string[] nothing = new string[0];
            Assert.AreEqual("", String.Join(",", _nameSorter.sortNames(nothing, true)));
        }

        [TestMethod]
        public void EmptyFileTest()
        {
            string[] input = { "" };
            System.IO.File.WriteAllLines(@"blank.txt", input);
            ReadInterface name_source = new FileRead();

            // Get the names from the input file
            string[] names = name_source.getNames(@"blank.txt");
            // Create a sort interface
            SortInterface sorter = new NameSorter();

            // Sort the names (in ascending order)
            string[] sorted_names = sorter.sortNames(names, true);
            System.IO.File.WriteAllLines(@"sorted-names-list.txt", sorted_names);
            
            //Check asserts
            Assert.IsTrue(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            Assert.AreEqual(input.Length, output.Length);
            System.IO.File.Delete(@"blank.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
        }

        [TestMethod]
        public void LargeFileTest()
        {
            string[] input = { "Janet Parsons", "Vaughn Lewis", "Adonis Julius Archer", "Shelby Nathan Yoder", "Marin Alvarez", "London Lindsey", "Beau Tristan Bentley", "Leo Gardner", "Hunter Uriah Mathew Clarke", "Mikayla Lopez", "Frankie Conner Ritter", "Joshua" };
            
            // write it 10000 times
            for (int i = 0; i < 10000; i++)
            {
                System.IO.File.AppendAllLines(@"large.txt", input);
            }
         
            ReadInterface name_source = new FileRead();

            // Get the names from the input file
            string[] names = name_source.getNames(@"large.txt");
            // Create a sort interface
            SortInterface sorter = new NameSorter();

            // Sort the names (in ascending order)
            string[] sorted_names = sorter.sortNames(names, true);
            System.IO.File.WriteAllLines(@"sorted-names-list.txt", sorted_names);

            //Check asserts
            Assert.IsTrue(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output = System.IO.File.ReadAllLines(@"sorted-names-list.txt");
            Assert.AreEqual(input.Length * 10000, output.Length);
            System.IO.File.Delete(@"large.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
        }

        [TestMethod]
        public void LargeFileRandomNamesTest()
        {
            string[] input = RandomNames.nameList(10000, 100);
            System.IO.File.WriteAllLines(@"large_random.txt", input);

            ReadInterface name_source = new FileRead();

            // Get the names from the input file
            string[] names = name_source.getNames(@"large_random.txt");
            // Create a sort interface
            SortInterface sorter = new NameSorter();

            // Sort the names (in ascending order)
            string[] sorted_names = sorter.sortNames(names, true);
            System.IO.File.WriteAllLines(@"sorted-names-list.txt", sorted_names);

            //Check asserts
            Assert.IsTrue(System.IO.File.Exists(@"sorted-names-list.txt"));
            string[] output = System.IO.File.ReadAllLines(@"sorted-names-list.txt");

            //Test to ensure we aren't losing characters
            Assert.AreEqual(String.Concat(input).Length, String.Concat(output).Length);

            // Test to ensure we aren't losing names
            Assert.AreEqual(input.Length, output.Length);

            System.IO.File.Delete(@"large_random.txt");
            System.IO.File.Delete(@"sorted-names-list.txt");
        }
    }
}
