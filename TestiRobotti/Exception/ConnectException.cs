//-----------------------------------------------------------------------
// <copyright file=ConnectException.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

namespace BotTester.Exception
{
    internal class ConnectException : System.Exception
    {
        public ConnectException()
        {
        }

        public ConnectException(string message)
            : base(message)
        {
        }

        public ConnectException(string message, System.Exception inner)
            : base(message, inner)
        {
        }
    }
}