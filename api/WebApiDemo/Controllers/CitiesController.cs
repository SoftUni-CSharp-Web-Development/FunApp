using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Data;

namespace WebApiDemo.Controllers
{
    public class CitiesController : ApiController
    {
        private readonly MyDbContext context;

        public CitiesController(MyDbContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<CityInfo>> Get(int page)
        {
            return this.context.Cities.ToList();
        }

        // GET api/cities/Sofia
        [HttpGet("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityInfo> Get(string id)
        {
            var city = this.context.Cities.FirstOrDefault(x => x.Name == id);
            if (city == null)
            {
                return this.NotFound();
            }

            return city;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public ActionResult<CityInfo> Post(CityInfo cityInfo)
        {
            this.context.Cities.Add(cityInfo);
            this.context.SaveChanges();
            return this.CreatedAtAction(nameof(Get), new {id = cityInfo.Name}, cityInfo);
        }

        // PUT api/cities/Sofia
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public ActionResult<CityInfo> Put(string id, CityInfo cityInfo)
        {
            var dbId = this.context.Cities.Where(x => x.Name == id)
                .Select(x => x.Id).FirstOrDefault();

            if (dbId == 0)
            {
                return this.NotFound();
            }

            cityInfo.Id = dbId;
            this.context.Entry(cityInfo).State = EntityState.Modified;
            this.context.SaveChanges();

            return cityInfo;
        }

        // DELETE api/cities/Sofia
        [HttpDelete("{id}")]
        [ProducesDefaultResponseType]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CityInfo> Delete(string id)
        {
            var city = this.context.Cities.FirstOrDefault(x => x.Name == id);
            if (city == null)
            {
                return this.NotFound();
            }

            this.context.Cities.Remove(city);
            this.context.SaveChanges();

            return city;
        }
    }
}
