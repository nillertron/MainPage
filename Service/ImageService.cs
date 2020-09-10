using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class ImageService : IImageService
    {
        private RestClient client;
        public ImageService()
        {
            client = new RestClient();
        }
        public async Task UploadFotoToServer()
        {

        }
    }
}
