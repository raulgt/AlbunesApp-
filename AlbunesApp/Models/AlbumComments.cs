using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbunesApp.Models
{
    public class AlbumComments
    {
        public int id { get; set; }

        public int postId { get; set; }

        [Display(Name = "Nombre")]
        public string name { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Descripción")]
        public string body { get; set; }       
    }
}