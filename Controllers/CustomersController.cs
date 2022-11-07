using Microsoft.AspNetCore.Mvc;
using customersApi.Models;
using Newtonsoft.Json;

namespace customersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class CustomersController : ControllerBase
    {
        JsonLoad jsonLoad;
        String filePath = ".\\db\\CustomersJson.json";
        public CustomersController(){
            jsonLoad = new JsonLoad(filePath);
        }

        // GET: api/Customers/226349264
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(String id)
        {
            var customers = jsonLoad.readJson();

            if (customers == null)
            {
                return NotFound();
            }

            await Task.Delay(1000);
            Customer customer = customers.customersList.Find(c => c.idNumber == id) ?? null;
            if(customer != null) return customer;

            return NotFound();
        }

        [HttpPost("{update}")]
        public async Task<IActionResult> UpdateCustomer(String address, String id)
        {
            Address add = JsonConvert.DeserializeObject<Address>(address);

            var customers = jsonLoad.readJson();
            if (customers == null)
            {
                return NotFound();
            }

            Customer customer = customers.customersList.Find(c => c.idNumber == id) ?? null;
            if(customer == null) return NotFound();
            customers.customersList.Remove(customer);
            customer.Address = add;
            customers.customersList.Add(customer);
            jsonLoad.writeJson(customers);

            return NoContent();
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(String id)
        {
            var customers = jsonLoad.readJson();
            if (customers == null)
            {
                return NotFound();
            }

            Customer customer = customers.customersList.Find(c => c.idNumber == id) ?? null;
            if(customer == null) return NotFound();
            customers.customersList.Remove(customer);
            jsonLoad.writeJson(customers);

            return NoContent();
        }
    }
}