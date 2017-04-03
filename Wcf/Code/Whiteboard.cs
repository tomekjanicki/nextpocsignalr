using System.Collections.Generic;

namespace Wcf.Code
{
    public sealed class Whiteboard
    {
        private static readonly Dictionary<int, List<int>> PageItemsDictionary = new Dictionary<int, List<int>>
        {
            { 1, new List<int> { 1, 2, 3 } },
            { 2, new List<int> { 4, 5, 6 } }
        };

        public IEnumerable<int> GetItems(int page)
        {
            return PageItemsDictionary[page];
        }

        public IEnumerable<int> GetPages()
        {
            return PageItemsDictionary.Keys;
        }

        public void Add(int item, int page)
        {
            PageItemsDictionary[page].Add(item);
        }
    }
}