//-----------------------------------------------------------------------
// <copyright file="HttpRequest.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

using RestSharp;
using System.Collections.Generic;
using System.Diagnostics;

namespace BotTester.Mechanism
{
    internal class HttpRequest
    {
        private static int timeout = 60000;

        public enum HttpMethod
        {
            Get = 0,
            Post = 1
        }

        public HttpResponse Request(HttpMethod method, string url, Dictionary<string, string> header, string body = null)
        {
            var client = new RestClient(url);
            client.Timeout = timeout;

            var request = new RestRequest(ConvertHttpMethod(method));

            foreach (KeyValuePair<string, string> pair in header)
            {
                request.AddHeader(pair.Key, pair.Value);
            }

            if (!string.IsNullOrEmpty(body))
            {
                request.AddParameter("application/json", body, ParameterType.RequestBody);
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();

            IRestResponse response = client.Execute(request);

            timer.Stop();

            HttpResponse httpResponse = new HttpResponse();
            httpResponse.ElapsedTime = timer.Elapsed;

            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                httpResponse.IsSuccess = false;
                httpResponse.ErrorMessage = response.ErrorMessage;
            }
            else
            {
                httpResponse.IsSuccess = true;
                httpResponse.Content = response.Content;
            }

            return httpResponse;
        }

        private Method ConvertHttpMethod(HttpMethod method)
        {
            switch (method)
            {
                case HttpMethod.Get:
                    return Method.GET;

                case HttpMethod.Post:
                    return Method.POST;

                default:
                    return Method.POST;
            }
        }
    }
}