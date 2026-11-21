using RTT.Assessment.WebApi.Contracts;
using RTT.Assessment.WebApi.Services;

namespace RTT.Assessment.WebApi;

public static class BootStrap{
    public static void AddExcelBuilderRegisterServices(this IServiceCollection services) => services.AddScoped<IPersonExcelBuilder, PersonCloseXmlExcelBuilder>();

}
