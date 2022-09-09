char[] arr1 = { 'a', 'b', 'c', 'x' };
char[] arr2 = { 'z', 'y', 'i' };

char[] arr3 = { 'a', 'b', 'c', 'x' };
char[] arr4 = { 'z', 'x', 'y' };

Console.WriteLine($"Naive Approach - Arr 1, Arr2 contain common item? = {ContainCommon(arr1, arr2)}"); // false
Console.WriteLine($"Naive Approach - Arr 3, Arr4 contain common item? = {ContainCommon(arr3, arr4)}"); // true
Console.WriteLine();
Console.WriteLine($"O(a+b) Approach - Arr 1, Arr2 contain common item? = {BetterContainCommon(arr1, arr2)}"); // false
Console.WriteLine($"O(a+b) Approach - Arr 3, Arr4 contain common item? = {BetterContainCommon(arr3, arr4)}"); // true
Console.WriteLine();
Console.WriteLine($"Using Linq - Arr 1, Arr2 contain common item? = {CleanerContainCommon(arr1, arr2)}"); // false
Console.WriteLine($"Using Linq - Arr 3, Arr4 contain common item? = {CleanerContainCommon(arr3, arr4)}"); // true

// naive approach
// O(n^2) if arrays are same size - otherwise O(a*b) time complexity
// O(1) space complexity 
// slower but more memory effecient
static bool ContainCommon(char[] arrOne, char[] arrTwo) {

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
static bool BetterContainCommon(char[] arrOne, char[] arrTwo) {

    var commonItems = new HashSet<char>();

    // loop through first array, add char values as key and true as value 
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
static bool CleanerContainCommon(char[] arrOne, char[] arrTwo) {
    // determines whether any element of a sequence exists or satisfies a condition
    return arrOne.Any(key => arrTwo.Contains(key));
}
