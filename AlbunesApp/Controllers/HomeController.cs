using AlbunesApp.Models;
using AlbunesApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AlbunesApp.Controllers
{
    public class HomeController : Controller
    {
        AlbumsService service = new AlbumsService();

        public async Task<ActionResult> Index()
        {

            var albums = await service.AlbumsListAsync();

            ViewBag.AlbumsList = albums.Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.title
            }).ToList();

            return View();
        }




        public async Task<JsonResult> GetAlbumsDetail(int id)
        {
            List<AlbumDetail> albumDetailList = new List<AlbumDetail>();
            albumDetailList = await service.AlbumsDetailListAsync();

            albumDetailList = albumDetailList.Where(x => x.albumId == id).ToList();
            return Json(new { data = albumDetailList }, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> Comments(int id)
        {
            List<AlbumComments> albumCommentsList = new List<AlbumComments>();            
            albumCommentsList = await service.AlbumsCommentsListAsync();
            albumCommentsList = albumCommentsList.Where(x => x.postId == id).ToList();
            return View(albumCommentsList);
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}