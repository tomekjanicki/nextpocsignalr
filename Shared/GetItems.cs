using System.Collections.Generic;

namespace Shared
{
    public sealed class GetItems : Base
    {
        public IEnumerable<int> Items { get; set; }
    }
}