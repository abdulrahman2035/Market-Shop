﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


public class Country
    {



    [Key]
    public int id { get; set; }
    [StringLength(150)]
    public string Name { get; set; }



}
