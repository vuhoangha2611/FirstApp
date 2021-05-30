using FirstApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApp.Controllers
{
    public class MyFirstController : Controller
    {
        // GET: MyFirst
        public ActionResult Index()
        {
            ViewBag.Message = "Vũ Hoàng Hà";
            ViewBag.MyData = "My data from ViewBag";
            //sử dụng TempData bằng cú pháp : TempData.<key> = <Data>
            TempData["MyData"] = "My data from TempData";
            return Redirect("SendViewBag"); //Redirect trả về một cái hàm bên trong
            //view không tham số sẽ trả về trang đó
            // view có tham số sẽ trả về trang của tham số đó   
        }

        // cách truyền dữ liệu từ controller về view
        // cách 1. sử dụng các đối tượng toàn cự : ViewBag, TempData
        // cách 2. sử dụng Model
        public ActionResult CallIndex()
        {
            return View("NewView");
        }
        public ActionResult SendViewBag()
        {
            // sử dụng ViewBag bằng cú pháp: ViewBag.<key> = <Data>
            //Key là do người dùng tự đặt tên như cách đặt tên biến
            //Data là dữ liệu muốn truyền về VIew có thể là số, chuỗi,
            //
            ViewBag.MyData = "My data from ViewBag";
            return View("NewView");
        }
        [HttpPost]
        public ActionResult PostModel(User u)
        {
            if (u.UserName == "admin" && u.PassWord == "123")
                return Content("Sucessfully");
            else
                return View();
        }
        public ActionResult PostModel()
        {
            return View();
        }
        public ActionResult SeendModel()
        {
            User u = new User();
            u.UserName = "admin";
            u.Email = "admin@gmail.com";
            u.PassWord = "1234";
            return View(u);
        }
        public ActionResult ReceiveFromView(string UserName, string Password)
        {
            if (UserName == "admin" && Password == "123")
                return Content("Successfully");
            else
                return Content("Fail");
        }
    }
}