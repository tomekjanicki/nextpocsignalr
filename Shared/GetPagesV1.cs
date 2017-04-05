using System.Collections.Generic;

namespace Shared
{
    public sealed class GetPagesV1 : Base
    {
        public IEnumerable<int> Items { get; set; }
    }
}