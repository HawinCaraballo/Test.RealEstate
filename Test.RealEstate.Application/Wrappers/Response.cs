// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Wrappers
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="Response.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Test.RealEstate.Application.Wrappers
{
    using System.Net;
    using Test.RealEstate.Application.Behaviours;
    public class Response<T>
    {
        public Response(int responseCode, string message, bool status, T data)
        {
            ResponseCode = responseCode;
            Message = message;
            Data = data;
            Status = status;

        }
        public Response()
        {
            ResponseCode = 500;
            Status = false;
        }

        public Response BadRequest(int entityId, string message)
        {
            return new Response
            {
                ResponseCode = (int)HttpStatusCode.BadRequest,
                Message = message,
                Status = false,
                Data = entityId
            };
        }

        public Response CreateInternalServerErrorResponse(string errorMessage, string traceExceptionMessage)
        {
            return new Response
            {
                ResponseCode = (int)HttpStatusCode.InternalServerError,
                Message = errorMessage,
                Status = false,
                Data = traceExceptionMessage
            };
        }

        public Response SuccessResponse(object entity, string message)
        {
            return new Response
            {
                ResponseCode = (int)HttpStatusCode.OK,
                Message = message,
                Status = true,
                Data = entity
            };
        }

        public int ResponseCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool? Status { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
