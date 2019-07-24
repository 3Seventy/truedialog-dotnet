using Newtonsoft.Json;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace TrueDialog.Helpers
{
    internal class NewtonsoftSerializer : ISerializer, IDeserializer
    {
        public string ContentType
        {
            get { return "application/json"; }
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
