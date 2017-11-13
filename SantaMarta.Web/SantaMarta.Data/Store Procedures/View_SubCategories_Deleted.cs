using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Data.Store_Procedures
{
    public class View_SubCategories_Deleted
    {
        public Int64 IdSubCategory { get; set; }
        public String NameSubCategory { get; set; }
        public Boolean StateSubCategory { get; set; }
        public String NameCategory { get; set; }
        public Boolean StateCategory { get; set; }
    }
}
