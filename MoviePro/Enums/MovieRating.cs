using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePro.Enums
{
    public enum MovieRating
    {
        G,
        PG, 
        [Display(Name = "PG-13")]
        PG13,
        R,
        [Display(Name = "NC-17")]
        NC17,
        NR
    }
}
