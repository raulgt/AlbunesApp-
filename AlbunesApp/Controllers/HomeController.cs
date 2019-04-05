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

            ViewBag.AlbumsList = albums.Take(5).Select(c => new SelectListItem
            {
                Value = c.id.ToString(),
                Text = c.title
            }).ToList();


            //List<AlbumComments> albumCommentsList = new List<AlbumComments>();
            //albumCommentsList = await service.AlbumsCommentsListAsync();
            //albumCommentsList = albumCommentsList.Where(x => x.postId == 1).ToList();
            //ViewBag.CommentsPartial = albumCommentsList;



            return View();
        }

               
        public async Task<JsonResult> GetAlbumsDetail(int id)
        {
            List<AlbumDetail> albumDetailList = new List<AlbumDetail>();
            albumDetailList = await service.AlbumsDetailListAsync();
            albumDetailList = albumDetailList.Where(x => x.albumId == id).ToList();
            return Json(new { data = albumDetailList }, JsonRequestBehavior.AllowGet);
        }


        //public async Task<ActionResult> _Comments(int id)
        //{
        //    List<AlbumComments> albumCommentsList = new List<AlbumComments>();
        //    albumCommentsList = await service.AlbumsCommentsListAsync();
        //    albumCommentsList = albumCommentsList.Where(x => x.postId == id).ToList();
        //    ViewBag.CommentsPartial = albumCommentsList;
        //    return PartialView(albumCommentsList);
        //}



        public async Task<JsonResult> CommentsList(int id)
        {
            List<AlbumComments> albumCommentsList = new List<AlbumComments>();
        
            albumCommentsList = await service.AlbumsCommentsListAsync();
            if (albumCommentsList != null)
            {
                albumCommentsList = albumCommentsList.Where(x => x.postId == id).ToList();
            }           
            return Json(new { data = albumCommentsList }, JsonRequestBehavior.AllowGet);
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