//-----------------------------------------------------------------------
// <copyright file="HttpResponse.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

using System;

namespace BotTester.Mechanism
{
    internal class HttpResponse
    {
        private TimeSpan elapsedTime;
        private String content;
        private bool success;
        private String errorMessage;

        public TimeSpan ElapsedTime { get => elapsedTime; set => elapsedTime = value; }
        public string Content { get => content; set => content = value; }
        public bool IsSuccess { get => success; set => success = value; }
        public string ErrorMessage { get => errorMessage; set => errorMessage = value; }
    }
}