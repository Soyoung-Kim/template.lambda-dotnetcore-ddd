using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLambdaDotNetCoreProject.Domain.Seedwork
{
    public interface IRepository<T> where T: IAggregateRoot
    {

    }
}
