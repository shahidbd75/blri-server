using System.Collections.Generic;
using BLRI.Common.Enum;

namespace BLRI.Manager.Interfaces.Core
{
    public interface IBaseService<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        ReasonCode Delete(object id);
        ReasonCode Add(T viewModel);
        ReasonCode Update(T viewModel);
    }
}
