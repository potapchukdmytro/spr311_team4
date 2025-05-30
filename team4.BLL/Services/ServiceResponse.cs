﻿namespace team4.BLL.Services
{
    public class ServiceResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;
        public object? Payload { get; set; }

        public static ServiceResponse Success(string message, object? payload = null)
        {
            return new ServiceResponse
            {
                IsSuccess = true,
                Message = message,
                Payload = payload
            };
        }

        public static ServiceResponse Error(string message, object? payload = null)
        {
            return new ServiceResponse
            {
                IsSuccess = false,
                Message = message,
                Payload = payload
            };
        }

        public static ServiceResponse FromResult(bool result, string successMsg, string errorMsg, object? payload = null)
        {
            return result ? ServiceResponse.Success(successMsg, payload) : ServiceResponse.Error(errorMsg, payload);
        }
    }
}
