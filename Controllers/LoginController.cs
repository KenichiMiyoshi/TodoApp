using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    //ログインしていない状態でもアクセス可能になる属性
    [AllowAnonymous]
    public class LoginController : Controller
    {

        //メンバーシッププロバイダーを一度だけ読み込み、保持
        readonly CustomMembershipProvider membershipProvider = new CustomMembershipProvider();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        //下２つはアノテーション
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "UserName,Password")] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (this.membershipProvider.ValidateUser(model.UserName, model.Password))
                {
                    //認証クッキーを設定して認証状態を保持
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    //todoesコントローラーのindexに処理を返す
                    return RedirectToAction("Index", "Todoes");
                }
            }
            ViewBag.Message = "ログインに失敗しました。";
            return View(model);
        }

        //サインアウトするとクッキーを自動削除
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

    } 
}
