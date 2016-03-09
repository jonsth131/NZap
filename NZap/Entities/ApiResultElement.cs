namespace NZap.Entities
{
    public interface IApiResultElement
    {
        string Key { get; set; }
        string Value { get; set; }
    }

    internal struct ApiResultElement : IApiResultElement
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
