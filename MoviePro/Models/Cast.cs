using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePro.Models
{
    public class Cast
    {

        public int Id { get; set; }
        //Below helps to identify parent (movie) and the child (id) from the other model
        public int MovieId { get; set; }

        //TMDB castID used to identify cast across movies
        public int CastID { get; set; }
        public string Department { get; set; }
        public string Name { get; set; }
        public string Character { get; set; }

        //Gets the order of relevance/seniority; A-list on down
        public int Order { get; set; }

        //Profile Image (DATA ANNOTATION)
        [Display (Name = "Profile Pic")]
        public byte[] Profile { get; set; }
        public string ContentType { get; set; }



    }
}
