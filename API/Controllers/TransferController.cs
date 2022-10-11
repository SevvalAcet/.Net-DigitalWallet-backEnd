using API.Model;
using Business.Abstarct;
using Entities;
using InterAPI;
using InterAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly TransferService transferService;
        private readonly ILastTransactionService lastTransactionService;

        public TransferController(ILastTransactionService lastTransactionService)
        {
            transferService = new TransferService();
            this.lastTransactionService = lastTransactionService;
        }

        [HttpPost("havale")]
        public async Task<IActionResult> RequestWireToIBAN([FromBody] ServiceProcessEftRequestToIbanRequest request)
        {
            var result = await transferService.RequestWireToIBAN(request.Explanation, request.Iban, request.ReceiverName, request.Amount,request.AccountNumber);
            var responseModel = new ResponseModel<RequestWireToIBANResponse>();
            if (result == null)
            {
                responseModel.IsSuccess = false;
                responseModel.Message = "Para gönderimi başarısız";
                return Ok(responseModel);
            }

            if (result.Data?.State == 2)
            {
                var lastTransaciton = new LastTransaction
                {
                    Amount = request.Amount.ToString(),
                    Iban = request.Iban,
                    Name = request.ReceiverName,
                    DateTime = DateTime.Now
                };
                await this.lastTransactionService.Add(lastTransaciton);
                responseModel.IsSuccess = true;
                responseModel.Message = "Havale işlemi başarılı";
                return Ok(responseModel);
            }

            responseModel.IsSuccess = false;
            responseModel.Message = "Para gönderimi başarısız";

            return Ok(responseModel);
        }

    }
}
