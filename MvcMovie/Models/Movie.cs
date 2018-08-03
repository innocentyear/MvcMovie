using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        [Display(Name ="片名")]
        public string Title { get; set; }

        [Display(Name ="发行日期")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name ="分级")]
        public string Genre { get; set; }

        [Display(Name ="价格")]
        [Column(TypeName ="money")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
