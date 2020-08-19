using ERPSysterm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPSysterm.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StoreHouseController : ControllerBase
    {
        private readonly SMDQContext context;
        public StoreHouseController()
        {
            context = new SMDQContext();
        }
        public ActionResult<IEnumerable<Storehouse>> GetAllStoreHouse()
        {
            List<Storehouse> personnels = context.Storehouse.ToList();
            if (personnels == null || personnels.Count() == 0)
                return new
                 List<Storehouse>();
            return personnels;
        }
        public async Task<Storehouse> GetStoreHousebyId(int Component)
        {
           var com = context.Storehouse.SingleAsync(o => o.Component == Component);
            return await com;
        }
        public async Task<IEnumerable<Storehouse>> GetStoreHousebyString(string str)
        {
            string sql = $"select * from Storehouse where  comname like '%{str}%'";
            var li = context.Storehouse.FromSqlRaw(sql).ToListAsync();
            return await li;
        }
        public async Task<string> DelStoreHousebyId(string Component)
        {
            var user = context.Storehouse.Single(o => o.Component == Convert.ToInt32(Component));
            if (user == null)
                return "没有此用户";
            context.Storehouse.Remove(user);
            var rest = await context.SaveChangesAsync() > 0;
            return "删除结果" + rest;
        }
        [HttpPost]
        public async Task<string> UpdateStoreHouse([FromBody] Storehouse StoreHouse)
        {

            //var user = context.Storehouse.Single(o => o.Component == Convert.ToInt32(StoreHouse.Component));
            if (StoreHouse == null)
                return "没有此用户";
            context.Entry<Storehouse>(StoreHouse).State = EntityState.Modified;//整个对象更新
            var reul = await context.SaveChangesAsync();
            return "操作成功数据库返回结果:" + reul;
        }
        [HttpPost]
        public async Task<string> CreateStoreHouse([FromBody] Storehouse StoreHouse)
        {
            var StoreH = context.Storehouse.Where(o => o.Comname == StoreHouse.Comname);
            if (StoreH.Count()!=0)
                return "已存在此记录";
            context.Storehouse.Add(StoreHouse);
            await context.SaveChangesAsync();
            return "添加用户成功,ID" + StoreHouse.Component;
        }
    }
}
