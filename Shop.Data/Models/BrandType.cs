﻿using System.Text.Json.Serialization;

namespace Shop.Data.Models
{
    public class BrandType: Base
    {
        [JsonIgnore]
        public long BrandId { get; set; }
        public Brand Brand { get; set; }
        [JsonIgnore]
        public long TypeId { get; set; }
        public Type Type { get; set; }
    }
}