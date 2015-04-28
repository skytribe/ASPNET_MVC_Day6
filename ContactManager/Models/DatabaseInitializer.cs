using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ContactManager.Models
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DataContext>
    {

        Random d = new Random();



        protected override void Seed(DataContext context)
        {
            var contact = new List<Contact>();

            // Populate Random Contact Data
            for (int index = 0; index < 100; index++)
            {
 
                var newContact = new Contact
                {
                    Id = index,
                    FirstName = "First" + index.ToString(),
                    LastName = "Last" + index.ToString(),
                    Phone = "Tel" + index.ToString(),
                    Birthday = RandomDate() 
                };

                contact.Add(newContact);

            }

            contact.ForEach(m => context.ContactDetails.Add(m));

        }


        /// <summary>
        /// Generate a random datetime
        /// </summary>
        /// <returns></returns>
        private DateTime RandomDate()
        {

            var d1 = d.Next(28);
            var m1 = d.Next(12);
            var y1 = d.Next(10);

            var d2 = new DateTime(month: m1 + 1,
                                  day: d1 + 1,
                                  year: (1990 + y1));

            return d2;
                
        }
 

    }
}