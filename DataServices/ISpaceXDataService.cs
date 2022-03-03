using System.Threading.Tasks;
using BlazorAPIClient.Dtos;

namespace  BlazorAPIClient
{
    public interface ISpaceXDataService
    {
        Task<LaunchDto[]> GetAllLaunches();
    }
}