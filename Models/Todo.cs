using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    //クラス名は必ず単数形の名詞。クラス名が複数形となりテーブルを作成
    public class Todo
    {
        //プロパティ名が列名となる（idプロパティは自動的に主キー)
        public int Id { get; set; }

        [DisplayName("概要")]
        public string Summary { get; set; }

        [DisplayName("詳細")]
        public string Detail { get; set; }

        [DisplayName("期限")]
        public DateTime Limit { get; set; }

        [DisplayName("完了")]
        public bool Done { get; set; }

        public virtual User User { get; set; }

    }
}