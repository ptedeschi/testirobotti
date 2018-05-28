//-----------------------------------------------------------------------
// <copyright file="TestSuite.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------
namespace BotTester.Model
{
    public class TestSuite
    {
        public string name { get; set; }
        public string description { get; set; }
        public string secretKey { get; set; }
        public Test[] test { get; set; }
        public Looptest[] looptest { get; set; }
    }

    public class Test
    {
        public string request { get; set; }
        public string[] response { get; set; }
        public string custom_request { get; set; }
    }

    public class Looptest
    {
        public string request { get; set; }
        public string[] response { get; set; }
        public string custom_request { get; set; }
    }
}