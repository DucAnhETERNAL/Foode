using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Username { get; set; }

        [MaxLength(15)]
        public string Mobile { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public string Address { get; set; }

        [MaxLength(10)]
        public string PostCode { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(500)]
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<Cart> Carts { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
