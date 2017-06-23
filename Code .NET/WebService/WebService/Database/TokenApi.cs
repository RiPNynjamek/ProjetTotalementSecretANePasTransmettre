namespace WebService.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TokenApi")]
    public partial class TokenApi
    {
        public int Id { get; set; }

        [Column("TokenApi")]
        [Required]
        [StringLength(250)]
        public string TokenApi1 { get; set; }

        [Required]
        [StringLength(50)]
        public string ApplicationName { get; set; }
    }
}
