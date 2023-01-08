using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane.Data.Models
{
    public class Books
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public int PageCount { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

        public virtual Users User { get; set; }
        public virtual Authors Author { get; set; }
        public virtual Categories Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        
    }
}
