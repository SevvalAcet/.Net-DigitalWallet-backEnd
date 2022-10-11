using API.Model;
using InterAPI;
using InterAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService accountService;

        public AccountController()
        {
            accountService = new AccountService();
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAccount()
        {
            var result = await accountService.GetCorporateAccountList();
            var responseModel = new ResponseModel<GetCorporateAccountTransactionListResponse>();
            if (result == null)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "Servis çağrımı başarısız";
                return Ok(responseModel);
            }

            responseModel.IsSuccess = true;
            responseModel.Message = "Servis çağırıldı";
            responseModel.Data = result;

            return Ok(responseModel);
        }

        [HttpGet("getalltransactions")]
        public async Task<IActionResult> GetTransaction()
        {
            var result = await accountService.GetCorporateAccountTransactionList();
            var responseModel = new ResponseModel<List<Transaction>>();
            if (result == null)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "Servis çağrımı başarısız";
                return Ok(responseModel);
            }
            responseModel.IsSuccess = true;
            responseModel.Message = "Servis çağrıldı";
            responseModel.Data = result.Data?.Accounts[0]?.Transactions;

            return Ok(responseModel);
        }
    }
}
