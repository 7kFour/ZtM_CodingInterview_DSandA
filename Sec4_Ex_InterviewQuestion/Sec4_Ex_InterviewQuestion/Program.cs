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

        // first attempt
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
