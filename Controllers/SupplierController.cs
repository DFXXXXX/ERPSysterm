using ERPSysterm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSysterm.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SMDQContext context;
        public SupplierController()
        {
            context = new SMDQContext();
        }
        public ActionResult<IEnumerable<Supplier>> GetAllSupplier()
        {
            List<Supplier> personnels = context.Supplier.ToList();
            if (personnels == null || personnels.Count() == 0)
                return new
                 List<Supplier>();
            return personnels;
        }
        public async Task<IEnumerable<Supplier>> GetSupplierbyId(int id)
        {
            var list = context.Supplier.Where(o => o.Supid == id).ToListAsync();
            return await list;
        }
        public async Task<IEnumerable<Supplier>> GetSupplierbyString(string str)
        {
            string sql = $"select * from Supplier where Supname like '%{str}%'or Suptel like '%{str}%' or  supadr like '%{str}%'";
            var li = context.Supplier.FromSqlRaw(sql).ToListAsync();
            return await li;
        }
        public async Task<string> DelSupplierbyId(int id)
        {
            var user = context.Supplier.Single(o => o.Supid == id);
            if (user == null)
                return "没有此用户";
            context.Supplier.Remove(user);
            var rest = await context.SaveChangesAsync() > 0;
            return "删除结果" + rest;
        }
        [HttpPost]
        public async Task<string> UpdateSupplier([FromBody] Supplier Supplier)
        {

           // var user = context.Supplier.Single(o => o.Supid == Convert.ToInt32(Supplier.Supid));
            if (Supplier == null)
                return "没有此用户";
          //  var findname = context.Supplier.Where(o => o.Supid == Supplier.Supid);
            context.Entry<Supplier>(Supplier).State = EntityState.Modified;//整个对象更新
            var reul = await context.SaveChangesAsync();
            return "操作成功数据库返回结果:" + reul;
        }
        [HttpPost]
        public async Task<string> CreateSupplier([FromBody] Supplier Supplier)
        {
            var findname = context.Supplier.Where(o => o.Supname == Supplier.Supname);
            if (findname.Count()!=0)
                return "此用户已存在";
            context.Supplier.Add(Supplier);
            await context.SaveChangesAsync();
            return "添加用户成功,ID" + Supplier.Supid;
        }
    }
}
