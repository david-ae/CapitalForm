namespace CapitalForm.Gateway.Core.ServiceContracts
{
    public interface ICapitalFormService
    {
        Task<dynamic?> EditApplication(string applicationId);
    }
}
