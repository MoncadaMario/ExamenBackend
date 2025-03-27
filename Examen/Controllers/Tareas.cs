using Examen.Models;
using Examen.Services;
using Microsoft.AspNetCore.Mvc;

namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class TareasController : ControllerBase
{
    private readonly TareaService _tareaService;

    public TareasController(TareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Tarea>>> ObtenerTareas()
    {
        var tareas = await _tareaService.ObtenerTareas();
        return Ok(tareas);
    }

    [HttpPost]
    public async Task<ActionResult> CrearTarea([FromBody] Tarea tarea)
    {
        if (tarea == null)
        {
            return BadRequest("No hay tarea valida");
        }
        var nuevaTarea = await _tareaService.CrearUsuario(tarea);
        return Ok(nuevaTarea);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarUsuario(Guid id, [FromBody] Tarea tareaActualizada)
    {
        if (tareaActualizada == null)
        {
            return BadRequest("Tarea vacia");
        }

        var response = await _tareaService.ActualizarTarea(id, tareaActualizada);

        if (response == false)
        {
            return NotFound("Tarea  no encontrada");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarUsuario(Guid id)
    {
        var response = await _tareaService.EliminarTarea(id);
        if (response == false)
        {
            return NotFound("Tarea no encontrada");
        }
        return NoContent();
    }

}