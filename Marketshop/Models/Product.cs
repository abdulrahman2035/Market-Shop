using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


public class Product
    {



    [Key]
    public int id { get; set; }
    [StringLength(200)]
    public string Name { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    [StringLength(200)]
    public string Image { get; set; }

    public Category Category { get; set; }
    public int Categoryid { get; set; }
}
