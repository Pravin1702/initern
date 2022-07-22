using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBLibrary
{
    public interface IRepo<K, T>
    {
        T Add(T item);
        T Get(T item);
        ICollection<T> GetAll();
    }
}