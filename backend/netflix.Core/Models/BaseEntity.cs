using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace netflix.Core.Models
{
    public class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }


        [JsonIgnore]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;
    }
}
