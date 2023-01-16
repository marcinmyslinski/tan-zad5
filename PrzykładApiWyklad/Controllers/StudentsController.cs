using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrzykładApiWyklad.Data;
using PrzykładApiWyklad.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace PrzykładApiWyklad.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet] // zwraca tablicę studentów
        public IActionResult GetStudents()
        {
            //int j = 5;
            var x = Activator.CreateInstance(null, "PrzykładApiWyklad.Data.StudentsList");
            StudentsList sl = (StudentsList)x.Unwrap();
        if  (sl.Studenci.Count == 0)
                {
                return StatusCode(404, "Brak danych"); 
            }else if (sl.Studenci != null)  
            {
                return Ok(sl.Studenci);
            }
            else
            {
                return BadRequest();    
            }
        }

        [HttpGet("list")] // zwraca liczbę studentów
        public IActionResult GetCountStudents()
        {
            var x = Activator.CreateInstance(null, "PrzykładApiWyklad.Data.StudentsList");
            StudentsList sl = (StudentsList)x.Unwrap();
           
            return Ok(sl.Studenci.Count);
        }

        [HttpPost("Student")] // dodaj studenta
        public IActionResult AddStudent(string FN, string LN)
        {
            var x = Activator.CreateInstance(null, "PrzykładApiWyklad.Data.StudentsList");
            StudentsList sl = (StudentsList)x.Unwrap();
            Student sNew = new Student()
            {
                FirstName = FN,
                LastName = LN
            };
            if ((FN== null) || (LN== null))
            {
                return StatusCode(400, "Podano błędne dane. Użytkownik NIE został dodany");
            }
            else
            {
                sl.AddStudent(sNew);
                return Ok();
            }
            
        }
        [HttpDelete("Student")] // usuwa studenta
        public IActionResult DelStudent(string FN, string LN)
        {
            var x = Activator.CreateInstance(null, "PrzykładApiWyklad.Data.StudentsList");
            StudentsList sl = (StudentsList)x.Unwrap();
            Student sDel = new Student()
            {
                FirstName = FN,
                LastName = LN
            };
            if ((FN == null) || (LN == null))
            {
                return StatusCode(400, "Podano błędne dane. Użytkownik NIE został usunięty");
            }
            else
            {
               if (sl.RemoveStudent(sDel) == 0)
                {
                    return StatusCode(400, "Brak użytkownika w bazie. Użytkownik NIE został usunięty");
                }
                else
                {
                    return Ok();
                }
            }
        }
    }
}
