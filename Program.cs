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
                    // Read Files Menu
                    case 1:
                        Console.Clear();
                        ReadFilesSwitch();
                        break;
                    // Binary Search Tree Menu
                    case 2:
                        Console.Clear();
                        BSTSwitch();
                        break;
                    // Balanced Search Tree Menu
                    case 3:
                        Console.Clear();
                        AVLSwitch();
                        break;
                    // Exit Console Program
                    case 4:
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
            while (opt < 1 || opt > 4)
            {
                Console.WriteLine("******************* [ Main Menu ] ********************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*              1 - Reading Files Menu                *");
                Console.WriteLine("*              2 - Binary Search Tree Menu           *");
                Console.WriteLine("*              3 - Balanced Search Tree Menu         *");
                Console.WriteLine("*              4 - Exit                              *");
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
        private static void ReadFilesSwitch() // Reading List
        {
            while (true)
            {
                int opt = ReadFilesMenu();
                switch (opt)
                {
                    case 1:
                        ReadingOrderedFiles(); // Read Ordered List
                        break;
                    case 2:
                        ReadingRandomFiles(); // Read Random List
                        break;
                    case 3:
                        PrintTree(); // Print a Tree from Selection
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

        private static int ReadFilesMenu() // Reading List Files
        {
            int opt = 0;
            while (opt < 1 || opt > 4)
            {
                Console.WriteLine("*************** [ Reading Files Menu ] ***************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*                  1 - Ordered List                  *");
                Console.WriteLine("*                  2 - Random List                   *");
                Console.WriteLine("*                  3 - Print                         *");
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

        #region --------------------------------------------------------------------------------- [ BINARY SEARCH TREE MENU / SWITCH ] -------------------------------------
        private static void BSTSwitch() // Binary Seach Tree Menu
        {
            while (true)
            {
                int opt = BSTMenu();
                switch (opt)
                {
                    case 1:
                        Console.Clear();
                        InsertOp_BST(); // Insert Word
                        break;
                    case 2: // Find Word
                        Console.Clear();
                        FindOp();
                        break;
                    case 3: // Delete Word
                        Console.Clear();
                        DeleteOp();
                        break;
                    case 4:
                        PrintBST(); // Print BST
                        break;
                    case 5:
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
            while (opt < 1 || opt > 5)
            {
                Console.WriteLine("************ [ Binary Search Tree Menu ] *************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*               1 - Insert Word                      *");
                Console.WriteLine("*               2 - Find Word                        *");
                Console.WriteLine("*               3 - Delete Word                      *");
                Console.WriteLine("*               4 - Print BST                        *");
                Console.WriteLine("*               5 - Main Menu                        *");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("******************************************************");
                Console.WriteLine();
                Console.WriteLine("Enter an Option: ");

                opt = int.Parse(Console.ReadLine());
            }
            return opt;
        }
        #endregion

        #region --------------------------------------------------------------------------------- [ BALANCED SEARCH TREE MENU / SWITCH ] -----------------------------------
        private static void AVLSwitch() // Balanced Seach Tree Menu
        {
            while (true)
            {
                int opt = AVLMenu();
                switch (opt)
                {
                    case 1:
                        InsertOp_AVL(); // Insert Word
                        break;
                    case 2:
                        Console.Clear();
                        FindOp(); // Find Word
                        break;
                    case 3:
                        DeleteOp(); // Delete Word
                        break;
                    case 4:
                        PrintAVL(); // Print AVL
                        break;
                    case 5:
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }
            }
        }

        private static int AVLMenu()
        {
            int opt = 0;
            while (opt < 1 || opt > 5)
            {
                Console.WriteLine("*********** [ Balanced Search Tree Menu ] ************");
                Console.WriteLine("*                                                    *");
                Console.WriteLine("*               1 - Insert Word                      *");
                Console.WriteLine("*               2 - Find Word                        *");
                Console.WriteLine("*               3 - Delete Word                      *");
                Console.WriteLine("*               4 - Print AVL                        *");
                Console.WriteLine("*               5 - Main Menu                        *");
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
                {
                    bsTree.Add(word);
                    avlTree.Add(word);
                }
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
                if (word.Contains(word))
                {
                    bsTree.Add(word);
                    avlTree.Add(word);
                }
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

        #region --------------------------------------------------------------------------------- [ INSERT OPERATION ] -------------------------------
        static void InsertOp_BST()
        {
            Console.Clear();
            Console.WriteLine("Enter the word you'd like to add: ");
            string word = UserInput();

            if (Contains(bsTree.Root, word))
            {
                Console.WriteLine("\nWord: " + word + " already exists in the BST. Insertion failed.\n");
            }
            else
            {
                bsTree.Add(word);
                Console.WriteLine("\nWord: " + word + " Length: " + word.Length + " inserted into the BST successfully.\n");
            }
        }

        static void InsertOp_AVL()
        {
            Console.Clear();
            Console.WriteLine("Enter the word you'd like to add: ");
            string word = UserInput();

            if (Contains(avlTree.Root, word))
            {
                Console.WriteLine("\nWord: " + word + " already exists in the AVL. Insertion failed.\n");
            }
            else
            {
                bsTree.Add(word);
                Console.WriteLine("\nWord: " + word + " Length: " + word.Length + " inserted into the AVL tree successfully.\n");
            }
        }

        static string UserInput() // Validate users word input
        {
            // Read the input from the user.
            string word = Console.ReadLine();

            // Iterate over the input string and check if each character is a letter A-Z.
            foreach (char character in word)
            {
                if (!char.IsLetter(character))
                {
                    // Display an error message to the user and ask them to try again.
                    Console.WriteLine("\n" + word + " is invalid. Please enter only letters A-Z.\n");
                    return UserInput();
                }
            }
            // Return the input string.
            return word;
        }

        static bool Contains(Node tree, string word)
        {
            if (tree == null)
                return false;

            int comparison = string.Compare(word, tree.Word);

            if (comparison < 0)
                return Contains(tree.Left, word);
            else if (comparison > 0)
                return Contains(tree.Right, word);
            else
                return true; // Word found in the tree
        }
        #endregion

        #region --------------------------------------------------------------------------------- [ FIND OPERATION ] ---------------------------------
        static void FindOp()
        {
            Console.Clear();
            Console.WriteLine("Enter the word you'd like to find: ");
            string wordToFind = Console.ReadLine();

            Console.WriteLine("Select the tree to search: ");
            Console.WriteLine("1. Binary Search Tree");
            Console.WriteLine("2. Balanced Search Tree");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(bsTree.Find(wordToFind));
                        break;
                    case 2:
                        Console.WriteLine(avlTree.Find(wordToFind));
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1 or 2.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number ( 1 , 2 ).");
            }
        }
        #endregion

        #region --------------------------------------------------------------------------------- [ DELETE OPERATION ] -------------------------------
        static void DeleteOp()
        {
            Console.Clear();
            Console.WriteLine("Enter the word you'd like to delete: ");
            string wordToDelete = Console.ReadLine();

            Console.WriteLine("Select the tree to delete from: ");
            Console.WriteLine("1. Binary Search Tree");
            Console.WriteLine("2. Balanced Search Tree");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine(bsTree.Remove(wordToDelete));
                        break;
                    case 2:
                        Console.WriteLine(avlTree.Remove(wordToDelete));
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1 or 2.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number ( 1 , 2 ).");
            }
        }
        #endregion

        #region --------------------------------------------------------------------------------- [ PRINT OPERATIONS ] -------------------------------
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

        static void PrintAVL() // Print the Balanced Search Tree ( AVL )
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
                        Console.WriteLine(avlTree.PreOrder());

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2: // Print In-Order
                        Console.WriteLine("In-order traversal:");
                        Console.WriteLine(avlTree.InOrder());

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3: // Print Post-Order
                        Console.WriteLine("Post-order traversal:");
                        Console.WriteLine(avlTree.PostOrder());

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

        static void PrintTree()
        {
            Console.WriteLine("Select the tree to print:");
            Console.WriteLine("1. Binary Search Tree (BST)");
            Console.WriteLine("2. AVL Tree");

            int opt;
            if (int.TryParse(Console.ReadLine(), out opt))
            {
                switch (opt)
                {
                    case 1:
                        PrintBST();
                        break;
                    case 2:
                        PrintAVL();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 1 or 2.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
        #endregion
        #endregion
    }
}
