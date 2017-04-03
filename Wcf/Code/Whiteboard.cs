using System.Collections.Generic;
using Shared;

namespace Wcf.Code
{
    public sealed class Whiteboard
    {
        private static readonly Dictionary<int, List<int>> PageItemsDictionary = new Dictionary<int, List<int>>
        {
            { 1, new List<int> { 1, 2, 3 } },
            { 2, new List<int> { 4, 5, 6 } }
        };

        private static readonly Dictionary<int, Shape> PageShapeDictionary = new Dictionary<int, Shape>
        {
            { 1, new Shape { Left = 0, Top = 0 } },
            { 2, new Shape { Left = 0, Top = 0 } }
        };

        public IEnumerable<int> GetItems(int page)
        {
            return PageItemsDictionary[page];
        }

        public IEnumerable<int> GetPages()
        {
            return PageItemsDictionary.Keys;
        }

        public Shape GetShape(int page)
        {
            return PageShapeDictionary[page];
        }

        public void UpdateShape(Shape shape, int page)
        {
            PageShapeDictionary[page] = new Shape { Top = shape.Top, Left = shape.Left };
        }

        public void AddItem(int item, int page)
        {
            PageItemsDictionary[page].Add(item);
        }
    }
}