/*
	This is a collection of ten small programs mostly based around recursion, 
	created for a university course 'Data Structures and Algorithms'.

	1	RECURSIVELY PRINT INTS N TO ZERO 
	2 	RECURSIVELY PRINT INTS ZERO TO N
	3  	ITERATIVELY CALCULATE POWERS
	4  	RECURSIVELY CALCULATE POWERS
	5  	COMPARE PROGRAM 3 TO PROGRAM 4 TO MATH.POW
	6  	RECURSIVELY PRINT A STRING IN REVERSE
	7  	ITERATIVELY AND RECURSIVELY CALCULATE SUM OF A LIST OF NUMBERS
	8  	ITERATIVELY CONVERT AN INT TO A STRING IN DECIMAL AND BINARY
	9  	RECURSIVELY SOLVE TOWERS OF HANOI
	10	RECURSIVELY PRINT A PATTERN OF INTS

    Joshua Scott
    jscott313@gmail.com
*/

/*******************************************
 1	RECURSIVELY PRINT INTS N TO ZERO 
********************************************/
using System;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer: ");
            int n = GetInt();
            PrintIntsNToZero(n);
            Console.ReadKey();              // Keep console active so output can be read
        }

        private static void PrintIntsNToZero(int n)
        {
            if (n < 0)                      // Base case
                return;
            else                            // Print n, recursive call for n-1
            {
                Console.WriteLine(n);
                PrintIntsNToZero(n - 1);
            }
        }

        private static int GetInt()         // Gets int from user, checks for incorrect input
        {
            int number = 0;
            bool success = false;
            while (!success)
            {
                string str = Console.ReadLine();
                success = Int32.TryParse(str, out number);
            }
            return number;
        }
    }
}

/*******************************************
 2 	RECURSIVELY PRINT INTS ZERO TO N
********************************************/
using System;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a positive integer: ");
            int n = GetInt();
            PrintIntsZeroToN(n);
            Console.ReadKey();              // Keep console active so output can be read
        }

        private static void PrintIntsZeroToN(int n)
        {
            if (n < 0)                      // Base case
                return;
            else                            // Recursive call for n-1, THEN print n
            {                                   // ...so n is printed as the stack is popped back down...
                PrintIntsZeroToN(n - 1);            // ...resulting in the opposite order!
                Console.WriteLine(n);
            }
        }

        private static int GetInt()         // Gets int from user, checks for incorrect input
        {
            int number = 0;
            bool success = false;
            while (!success)
            {
                string str = Console.ReadLine();
                success = Int32.TryParse(str, out number);
            }
            return number;
        }
    }
}

/***************************************
 3  	ITERATIVELY CALCULATE POWERS
****************************************/
using System;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = GetBaseInput();
            int n = GetExponentInput();
            Console.WriteLine(x + "^" + n + " = " + PowerUsingMultiplicationIterative(x, n));  // Compute x^n and print result
            Console.ReadKey();                                                  // Pause console so output can be read
        }

        private static double PowerUsingMultiplicationIterative(double x, int n)
        {
            double result = 1;
            if (n < 0)                                                          // In case exponent is negative
            {
                x = 1 / x;
                n = -n;
            }
            while (n > 0)                                                       // Multiply x by itself n times
            {
                result *= x;
                n--;
            }
            return result;    // Note that if n == 0, correct answer of 1 will still be reached (since result initializes to 1)
        }

        private static double GetBaseInput()                                    // Gets double from user, checks for incorrect input
        {
            double number = 0;
            bool success = false;
            while (!success)
            {
                Console.Write("Enter the base: ");
                string str = Console.ReadLine();
                success = Double.TryParse(str, out number);
            }
            return number;
        }

        private static int GetExponentInput()                                   // Gets int from user, checks for incorrect input
        {
            int number = 0;
            bool success = false;
            while (!success)
            {
                Console.Write("Enter the exponent: ");
                string str = Console.ReadLine();
                success = Int32.TryParse(str, out number);
            }
            return number;
        }
    }
}

/***************************************
 4  	RECURSIVELY CALCULATE POWERS
****************************************/
using System;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = GetBaseInput();
            int n = GetExponentInput();
            Console.WriteLine(x + "^" + n + " = " + PowerUsingRecursion(x, n));  // Compute x^n and print result
            Console.ReadKey();                                                  // Pause console so output can be read
        }

        private static double PowerUsingRecursion(double x, int n)
        {
            if (n == 0)                                             // Base case
                return 1;
            else if (n > 0)                                         // Usual recursive call
                return x * PowerUsingRecursion(x, n - 1);
            else                                                    // Will only be called once because after, n != negative
                return 1 / (x * PowerUsingRecursion(x, -n - 1));
        }

        private static double GetBaseInput()                                    // Gets double from user, checks for incorrect input
        {
            double number = 0;
            bool success = false;
            while (!success)
            {
                Console.Write("Enter the base: ");
                string str = Console.ReadLine();
                success = Double.TryParse(str, out number);
            }
            return number;
        }

        private static int GetExponentInput()                                   // Gets int from user, checks for incorrect input
        {
            int number = 0;
            bool success = false;
            while (!success)
            {
                Console.Write("Enter the exponent: ");
                string str = Console.ReadLine();
                success = Int32.TryParse(str, out number);
            }
            return number;
        }
    }
}

/*****************************************************
 5  	COMPARE PROGRAM 3 TO PROGRAM 4 TO MATH.POW
******************************************************/
using System;
using System.Diagnostics;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            double x = GetBaseInput();
            int n = GetExponentInput();
            double justTesting = 0;

            Stopwatch timer = new Stopwatch();                                      // Make and start a Stopwatch object called timer
            timer.Start();

            for (int i = 0; i < 1000000; i++)                                       // Compute x^n... 1 million times
            {
                justTesting = PowerUsingMultiplicationIterative(x, n);              // Comment out unused methods
                //justTesting = PowerUsingRecursion(x, n);
                //justTesting = Math.Pow(x, n);
            }
            
            timer.Stop();                                                           // Stop timer and display elapsed time
            Console.WriteLine("The operation took {0}ms", 
                timer.ElapsedMilliseconds);

            Console.WriteLine(justTesting);                                         // Print the (last) result just to confirm it worked properly
            Console.ReadKey();                                                      // Pause console so output can be read
        }

        private static double PowerUsingMultiplicationIterative(double x, int n)
        {
            double result = 1;
            if (n < 0)                                                          // In case exponent is negative
            {
                x = 1 / x;
                n = -n;
            }
            while (n > 0)                                                       // Multiply x by itself n times
            {
                result *= x;
                n--;
            }
            return result;    // Note that if n == 0, correct answer of 1 will still be reached (since result initializes to 1)
        }

        private static double PowerUsingRecursion(double x, int n)
        {
            if (n == 0)                                             // Base case
                return 1;
            else if (n > 0)                                         // Usual recursive call
                return x * PowerUsingRecursion(x, n - 1);
            else                                                    // Will only be called once because after, n != negative
                return 1 / (x * PowerUsingRecursion(x, -n - 1));
        }

        private static double GetBaseInput()                                    // Gets double from user, checks for incorrect input
        {
            double number = 0;
            bool success = false;
            while (!success)
            {
                Console.Write("Enter the base: ");
                string str = Console.ReadLine();
                success = Double.TryParse(str, out number);
            }
            return number;
        }

        private static int GetExponentInput()                                   // Gets int from user, checks for incorrect input
        {
            int number = 0;
            bool success = false;
            while (!success)
            {
                Console.Write("Enter the exponent: ");
                string str = Console.ReadLine();
                success = Int32.TryParse(str, out number);
            }
            return number;
        }
    }
}

/************************************************
 6  	RECURSIVELY PRINT A STRING IN REVERSE
*************************************************/
using System;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter string you would like to reverse: ");
            string input = Console.ReadLine();                              // Get string from user
            Console.WriteLine("Reversing...");
            ReverseString(input);
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void ReverseString(string str)
        {
            if (str == "")                                                  // Base case
                return;
            else
            {
                char firstLetter = str[0];                                  // Get first letter
                ReverseString(str.Remove(0, 1));                            // Recursive call with first letter removed
                Console.Write(firstLetter);                                 // Print first letter (after recursion, so reversed)
            }
        }
    }
}

/*************************************************************************
 7  	ITERATIVELY AND RECURSIVELY CALCULATE SUM OF A LIST OF NUMBERS
**************************************************************************/
using System;
using System.Collections.Generic;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> MyList = new LinkedList<int>();
            Console.WriteLine("Enter as many integers as you need. When you're done, press Return to calculate the sum of the integers.");
            MyList = AddIntsToList(MyList);
            Console.WriteLine("Result of Iterative calculation is " + SumOfLinkedListIterative(MyList));
            Console.WriteLine("Result of Recursive calculation is " + SumOfLinkedListRecursive(MyList));
            Console.ReadKey();
        }

        private static LinkedList<int> AddIntsToList(LinkedList<int> SomeList)              // Allows user to add ints to the LinkedList until they press (only) Return
        {
            int intIndex = 0;
            while (true)
            {
                Console.Write("Enter integer {0}: ", intIndex + 1);
                string input = Console.ReadLine();
                if (input == "")                                                            // If empty string, user has finished inputting ints
                    return SomeList;
                else                                                                        // Else add number to LinkedList iff it's an int
                {
                    int number;
                    bool success = Int32.TryParse(input, out number);
                    if (success)
                    {
                        SomeList.AddLast(number);
                        intIndex++;
                    }
                    else
                        Console.WriteLine("That's not an integer!");
                }
            }
        }

        private static int SumOfLinkedListIterative(LinkedList<int> SomeList)
        {
            int result = 0;
            foreach (var v in SomeList)
                result += v;
            return result;
        }

        public static int SumOfLinkedListRecursive(LinkedList<int> SomeList)
        {
            if (SomeList.Count == 1)                                                        // Base case (one item remaining)
                return SomeList.First.Value;
            else                                                                            // Add first element to recursive call without first element
            {
                int value = SomeList.First.Value;
                SomeList.RemoveFirst();
                return value + SumOfLinkedListRecursive(SomeList);
            }
        }
    }
}

/***********************************************************************
 8  	ITERATIVELY CONVERT AN INT TO A STRING IN DECIMAL AND BINARY
************************************************************************/
/* Note that the conversions to decimal/binary strings in this program are easier to accomplish 
 * using "Convert.ToString(someInt, desiredBase)", but it's been achieved iteratively in this program */

using System;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            string quit = "";
            do                                                                  // 'Do' loop is for the quit prompt at the end
            {
                Console.Write("Enter the integer you'd like to convert: ");
                int userInput = GetInt();                
                
                Console.WriteLine("\nDecimal string form of {0} is \"{1}\"", userInput, IntToString(userInput, 10));            
                Console.WriteLine("Binary string form of {0} is \"{1}\"\n", userInput, IntToString(userInput, 2));

                Console.Write("Type q to quit, or Return to go again. ");
                quit = Console.ReadLine().ToUpper();
                Console.WriteLine();
            } while (quit != "Q");
        }

        private static string IntToString(int userInput, int baseToConvertTo)   // Note that this method can handle any (reasonable) base, not only 2 or 10
        {                                                                           // Also, negative numbers are handled by inserting a preceding '-'
            if (userInput == 0)
                return "0";

            bool isNegative = false;                                            // If input is negative, bool=true and make positive so iteration works
            if (userInput < 0)
            {
                isNegative = true;
                userInput = -userInput;
            }

            string result = "";
            int remainder;
            while (userInput > 0)                                               // This is where the actual conversion happens
            {
                remainder = userInput % baseToConvertTo;
                userInput /= baseToConvertTo;
                result = remainder.ToString() + result;
            }
            if (isNegative)
                result = "-" + result;
            return result;
        }

        private static int GetInt()                                             // Gets int from user, checks for incorrect input
        {
            int number = 0;
            bool success = false;
            while (!success)
            {
                string str = Console.ReadLine();
                success = Int32.TryParse(str, out number);
            }
            return number;
        }
    }
}

/********************************************
 9  	RECURSIVELY SOLVE TOWERS OF HANOI
*********************************************/
using System;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            string quit = "";
            do                                                                  // 'Do' loop is for the quit prompt at the end
            {
                Console.Write("Welcome to Tower of Hanoi! \nHow many discs to solve for? ");
                int n = GetInt();
                Console.WriteLine("Solving for {0} discs...\n", n);
                char from = 'A', aux = 'B', to = 'C';
                SolveTowers(n, from, aux, to);
                Console.WriteLine("\nTook {0} moves to solve!", Math.Pow(2, n) - 1);
                Console.Write("Type q to quit, or Return to play again.\n");
                quit = Console.ReadLine().ToUpper();
                Console.WriteLine();
            } while (quit != "Q");

        }

        private static int GetInt()                                             // Gets int from user, checks for incorrect input
        {
            int number = 0;
            bool success = false;
            while (!success)
            {
                string str = Console.ReadLine();
                success = Int32.TryParse(str, out number);
            }
            return number;
        }

        private static void SolveTowers(int n, char from, char aux, char to)
        {
            if (n == 1)                                                         // Base case
                Console.WriteLine("Move disc 1 from {0} to {1}", from, to);
            else
            {
                SolveTowers(n - 1, from, to, aux); // Recursive call to move everything but the largest unsorted disc to the auxiliary pole                          
                Console.WriteLine("Move disc {0} from {1} to {2}", n, from, to); // Move largest unsorted disc to the destination pole
                SolveTowers(n - 1, aux, from, to);  // Move remaining discs to the destination pole 
            }
        }
    }
}

/**********************************************
 10	RECURSIVELY PRINT A PATTERN OF INTS
***********************************************/
using System;

namespace DSAA_PSET2
{
    class Program
    {
        static void Main(string[] args)
        {
            string quit = "";
            do                                                                  // 'Do' loop is for the quit prompt at the end
            {
                Console.Write("Enter length of longest row: ");
                int targetN = GetInt();
                Console.WriteLine();
                RecursiveIntPrinter(targetN, 0);
                Console.Write("\nType q to quit, or Return to go again. ");
                quit = Console.ReadLine().ToUpper();
                Console.WriteLine();
            } while (quit != "Q");
        }

        private static void RecursiveIntPrinter(int targetN, int currentN)      // This is the recursive method
        {
            if (currentN == targetN || currentN < 0)                            // Base cases
                return;
            else
            {
                PrintIntsFrom0ToCurrentN(currentN);

                RecursiveIntPrinter(targetN, currentN + 1);                     // Recursive call

                if (currentN != targetN - 1)                                    // Don't print the ints to targetN twice
                    PrintIntsFrom0ToCurrentN(currentN);
            }
        }

        private static void PrintIntsFrom0ToCurrentN(int currentN)              // Print a line of ints from 0 to currentN
        {
            for (int i = 0; i <= currentN; i++)                             
                Console.Write(" {0} ", i);
            Console.WriteLine();
        }

        private static int GetInt()                                             // Gets int from user, checks for incorrect input
        {
            int number = 0;
            bool success = false;
            while (!success)
            {
                string str = Console.ReadLine();
                success = Int32.TryParse(str, out number);
            }
            return number;
        }
    }
}
