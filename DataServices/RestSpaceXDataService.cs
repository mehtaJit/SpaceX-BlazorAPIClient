using BlazorAPIClient.Dtos;
using System.Net.Http.Json;

namespace BlazorAPIClient.DataServices
{
    public class RestSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient httpClient;

        public RestSpaceXDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<LaunchDto[]> GetAllLaunches()
        {
            return await httpClient.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}