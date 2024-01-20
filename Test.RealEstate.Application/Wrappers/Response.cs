
using FluentValidation.Results;
using FluentValidation;
using System.Net;
using Test.RealEstate.Application.Behaviours;

namespace Test.RealEstate.Application.Wrappers
{
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

        //public Response ValidateCommand<TCommand>(TCommand command, IEnumerable<IValidator<TCommand>> validators)
        //{
        //    if (validators.Any())
        //    {
        //        ValidationContext<TCommand> context = new ValidationContext<TCommand>(command);
        //        List<ValidationResult> source = validators.Select((IValidator<TCommand> v) => v.Validate(context)).ToList();
        //        List<ValidationFailure> list = (from f in source.SelectMany((ValidationResult r) => r.Errors)
        //                                        where f != null
        //                                        select f).ToList();
        //        if (list.Count != 0)
        //        {
        //            ValidationErrorResponse validationErrorResponse = new ValidationErrorResponse();
        //            foreach (ValidationFailure item in list)
        //            {
        //                validationErrorResponse.Add(item.PropertyName, new List<string> { item.ErrorMessage });
        //            }

        //            return new Response
        //            {
        //                ResponseCode = (int)HttpStatusCode.BadRequest,
        //                Message = "The request contains validation errors.",
        //                Status = false,
        //                Data = validationErrorResponse
        //            };
        //        }
        //    }

        //    return null;
        //}

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
