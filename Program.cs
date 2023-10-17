using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Program
    {
        private static AVLTree avlTree = new AVLTree();
        private static BSTree bsTree = new BSTree();
        static void Main(string[] args)
        {
        #region --------------------------------------------------------------------------------- [ MENUS / MENU SWITCHES ] ------------------------------------------------
        #region --------------------------------------------------------------------------------- [ MAIN MENU / SWITCH ] ---------------------------------------------------
            while (true)
            {
                int opt = MainMenu();
                switch (opt)
                {
                    // Read Files into Dictionary Menu
                    case 1:
                        Console.Clear();
                        ReadIntoDictionarySwitch();
                        break;
                    // Sorting Algorithms Menu
                    case 2:
                        Console.Clear();
                        BSTSwitch();
                        break;
                    // Exit Console Program
                    case 3:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        private static int MainMenu()
        {
            int opt = 0;
            while (opt < 1 || opt > 3)
            {
                Console.WriteLine("******************* [ Main Menu ] ********************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*              1 - Reading Files Menu                *");
                Console.WriteLine("*              2 - DLL Operations Menu               *");
                Console.WriteLine("*              3 - Exit                              *");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                Console.WriteLine("Enter an Option: ");

                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }
        #endregion

        #region --------------------------------------------------------------------------------- [ READING DICTIONARY MENU / SWITCH ] -------------------------------------
        private static void ReadIntoDictionarySwitch() // Reading List
        {
            while (true)
            {
                int opt = ReadIntoDictionaryMenu();
                switch (opt)
                {
                    case 1:
                        ReadingOrderedFiles(); // Read Ordered List
                        break;
                    case 2:
                        ReadingRandomFiles(); // Read Random List
                        break;
                    case 3:
                        PrintBST(); // Print BST
                        break;
                    case 4:
                        // Return to the main menu
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        private static int ReadIntoDictionaryMenu() // Reading List Files
        {
            int opt = 0;
            while (opt < 1 || opt > 4)
            {
                Console.WriteLine("*************** [ Reading Files Menu ] ***************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*                  1 - Ordered List                  *");
                Console.WriteLine("*                  2 - Random List                   *");
                Console.WriteLine("*                  3 - Print DLL                     *");
                Console.WriteLine("*                  4 - Exit                          *");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                Console.WriteLine("Enter an Option: ");

                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }
        #endregion

        #region --------------------------------------------------------------------------------- [ BINARY SEARCH TREE MENU / SWITCH ] -----------------------------------
        private static void BSTSwitch() // Binary Seach Tree Menu
        {
            while (true)
            {
                int opt = BSTMenu();
                switch (opt)
                {
                    case 1:
                        Console.Clear();
                        DLLInsertMenuSwitch(); // Insert Submenu
                        break;
                    case 2:
                        Console.Clear();
                        FindOp();
                        break;
                    case 3:
                        PrintBST(); // Print BST
                        break;
                    case 4:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        private static int BSTMenu()
        {
            int opt = 0;
            while (opt < 1 || opt > 4)
            {
                Console.WriteLine("************ [ Binary Search Tree Menu ] *************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*               1 - Insertion Menu                   *");
                Console.WriteLine("*               2 - Find Word                        *");
                Console.WriteLine("*               3 - Print BST                        *");
                Console.WriteLine("*               4 - Main Menu                        *");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                Console.WriteLine("Enter an Option: ");

                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }

        #region INSERT SUBMENU / SWITCH
        private static void DLLInsertMenuSwitch() // Insert Menu Switch
        {
            while (true)
            {
                int opt = DLLInsertMenu();
                switch (opt)
                {
                    case 1:
                        //InsertToFront(); // Add New Word before Target
                        break;
                    case 2:
                        //InsertToRear(); // Add New Word after Target
                        break;
                    case 3:
                        //InsertBeforeNode(); // Add New Word before Target
                        break;
                    case 4:
                        //InsertAfterNode(); // Add New Word after Target
                        break;
                    case 5:
                        //FindWord(); // Find a Word
                        break;
                    case 6:
                        //PrintDLL(); // Print
                        break;
                    case 7:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        private static int DLLInsertMenu()
        {
            int opt = 0;
            while (opt < 1 || opt > 7)
            {
                Console.WriteLine("***************** [ Insertion Menu ] *****************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*               1 - Add Word To Front                *");
                Console.WriteLine("*               2 - Add Word To Rear                 *");
                Console.WriteLine("*               3 - Add Word Before                  *");
                Console.WriteLine("*               4 - Add Word After                   *");
                Console.WriteLine("*               5 - Find a Word                      *");
                Console.WriteLine("*               6 - Print DLL                        *");
                Console.WriteLine("*               7 - Back                             *");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                Console.WriteLine("Enter an Option: ");

                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }
        #endregion

        #region DELETE SUBMENU / SWITCH
        private static void DLLDeleteMenuSwitch() // Delete Menu Switch
        {
            while (true)
            {
                int opt = DLLDeleteMenu();
                switch (opt)
                {
                    case 1:
                        //DeleteFromFront(); // Remove from Front
                        break;
                    case 2:
                        //DeleteFromRear(); // Remove from Rear
                        break;
                    case 3:
                        //DeleteWord(); // Delete a Word
                        break;
                    case 4:
                        //FindWord(); // Find a Word
                        break;
                    case 5:
                        //PrintDLL(); // Print
                        break;
                    case 6:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        private static int DLLDeleteMenu()
        {
            int opt = 0;
            while (opt < 1 || opt > 6)
            {
                Console.WriteLine("***************** [ Deletion Menu ] ******************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*               1 - Delete From Front                *");
                Console.WriteLine("*               2 - Delete From Rear                 *");
                Console.WriteLine("*               3 - Delete a Word                    *");
                Console.WriteLine("*               4 - Find a Word                      *");
                Console.WriteLine("*               5 - Print DLL                        *");
                Console.WriteLine("*               6 - Back                             *");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                Console.WriteLine("Enter an Option: ");

                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }
        #endregion
        #endregion
        #endregion

        #region --------------------------------------------------------------------------------- [ OPERATIONS ] -------------------------------------

        #region --------------------------------------------------------------------------------- [ READING FILE METHODS ] ---------------------------
        static void ReadingOrderedFiles() // Read from words from an Ordered List
        {
            Console.Clear();
            #region ORDERED FILE CHOICES
            // Prompt the user to select a file
            Console.WriteLine("Select a file to read: \n");
            Console.WriteLine("***** ORDERED FILES LIST *****");
            Console.WriteLine("1. 1000-words.txt");
            Console.WriteLine("2. 5000-words.txt");
            Console.WriteLine("3. 10000-words.txt");
            Console.WriteLine("4. 15000-words.txt");
            Console.WriteLine("5. 20000-words.txt");
            Console.WriteLine("6. 25000-words.txt");
            Console.WriteLine("7. 30000-words.txt");
            Console.WriteLine("8. 35000-words.txt");
            Console.WriteLine("9. 40000-words.txt");
            Console.WriteLine("10. 45000-words.txt");
            Console.WriteLine("11. 50000-words.txt");

            // Get the user's selection
            int choice = int.Parse(Console.ReadLine());

            // Define the file path based on the user's choice
            string filePath = null;
            switch (choice)
            {
                case 1:
                    filePath = @"..\Debug\ordered\1000-words.txt";
                    break;
                case 2:
                    filePath = @"..\Debug\ordered\5000-words.txt";
                    break;
                case 3:
                    filePath = @"..\Debug\ordered\10000-words.txt";
                    break;
                case 4:
                    filePath = @"..\Debug\ordered\15000-words.txt";
                    break;
                case 5:
                    filePath = @"..\Debug\ordered\20000-words.txt";
                    break;
                case 6:
                    filePath = @"..\Debug\ordered\25000-words.txt";
                    break;
                case 7:
                    filePath = @"..\Debug\ordered\30000-words.txt";
                    break;
                case 8:
                    filePath = @"..\Debug\ordered\35000-words.txt";
                    break;
                case 9:
                    filePath = @"..\Debug\ordered\40000-words.txt";
                    break;
                case 10:
                    filePath = @"..\Debug\ordered\45000-words.txt";
                    break;
                case 11:
                    filePath = @"..\Debug\ordered\50000-words.txt";
                    break;
            }
            #endregion

            // Read the words from the file and add them to the dictionary
            string[] fileContent = System.IO.File.ReadAllLines(filePath);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (string word in fileContent)
            {
                if (word.Contains("#"))
                    continue;
                if (word.Contains(word))
                bsTree.Add(word);
            }
            sw.Stop();
            Console.WriteLine();
            Console.Clear();
            TimeSpan timespan = sw.Elapsed;
            // Print the elapsed time in minutes:seconds and as seconds
            Console.WriteLine(@"- Time taken to read: " + filePath);
            Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.ffffff") + " seconds\n");
        }

        static void ReadingRandomFiles() // Read from words from a Random List
        {
            Console.Clear();
            #region RANDOM FILE CHOICES
            // Prompt the user to select a file
            Console.WriteLine("Select a file to read: \n");
            Console.WriteLine("***** RANDOM FILES LIST *****");
            Console.WriteLine("1. 1000-words.txt");
            Console.WriteLine("2. 5000-words.txt");
            Console.WriteLine("3. 10000-words.txt");
            Console.WriteLine("4. 15000-words.txt");
            Console.WriteLine("5. 20000-words.txt");
            Console.WriteLine("6. 25000-words.txt");
            Console.WriteLine("7. 30000-words.txt");
            Console.WriteLine("8. 35000-words.txt");
            Console.WriteLine("9. 40000-words.txt");
            Console.WriteLine("10. 45000-words.txt");
            Console.WriteLine("11. 50000-words.txt");

            // Get the user's selection
            int choice = int.Parse(Console.ReadLine());

            // Define the file path based on the user's choice
            string filePath = null;
            switch (choice)
            {
                case 1:
                    filePath = @"..\Debug\random\1000-words.txt";
                    break;
                case 2:
                    filePath = @"..\Debug\random\5000-words.txt";
                    break;
                case 3:
                    filePath = @"..\Debug\random\10000-words.txt";
                    break;
                case 4:
                    filePath = @"..\Debug\random\15000-words.txt";
                    break;
                case 5:
                    filePath = @"..\Debug\random\20000-words.txt";
                    break;
                case 6:
                    filePath = @"..\Debug\random\25000-words.txt";
                    break;
                case 7:
                    filePath = @"..\Debug\random\30000-words.txt";
                    break;
                case 8:
                    filePath = @"..\Debug\random\35000-words.txt";
                    break;
                case 9:
                    filePath = @"..\Debug\random\40000-words.txt";
                    break;
                case 10:
                    filePath = @"..\Debug\random\45000-words.txt";
                    break;
                case 11:
                    filePath = @"..\Debug\random\50000-words.txt";
                    break;
            }
            #endregion

            // Read the words from the file and add them to the dictionary
            string[] fileContent = System.IO.File.ReadAllLines(filePath);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (string word in fileContent)
            {
                if (word.Contains("#"))
                    continue;
                if (word.Contains(word)) ;
                //dLList.AddToRear(word); TODO
            }
            sw.Stop();
            Console.WriteLine();
            Console.Clear();
            TimeSpan timespan = sw.Elapsed;
            // Print the elapsed time in minutes:seconds and as seconds
            Console.WriteLine(@"- Time taken to read: " + filePath);
            Console.WriteLine("Time: " + timespan.ToString(@"mm\:ss\.ffffff") + " seconds\n");
        }
        #endregion

        #region FIND OPERATION
        static void FindOp()
        {
            Console.Clear();
            Console.WriteLine("Enter the Word you'd like to find: ");
            Console.WriteLine(bsTree.Find(Console.ReadLine()));
        }
        #endregion

        #region --------------------------------------------------------------------------------- [ PRINT METHODS ] ----------------------------------
        static void PrintBST() // Print the Binary Search Tree ( BST )
        {
            Console.Clear();
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Print Pre-order");
            Console.WriteLine("2. Print In-order");
            Console.WriteLine("3. Print Post-order");

            int opt;
            if (int.TryParse(Console.ReadLine(), out opt))
            {
                switch (opt)
                {
                    case 1: // Print Pre-Order
                        Console.WriteLine("Pre-order traversal:");
                        Console.WriteLine(bsTree.PreOrder());

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2: // Print In-Order
                        Console.WriteLine("In-order traversal:");
                        Console.WriteLine(bsTree.InOrder());

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3: // Print Post-Order
                        Console.WriteLine("Post-order traversal:");
                        Console.WriteLine(bsTree.PostOrder());

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.\n");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid option (1, 2, or 3).\n");
            }
        }
        #endregion
        #endregion
    }
}
