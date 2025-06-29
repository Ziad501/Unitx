﻿using System.Net;

namespace API.Models
{
    public class APIResponse 
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }    
        public List<string> Errors { get; set; }
        public object Result { get; set; }
    }
}
