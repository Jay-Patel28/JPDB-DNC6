using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace JPDB.Model
{
    
    [Index(nameof(Code), IsUnique = true)]

    public class Crypto
    {
        public int Id { get; set; }

        public string? Code { get; set; }
        public DateTime Created { get; set; }


        [Required]

        public List<User>? Users { get; set; }



    }
    [Table("Users")]
    public class User
    {
        public int UserId { get; set; }
        public int CryptoId { get; set; }
        public string? UserName { get; set; }
    }

}
