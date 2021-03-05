using Microsoft.AspNetCore.Mvc;
using Order.HistoryService.Services;
using System.Collections.Generic;

namespace Order.HistoryService.Controllers {
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

        [HttpDelete("")]
        public ActionResult Delete() {
            historyService.DeleteAll();
            return Ok();
        }
    }
}
