using PenghuTraveler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PenghuTraveler.Controllers
{
    public class BlogController : Controller
    {
        /// <summary>
        /// 單篇文章
        /// </summary>
        /// <returns></returns>
        public ActionResult Single()
        {
            return View();
        }

        /// <summary>
        /// 取得單筆留言
        /// </summary>
        /// <returns></returns>
        public ActionResult GetComment(int id, string viewName)
        {
            try
            {
                var db = new PenghuTravelerEntities();

                var model = db.Comment.Where(x => x.Id == id && x.ViewName == viewName).FirstOrDefault();
                var result = new
                {
                    Id = model.Id,
                    ViewName = model.ViewName,
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Content = model.Content,
                    CreatedTime = model.CreatedTime.ToString("yyyy-MM-dd")
                };
                return Json(new { IsSuccess = true, Data = result });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Data = "取得留言失敗：" + ex.Message });
            }
        }

        /// <summary>
        /// 取得多筆留言
        /// </summary>
        /// <returns></returns>
        public ActionResult GetComments(string viewName)
        {
            try
            {
                var db = new PenghuTravelerEntities();

                var model = db.Comment.Where(x => x.ViewName == viewName).OrderByDescending(x => x.CreatedTime).ToList();
                var result = model.Select(x=> new
                {
                    Id = x.Id,
                    ViewName = x.ViewName,
                    UserName = x.UserName,
                    UserEmail = x.UserEmail,
                    Content = x.Content,
                    CreatedTime = x.CreatedTime.ToString("yyyy-MM-dd")
                }).ToList();
                return Json(new { IsSuccess = true, Data = result });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Data = "取得留言失敗：" + ex.Message });
            }
        }

        /// <summary>
        /// 新增留言
        /// </summary>
        /// <returns></returns>
        public ActionResult AddComment(string viewName, string userName, string userEmail, string content)
        {
            try
            {
                var db = new PenghuTravelerEntities();

                var model = new Comment
                {
                    ViewName = viewName,
                    UserName = userName,
                    UserEmail = userEmail,
                    Content = content,
                    CreatedTime = DateTime.Now
                };
                db.Comment.Add(model);
                db.SaveChanges();
                var result = new
                {
                    Id = model.Id,
                    ViewName = model.ViewName,
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Content = model.Content,
                    CreatedTime = model.CreatedTime.ToString("yyyy-MM-dd")
                };
                return Json(new { IsSuccess = true, Data = result });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Data = "新增留言失敗：" + ex.Message });
            }
        }

        /// <summary>
        /// 修改留言
        /// </summary>
        /// <returns></returns>
        public ActionResult EditComment(int id, string viewName, string userName, string userEmail, string content)
        {
            try
            {
                var db = new PenghuTravelerEntities();

                var model = db.Comment.Where(x => x.Id == id && x.ViewName == viewName).FirstOrDefault();
                model.UserName = userName;
                model.UserEmail = userEmail;
                model.Content = content;
                db.SaveChanges();
                var result = new
                {
                    Id = model.Id,
                    ViewName = model.ViewName,
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Content = model.Content,
                    CreatedTime = model.CreatedTime.ToString("yyyy-MM-dd")
                };
                return Json(new { IsSuccess = true, Data = result });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Data = "修改留言失敗：" + ex.Message });
            }
        }

        /// <summary>
        /// 刪除留言
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteComment(int id, string viewName)
        {
            try
            {
                var db = new PenghuTravelerEntities();

                var model = db.Comment.Where(x => x.Id == id && x.ViewName == viewName).FirstOrDefault();
                db.Comment.Remove(model);
                db.SaveChanges();
                var result = new
                {
                    Id = model.Id,
                    ViewName = model.ViewName,
                    UserName = model.UserName,
                    UserEmail = model.UserEmail,
                    Content = model.Content,
                    CreatedTime = model.CreatedTime.ToString("yyyy-MM-dd")
                };
                return Json(new { IsSuccess = true, Data = result });
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = false, Data = "刪除留言失敗：" + ex.Message });
            }
        }
    }
}