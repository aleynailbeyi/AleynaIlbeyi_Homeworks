using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Product_Photo
    {
        [Key]
        public int PhotoID { get; set; }
        public string PhotoUrl { get; set; }
        public int ProductID { get; set; }
    }
}
