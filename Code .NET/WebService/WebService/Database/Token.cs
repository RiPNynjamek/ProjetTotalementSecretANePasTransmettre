namespace WebService.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Token")]
    public partial class Token
    {
        public int Id { get; set; }

        [Column("Token")]
        [Required]
        [StringLength(250)]
        public string Token1 { get; set; }

        public int UserId { get; set; }

        public DateTime CreateTime { get; set; }

        public virtual User User { get; set; }
    }
}
