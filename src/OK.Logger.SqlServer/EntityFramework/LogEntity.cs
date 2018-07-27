using System;
using System.ComponentModel.DataAnnotations;

namespace OK.Logger.SqlServer.EntityFramework
{
    public class LogEntity
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Message { get; set; }
        
        public string Data { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}