using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiProducts.Models;

public class Product
{   
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(30, ErrorMessage = "The name cannot be longer than 30 characters.")]
    public string? Name { get; set; }

    [StringLength(200, ErrorMessage = "The description cannot be longer than 200 characters.")]
    public string? Description { get; set; }

    [Range(0.01, 10000)]
    public decimal Price { get; set; }

    [Range(0, 10000)]
    public int Stock { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    public Category Category { get; set; }

}
