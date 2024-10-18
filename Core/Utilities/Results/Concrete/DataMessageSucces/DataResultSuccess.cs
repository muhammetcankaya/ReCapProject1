using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete.DataMessageSucces
{
    public class DataResultSuccess<T>:DataResult<T>
    {
        public DataResultSuccess(T data,string message):base(data,true,message)
        {
            
        }
        public DataResultSuccess(T data):base(data,false) 
        {
            
        }
    }
}
