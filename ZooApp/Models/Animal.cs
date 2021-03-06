﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public class Animal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index("Ix_AnimalName")]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        [Index("Ix_AnimalOrigin")]
        public string Origin { get; set; }
        
        [Required]
        public double quantity { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
    }

    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
    }

    public class AnimalFood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Animal")]
        [Required]
        public int AnimalId { get; set; }
        [ForeignKey("Food")]
        public int FoodId { get; set; }
        [Required]
        public double? Quantity { get; set; }
        public virtual Food Food { get; set; }
        public virtual Animal Animal { get; set; }

    }
}
