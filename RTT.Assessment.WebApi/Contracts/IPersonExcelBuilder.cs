using RTT.Assessment.Application.Features.Reports;

namespace RTT.Assessment.WebApi.Contracts
{
    public interface IPersonExcelBuilder
    {
        byte[] Build(PersonReportDto report);
    }
}
