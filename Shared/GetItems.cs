using System.Collections.Generic;

namespace Shared
{
    public class GetItems
    {
        public WebContextData Data { get; set; }

        public IEnumerable<int> Items { get; set; }
    }
}