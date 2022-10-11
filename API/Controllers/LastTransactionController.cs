using API.Model;
using Business.Abstarct;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LastTransactionController : ControllerBase
    {
        private readonly ILastTransactionService lastTransactionService;

        public LastTransactionController(ILastTransactionService lastTransactionService)
        {
            this.lastTransactionService = lastTransactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await this.lastTransactionService.GetList();
            var responseModel = new ResponseModel<List<LastTransaction>>();

            if (result == null)
            {
                responseModel.IsSuccess = false;
                return Ok(result);
            }

            responseModel.IsSuccess = true;
            responseModel.Data = result;

            return Ok(result);
        }
    }
}
