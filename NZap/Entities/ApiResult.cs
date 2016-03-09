using System.Collections.Generic;

namespace NZap.Entities
{
    public interface IApiResult
    {
        ICollection<IApiResultList> ResultList { get; set; }
        string Key { get; set; }
        string Value { get; set; }
    }

    internal class ApiResult : IApiResult
    {
        public ICollection<IApiResultList> ResultList { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public ApiResult()
        {
            ResultList = new List<IApiResultList>();
        }
    }
}
