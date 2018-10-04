using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Core;
using Microsoft.WindowsAzure.Storage.Blob;

namespace ImageSharingWithCloudStorage.DAL
{
    public class ImageStorage
    {
        public const bool USE_BLOB_STORAGE = true;

        public const String ACCOUNT = "tguanimagesharing";
        public const String CONTAINER = "imagesharingcontainer";


        public static void saveFile(HttpServerUtilityBase server,
                                    HttpPostedFileBase imageFile,
                                    int imageId)
        {
            if (USE_BLOB_STORAGE)
            {
                CloudStorageAccount account = CloudStorageAccount.Parse(
                    "DefaultEndpointsProtocol=https;AccountName=tguanimagesharing;AccountKey=4sxeD+pfgICjWnEyqqucfK5e8yvwN+5Uwnr2y5+fzgNObqoN0LyR0otesvxdlVHo8HP7wXsI4ei3uFVUpigxNQ==;EndpointSuffix=core.windows.net");
                CloudBlobClient client = account.CreateCloudBlobClient();
                CloudBlobContainer container = client.GetContainerReference("imagesharingcontainer");
                CloudBlockBlob blob = container.GetBlockBlobReference(filePath(server, imageId));
                blob.UploadFromStream(imageFile.InputStream);
            }
            else
            {
                imageFile.SaveAs(filePath(server, imageId));
            }
        }

        public static void deleteFile(HttpServerUtilityBase server,
                                    int imageId)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(
                   "DefaultEndpointsProtocol=https;AccountName=tguanimagesharing;AccountKey=4sxeD+pfgICjWnEyqqucfK5e8yvwN+5Uwnr2y5+fzgNObqoN0LyR0otesvxdlVHo8HP7wXsI4ei3uFVUpigxNQ==;EndpointSuffix=core.windows.net");
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("imagesharingcontainer");
            CloudBlockBlob blob = container.GetBlockBlobReference(filePath(server, imageId));
            blob.Delete();
        }

        public static String filePath(HttpServerUtilityBase server, int imageId)
        {
            String imageFile = "";
            if (USE_BLOB_STORAGE)
            {
                imageFile = imageId + ".jpg";
            }
            else
            {
                imageFile = server.MapPath("~/Content/Images/" + imageId + ".jpg");
            }
            return imageFile;
        }

        public static String ImageURl(UrlHelper helper, int imageId)
        {
            String uri = "";
            if (USE_BLOB_STORAGE)
            {
                uri = "http://" + ACCOUNT + ".blob.core.windows.net/" + CONTAINER + "/" + imageId + ".jpg";
            }else
            {
                uri = helper.Content("~/Content/Images/" + imageId + ".jpg");
            }
            return uri;
        }
    }
}