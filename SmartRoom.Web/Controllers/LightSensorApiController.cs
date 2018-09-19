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
    public class LightSensoreApiController : ApiController
    {
        Context _context;
        DbSet<LightSensor> set;


        public LightSensoreApiController()
        {
            _context = new Context();
            set = _context.LightSensors;
        }
        // GET api/<controller>
        [HttpGet]
        public async Task<LightSensorViewModel> Get(int id)
            => await set.Where(r => r.Id == id).
            Select(x => new LightSensorViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value,

            }).FirstOrDefaultAsync();

        [Route("api/LightSensorApi/GetAll")]
        [HttpGet]
        public async Task<IEnumerable<LightSensorViewModel>> Get()
                 => await set.Select(x => new LightSensorViewModel
                 {
                     Id = x.Id,
                     Name = x.Name,
                     Value = x.Value
                 }).ToListAsync();



        [HttpPost]
        public async Task Post(LightSensorViewModel model)
        {
            set.Add(new LightSensor
            {
                Name = model.Name,
                Value = model.Value,
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
        public async Task Put(LightSensorViewModel model)
        {
            var sensor = await set.FirstOrDefaultAsync(r => r.Id == model.Id);
            sensor.Name = model.Name;
            sensor.Value = model.Value;
            await _context.SaveChangesAsync();
        }
    }
}