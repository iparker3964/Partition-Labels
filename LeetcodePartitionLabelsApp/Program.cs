using System;
using System.Collections.Generic;

namespace LeetcodePartitionLabelsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "ababcbacadefegdehijhklij";
            Console.WriteLine(string.Join(',',PartitionLabels(input)));
            Console.ReadLine();
        }
        public static List<int> PartitionLabels(string input)
        {
            char[] inputArray = input.ToCharArray();
            int[] asciiGrid = new int[128];

            for (int i = 0; i < inputArray.Length; i++)
            {
                char currChar = inputArray[i];
                asciiGrid[currChar] = i;
            }

            int left = 0;
            int right = 0;
            int index = 0;

            List<int> results = new List<int>();

            while (index < inputArray.Length)
            {
                char currChar = inputArray[index];

                right = Math.Max(right,asciiGrid[currChar]);

                if (right == index)
                {
                    int size = right - left + 1;

                    results.Add(size);

                    right++;
                    left = right;
                }
                index++;
            }
            return results;
        }
    }
}
