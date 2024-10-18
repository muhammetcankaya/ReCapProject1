using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete.MessageSucces
{
    public class ResultError:Result
    {
        public ResultError(string message):base(false,message)
        {
            
        }
        public ResultError():base(false)
        {
            
        }
    }
}
