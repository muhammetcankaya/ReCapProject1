﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete.DataMessageSucces
{
    public class DataResultError<T>:DataResult<T>
    {
        public DataResultError(T data, string message) : base(data, true, message)
        {

        }
        public DataResultError(T data) : base(data, false)
        {

        }
    }
}
