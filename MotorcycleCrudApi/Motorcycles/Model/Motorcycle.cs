using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorcycleCrudApi.Motorcycles.Model;
[Table("bikes")]
public class Motorcycle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    [Required]
    [Column("price")]

    public double Price { get; set; }
    [Required]
    [Column("name")]

    public string Name { get; set; }
    [Required]
    [Column("category")]

    public string Category { get; set; }
    [Required]
    [Column("date_of_fabrication")]

    public DateTime DateOfFabrication { get; set; }
}
