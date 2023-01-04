/*
2244. Minimum Rounds to Complete All Tasks
Link: https://leetcode.com/problems/minimum-rounds-to-complete-all-tasks/

You are given a 0-indexed integer array tasks, where tasks[i] represents the
difficulty level of a task. In each round, you can complete either 2 or 3
tasks of the same difficulty level.

Return the minimum rounds required to complete all the tasks, or -1 if it is
not possible to complete all the tasks.

Example 1:
Input: tasks = [2,2,3,3,2,4,4,4,4,4]
Output: 4
Explanation: To complete all the tasks, a possible plan is:
- In the first round, you complete 3 tasks of difficulty level 2. 
- In the second round, you complete 2 tasks of difficulty level 3. 
- In the third round, you complete 3 tasks of difficulty level 4. 
- In the fourth round, you complete 2 tasks of difficulty level 4.  
It can be shown that all the tasks cannot be completed in fewer than 4 rounds,
so the answer is 4.

Example 2:
Input: tasks = [2,3,3]
Output: -1
Explanation: There is only 1 task of difficulty level 2, but in each round, you
can only complete either 2 or 3 tasks of the same difficulty level. Hence, you
cannot complete all the tasks, and the answer is -1.
*/

class Solution {
    public int minimumRounds(int[] tasks) {
        
        // Count number of tasks with the same difficulties
        HashMap<Integer, Integer> map = new HashMap<>();
        for (int task : tasks) {
            map.put(task, map.getOrDefault(task, 0) + 1);
        }

        // Calculate the minimum rounds required to complete all the tasks
        int result = 0;
        for (int value : map.values()) {
            // not possible to complete all the tasks
            if (value == 1) return -1;

            result += value/3;
            if (value % 3 != 0) result++;
        }

        return result;
    }
}