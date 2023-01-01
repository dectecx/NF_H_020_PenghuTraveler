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
        /// 取得留言板列表資料
        /// </summary>
        /// <returns></returns>
        public ActionResult GetMessageBoard(string id)
        {
            return View();
        }
    }
}