using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNetCore
{
    public class CatalogSettings
    {
        public string PicBaseUrl { get; set; } = "http://http://192.168.99.100:3000/api/v1/catalog/items/[0]/pic/";

        public string EventBusConnection { get; set; } = "192.168.99.100:3000";

        public bool UseCustomizationData { get; set; }

        public bool AzureStorageEnabled { get; set; }
    }
}
