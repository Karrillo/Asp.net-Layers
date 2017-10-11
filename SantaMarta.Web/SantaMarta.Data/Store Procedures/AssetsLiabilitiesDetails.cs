using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SantaMarta.Data.Store_Procedures
{
    public class AssetsLiabilitiesDetails
    {
        public Int64 IDAssetLiability { get; set; }
        public DateTime CurrentDate { get; set; }
        public Int64 Code { get; set; }
        public Decimal Rode { get; set; }
        public String Type { get; set; }
        public String Description { get; set; }
        public String Name { get; set; }
        public Boolean State { get; set; }
        public Int64? IdUser { get; set; }
        public String NameAccount { get; set; }
        public String NameUser { get; set; }
        public String NameCategory { get; set; }
        public String NameSubCategory { get; set; }
    }
}
