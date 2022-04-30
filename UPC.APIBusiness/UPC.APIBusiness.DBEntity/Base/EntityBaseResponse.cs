using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityBaseResponse
    {
        public bool isSuccess { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public object data { get; set; }
    }
}