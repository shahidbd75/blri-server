using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLRI.Common.Enum;

namespace BLRI.API.Helper
{
    public class Response:IResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public ReasonCode Code { get; set; }
    }

    public class SingleResponse<TModel> : ISingleResponse<TModel>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public ReasonCode Code { get; set; }
        public TModel Model { get; set; }
    }

    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public ReasonCode Code { get; set; }
        public IEnumerable<TModel> Model { get; set; }
    }

    public class PagedResponse<TModel> : IPagedResponse<TModel>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public ReasonCode Code { get; set; }
        public IEnumerable<TModel> Model { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int ItemsCount { get; set; }
        public double PageCount
            => ItemsCount < PageSize ? 1 : (int)(((double)ItemsCount / PageSize) + 1);
    }
}
