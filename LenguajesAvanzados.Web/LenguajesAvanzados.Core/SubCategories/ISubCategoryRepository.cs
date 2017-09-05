using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenguajesAvanzados.Core.SubCategories
{
    public interface ISubCategoryRepository
    {
        void Create(SubCategory input);
        void Update(SubCategory input);
        void Delete(int id);
        SubCategory Get(int id);
        SubCategory GetById(int id);
        List<SubCategory> GetAll();
    }
}
