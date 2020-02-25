using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Persistance.EntityFramework.Entitys
{
    [Table("ADDRESSES")]
    public class Addresses
    {
        [Key]
        [Column("ADDRESS_ID")]
        public long AddressId { get; set; }

        [MaxLength(100)]
        [Column("ADDRESS_STRING")]
        public string AddressString { get; set; }

        [Column("LON")]
        public double? Lon { get; set; }

        [Column("LAT")]
        public double? Lat { get; set; }
    }
}
