namespace NossaLoja.Core.Domain.Enums;

public enum StatusCodeEnum
{
    Ok = 200,
    Created = 201,
    Accepted = 202,
    MultiStatus = 207,

    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    UnprocessableEntity = 422,
    Locked = 423,

    InternalServerError = 500,
    ServiceUnavailable = 503,
}
