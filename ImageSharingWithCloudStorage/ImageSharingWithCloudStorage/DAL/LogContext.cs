using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Core;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;

using ImageSharingWithCloudStorage.Models;

namespace ImageSharingWithCloudStorage.DAL
{
    public class LogContext

    {
        protected TableServiceContext tableContext;

        public LogContext(TableServiceContext context)
        {
            this.tableContext = context;
        }

        public const string LOG_TABLE_NAME = "imageviewlogs";

        protected static LogContext getContext()
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(
                    "DefaultEndpointsProtocol=https;AccountName=tguanimageviewinglogs;AccountKey=sS/Uy0gPveu0eo7uoZgQWgnjllfFZgzo7icHtssMokhqgF9vsdhTnKJswPsSHxUdYsovX7Cyzspg9E5czS97Mg==;EndpointSuffix=core.windows.net");
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable table = client.GetTableReference(LOG_TABLE_NAME);
            LogContext context = new LogContext(client.GetTableServiceContext());
            return context;
        }



        public static IEnumerable<LogEntity> selectLog()
        {

            LogContext context = LogContext.getContext();
            return context.Select();
        }
        public static void addLogEntity(ImageInfo image)
        {
            LogContext context = LogContext.getContext();
            context.addLog(image);
        }

        public void addLog(ImageInfo image)
        {
            LogEntity entity = new LogEntity();
            entity.userId = image.user_id;
            entity.Caption = image.Caption;
            entity.ImageId = image.id;
            entity.Uri = image.URL;
            tableContext.AddObject(LOG_TABLE_NAME, entity);
            tableContext.SaveChangesWithRetries();
        }

        public IEnumerable<LogEntity> Select()
        {
            var result = from entity in tableContext.CreateQuery<LogEntity>(LOG_TABLE_NAME)
                         //where entity.PartitionKey == DateTime.UtcNow.ToString("mmddyyyy")
                         select entity;
            return result.ToList();
        }
    }
}