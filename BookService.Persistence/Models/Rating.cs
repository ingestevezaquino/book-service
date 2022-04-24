using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookService.Persistence.Models
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Stars { get; set; }

        public virtual Book Book { get; set; }
    }
}
