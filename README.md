# NameSorter
Simple Name Sorter program written in C#

This program runs on the cmd line and takes one argument - a file-name which contains a list of names.
name-sorter.exe <unsorted-file>
The program will order that list by last name, then given names and print the names out to the screen.

A name must have from 0 to 3 given names and one last name.

The program will create a file in the working directory called sorted-names-list.txt (not configurable) and this will contain
 the list of names sorted in ascending order.
 
 Some unit tests exist to test the sorting is correct and whether the program works correctly for large files and large names.
