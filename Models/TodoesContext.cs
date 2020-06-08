using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
	//コンテキストクラスはDbContextを継承する必要がある
	public class TodoesContext : DbContext
	{
		//DBを格納するデータセットのプロパティ
		public DbSet<Todo> Todoes { get; set; }
		//public DbSet<User> Users { get; set; }
		//public DbSet<Role> Roles { get; set; }

	}
}