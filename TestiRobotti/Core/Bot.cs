//-----------------------------------------------------------------------
// <copyright file="Bot.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

namespace BotTester.Core
{
    using BotTester.Exception;
    using BotTester.Mechanism;
    using BotTester.Model;
    using BotTester.View;
    using JsonPath;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

    // https://docs.microsoft.com/pt-br/azure/bot-service/rest-api/bot-framework-rest-direct-line-3-0-end-conversation?view=azure-bot-service-3.0
    internal class Bot
    {
        private static string BASE_URL = "https://directline.botframework.com/v3/directline/conversations/";
        private string botSecret = string.Empty;
        private string token = string.Empty;
        private string conversationId = string.Empty;

        public Bot(string secret)
        {
            this.botSecret = secret;
        }

        public void Reauthenticate()
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("authorization", "Bearer " + this.token);

            var client = new HttpRequest();
            HttpResponse response = client.Request(HttpRequest.HttpMethod.Post, "https://directline.botframework.com/v3/directline/tokens/refresh", header);

            if (response.IsSuccess)
            {
                string content = response.Content;

                token = new Node(content)["token"];
            }
            else
            {
                throw new ConnectException(response.ErrorMessage);
            }
        }

        public void StartConversation()
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("authorization", "Bearer " + this.botSecret);

            var client = new HttpRequest();
            HttpResponse response = client.Request(HttpRequest.HttpMethod.Post, BASE_URL, header);

            if (response.IsSuccess)
            {
                MainForm.List(response.ElapsedTime);

                string content = response.Content;

                token = new Node(content)["token"];
                conversationId = new Node(content)["conversationId"];
            }
            else
            {
                throw new ConnectException(response.ErrorMessage);
            }
        }

        public Activities ReceiveWelcomeMessage()
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("authorization", "Bearer " + this.token);
            header.Add("content-type", "application/json");

            var client = new HttpRequest();
            HttpResponse response = client.Request(HttpRequest.HttpMethod.Get, BASE_URL + conversationId + "/activities/", header);

            if (response.IsSuccess)
            {
                MainForm.List(response.ElapsedTime);

                string content = response.Content;
                Activities activities = JsonConvert.DeserializeObject<Activities>(content);

                return activities;
            }
            else
            {
                throw new ConnectException(response.ErrorMessage);
            }
        }

        public string SendActivityToBot(string user, string text)
        {
            Activity activity = new Activity();
            activity.type = "message";
            activity.from = new From();
            activity.from.id = user;
            activity.text = text;

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            var output = JsonConvert.SerializeObject(activity, settings);

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("authorization", "Bearer " + this.token);
            header.Add("content-type", "application/json");

            var client = new HttpRequest();
            HttpResponse response = client.Request(HttpRequest.HttpMethod.Post, BASE_URL + conversationId + "/activities/", header, output);

            if (response.IsSuccess)
            {
                MainForm.List(response.ElapsedTime);

                string content = response.Content;

                string id = new Node(content)["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    id = id.Split('|')[1];
                }
                else
                {
                    throw new ConnectException("Received invalid Id: " + content);
                }

                return id;
            }
            else
            {
                throw new ConnectException(response.ErrorMessage);
            }
        }

        public string SendCustomActivityToBot(string activity)
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("authorization", "Bearer " + this.token);
            header.Add("content-type", "application/json");

            var client = new HttpRequest();
            HttpResponse response = client.Request(HttpRequest.HttpMethod.Post, BASE_URL + conversationId + "/activities/", header, activity);

            if (response.IsSuccess)
            {
                MainForm.List(response.ElapsedTime);

                string content = response.Content;

                string id = new Node(content)["id"];

                if (!string.IsNullOrEmpty(id))
                {
                    id = id.Split('|')[1];
                }
                else
                {
                    throw new ConnectException("Received invalid Id: " + content);
                }

                return id;
            }
            else
            {
                throw new ConnectException(response.ErrorMessage);
            }
        }

        public Activities ReceiveActivitiesFromBot(string id)
        {
            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("authorization", "Bearer " + this.token);
            header.Add("content-type", "application/json");

            var client = new HttpRequest();
            HttpResponse response = client.Request(HttpRequest.HttpMethod.Get, BASE_URL + conversationId + "/activities/" + "?watermark=" + id, header);

            if (response.IsSuccess)
            {
                MainForm.List(response.ElapsedTime);

                string content = response.Content;

                Activities activities = JsonConvert.DeserializeObject<Activities>(content);

                return activities;
            }
            else
            {
                throw new ConnectException(response.ErrorMessage);
            }
        }

        public void EndConversation()
        {
            throw new NotImplementedException();
        }
    }
}