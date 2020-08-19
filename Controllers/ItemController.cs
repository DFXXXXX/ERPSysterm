using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSysterm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ERPSysterm.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly SMDQContext context;
        public ItemController()
        {
            context = new SMDQContext();
        }
        public ActionResult<IEnumerable<Item>> GetAllItem()
        {
            List<Item> personnels = context.Item.ToList();
            if (personnels == null || personnels.Count() == 0)
                return new
                 List<Item>();
            return personnels;
        }
    }
}
