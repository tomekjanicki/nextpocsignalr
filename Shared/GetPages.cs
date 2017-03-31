using System.Collections.Generic;

namespace Shared
{
    public sealed class GetPages : Base
    {
        public IEnumerable<int> Items { get; set; }
    }
}