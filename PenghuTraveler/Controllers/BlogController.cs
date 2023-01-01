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
        public ActionResult Single(string id)
        {
            return View();
        }

        /// <summary>
        /// 取得留言板列表資料
        /// </summary>
        /// <returns></returns>
        public ActionResult GetComments(string id)
        {
            return View();
        }

        /// <summary>
        /// 新增留言
        /// </summary>
        /// <returns></returns>
        public ActionResult AddComments(string id)
        {
            return Json(true);
        }

        /// <summary>
        /// 修改留言
        /// </summary>
        /// <returns></returns>
        public ActionResult EditComments(string id)
        {
            return Json(true);
        }

        /// <summary>
        /// 刪除留言
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteComments(string id)
        {
            return Json(true);
        }
    }
}