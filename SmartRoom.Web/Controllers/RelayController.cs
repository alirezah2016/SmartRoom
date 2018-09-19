using SmartRoom.Web.Models;
using SmartRoom.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SmartRoom.Web.Controllers
{
    public class ReleyController : ApiController
    {
        Context _context;
        DbSet<Reley> set;
        public ReleyController()
        {
            _context = new Context();
            set = _context.Releys;
        }

        [HttpGet]
        public async Task<ReleyViewModel> Get(int id)
            => await set.Where(r => r.id == id).Select(x => new ReleyViewModel
            {
                Id = x.id,
                LightSensorId = x.LightSensorId.Value,
                Name = x.Name,
                TmpSensorId = x.TmpSensorId.Value,
                Value = x.Value
            }).FirstOrDefaultAsync();

        [Route("api/Reley/GetAll")]
        [HttpGet]
        public async Task<IEnumerable<ReleyViewModel>> Get()
                 =>await set.Select(x => new ReleyViewModel
                 {
                     Id = x.id,
                     LightSensorId = x.LightSensorId.Value,
                     Name = x.Name,
                     TmpSensorId = x.TmpSensorId.Value,
                     Value = x.Value
                 }).ToListAsync();



        [HttpPost]
        public async Task Post(ReleyViewModel model)
        {
            set.Add(new Reley
            {
                Value = model.Value.Value,
                LightSensorId = model.LightSensorId,
                Name = model.Name,
                TmpSensorId = model.TmpSensorId
            });
            await _context.SaveChangesAsync();
        }



        [HttpDelete]
        public async Task Delete(int id)
        {
            set.Remove(await set.FirstOrDefaultAsync(r => r.id == id));
            await _context.SaveChangesAsync();
        }



        [HttpPut]
        public async Task Put(ReleyViewModel model)
        {
            var relay = await set.FirstOrDefaultAsync(r => r.id == model.Id);
            relay.Name = model.Name ?? relay.Name;
            relay.Value = model.Value ?? relay.Value;
            relay.TmpSensorId = model.TmpSensorId ?? relay.TmpSensorId ;
            relay.LightSensorId = model.LightSensorId ?? relay.LightSensorId;       
            await _context.SaveChangesAsync();
        }
    }
}