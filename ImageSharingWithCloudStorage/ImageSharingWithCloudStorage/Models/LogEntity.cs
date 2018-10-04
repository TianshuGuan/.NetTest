using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Core;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;

namespace ImageSharingWithCloudStorage.Models
{
    public class LogEntity:TableServiceEntity
    {

        public LogEntity()
        {
            createKeys();
        }

        public string userId { get; set; }

        public string Caption { get; set; }

        public string Uri { get; set; }

        public int ImageId { get; set; }

        public DateTime EntryTime{ get; set; }

        public void createKeys()
        {
            EntryTime = DateTime.UtcNow;
            PartitionKey = EntryTime.ToString("mmddyyyy");
            RowKey = string.Format("{0}-{1:10}_{2}",ImageId,DateTime.MaxValue.Ticks-EntryTime.Ticks,Guid.NewGuid());
        }
    }
}