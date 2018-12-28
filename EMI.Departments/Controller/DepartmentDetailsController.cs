using EMI.Departments.Domain.Models;
using EMI.Departments.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EMI.Departments.Users.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentDetailsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentDetailsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/DepartmentDetails
        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var departmentDetails = _departmentService.GetDepartments();
            if (departmentDetails.Result == null)
            {
                return NotFound();
            }
            else
            {

                return Ok(await departmentDetails);
            }
        }
        [HttpPost]
        public async Task<IActionResult> addDepartment(DepartmentDetails departmentDetails)
        {
            if (departmentDetails == null)
            {
                return BadRequest();
            }
            else
            {
                await _departmentService.add(departmentDetails);
                return Ok();
            }
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int idToRemove)
        {
            if (idToRemove == 0)
            {
                return BadRequest();
            }
            else
            {
                _departmentService.DeleteDepartment(idToRemove);
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult UpdateDepartment(DepartmentDetails departmentDetails)
        {
            if(departmentDetails != null)
            {
                return Ok( _departmentService.updateDepartment(departmentDetails));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}