using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    //コントローラークラスの継承が必要
    public class TodoesController : Controller
    {
        //プライベート変数でコンテキストを保持。このオブジェクト(TodoesContext)でデータを保持
        private TodoesContext db = new TodoesContext();

        // GET: Todoes
        //メソッド(index)。ブラウザからアクセスがあると呼ばれる。アクションメソッド
        public ActionResult Index()
        {
            //viewメソッド。ヘルパーメソッド
            return View(db.Todoes.ToList());
        }

        // GET: Todoes/Details/5
        //Detailsメソッド
        //intはnullを設定できないが、int?でnullable型となりnullを許容する
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: Todoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todoes/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        //ポストした際のアクションメソッド
        [HttpPost]
        [ValidateAntiForgeryToken]
        //過多ポスティング攻撃を防止するためバインドにモデルバインドの対象となるプロパティを指定
        public ActionResult Create([Bind(Include = "Id,Summary,Detail,Limit")] Todo todo)
        {
            //IsValidは入力が適切かどうかを返す
            if (ModelState.IsValid)
            {
                db.Todoes.Add(todo);
                db.SaveChanges();
                //RedirectToActionは指定されたアクションメソッドに処理を転送するヘルパーメソッド
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        // GET: Todoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Summary,Detail,Limit,Done")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                //stateプロパティにModifiedをセットすることで該当のtodoを更新
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Delete/5
        [HttpPost, ActionName("Delete")]
        //HOSTされたトークンを確認
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todo todo = db.Todoes.Find(id);
            db.Todoes.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //保持しているコンテキストを開放
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
