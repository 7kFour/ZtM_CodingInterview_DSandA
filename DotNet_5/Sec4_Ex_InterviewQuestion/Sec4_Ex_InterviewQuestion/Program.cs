using System;

namespace Sec4_Ex_InterviewQuestion {
    internal class Program {
        static void Main(string[] args) {

            char[] arr1 = { 'a', 'b', 'c', 'x' };
            char[] arr2 = { 'z', 'y', 'i' };

            char[] arr3 = { 'a', 'b', 'c', 'x' };
            char[] arr4 = { 'z', 'y', 'x' };

            Console.WriteLine(ContainCommon(arr1, arr2)); // false
            Console.WriteLine(ContainCommon(arr3, arr4)); // true
        }

        // naive approach - usually enough to describe this and not code it - but you can depending on your time
        // let interviewer know this is the easy/naive approach and not necessarily most effecient
        // but at least you have the correct answer which is better than running out of time and not having an answer
        // good starting point to improve your approach 
        // O(n^2) if arrays are same size - otherwise O(a*b) - really slow
        // try to avoid nested loops in a tech interview
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
    }
}
