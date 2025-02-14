﻿
using Ambev.DeveloperEvaluation.Common.Validation;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class ApiResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public IEnumerable<ValidationErrorDetail> Errors { get; set; } = [];

    public ApiResponse()
    {
        Success = true;
    }

    public ApiResponse(string message)
    {
        Success = true;
        Message = message;
    }
}
