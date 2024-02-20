using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
       
       int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);

        double mean = arr.Sum() / (double)n;
        double median = CalculateMedian(arr);
        int mode = CalculateMode(arr);

        Console.WriteLine($"{mean:F1}");
        Console.WriteLine($"{median:F1}");
        Console.WriteLine($"{mode}");
    }

    static double CalculateMedian(int[] arr)
    {
        Array.Sort(arr);
        int n = arr.Length;
        if (n % 2 == 0)
            return (arr[n / 2 - 1] + arr[n / 2]) / 2.0;
        else
            return arr[n / 2];
    }

    static int CalculateMode(int[] arr)
    {
        Dictionary<int, int> frequencyMap = new Dictionary<int, int>();
        foreach (int num in arr)
        {
            if (frequencyMap.ContainsKey(num))
                frequencyMap[num]++;
            else
                frequencyMap[num] = 1;
        }

        int maxFrequency = frequencyMap.Max(x => x.Value);
        int mode = frequencyMap.First(x => x.Value == maxFrequency).Key;
        return mode;
    }
}