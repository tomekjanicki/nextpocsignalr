namespace WebRealTime
{
    public interface IClient
    {
        void BroadcastMessage(int item);

        void UpdateShape(ShapeModel model);
    }
}