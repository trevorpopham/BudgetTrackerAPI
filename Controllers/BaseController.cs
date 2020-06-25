using BudgetTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BudgetTrackerAPI.Controllers
{
    public class BaseController : ApiController
    {
        protected ApiContext db = new ApiContext();
    }
}