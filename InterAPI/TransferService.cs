using InterAPI.Model;
using System.Text;
using System.Text.Json;

namespace InterAPI
{
    public class TransferService
    {
        public async Task<RequestWireToIBANResponse> RequestWireToIBAN(string explanation, string iban, string receiverName,decimal amount, string accountNumber)
        {
            var account = accountNumber.Split("-");

            using (var client = new HttpClient())
            {
                var request = new RequestWireToIBANRequest();
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
                    Explanation = explanation,
                    IBANNumber = iban,
                    DestinationBankCode = 64,
                    Amount = amount,
                    CustomerNo = 12695682,
                    SourceAccount = new Account
                    {
                        AccountSuffix = Convert.ToInt32(account[2]),
                        BranchCode = Convert.ToInt32(account[0]),
                        CustomerNo = Convert.ToInt32(account[1]),
                    },
                    ReceiverName = receiverName,
                    ForceDuplicate = true,
                    TransferReferenceId = Guid.NewGuid().ToString()
                };
                request.Parameters.Add(parameter);

                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fc4ce6dd4dfc40da92e85aea9a848b09");
                var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var result = await client.PostAsync("https://api-gateway.intertech.com.tr/BankingApiV01/RequestWireToIBAN", content);
                string resultContent = await result.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<RequestWireToIBANResponse>(resultContent);
                return response;
            }
        }
    }
}
