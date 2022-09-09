using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Sec4_Ex_InterviewQuestion
{
    internal class Program
    {

        // todo - recreate this with a List<T> because that is better practice in modern c#

        static void Main(string[] args)
        {

            // arrays aren't const for reasons outside the scope of this note section
            // read up on const keyword in C# 
            // I would probably implement like this if you want it to truly function as a constant
            // keeping name arr1 to illustrate what is happening
            //var arr1 = new List<char>() { 'a', 'b', 'c', 'x' };
            //IReadOnlyList<char> myReadOnlyList = ImmutableList.CreateRange(arr1);

            char[] arr1 = { 'a', 'b', 'c', 'x' };
            char[] arr2 = { 'z', 'y', 'i' };

            char[] arr3 = { 'a', 'b', 'c', 'x' };
            char[] arr4 = { 'z', 'y', 'x' };

            Console.WriteLine($"Naive Approach - Arr 1, Arr2 contain common item? = {ContainCommon(arr1, arr2)}"); // false
            Console.WriteLine($"Naive Approach - Arr 3, Arr4 contain common item? = {ContainCommon(arr3, arr4)}"); // true
            Console.WriteLine();
            Console.WriteLine($"O(a+b) Approach - Arr 1, Arr2 contain common item? = {BetterContainCommon(arr1, arr2)}"); // false
            Console.WriteLine($"O(a+b) Approach - Arr 3, Arr4 contain common item? = {BetterContainCommon(arr3, arr4)}"); // true
            Console.WriteLine();
            Console.WriteLine($"Using Linq - Arr 1, Arr2 contain common item? = {CleanerContainCommon(arr1, arr2)}"); // false
            Console.WriteLine($"USing Linq - Arr 3, Arr4 contain common item? = {CleanerContainCommon(arr3, arr4)}"); // true
            Console.WriteLine();
            Console.WriteLine($"HashSet - Arr 1, Arr2 contain common item? = {HashSetBetterContainCommon(arr1, arr2)}"); // false
            Console.WriteLine($"HashSet - Arr 3, Arr4 contain common item? = {HashSetBetterContainCommon(arr3, arr4)}"); // true


        }

        // naive approach - usually enough to describe this and not code it - but you can depending on your time
        // let interviewer know this is the easy/naive approach and not necessarily most effecient
        // but at least you have the correct answer which is better than running out of time and not having an answer
        // good starting point to improve your approach 
        // O(n^2) if arrays are same size - otherwise O(a*b) - really slow
        // try to avoid nested loops in a tech interview
        public static bool ContainCommon(char[] arrOne, char[] arrTwo)
        {

            for (int i = 0; i < arrOne.Length; i++)
            {
                for (int j = 0; j < arrTwo.Length; j++)
                {
                    if (arrOne[i] == arrTwo[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // loop through first array and map it to dictionary 'char' : true 
        // loop through second array and check if the values in the second array exist as keys in the dictionary already
        // as soon as one of them does - return true else return false
        // O(a+b) time complexity -- this solution is better if given sufficiently large arrays
        // prefer a hashset when you have no values
        public static bool BetterContainCommon(char[] arrOne, char[] arrTwo)
        {

            // can we always assume 2 params?
            // can use -- var myDict = new Dictionary<Tkey, TValue>(); -- for ease 
            Dictionary<char, bool> commonItems = new Dictionary<char, bool>();

            // loop through first array, add char values as key and true as value 
            foreach (char item in arrOne)
            {
                if (!commonItems.ContainsKey(item))
                {
                    commonItems.Add(item, true);
                }
            }

            // loop through second array, check if value exists as key in dictionary
            foreach (char item in arrTwo)
            {
                if (commonItems.ContainsKey(item))
                {
                    return true;
                }
            }

            return false;
        }

        // O(a+b) time complexity
        // O(a) space complexity 
        // using a HashSet since duplicates don't matter and we don't need values
        // leaving dictionary in above as a reference
        public static bool HashSetBetterContainCommon(char[] arrOne, char[] arrTwo)
        {

            var commonItems = new HashSet<char>();

            // loop through first array, add char values as key and true as value 
            foreach (char item in arrOne)
            {
                if (!commonItems.Contains(item))
                {
                    commonItems.Add(item);
                }
            }

            // loop through second array, check if value exists as key in hashset
            foreach (char item in arrTwo)
            {
                if (commonItems.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool CleanerContainCommon(char[] arrOne, char[] arrTwo)
        {
            // basically checks if any of the keys in arrOne == any of the keys in arrTwo
            // Enumerable.Any() determines whether any element of a sequence exists or satisfies a condition
            // https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.any?view=net-6.0
            return arrOne.Any(key => arrTwo.Contains(key));
        }

        //Think about step 11 in the interview cheatsheet
    }
}
