using System.Collections.Generic;

namespace Shared
{
    public sealed class GetPagesV2 : Base
    {
        public IEnumerable<int> Items { get; set; }
    }
}