using SeeSharp.Models;
using SeeSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace SeeSharp.Controllers;

[ApiController]
[Route("[controller]")]
public class GlassController : ControllerBase
{
    public GlassController()
    {
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Glass>> GetAll() =>
        GlassService.GetAll();

    // GET by Id action
    [HttpGet("{id}")]
    public ActionResult<Glass> Get(int id)
    {
        var Glass = GlassService.Get(id);

        if(Glass == null)
            return NotFound();

        return Glass;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Glass newGlass)
    {            
        // This code will save the glass and return a result
        GlassService.Add(newGlass);
        return CreatedAtAction(nameof(Get), new { id = glass.Id }, glass);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Glass glass)
    {
        if (id != glass.Id)
        return BadRequest();
           
        var existingGlass = GlassService.Get(id);
        if(existingGlass is null)
        return NotFound();
   
        GlassService.Update(glass);           
   
        return NoContent();
        // you can also return Ok() ~ 200 created
    }

    // DELETE 
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var glass = GlassService.Get(id);
   
        if (glass is null)
        return NotFound();
       
        GlassService.Delete(id);
   
        return NoContent();

    }
}