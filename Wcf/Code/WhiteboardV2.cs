using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Wcf.Code
{
    public sealed class WhiteboardV2
    {
        public const string D1S1Id = "6215bf87-b494-42d4-830d-fcd07af7a5e7";

        public const string D1S2Id = "6215bf88-b494-42d4-830d-fcd07af7a5e7";

        public const string D2S1Id = "6215bf89-b494-42d4-830d-fcd07af7a5e7";

        public const string D2S2Id = "6215bf85-b494-42d4-830d-fcd07af7a5e7";

        public static void Reset()
        {
            lock (_pagesWithSquares)
            {
                _pagesWithSquares = GetPagesWithSquares();
            }
        }

        private static Dictionary<int, Dictionary<Guid, Square>> GetPagesWithSquares()
        {
            var d1S1 = new Square { Id = Guid.Parse(D1S1Id), Left = 0, Top = 0 };

            var d1S2 = new Square { Id = Guid.Parse(D1S2Id), Left = 20, Top = 20 };

            var d2S1 = new Square { Id = Guid.Parse(D2S1Id), Left = 0, Top = 0 };

            var d2S2 = new Square { Id = Guid.Parse(D2S2Id), Left = 50, Top = 50 };

            return new Dictionary<int, Dictionary<Guid, Square>>
            {
                {
                    1,  new Dictionary<Guid, Square>
                    {
                        { d1S1.Id, d1S1 },
                        { d1S2.Id, d1S2 }
                    }
                },
                {
                    2,  new Dictionary<Guid, Square>
                    {
                        { d2S1.Id, d2S1 },
                        { d2S2.Id, d2S2 }
                    }
                }
            };
        }


        private static Dictionary<int, Dictionary<Guid, Square>> _pagesWithSquares;

        static WhiteboardV2()
        {
            _pagesWithSquares = GetPagesWithSquares();
        }

        public IEnumerable<int> GetPages()
        {
            lock (_pagesWithSquares)
            {
                return _pagesWithSquares.Keys;
            }            
        }

        public IEnumerable<Square> GetSquares(int page)
        {
            lock (_pagesWithSquares)
            {
                var squaresDictionary = _pagesWithSquares[page];
                return squaresDictionary.Values;
            }
        }

        public void UpdateSquares(int page, IEnumerable<Square> squares)
        {
            lock (_pagesWithSquares)
            {
                var squaresDictionary = _pagesWithSquares[page];

                var squareList = squares.ToList();

                foreach (var square in squareList)
                {
                    if (squaresDictionary.ContainsKey(square.Id))
                    {
                        squaresDictionary[square.Id] = square;
                    }
                    else
                    {
                        squaresDictionary.Add(square.Id, square);
                    }
                }

                var squareIdList = squareList.Select(square => square.Id).ToList();

                var squareIdsToRemove = squaresDictionary.Keys.Where(guid => !squareIdList.Contains(guid)).ToList();

                foreach (var squareId in squareIdsToRemove)
                {
                    squaresDictionary.Remove(squareId);
                }
            }
        }
    }
}