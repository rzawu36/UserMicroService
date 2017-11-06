using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserMicroService.Util
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ActiveStatusEnum
    {
        All,
        Active,
        Inactive
    }
}