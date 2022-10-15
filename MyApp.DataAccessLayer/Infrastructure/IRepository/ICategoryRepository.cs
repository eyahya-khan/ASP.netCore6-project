using MyAppModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.IRepository
{
    public interface ICategoryRepository: IRepository<Category> 
    {
        object GetT(int? id);
        void Update(Category category);

    }
}
