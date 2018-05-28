//-----------------------------------------------------------------------
// <copyright file="TextUtils.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

using System;

namespace BotTester.Util
{
    internal class TextUtils
    {
        public static String Clean(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = text.Replace("\r", string.Empty);
                text = text.Replace("\n", string.Empty);
                text = text.Replace("\"", string.Empty);
            }

            return text;
        }
    }
}