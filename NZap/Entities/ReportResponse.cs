namespace NZap.Entities
{
    public interface IReportResponse
    {
        string ReportData { get; }
    }

    internal struct ReportResponse : IReportResponse
    {
        public string ReportData { get; }

        public ReportResponse(string data)
        {
            ReportData = data;
        }
    }
}
