using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbunesApp.Models
{
    public class AlbumDetail
    {
        public int id { get; set; }

        public int albumId { get; set; }

        public string title { get; set; }

        public string url { get; set; }

        public string thumbnailUrl { get; set; }
    }
}