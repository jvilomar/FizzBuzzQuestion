using System;

namespace FizzBuzzQ.TechDemo.Models
{
    public class RequestInfo
    {
        public int Id { get; set; }
        public string RequestData { get; set; } = string.Empty;
        public string RequestDate { get; set; } = DateTime.Now.ToString("yyyyMMdd");
    }
}
