using System;
using System.Collections.Generic;
using System.Diagnostics;
using DSA.DataStructures.Trees;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX = 100000;
            int ITERATIONS = 11;

            double totalOrderedCreate = 0;
            double totalUnorderedCreate = 0;

            double totalOrderedGet = 0;
            double totalUnorderedGet = 0;

            double totalOrderedRemove = 0;
            double totalUnorderedRemove = 0;

            double totalHeightOrdered = 0;
            double totalHeightUnordered = 0;

            IKeyValueMap<int, int> keyValueMap = null ;

            var dictionaryKeyValueMap = new DictionaryKeyValueMap<int, int>();
            var bstKeyValueMap = new BinarySearchTreeKeyValueMap<int, int>();
            var avlKeyValueMap = new AVLTreeKeyValueMap<int, int>();
            var redblackKeyValueMap = new RedBlackTreeKeyValueMap<int, int>();

            keyValueMap = dictionaryKeyValueMap;

            for (int c = 0; c < ITERATIONS; c++)
            {
                var intKeyValuePairs = new List<KeyValuePair<int, int>>();

                for (int i = 0; i < MAX; i++)
                {
                    intKeyValuePairs.Add(new KeyValuePair<int, int>(i, i + 42));
                }


                keyValueMap.Clear();
            // Ordered
                //Add
                totalOrderedCreate += CreateKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);

                //Height
                totalHeightOrdered += keyValueMap.Height;

                //Search
                totalOrderedGet += QueryKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);

                //Remove
                totalOrderedRemove += RemoveKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);

            // Unordered
                intKeyValuePairs.Shuffle();
                keyValueMap.Clear();

                //Add
                totalUnorderedCreate += CreateKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);

                //Height
                totalHeightUnordered += keyValueMap.Height;

                //Search
                totalUnorderedGet += QueryKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);

                //Remove
                totalUnorderedRemove += RemoveKeyValueMap<int, int>(keyValueMap, intKeyValuePairs);

            }

            Console.WriteLine(keyValueMap.GetType());

            Console.WriteLine("Ordered");
            Console.WriteLine("Add:" + totalOrderedCreate / ITERATIONS);
            Console.WriteLine("Height:" + totalHeightOrdered/ ITERATIONS);
            Console.WriteLine("Search:" + totalOrderedGet / ITERATIONS);
            Console.WriteLine("Remove:" + totalOrderedRemove / ITERATIONS);

            Console.WriteLine("Unordered");
            Console.WriteLine("Add:" + totalUnorderedCreate / ITERATIONS);
            Console.WriteLine("Height:" + totalHeightUnordered / ITERATIONS);
            Console.WriteLine("Search:" + totalUnorderedGet / ITERATIONS);
            Console.WriteLine("Remove:" + totalUnorderedRemove / ITERATIONS);

        }


        public static double CreateKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey,TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs )
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            // do the work

            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Add(kvp.Key, kvp.Value);
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            return stopwatch.Elapsed.TotalSeconds;
            

        }


        //TODO
        public static double QueryKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Get(kvp.Key);
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            return stopwatch.Elapsed.TotalSeconds;
        }

        //TODO
        public static double RemoveKeyValueMap<TKey, TValue>(
                IKeyValueMap<TKey, TValue> keyValueMap,
                List<KeyValuePair<TKey, TValue>> keyValuePairs)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            foreach (var kvp in keyValuePairs)
            {
                keyValueMap.Remove(kvp.Key);
            }

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed.TotalSeconds);
            return stopwatch.Elapsed.TotalSeconds;
        }
    }
}
