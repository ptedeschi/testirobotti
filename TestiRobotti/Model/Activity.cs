//-----------------------------------------------------------------------
// <copyright file="Activity.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

using System;

namespace BotTester.Model
{
    public class Activities
    {
        public Activity[] activities { get; set; }
        public string watermark { get; set; }
    }

    public class Activity
    {
        public string type { get; set; }
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public DateTime localTimestamp { get; set; }
        public string channelId { get; set; }
        public From from { get; set; }
        public Conversation conversation { get; set; }
        public string attachmentLayout { get; set; }
        public string text { get; set; }
        public Attachment[] attachments { get; set; }
        public object[] entities { get; set; }
        public string replyToId { get; set; }
    }

    public class From
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Conversation
    {
        public string id { get; set; }
    }

    public class Attachment
    {
        public string contentType { get; set; }
        public Content content { get; set; }
    }

    public class Content
    {
        public string title { get; set; }
        public string subtitle { get; set; }
        public Image[] images { get; set; }
        public Button[] buttons { get; set; }
    }

    public class Image
    {
        public string url { get; set; }
    }

    public class Button
    {
        public string type { get; set; }
        public string title { get; set; }
        public string value { get; set; }
    }
}