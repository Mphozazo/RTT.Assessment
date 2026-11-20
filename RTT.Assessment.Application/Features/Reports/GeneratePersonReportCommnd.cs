using MediatR;

namespace RTT.Assessment.Application.Features.Reports
{
    public class GeneratePersonReportCommnd : IRequest<PersonReportDto>
    {
        public int PersonId { get; set; }
    }
}
