using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen.Models;
[Table("tareas")]

public class Tarea
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("clase")]
    public string Clase { get; set; }

    [Column("categoria")]
    public string Categoria { get; set; }

}
