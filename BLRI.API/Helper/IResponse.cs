using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLRI.Common.Enum;

namespace BLRI.API.Helper
{
    public interface IResponse
    {
        string Message { get; set; }

        bool IsSuccess { get; set; }
        ReasonCode Code { get; set; }
    }
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }

    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }

    public interface IPagedResponse<TModel> : IListResponse<TModel>
    {
        int ItemsCount { get; set; }

        double PageCount { get; }
    }
}
