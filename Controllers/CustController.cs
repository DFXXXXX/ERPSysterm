using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPSysterm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ERPSysterm.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustController : ControllerBase
    {
        // GET: api/<CustController>
        private readonly SMDQContext context;
        public CustController()
        {
            context = new SMDQContext();
        }
        public ActionResult<IEnumerable<Cust>> GetAllCust()
        {
            List<Cust> Custs = context.Cust.ToList();
            if (Custs == null || Custs.Count() == 0)
                return new
                 List<Cust>();
            return Custs;
        }
        public async Task<Cust> GetCustbyId(int id)
        {
            var Cust = context.Cust.SingleAsync(o => o.Custid == id);
            return await Cust;
        }
        public async Task<IEnumerable<Cust>> GetCustbyString(string str)
        {
            string sql = $"select * from Cust where Custname like '%{str}%'or Custtel like '%{str}%' or  custadr like '%{str}%'";
            var li = context.Cust.FromSqlRaw(sql).ToListAsync();
            return await li;
        }
        public async Task<string> DelCustbyId(int id)
        {
            var user = context.Cust.Single(o => o.Custid == id);
            if (user == null)
                return "没有此用户";
            context.Cust.Remove(user);
            var rest = await context.SaveChangesAsync() > 0;
            return "删除结果" + rest;
        }
        [HttpPost]
        public async Task<string> UpdateCust([FromBody] Cust Cust)
        {
           // var user = context.Cust.Where(o => o.Custid ==Cust.Custid);
            if (Cust == null)
                return "没有此用户";
            //var findname = context.Cust.Where(o => o.Custid == Cust.Custid);
            context.Entry<Cust>(Cust).State = EntityState.Modified;//整个对象更新
            var reul = await context.SaveChangesAsync();
            return "操作成功数据库返回结果:" + reul;
        }
        [HttpPost]
        public async Task<string> CreateCust([FromBody] Cust Cust)
        {
            var user = context.Cust.Where(o => o.Custname == Cust.Custname);
            if (user.Count()!=0)
                return "用户已存在";
            context.Cust.Add(Cust);
            await context.SaveChangesAsync();
            return "添加客户成功,ID" + Cust.Custid;
        }
    }
}

