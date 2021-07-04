using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        readonly Databases.IMyDatabase MyDatabaseService;

        public TestController(Databases.IMyDatabase mDatabaseService)
        {
            this.MyDatabaseService = mDatabaseService;
        }

        public IActionResult Index()
        {
            this.MyDatabaseService.Table1.AddTable1(new Models.Table1
            {
                Id = 1,
                Column1 = "v1"
            });
            return Ok();
        }
    }
}
