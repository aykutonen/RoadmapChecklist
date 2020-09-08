﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class ReturnModel<T>
    {
        public bool IsSuccess { get; set; } = true;
        public T Data { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; } = null;
    }
}
