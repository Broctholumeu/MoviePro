using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MoviePro.Enums;

namespace MoviePro.Models
{
    public class Movie
    {

        public int Id { get; set; }
        //The movieID from TMDB
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string TagLine { get; set; }
        public string Overview { get; set; }
        [DataType (DataType.Date)]
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        //Image Stuffs Below
        [Display (Name ="Movie Poster")]
        public byte[] Poster { get; set; }
        public string ContentType { get; set; }

        [Display (Name = "Background Image")]
        public byte[] BGImage { get; set; }
        public string BGContentType { get; set; }

        //Public url of trailer
        [Display (Name = "Trailer URL")]
        public string Trailer { get; set; }

        public MovieRating Rating { get; set; }

        public ICollection<Cast> Cast { get; set; } = new HashSet<Cast>();
        public ICollection<Crew> Crew { get; set; } = new HashSet<Crew>();



    }
}
