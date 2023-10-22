/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System.Text;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
        Question 1:
        You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
        Example 1:
        Input: nums = [0,1,3,50,75], lower = 0, upper = 99
        Output: [[2,2],[4,49],[51,74],[76,99]]  
        Explanation: The ranges are:
        [2,2]
        [4,49]
        [51,74]
        [76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
         {
        try
        {
            IList<IList<int>> result = new List<IList<int>>();
            long prev = (long)lower - 1; // To handle potential integer overflow when finding the missing ranges

            for (int i = 0; i <= nums.Length; i++)
            {
                long curr = (i == nums.Length) ? (long)upper + 1 : nums[i]; // To handle the upper range case

                if (prev + 1 <= curr - 1)
                {
                    if (prev + 1 == curr - 1)
                    {
                        result.Add(new List<int> { (int)(prev + 1) }); // If the range is just a single number
                    }
                    else
                    {
                        result.Add(new List<int> { (int)(prev + 1), (int)(curr - 1) }); // If the range has a start and end value
                    }
                }
                prev = curr;
            }
            return result;
        }
        catch (Exception)
        {
            throw;
        }
    }
        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

       
    public static bool IsValid(string s)
{
    try
    {
        // Check if the length of the input string is odd
        if (s.Length % 2 != 0)
        {
            return false; // If the length is odd, the string cannot be valid, so return false
        }

        // Loop until there are no more occurrences of '()', '[]', or '{}'
        while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
        {
            // Replace '()', '[]', and '{}' with an empty string to eliminate valid pairs
            s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
        }

        // If the string length becomes 0 after removing valid pairs, it is a valid string
        return s.Length == 0;
    }
    catch (Exception)
    {
        throw; // If any exception occurs during the execution, rethrow the exception
    }
}


        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)
        { 
            
            try
            {
                if (prices.Length == 0) // handling empty array case
                    return 0;

                int minPrice = prices[0]; // initializing the minimum price as the first price
                int maxProfit = 0; // initializing max profit as 0

                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] < minPrice) // update the minimum price if a smaller price is encountered
                        minPrice = prices[i];
                    else if (prices[i] - minPrice > maxProfit) // calculate and update the max profit if a better option is found
                        maxProfit = prices[i] - minPrice;
                }
                return maxProfit; // return the maximum profit
            }
            catch (Exception)
            {
                throw; // handling exceptions with try-catch block
            }
        }

        /*
        
        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */
public static bool IsStrobogrammatic(string s)
{
    try
    {
        // Initialize two pointers for checking characters from the two ends
        int left = 0;
        int right = s.Length - 1;

        // Iterate through the string until the pointers meet in the middle
        while (left <= right)
        {
            // Checking for invalid combinations that cannot be part of a strobogrammatic number
            if (!("00 11 88 696".Contains(s[left].ToString() + s[right])))
            {
                return false;
            }

            // Checking for mirror image conditions for 6 and 9
            if (s[left] == '6' && s[right] != '9' || s[left] == '9' && s[right] != '6')
            {
                return false;
            }

            // Checking for exactly same conditions for 0, 1, and 8
            if (s[left] == '0' && s[right] != '0' || s[left] == '1' && s[right] != '1' || s[left] == '8' && s[right] != '8')
            {
                return false;
            }

            // Move the pointers towards each other
            left++;
            right--;
        }

        // If all checks pass, the string is strobogrammatic
        return true;
    }
    catch (Exception)
    {
        throw;
    }
}

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

      public static int NumIdenticalPairs(int[] nums)
{
    try
    {
        // Check if the array is null or has less than 2 elements
        if (nums == null || nums.Length < 2)
        {
            return 0; // If the array has less than 2 elements, there can be no pairs
        }

        int count = 0;
        int[] frequency = new int[101]; // As per the constraint, the maximum value of nums[i] is 100

        // Loop through the array to count the frequency of each element and calculate the number of good pairs
        foreach (var num in nums)
        {
            count += frequency[num]; // Increment count by the frequency of the current number
            frequency[num]++; // Update the frequency array
        }

        return count; // Return the total count of good pairs
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message); // Print an error message if an exception occurs
        throw; // Rethrow the exception
    }
}


        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2's are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(n)
        */

       
        public static int ThirdMax(int[] nums)
        {
            try
            {
                if (nums.Length < 3)
                {
                    Array.Sort(nums); // Sort the array in ascending order
                    return nums[nums.Length - 1]; // If the length is less than 3, return the maximum number
                }

                Array.Sort(nums); // Sort the array in ascending order
                Array.Reverse(nums); // Reverse the array to get it in descending order

                int distinctCount = 1;
                int thirdMax = nums[0];

                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] != nums[i - 1])
                    {
                        distinctCount++; // Increase the distinct count if a new distinct number is found
                    }

                    if (distinctCount == 3)
                    {
                        thirdMax = nums[i]; // Store the third distinct maximum number
                        break;
                    }
                }

                return distinctCount < 3 ? nums[0] : thirdMax; // Return the third maximum if it exists, otherwise return the maximum
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message); // Print an error message if an exception occurs
                throw; // Rethrow the exception
            }
        }
        /*
        
        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []
 
        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(n), Space complexity:O(n)
        */

             public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                IList<string> result = new List<string>();

                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        char[] currentStateArray = currentState.ToCharArray();
                        currentStateArray[i] = '-';
                        currentStateArray[i + 1] = '-';
                        result.Add(new string(currentStateArray));
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                throw;
            }
        }

        /*

        Question 8:

        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: s = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: s = "aeiou"
        Output: ""

        Timecomplexity:O(n), Space complexity:O(n)
        */

          public static string RemoveVowels(string s)
        {
            try
            {
                // Check if the string is null or empty
                if (string.IsNullOrEmpty(s))
                {
                    return ""; // Return an empty string if the input string is null or empty
                }

                // Remove the vowels 'a', 'e', 'i', 'o', and 'u' from the string
                string result = "";
                foreach (char c in s)
                {
                    if (!"aeiou".Contains(c))
                    {
                        result += c;
                    }
                }
                return result; // Return the new string with vowels removed
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message); // Print an error message if an exception occurs
                throw; // Rethrow the exception
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}
