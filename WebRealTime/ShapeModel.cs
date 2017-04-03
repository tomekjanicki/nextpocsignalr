using Newtonsoft.Json;

namespace WebRealTime
{
    public class ShapeModel
    {
        [JsonProperty("left")]
        public double Left { get; set; }
        [JsonProperty("top")]
        public double Top { get; set; }
    }
}