using System;
using System.Collections.Generic;

namespace Wcf.Code
{
    public sealed class Whiteboard
    {
        private static readonly Dictionary<int, Tuple<string, List<int>>> PageItemsDictionary = new Dictionary<int, Tuple<string, List<int>>>
        {
            { 1, new Tuple<string, List<int>>(null, new List<int> { 1, 2, 3 }) },
            { 2, new Tuple<string, List<int>>(null, new List<int> { 4, 5, 6 }) }
        };

        public IEnumerable<int> GetItems(int page)
        {
            return PageItemsDictionary[page].Item2;
        }

        public IEnumerable<int> GetPages()
        {
            return PageItemsDictionary.Keys;
        }

        public void EndEdit(string userName, int page)
        {
            if (string.IsNullOrEmpty(PageItemsDictionary[page].Item1) || PageItemsDictionary[page].Item1 == userName)
            {
                PageItemsDictionary[page] = new Tuple<string, List<int>>(null, PageItemsDictionary[page].Item2);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Add(int item, string userName, int page)
        {
            if (string.IsNullOrEmpty(PageItemsDictionary[page].Item1) || PageItemsDictionary[page].Item1 == userName)
            {
                PageItemsDictionary[page].Item2.Add(item);
                PageItemsDictionary[page] = new Tuple<string, List<int>>(userName, PageItemsDictionary[page].Item2);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}