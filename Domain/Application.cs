using System;

namespace Domain
{
    public class Application
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string PathLocal { get; set; }
        public bool DebuggingMode { get; set; }
    }
}