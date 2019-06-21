using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IEmailSender sender;

        public ValuesController(IEmailSender sender)
        {
            this.sender = sender;
        }

        // GET api/values
        [HttpGet]
        public void Get(string email)
        {
            sender.Subject = "Successfully Registered";
            sender.ToEmail = email;
            sender.Body = "You have successfully registered!";
            sender.Send();
        }
    }
}
