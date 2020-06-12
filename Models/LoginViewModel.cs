//ビューモデルーモデル(データトランスファーオブジェクト)はDBの項目と表示する項目の違いを吸収する
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class LoginViewModel
    {
        [Required]
        //日本語表示にはdisplaynameが必要
        [DisplayName("ユーザー名")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("パスワード")]
        public string Password { get; set; }
    }
}