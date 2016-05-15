using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class AllAdds
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "price")]
        public string Price { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }



        [JsonProperty(PropertyName = "Dlongitude")]
        public double Dlongitude { get; set; }

        [JsonProperty(PropertyName = "Dlatitude")]
        public double Dlatitude { get; set; }



        [JsonProperty(PropertyName = "picture")]
        public string PictureName { get; set; }

        [JsonProperty(PropertyName = "accID")]
        public string AccID { get; set; }

        //[JsonProperty(PropertyName = "picturebloburl")]
        //public string PictureBlobUrl { get; set; }

        //[JsonProperty(PropertyName = "sasQueryString")]
        //public string SasQueryString { get; set; }


    }
}
