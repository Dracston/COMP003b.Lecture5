
using COMP003b.Lecture5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003b.Lecture5.Controllers
{
    //api/vehicle
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {//Todo: Create an in-memory list
        private List<Vehicle> _vehicles =  new List<Vehicle>();

        //TODO: Added default constructor to pre-fill
        public VehiclesController() {
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
            var vehicle=_vehicles.FirstOrDefault(x => x.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }
        //Todo: POST (create): api/ vehicle


        //TODO: Put(update0: api.vehicles
        //TODO: Delete: Api/vehicle
    }
}
