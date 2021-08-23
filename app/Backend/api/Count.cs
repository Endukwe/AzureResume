using Newtonsoft.Json;

namespace Company.Function
{
    public class Count
    {
        [JsonProperty ("id")]
        public string Id { get; set; }
        [JsonProperty ("visitorcount")]
        public int count { get; set; }

    }
}