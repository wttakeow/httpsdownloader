using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            FileStream m_outputStream;
            string tempFile = "nicefile.zip";
            FileInfo fileInfo = new FileInfo(tempFile);
            if (!Directory.Exists(fileInfo.DirectoryName))
            {
                Directory.CreateDirectory(fileInfo.DirectoryName);
            }
            Stream downloadStream = null;
            m_outputStream = new FileStream(tempFile, FileMode.Create, FileAccess.Write);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string url = "https://github.com/electron/electron-api-demos/archive/master.zip";
            WebRequest request = WebRequest.Create(url);
            HttpWebRequest httpRequest = (HttpWebRequest)request;
            HttpWebResponse response = (HttpWebResponse)httpRequest.GetResponse();
            long fileSize = response.ContentLength;
            m_outputStream.SetLength(Math.Max(fileSize, 0));
            downloadStream = response.GetResponseStream();
            long readSize = 0;
            int buffSize = 8192;
            byte[] buffer = new byte[buffSize];
            do
            {
                readSize = downloadStream.Read(buffer, 0, buffSize);

            
                m_outputStream.Write(buffer, 0, (int)readSize);


            } while (readSize > 0);

        }

        

        //request.Timeout = 3000;

        //request.Proxy = CreateProxy(url, proxyServer, proxyUsername, proxyPassword);
        //
       

    }







}


