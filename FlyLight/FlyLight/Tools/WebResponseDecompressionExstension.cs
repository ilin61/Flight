﻿using System.IO;
using System.Linq;
using System.Net;

namespace FlyLight.Tools
{
    public static class WebResponseDecompressionExstension
    {
        public static Stream GetDecompressedStream(this WebResponse webResponse)
        {
            Stream stream;
            const string contentEncodingHeader = "Content-Encoding";
            if (!webResponse.Headers.AllKeys.Contains(contentEncodingHeader))
                return null;

            var contentEncoding = webResponse.Headers[contentEncodingHeader];
            if (string.IsNullOrEmpty(contentEncoding))
                return webResponse.GetResponseStream();
            stream = webResponse.GetResponseStream();

            /*switch (contentEncoding.ToUpperInvariant())
            {
                case "GZIP":
                    stream = new GZipStream(webResponse.GetResponseStream(), CompressionMode.Decompress);
                    break;
                case "DEFLATE":
                    stream = new DeflateStream(webResponse.GetResponseStream(), CompressionMode.Decompress);
                    break;

                default:
                    stream = webResponse.GetResponseStream();
                    break;
            }*/
            return stream;
        }
    }
}
