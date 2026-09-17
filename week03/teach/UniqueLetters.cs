public static class UniqueLetters {
    public static void Run() {
        var test1 = "abcdefghjiklmnopqrstuvwxyz"; // Expect True because all letters unique
        Console.WriteLine(AreUniqueLetters(test1));

        var test2 = "abcdefghjiklanopqrstuvwxyz"; // Expect False because 'a' is repeated
        Console.WriteLine(AreUniqueLetters(test2));

        var test3 = "";
        Console.WriteLine(AreUniqueLetters(test3)); // Expect True because its an empty string
    }

    /// <summary>Determine if there are any duplicate letters in the text provided</summary>
    /// <param name="text">Text to check for duplicate letters</param>
    /// <returns>true if all letters are unique, otherwise false</returns>

    /// To make this more efficient, we can use a HashSet to track the letters we've seen as we iterate through the string. 
    /// This way, we can check for duplicates in O(n) time complexity instead of O(n^2).
    private static bool AreUniqueLetters(string text) {
        // TODO Problem 1 - Replace the O(n^2) algorithm to use sets and O(n) efficiency
        var seenLetters = new HashSet<char>();
        foreach (var letter in text) {
            // Console.WriteLine($"Checking letter: {letter} and seen letters: {string.Join(", ", seenLetters)}");
            if (!seenLetters.Add(letter)) {
                return false;
            }
        }
        return true;
    }
}