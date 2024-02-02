using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private static List<PersonClass> _people = new List<PersonClass>();

        [HttpPost]
        public IActionResult Create(PersonClass person)
        {
            // Assumption: Id is auto-incremented
            person.Id = _people.Count + 1;
            _people.Add(person);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var person = _people.FirstOrDefault(x => x.Id == id);
            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_people);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, PersonClass person)
        {
            var existingPerson = _people.FirstOrDefault(x => x.Id == id);
            if (existingPerson == null)
                return NotFound();

            existingPerson.FullName = person.FullName;
            existingPerson.Gender = person.Gender;
            existingPerson.Age = person.Age;
            existingPerson.Email = person.Email;
            existingPerson.University = person.University;
            // Update other properties...

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPerson = _people.FirstOrDefault(x => x.Id == id);
            if (existingPerson == null)
                return NotFound();

            _people.Remove(existingPerson);
            return NoContent();
        }
    }
}
