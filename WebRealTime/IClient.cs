namespace WebRealTime
{
    public interface IClient
    {
        void NewItemAdded(int item);

        void ShapeUpdated();
    }
}