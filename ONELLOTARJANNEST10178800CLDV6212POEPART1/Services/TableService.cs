using Azure;
using Azure.Data.Tables;
using ONELLOTARJANNEST10178800CLDV6212POEPART1.Models;
using System.Threading.Tasks;

namespace ONELLOTARJANNEST10178800CLDV6212POEPART1.Services
{
    public class TableService
    {
        private readonly TableServiceClient _serviceClient;
        private readonly TableClient _userProfilesTableClient;
        private readonly TableClient _productsTableClient;

        public TableService(IConfiguration configuration)
        {
            var connectionString = configuration["AzureStorage:ConnectionString"];
            _serviceClient = new TableServiceClient(connectionString);

            _userProfilesTableClient = _serviceClient.GetTableClient("UserProfiles");
            _userProfilesTableClient.CreateIfNotExists();

            _productsTableClient = _serviceClient.GetTableClient("Products");
            _productsTableClient.CreateIfNotExists();
        }

        public async Task AddUserProfileAsync(UserProfile profile)
        {
            await _userProfilesTableClient.AddEntityAsync(profile);
        }

        public async Task AddProductAsync(Product product)
        {
            await _productsTableClient.AddEntityAsync(product);
        }
    }
}
