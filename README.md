# Glasses API /  .NET REST API

## Description
An example of creating a web API with ASP.NET Core controllers with mock data

---

## Startup
`dotnet new webapi -n GlassesApi --no-https` -- make new boiler plate.
 Namespace will be GlassesApi. Project will have demo WeatherForecast in it.

Inside that project:
`dotnet new gitignore` -- make new .gitignore file for c# dotnet

## Model
First lets make a Model for our data.
`Glass.cs`
```cs
//dotnet namespace can just be declared. Dotnotation for sub name spaces...
namespace SeeSharp.Models;
public class Glass
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Color { get; set; }
    public string? Shape { get; set; }
    
}
```

## REST Controller - CRUD
`GlassController.cs`
```cs
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
```

### Accessing classes and functionalities
```cs
using Microsoft.AspNetCore.Mvc;
```
This line of code is importing the Microsoft.AspNetCore.Mvc namespace which contains classes that are essential to create web applications built on top of the ASP.NET Core framework. This namespace includes classes for building APIs, web pages using the Razor view engine, and handling requests and responses.

This namespace also includes classes like ControllerBase used to create controllers in ASP.NET Core, ActionResult class used to return HTTP responses from a controller action method, RouteAttribute class used to define routing templates for controllers and actions, and many more.

By including this namespace, we can access all of its classes and functionalities in our own C# code file.

---
### Basic build of the web api controller:

```cs
[ApiController]
[Route("[controller]")]
public class GlassController : ControllerBase
```
This code is creating a class named GlassController that inherits from the ControllerBase class. The class has an attribute [ApiController] which indicates that it should be treated as a web API controller and enables features like automatic model binding, validation, and handling of bad requests.

The attribute [Route("[controller]")] is used to specify the base URL for all the actions inside the GlassController. Here [controller] is a placeholder token that will be replaced with the name of the controller without the "Controller" suffix. For example, if the controller name is GlassController, then the route template for this controller will be /glass.

This code defines a basic skeleton of a Web API controller named GlassController.

---

### Swagger
Swagger is an open-source software framework that is used to create, document, and consume RESTful web services. It provides a set of tools that enable developers to describe the structure and functionality of their API in a standardized way, making it easier to understand and interact with.

example: 
http://localhost:5065/swagger/index.html 

---

