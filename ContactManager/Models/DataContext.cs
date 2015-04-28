using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class DataContext : DbContext
    {
        public IDbSet<Contact> ContactDetails { get; set; }

        public DataContext()
        {
            Database.SetInitializer(new DatabaseInitializer());  // This will call the database seed
        }
    }
}