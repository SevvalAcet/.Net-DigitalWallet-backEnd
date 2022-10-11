using InterAPI.Model;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InterAPI
{
    public class AccountService
    {
        public async Task<GetCorporateAccountTransactionListResponse> GetCorporateAccountList()
        {
            using (var client = new HttpClient())
            {
                var request = new GetCorporateAccountTransactionListRequest();
                request.Header = new Header
                {
                    AppKey = "c1c2a508fdf64c14a7b44edc9241c9cd",
                    Channel = "API",
                    ChannelRequestId = Guid.NewGuid().ToString(),
                    ChannelSessionId = Guid.NewGuid().ToString(),
                };
                request.Parameters = new List<Parameters>();
                var parameter = new Parameters
                {
                    AssociationCode = " ",
                    CustomerNo = 12695508,
                    EndDate = DateTime.Now,
                    QueryDate = DateTime.Now
                };
                request.Parameters.Add(parameter);

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fc4ce6dd4dfc40da92e85aea9a848b09");
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://api-gateway.intertech.com.tr/BankingApiV01/accounts/GetCorporateAccountTransactionList", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<GetCorporateAccountTransactionListResponse>(resultContent);
                return response;
            }
        }

        public async Task<GetCorporateAccountTransactionListResponse> GetCorporateAccountTransactionList()
        {
            using (var client = new HttpClient())
            {
                var request = new GetCorporateAccountTransactionListRequest();
                request.Header = new Header
                {
                    AppKey = "c1c2a508fdf64c14a7b44edc9241c9cd",
                    Channel = "API",
                    ChannelRequestId = Guid.NewGuid().ToString(),
                    ChannelSessionId = Guid.NewGuid().ToString(),
                };
                request.Parameters = new List<Parameters>();
                var parameter = new Parameters
                {
                    AssociationCode = " ",
                    CustomerNo = 12695508,
                    AccountBranchCode = 4420,
                    AccountSuffix = 352,
                    EndDate = DateTime.Parse("2022-06-23T13:40:00+03:00"),
                    QueryDate = DateTime.Parse("2022-06-18T13:40:00+03:00")
                };
                request.Parameters.Add(parameter);

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fc4ce6dd4dfc40da92e85aea9a848b09");
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://api-gateway.intertech.com.tr/BankingApiV01/accounts/GetCorporateAccountTransactionList", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<GetCorporateAccountTransactionListResponse>(resultContent);
                return response;
            }
        }
    }
}
