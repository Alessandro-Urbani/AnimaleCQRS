using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AnimaleCQRS.Shared
{
    public class BusContainerMessage
    {
        public string Type { get; set; }
        public string Payload { get; set; }

        public BusContainerMessage(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }

        public static BusContainerMessage Serializza(string type, object value)
        {

            if (value != null && !String.IsNullOrEmpty(type))
                return new BusContainerMessage(type, JsonConvert.SerializeObject(value));

            throw new Exception("Serializzazione non riuscita" + $"Type: {type}" + $"Value{value}");

        }

        public static T Deserializza<T>(string value)
        {
            if (!String.IsNullOrEmpty(value))
                return JsonConvert.DeserializeObject<T>(value);

            throw new Exception("Deserializzazione non riuscita" + $"Value{value}");
        }

        public async static Task<T> DeserializzaHttp<T>(HttpResponseMessage value)
        {

            var json = await value.Content.ReadAsStringAsync();
            try
            {
                BusContainerMessage bus = JsonConvert.DeserializeObject<BusContainerMessage>(json);
                return JsonConvert.DeserializeObject<T>(bus.Payload);
            }
            catch (Exception)
            {
                throw new Exception("Deserializzazione Http non avvenuta");
            }
        }
    }
}

