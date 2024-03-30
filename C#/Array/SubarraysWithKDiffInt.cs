/*
992. Subarrays with K Different Integers
Link: https://leetcode.com/problems/subarrays-with-k-different-integers/

Given an integer array nums and an integer k, return the number of good subarrays of nums.

A good array is an array where the number of different integers in that array is exactly k.

For example, [1,2,3,1,2] has 3 different integers: 1, 2, and 3.
A subarray is a contiguous part of an array.

Example 1:
Input: nums = [1,2,1,2,3], k = 2
Output: 7
Explanation: Subarrays formed with exactly 2 different integers:
[1,2], [2,1], [1,2], [2,3], [1,2,1], [2,1,2], [1,2,1,2]

Example 2:
Input: nums = [1,2,1,3,4], k = 3
Output: 3
Explanation: Subarrays formed with exactly 3 different integers: [1,2,1,3], [2,1,3], [1,3,4].

Solution:
https://leetcode.com/problems/subarrays-with-k-different-integers/?envType=daily-question&envId=2024-03-30
*/

public class Solution {
    public int SubarraysWithKDistinct(int[] nums, int k) {
        int subWithMaxK = SubarrayWithAtMostK(nums, k);
        int reducedSubWithMaxK = SubarrayWithAtMostK(nums, k - 1);
        return subWithMaxK - reducedSubWithMaxK;
    }
    
    public int SubarrayWithAtMostK(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int left = 0, right = 0;
        int ans = 0;
        
        // Expand the window to the right until it reaches the end of the array
        while (right < nums.Length) {
            if (!map.ContainsKey(nums[right]))
                map[nums[right]] = 0;
            map[nums[right]]++;
            
            // If the number of distinct elements in the window exceeds k, 
            // shrink the window from the left
            while (map.Count > k) {
                map[nums[left]]--;
                if (map[nums[left]] == 0)
                    map.Remove(nums[left]);
                left++;
            }
            
            // Count the subarrays ending at the current right pointer and add it to the answer
            // The number of subarrays is equal to the size of the window (right - left + 1)
            ans += right - left + 1; 

            right++;
        }

        return ans;
    }
}