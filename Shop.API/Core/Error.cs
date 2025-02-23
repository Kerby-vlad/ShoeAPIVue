﻿using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Shop.API.Core
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set;}

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}