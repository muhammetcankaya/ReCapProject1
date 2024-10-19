using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Concrete.MessageSucces
{
    public class ResultSuccess:Result
    {
        public ResultSuccess(string message):base(true,message)
        {
            
        }
        public ResultSuccess():base(true)
        {
            
        }
    }
}
