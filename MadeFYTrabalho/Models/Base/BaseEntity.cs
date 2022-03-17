using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoulSoftApi.Model.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public long Id { get; set; }
    }
}
