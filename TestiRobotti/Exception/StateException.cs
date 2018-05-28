//-----------------------------------------------------------------------
// <copyright file="StateException.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

namespace BotTester.Exception
{
    using System;

    internal class StateException : Exception
    {
        public StateException()
        {
        }

        public StateException(string message)
            : base(message)
        {
        }

        public StateException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}