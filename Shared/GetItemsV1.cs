using System.Collections.Generic;

namespace Shared
{
    public sealed class GetItemsV1 : Base
    {
        public IEnumerable<int> Items { get; set; }
    }
}