//-----------------------------------------------------------------------
// <copyright file="NamedBackgroundWorker.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

namespace TestiRobotti.Worker
{
    using System.ComponentModel;

    internal class NamedBackgroundWorker : BackgroundWorker
    {
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}