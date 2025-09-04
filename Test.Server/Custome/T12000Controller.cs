using Microsoft.AspNetCore.Mvc;

namespace Test.Server.Custome
{
    public class T12000Controller : ControllerBase
    {
        [HttpGet("api/t12000/getData")]
        public IActionResult GetPieChartData(string Name)
        {
           // if (!Session.IsUserLoggedIn) return Unauthorized();
           // var data = q07259Dal.GetPieChartData(FROM_DATE, TO_DATE, SPCLTY_CODE);
            return Ok(Name);
        }
    }
}
