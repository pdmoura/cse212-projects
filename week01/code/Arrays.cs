public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // All right for my plan, I will:
        // 1. Create a new array of doubles with the length given.
        // 2. Use a for loop to iterate from 0 to length - 1.
        // 3. In each iteration, I will calculate the multiple of the (number) by multiplying it by i + 1 and assign the value to the index in the array since index 0 holds the 1st multiple, index 1 the 2nd multiple, etc.
        // 4. Then I will return the populated array.

        double[] multiples = new double[length];
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Plan:
        // 1. Rotating right means the last 'amount' elements move to the front,
        //    and everything else shifts right by 'amount' positions.
        // 2. I will build a new list by walking through NEW index positions (i).
        // 3. For each new index i, the value comes from the original list at
        //    position (i - amount), wrapping around to the end if that's negative.
        //    Adding data.Count before the modulo keeps the index positive.
        // 4. After building the rotated list, replace the contents of the
        //    original list with it (Clear + AddRange), since the function must
        //    modify 'data' in place instead of returning a new list.
        List<int> rotated = new List<int>();

        for (int i = 0; i < data.Count; i++)
        {
            int oldIndex = (i - amount + data.Count) % data.Count;
            rotated.Add(data[oldIndex]);
        }

        data.Clear();
        data.AddRange(rotated);
    }
}
