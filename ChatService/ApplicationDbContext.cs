using ChatService.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChatService
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
             : base("DbConnection")
        { }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Chat> Chats { get; set; }

    }
}