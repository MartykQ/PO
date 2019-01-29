using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql
{
    public class Zasoby
    {
        [Key]
        public int zasobyId { get; set; }
        public string dane { get; set; }



    }
}
