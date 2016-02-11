using System.Collections.Generic;

namespace NZap.Entities
{
    public interface IApiResult
    {
        ICollection<ApiResultList> ResultList { get; set; }
        string Key { get; set; }
        string Value { get; set; }
    }

    public class ApiResult : IApiResult
    {
        public ICollection<ApiResultList> ResultList { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public ApiResult()
        {
            ResultList = new List<ApiResultList>();
        }
    }
}
