using ObrabotkaYes.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObrabotkaYes.Domain.Response
{
    public interface IBaseResponce<T>
    {
        string Description { get; }
        StatusCode StatusCode { get; }
        T Result { get; }
    }

    public class BaseResponse<T> : IBaseResponce<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Result { get; set; }
    }
}
