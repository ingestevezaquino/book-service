using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookService.Persistence.Models
{
    public partial class Book
    {
        public Book()
        {
            Rating = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Author Author { get; set; }
        public virtual ICollection<Rating> Rating { get; set; }
    }
}
