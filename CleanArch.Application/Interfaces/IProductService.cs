using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArch.Application.ViewModels;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetById(int? id);
        void Add(ProductViewModel product);
        void Update(ProductViewModel product);
        void Remove(int? id);
    }
}