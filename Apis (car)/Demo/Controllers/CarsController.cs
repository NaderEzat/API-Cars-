using Demo.Filter;
using Demo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
       static List<Car> Cars =new List<Car>();


        #region CRUD Operations
        [HttpGet]
        public ActionResult< List<Car>> AllCars()
        {
            return Cars.ToList();
        }

        [HttpGet]
        [Route("{id:Min(1)}")]
        public ActionResult<List<Car>> CarsById(int id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            return Ok(car);
        }

        [HttpPost]
        public ActionResult AddCars(Car Obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Cars.Add(Obj);
            return CreatedAtAction("AddCars",
                new { id = Obj.Id },
                new { massege = "Sucess Add" });
        }

        [HttpPost]
        [Route("V2")]
        [TypeValidtion]
        public ActionResult AddCarsV2(Car Obj)
        {
            Cars.Add(Obj);
            return CreatedAtAction("CarsById",
                new { id = Obj.Id },
                new { massege = "Sucess Add" });
        }


        [HttpPut]
        [Route("{id}")]
        public ActionResult EditCars(Car obj , int id)
        {
            var c1 = Cars.FirstOrDefault(c => c.Id == id);
            c1.Name = obj.Name;

            c1.OpenData = obj.OpenData;
            c1.Type = obj.Type;
            return Ok("Update");
        }

        [HttpDelete]
        public void Delete(int id)
        {
           var c1 = Cars.FirstOrDefault(c => c.Id == id);
            if (c1 == null)
            {
               NotFound();
            }
            else
            {
                Cars.Remove(c1);
             
            }
            
        }


    }
}
    #endregion  