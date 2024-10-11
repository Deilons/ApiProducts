using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models;

[Table("Categories")]
public class Category
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(30, ErrorMessage = "Name cannot be longer than 30 characters")]
    public string? Name { get; set; }

    [Required]
    [MaxLength(200, ErrorMessage = "Description cannot be longer than 200 characters")]
    public string? Description { get; set; }

    public List<Product> Products { get; set; }
}
