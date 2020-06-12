using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        //本クラスとユーザークラスの関連を表すナビゲーションプロパティ
        public virtual ICollection<User> Users { get; set; }
    }
}