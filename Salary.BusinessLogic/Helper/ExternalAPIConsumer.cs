using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BusinessLogic.Helper
{
    public class ExternalAPIConsumer
    {

        public string GetDataFromExternalAPI(string externalUrl)
        {

            if (string.IsNullOrEmpty(externalUrl.Trim()))
            {
                throw new ArgumentException("External API url not found or not provided.");
            }

            var request = (HttpWebRequest)WebRequest.Create(externalUrl);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return string.Empty;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);

                            return responseBody;

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
                throw new Exception("An error ocurred reaching the external API. " + ex.Message);
            }

        }
    }
}
