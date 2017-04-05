using System;
using Shared;

namespace WcfProxy.RealTime
{
    public interface IClinetV2
    {
        void SquareDeleted(Guid id);

        void SquareMoved(Square square);

        void SquareAdded(Square square);
    }
}