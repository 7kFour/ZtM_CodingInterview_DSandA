using System;
using System.Collections.Generic;
using System.Linq;

namespace Sec4_Ex_InterviewQuestion_NoNotes {
    internal class Program {
        static void Main(string[] args) {

            char[] arr1 = { 'a', 'b', 'c', 'x' };
            char[] arr2 = { 'z', 'y', 'i' };

            char[] arr3 = { 'a', 'b', 'c', 'x' };
            char[] arr4 = { 'z', 'x', 'y' };

            Console.WriteLine($"Naive - {ContainCommon(arr1, arr2)}"); // false
            Console.WriteLine($"Naive - {ContainCommon(arr3, arr4)}\n"); // true
            
            Console.WriteLine($"HashSet - {BetterContainCommon(arr1, arr2)}"); // false
            Console.WriteLine($"HashSet - {BetterContainCommon(arr3, arr4)}\n"); // true
            
            Console.WriteLine($"Linq - {CleanerContainCommon(arr1, arr2)}"); // false
            Console.WriteLine($"Linq - {CleanerContainCommon(arr3, arr4)}\n"); // true
        }

        // naive approach
        // O(n^2) if arrays are same size - otherwise O(a*b) time complexity
        // O(1) space complexity 
        // slower but more memory effecient
        public static bool ContainCommon(char[] arrOne, char[] arrTwo) {

            for (int i = 0; i < arrOne.Length; i++) {
                for (int j = 0; j < arrTwo.Length; j++) {
                    if (arrOne[i] == arrTwo[j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        // O(a+b) time complexity
        // O(a) space complexity 
        // using a HashSet since duplicates don't matter and we don't need values
        public static bool BetterContainCommon(char[] arrOne, char[] arrTwo) {

            var commonItems = new HashSet<char>();

            // loop through first array, add char values to set if they dont exist
            foreach (char item in arrOne) {
                if (!commonItems.Contains(item)) {
                    commonItems.Add(item);
                }
            }

            // loop through second array, check if value exists as key in hashset
            foreach (char item in arrTwo) {
                if (commonItems.Contains(item)) {
                    return true;
                }
            }
            return false;
        }

        // Same time/space complexity as BetterContainCommon()
        // Using Linq for readability 
        public static bool CleanerContainCommon(char[] arrOne, char[] arrTwo) {
            // determines whether any element of a sequence exists or satisfies a condition
            return arrOne.Any(arrTwo.Contains);
        }
    }
}
