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
    // [Authorize]
    public class UserController : ControllerBase
    {
        private readonly SMDQContext context;
        public UserController()
        {
            context = new SMDQContext();
        }
        public ActionResult<IEnumerable<Personnel>> GetAllUser()
        {
            List<Personnel> personnels = context.Personnel.ToList();
            if (personnels == null || personnels.Count() == 0)
                return new
                 List<Personnel>();
            return personnels;
        }
        public async Task<IEnumerable<Personnel>> GetUserbyId(int id)
        {
            var list = context.Personnel.Where(o => o.Perid == id).ToListAsync();
            return await list;
        }
        public async Task<IEnumerable<Personnel>> GetUserbyString(string str)
        {
            string sql = $"select * from Personnel where Pername like '%{str}%'or Pertel like '%{str}%' or  Adr like '%{str}%'";
            var li = context.Personnel.FromSqlRaw(sql).ToListAsync();
            return await li;
        }
        public async Task<string> DelUserbyId(int id)
        {
            if (id == 0)
                return "参数错误";
            var user = context.Personnel.Where(o => o.Perid == id).Single();
            if (user == null)
                return "没有此用户";

            context.Personnel.Remove(user);
            var rest = await context.SaveChangesAsync() > 0;
            return "删除结果" + rest;
        }
        [HttpPost]
        public async Task<string> UpdateUser([FromBody] Personnel User)
        {

            //var user = context.Personnel.Single(o => o.Perid == Convert.ToInt32(User.Perid));
            if (User == null)
                return "没有此用户";
           // var findname = context.Personnel.Where(o => o.Perid == User.Perid);
            context.Entry<Personnel>(User).State = EntityState.Modified;//整个对象更新
            var reul=  await context.SaveChangesAsync();
            return "操作成功数据库返回结果:"+ reul;
        }
        [HttpPost]
        public async Task<string> CreateUser([FromBody] Personnel User)
        {
            var findname = context.Personnel.Where(o => o.Pername == User.Pername);
            if (findname.Count()!=0)
                return "此用户已存在";
            context.Personnel.Add(User);
            await context.SaveChangesAsync();
            return "添加用户成功,ID" + User.Perid; 
        }
    }
}
