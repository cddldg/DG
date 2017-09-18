using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DG.Core.Entities
{
    [Table("Category")]
    public class Category
    { 
        public int Id { get; set; }

        public int SysNo { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
