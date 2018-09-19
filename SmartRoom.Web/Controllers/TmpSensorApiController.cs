using SmartRoom.Web.Models;
using SmartRoom.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SmartRoom.Web.Controllers
{
    public class TmpSensorApiController : ApiController
    {
        Context _context;
        DbSet<TmpSensor> set;


        public TmpSensorApiController()
        {
            _context = new Context();
            set = _context.TmpSensors;
        }
        // GET api/<controller>
        [HttpGet]
        public async Task<TmpSensorViewModel> Get(int id)
            => await set.Where(r => r.Id == id).
                    Select(x => new TmpSensorViewModel
                    {
                        Id = x.Id,
                        Max = x.Max,
                        Name = x.Name,
                        Min = x.Min,
                        Value = x.Value,
                    }).FirstOrDefaultAsync();

        [Route("api/TmpSensorApi/GetAll")]
        [HttpGet]
        public async Task<IEnumerable<TmpSensorViewModel>> Get()
                 => await set.Select(x => new TmpSensorViewModel
                 {
                     Id = x.Id,
                     Max = x.Max,
                     Name = x.Name,
                     Min = x.Min,
                     Value = x.Value
                 }).ToListAsync();



        [HttpPost]
        public async Task Post(TmpSensorViewModel model)
        {
            set.Add(new TmpSensor
            {
                Max = model.Max.Value,
                Name = model.Name,
                Min = model.Min.Value,
                Value = model.Value.Value
            });
            await _context.SaveChangesAsync();
        }



        [HttpDelete]
        public async Task Delete(int id)
        {
            set.Remove(await set.FirstOrDefaultAsync(r => r.Id == id));
            await _context.SaveChangesAsync();
        }



        [HttpPut]
        public async Task Put(TmpSensorViewModel model)
        {
            var relay = await set.FirstOrDefaultAsync(r => r.Id == model.Id);
            relay.Name = model.Name?? relay.Name;
            relay.Value = model.Value ?? relay.Value;
            relay.Max = model.Max ?? relay.Max;
            relay.Min = model.Min ?? relay.Min;

            await _context.SaveChangesAsync();
        }
    }
}