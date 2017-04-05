using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Wcf.Code
{
    public sealed class WhiteboardV2Proxy
    {
        private static Dictionary<int, Tuple<bool, Dictionary<Guid, Square>>> _pagesWithSquares;

        private readonly WhiteboardV2 _whiteboardV2 = new WhiteboardV2();

        static WhiteboardV2Proxy()
        {
            _pagesWithSquares = new Dictionary<int, Tuple<bool, Dictionary<Guid, Square>>>();
        }

        public static void Reset()
        {
            lock (_pagesWithSquares)
            {
                _pagesWithSquares = new Dictionary<int, Tuple<bool, Dictionary<Guid, Square>>>();
            }
        }

        public IEnumerable<int> GetPages() => _whiteboardV2.GetPages();

        public IEnumerable<Square> GetSquares(int page)
        {
            lock (_pagesWithSquares)
            {
                InitPage(page);
                return _pagesWithSquares[page].Item2.Values;
            }
        }

        public void InsertOrUpdateSquare(int page, Square square)
        {
            lock (_pagesWithSquares)
            {
                InitPage(page);
                var tuple = _pagesWithSquares[page];
                var dictionary = tuple.Item2;

                if (dictionary.ContainsKey(square.Id))
                {
                    dictionary[square.Id] = square;
                }
                else
                {
                    dictionary.Add(square.Id, square);
                }

                _pagesWithSquares[page] = new Tuple<bool, Dictionary<Guid, Square>>(true, dictionary);
            }
        }

        public void DeleteSquare(int page, Guid id)
        {
            lock (_pagesWithSquares)
            {
                InitPage(page);

                var tuple = _pagesWithSquares[page];

                var dictionary = tuple.Item2;

                if (dictionary.ContainsKey(id))
                {
                    dictionary.Remove(id);
                    _pagesWithSquares[page] = new Tuple<bool, Dictionary<Guid, Square>>(true, dictionary);
                }
            }
        }

        public void SaveChanges(int page)
        {
            lock (_pagesWithSquares)
            {
                InitPage(page);
                var pagesWithSquare = _pagesWithSquares[page];
                if (pagesWithSquare.Item1)
                {
                    _whiteboardV2.UpdateSquares(page, pagesWithSquare.Item2.Values);
                    _pagesWithSquares.Remove(page);
                }
            }
        }

        private void InitPage(int page)
        {
            if (!_pagesWithSquares.ContainsKey(page))
            {
                var squareDictionary = _whiteboardV2.GetSquares(page).ToDictionary(square => square.Id, square => square);
                _pagesWithSquares.Add(page, new Tuple<bool, Dictionary<Guid, Square>>(false, squareDictionary));
            }
        }
    }
}