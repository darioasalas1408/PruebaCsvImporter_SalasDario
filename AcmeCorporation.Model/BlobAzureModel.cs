using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCorporation.CsvImporter
{
    public class BlobAzureModel
    {
        public string Uri { get; set; }
        public string ContainerClient { get; set; }
        public string BlobClient { get; set; }
    }
}
