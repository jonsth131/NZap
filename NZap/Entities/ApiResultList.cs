using System.Collections.Generic;

namespace NZap.Entities
{
    public interface IApiResultList
    {
        ICollection<IApiResultElement> ApiResultElements { get; set; }
        string Key { get; set; }
    }

    internal class ApiResultList : IApiResultList
    {
        public ICollection<IApiResultElement> ApiResultElements { get; set; }
        public string Key { get; set; }

        public ApiResultList()
        {
            ApiResultElements = new List<IApiResultElement>();
        }
    }
}
