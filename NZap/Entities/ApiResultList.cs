using System.Collections.Generic;

namespace NZap.Entities
{
    public class ApiResultList
    {
        public ICollection<ApiResultElement> ApiResultElements { get; set; }
        public string Key { get; set; }

        public ApiResultList()
        {
            ApiResultElements = new List<ApiResultElement>();
        }
    }
}
