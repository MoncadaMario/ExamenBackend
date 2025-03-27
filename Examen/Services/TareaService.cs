using Examen.Data;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Services;

public class TareaService
{
    private readonly DataContext _context;

    public TareaService(DataContext context)
    {
        _context = context;
    }

    //obtener todas las tareas
    public async Task<List<Tarea>> ObtenerTareas()
    {
        return await _context.Tareas.ToListAsync();
    }

    //agregar tarea
    public async Task<Tarea> CrearUsuario(Tarea tarea)
    {
        tarea.Id = Guid.NewGuid();

        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();

        return tarea;
    }

    //actualizar tarea
    public async Task<bool> ActualizarTarea(Guid id, Tarea tareaActualizada)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return false;

        tarea.Clase = tareaActualizada.Clase;
        tarea.Categoria = tareaActualizada.Categoria;

        await _context.SaveChangesAsync();
        return true;
    }

    //eliminar tarea
    public async Task<bool> EliminarTarea(Guid id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return false;

        _context.Tareas.Remove(tarea);
        await _context.SaveChangesAsync();
        return true;
    }
}