using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrueDialog.Client.Standard.WebTests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITrueDialogClient m_client;
        public TestController(ITrueDialogClient client)
        {
            m_client = client;
        }

        [HttpGet]
        public IActionResult Test()
        {
            var info = m_client.Account.GetCurrentAccount();

            return Ok(info.Id);
        }
    }
}
