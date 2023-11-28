using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        //public List<string> InitializeList(IEnumerable<string> items)
        //{
        //    var bag = new ConcurrentBag<string>();
        //    Parallel.ForEach(items, async i =>
        //    {
        //        var r = await Task.Run(() => i).ConfigureAwait(false);
        //        bag.Add(r);
        //    });
        //    var list = bag.ToList();
        //    return list;
        //}

        public async Task<List<string>> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            var tasks = items.Select(async i =>
            {
                var r = await Task.Run(() => i).ConfigureAwait(false);
                bag.Add(r);
            });

            await Task.WhenAll(tasks);

            var list = bag.ToList();
            return list;
        }


        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            int numberOfThreads = 3;

            // Partition the range for each thread
            int itemsPerThread = itemsToInitialize.Count / numberOfThreads;

            var threads = new List<Thread>();
            for (int threadIndex = 0; threadIndex < numberOfThreads; threadIndex++)
            {
                int start = threadIndex * itemsPerThread;
                int end = (threadIndex == numberOfThreads - 1) ? itemsToInitialize.Count : start + itemsPerThread;

                var thread = new Thread(() =>
                {
                    for (int i = start; i < end; i++)
                    {
                        concurrentDictionary.TryAdd(itemsToInitialize[i], getItem(itemsToInitialize[i]));
                    }
                });

                threads.Add(thread);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

    }
}