using System;
using System.Collections.Generic;
using System.Text;

namespace BLRI.Common.Enum
{
    public enum ReasonCode
    {
        Ok = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        Conflict = 409,
        InternalServerError = 500,
        Updated = 1000,
        Deleted = 1001,
        OperationFailed,
        NothingModified,
        InvalidContent,
        InvalidClient,
        SmsLimit,
        InvalidPhone,
        ValidPhone,
        AlreadyVerified,
        ActiveAccount,
        AlreadyExist,
        NotActive
    }
}
