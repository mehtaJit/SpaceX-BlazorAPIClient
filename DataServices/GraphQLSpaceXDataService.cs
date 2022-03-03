using BlazorAPIClient.Dtos;
using System.Text;
using System.Text.Json;

namespace BlazorAPIClient.DataServices
{
    public class GraphQLSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient httpClient;

        public GraphQLSpaceXDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<LaunchDto[]?> GetAllLaunches()
        {
            var queryObject = new
            {
                query = @"{launches {id is_tentative mission_name launch_date_local}}",
                variables = new {}
            };

            var launchQuery = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8,
                "application/json"
                );

            var response  = await httpClient.PostAsync("graphql", launchQuery);

            if (response.IsSuccessStatusCode)
            {
                var gqlData = await JsonSerializer.DeserializeAsync<GqlData>(
                    await response.Content.ReadAsStreamAsync()
                    );

                return gqlData.Data.Launches;
            }

            return null;
        }
    }
}
