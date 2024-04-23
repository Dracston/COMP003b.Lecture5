
using COMP003b.Lecture5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003b.Lecture5.Controllers
{
    //api/vehicle
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {//Todo: Create an in-memory list
        private List<Vehicle> _vehicles = new List<Vehicle>();

        //TODO: Added default constructor to pre-fill
        public VehiclesController()
        {
            _vehicles.Add(new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2018 });
            _vehicles.Add(new Vehicle { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 });
            _vehicles.Add(new Vehicle { Id = 3, Make = "Ford", Model = "Fusion", Year = 2020 });
        }

        //CRUD operations

        //Get ALL (read): api/vehicles
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return _vehicles;
        }
        //TODO: Get by Id (read): api/vehicles/5
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicleById(int id)
        {
            var vehicle = _vehicles.FirstOrDefault(x => x.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }
        //Todo: POST (create): api/ vehicle
        [HttpPost]
        public ActionResult<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            //TODO: Automatically assign Id
            vehicle.Id = _vehicles.Max(v => v.Id) + 1;

            //TODO: Add it to list
            _vehicles.Add(vehicle);

            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        //TODO: Put(update0: api.vehicles
        [HttpPut]
        public ActionResult<Vehicle> UpdateVehicle(int id, Vehicle updatedvehicle)
        {
            //Todo: Look for the vehicle by Id
            var vehicle = _vehicles.Find(v => v.Id == id);

            //TODO: return Bad Request if not found. 
            if (vehicle == null)
            {
                return BadRequest();
            }

            //Todo: Update vehicle
            vehicle.Make = updatedvehicle.Make;
            vehicle.Model = updatedvehicle.Model;
            vehicle.Year = updatedvehicle.Year;
            return NoContent();


            

        }
        //TODO: Delete: Api/vehicle
        [HttpDelete]
        public ActionResult DeleteVehicle(int id)
        {
            //TODO: find vehicle by id
            var vehicle = _vehicles.Find(v => v.Id == id);

            //TODO: return not found if not found
            if(vehicle == null)
            {
                return NotFound();

            }

            //Todo;remvove from list
            _vehicles.Remove(vehicle);
            return NoContent();
        }
    }
}
