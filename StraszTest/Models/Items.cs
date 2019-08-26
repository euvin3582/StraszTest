using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace StraszTest.Models {
    
    public class Item {
        public Guid ItemId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemTypeEnum ItemType {get; set;}
    }
}
