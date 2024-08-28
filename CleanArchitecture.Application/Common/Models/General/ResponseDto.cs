﻿using CleanArchitecture.Application.Common.Models.Errors;

namespace CleanArchitecture.Application.Common.Models.General
{
    public class ResponseDto<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }= string.Empty;
        public T Data { get; set; }
        public List<ErrorDto> Errors { get; set; } = [];

        public ResponseDto(T data)
        {
            Data = data;
        }

        public ResponseDto(string message, bool success)
        {
            Message = message;
            Success = success;
        }

        public ResponseDto(T data, string message) : this(data)
        {
            Message = message;
        }
        
        public ResponseDto(string message, List<ErrorDto> errors)
        {
            Message = message;
            Errors = errors;
            Success = false;
        }

        public ResponseDto(T data, string message, List<ErrorDto> errors) : this(message, errors)
        {
            Data = data;
            Success = false;
        }

        public ResponseDto(T data, string message, bool success, List<ErrorDto> errors) : this(data, message, errors)
        {
            Success = success;

        }
    } 
}
