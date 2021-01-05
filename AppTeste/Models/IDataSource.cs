using System.Collections.Generic;

namespace AppTeste.Models
{
    public interface IDataSource
    {
        IEnumerable<Product> Products { get; }
    }
}