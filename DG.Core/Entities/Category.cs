using System;
using System.Collections.Generic;
using System.Text;

namespace DG.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }

        public int SysNo { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string UrlSlug { get; set; }
    }
}
