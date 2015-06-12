using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelAdvisor.Controllers
{
    public class HotelsController : ApiController
    {
        Managers.HotelManager Manager = new Managers.HotelManager();

        public ICollection<Models.HotelDetailsViewModel> GetAll()
        {
            return Manager.GetHotels();
        }

        public IHttpActionResult Get(int id)
        {
            var item = Manager.GetHotelDetails(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        public Models.Hotel Add(Models.Hotel item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            Manager.Create(item);
            return item;
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Models.Hotel item)
        {
            if (item == null)
            {
                return false;
            }
            Manager.Edit(item);
            return true;
        }
    }
}