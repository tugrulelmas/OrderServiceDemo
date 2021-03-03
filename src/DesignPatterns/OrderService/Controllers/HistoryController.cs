using Microsoft.AspNetCore.Mvc;
using OrderService.Services;
using System.Collections.Generic;

namespace OrderService.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class HistoryController : ControllerBase {
        private readonly IHistoryService historyService;

        public HistoryController(IHistoryService historyService) {
            this.historyService = historyService;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<string>> Get() {
            return Ok(historyService.GetAll());
        }
    }
}
