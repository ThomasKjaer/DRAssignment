﻿namespace DR.Common.Entities
{
    public class Response<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
    }
}
