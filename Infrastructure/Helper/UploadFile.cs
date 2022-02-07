using Common.Infrastructure;
using Core.Component.Library.StorageV2;
using System;

namespace Infrastructure.Helper
{
    public static class UploadFile
    {
        public static string Upload(string name, string contentFile, Storage configuration)
        {
            var file = Convert.FromBase64String(contentFile);
            var resp = new BlobCloud().UploadFile(file, name, configuration.ConnectionString, configuration.ContaninerName);
            return resp.Uri.AbsoluteUri;
        }
    }
}
