//Adapted code repository skeleton from Bret Hargreaves (2019) https://github.com/completecoder/MyShop
using System.Linq;
using MyFYP.Core.Models;

namespace MyFYP.Core.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Comit();
        void Delete(string Id);
        T Find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}