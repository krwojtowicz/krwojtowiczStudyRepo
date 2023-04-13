using System.Collections;
using System.Linq.Expressions;
using System.Net.NetworkInformation;

namespace SPOJ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] points = { new int[] { 0, 1 }, new int[] { 0, 0 }, new int[] { 0, 4 }, new int[] { 0, -2 }, new int[] { 0, -1 }, new int[] { 0, 3 }, new int[] { 0, -4 } };

            Console.WriteLine(PreorderTraversal(points));

        }

        public static IList<int> PreorderTraversal(TreeNode root)
        {
            var output = new List<int>();

            void call(TreeNode root)
            {
                if (root != null)
                {
                    output.Add(root.val);
                    call(root.left);
                    call(root.right);
                }  
            }
            
            return output;
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                 this.val = val;
                 this.left = left;
                 this.right = right;
            }
        }
        public static int MaxPoints(int[][] points)
        {
            int max = 0;
            if (points.Length == 1) return 1;
            Dictionary<Tuple<double, double>, int> result = new Dictionary<Tuple<double, double>, int>();
            for (int i = 0; i < points.Length; i++)
            {
                result.Clear();
                for (int j = i + 1; j < points.Length; j++)
                {
                    double a = 0;
                    double b = 0;
                    Tuple<double, double> straight;
                    if (points[j][0] - points[i][0] == 0)
                    {
                        straight = new Tuple<double, double>(0, 0);
                    }
                    else
                    {
                        a = (double)(points[j][1] - points[i][1]) / (double)(points[j][0] - points[i][0]);
                        b = -1 * a * points[i][0] + points[i][1];
                        straight = new Tuple<double, double>(a, b);
                    }
                    bool tryParse = result.TryAdd(straight, 2);
                    Console.WriteLine($"{a} {b} {tryParse}");
                    if (!tryParse) result[straight] += 1;
                    if (result.Values.Max() > max) max = result.Values.Max();
                }
            }
            return max;
        }
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int gasSum = 0;
            int costSum = 0;
            for (int i = 0; i < cost.Length; i++)
            {
                gasSum += gas[i];
                costSum += cost[i];
            }

            if (costSum > gasSum) return -1;

            int idx = 0;

            return idx;
        }

        public static int MaxIceCream(int[] costs, int coins)
        {
            Array.Sort(costs);
            int iceBought = 0;
            foreach (var elem in costs)
            {
                // Console.WriteLine(elem + " " + coins);
                if (coins >= elem)
                {
                    iceBought++;
                    coins -= elem;
                }
            }


            return iceBought;
        }

        public static int FindMinArrowShots(int[][] points)
        {
            int arrows = 0;
            int[] destroyed = new int[points.Length];
            Array.Sort(points, (f, s) => f[1].CompareTo(s[1]));
            for (int i = 0; i < points.Length; i++)
            {
                if (destroyed[i] == 1) continue;
                for (int j = i + 1; j < points.Length; j++)
                {
                    if (points[i][1] >= points[j][0])
                    {
                        destroyed[i] = 1;
                        destroyed[j] = 1;
                    }
                    else break;
                }
                arrows++;
            }
            return arrows;
        }
        public static int MinimumRounds(int[] tasks)
        {
            int rounds = 0;
            Dictionary<int, int> sorted = new Dictionary<int, int>();
            foreach (int elem in tasks)
            {
                bool tryAdd = sorted.TryAdd(elem, 1);
                if (!tryAdd) sorted[elem] += 1;
            }
            foreach (var elem in sorted)
            {

                if (elem.Value == 1) return -1;
                rounds += elem.Value / 3;
                if (elem.Value! % 3 == 0) rounds++;

            }

            return rounds;
        }

        public static bool WordPattern(string pattern, string s)
        {
            char[] patternArray = pattern.ToCharArray();
            string[] sArray = s.Trim().Split(' ');
            //if(patternArray.Length != sArray.Length) return false;
            Dictionary<char, string> patternToS = new Dictionary<char, string>();

            for (int i = 0; i < patternArray.Length; i++)
            {
                bool ifAdded = patternToS.TryAdd(patternArray[i], sArray[i]);
                if (!ifAdded)
                {
                    foreach (var elem in patternToS)
                    {
                        if (elem.Key == patternArray[i])
                        {
                            if (elem.Value != sArray[i]) return false;
                        }
                    }
                }
                else
                {
                    foreach (var elem in patternToS)
                    {
                        if (elem.Key == patternArray[i])
                        {
                            if (elem.Value == sArray[i]) return false;
                        }
                    }
                }
            }
            return true;
        }
        //public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
        //{
        //    int l1Idx = 0;
        //    int l2Idx = 0;
        //    int longerListCount = 0;
        //    if (list1.Count > list2.Count) longerListCount = list1.Count;
        //    else longerListCount = list2.Count;

        //    for (int i = 0; i < longerListCount)
        //    {

        //    }
        //}
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
        public static int MinDeletionSize(string[] strs)
        {
            int delete = 0;

            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int j = 1; j < strs.Length; j++)
                {
                    if (strs[j][i] < strs[j - 1][i])
                    {
                        delete++;
                        break;
                    }
                }
            }
            return delete;
        }
        public static bool IsSubsequence(string s, string t)
        {
            int lastTindex = -1;
            int founded = 0;
            for (int i = 0; i < s.Length; i++)
            {
                bool notFound = true;
                Console.WriteLine($"{s[i]} {lastTindex + 1}");
                for (int j = lastTindex + 1; j < t.Length; j++)
                {
                    if (s[i] == t[j])
                    {
                        lastTindex = j;
                        founded++;
                        notFound = false;
                        break;
                    }
                }
                if (notFound) return false;
            }
            Console.WriteLine(founded);
            if (founded != s.Length) return false;
            return true;
        }
        public static int PivotIndex(int[] nums)
        {
            int[] leftArray = (int[])nums.Clone();
            int[] rightArray = (int[])nums.Clone();
            if (leftArray.Length == 1) return 0;
            for (int i = rightArray.Length - 1; i > 0; i--)
            {
                if (i == rightArray.Length - 1) rightArray[i] += 0;
                else rightArray[i] += rightArray[i + 1];
                if (i == 1)
                {
                    if (rightArray[i] == 0) return 0;
                    continue;
                }
            }
            for (int i = 0; i < leftArray.Length - 1; i++)
            {
                if (i == 0) leftArray[i] += 0;
                else leftArray[i] += leftArray[i - 1];

                if (i == leftArray.Length - 2)
                {
                    if (leftArray[i] == 0) return leftArray.Length - 1;
                    continue;
                }
                Console.WriteLine($"{i} {leftArray[i]} {rightArray[i + 2]}");
                if (leftArray[i] == rightArray[i + 2]) return i + 1;

            }


            return -1;
        }
        public static bool DetectCapitalUse(string word)
        {
            int length = word.Length;
            int lowercase = 0;
            int uppercase = 0;
            foreach (var letter in word)
            {
                if (Char.IsUpper(letter))
                    uppercase++;
                else
                    lowercase++;
            }
            Console.WriteLine($"{length} {uppercase} {lowercase} {word[0]} {char.IsUpper(word[0])}");
            if (uppercase == 0 && lowercase == length) return true;
            if (uppercase == length && lowercase == 0) return true;
            if (uppercase == 1 && !char.IsUpper(word[0])) return false;
            if (uppercase > 1) return false;

            return true;
        }



    }
}