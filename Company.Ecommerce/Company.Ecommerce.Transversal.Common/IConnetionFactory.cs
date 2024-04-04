using System.Data;


namespace Company.Ecommerce.Transversal.Common
{
    public interface IConnetionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
