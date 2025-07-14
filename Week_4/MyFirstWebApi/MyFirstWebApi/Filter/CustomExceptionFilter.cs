using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace MyFirstWebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            string logPath = "D:\\Cognizant\\Week_2\\MyFirstWebApi\\logs.txt";

            File.AppendAllText(logPath, $"[{DateTime.Now}] {exception.Message}{Environment.NewLine}");

            context.Result = new ObjectResult("Internal Server Error occurred")
            {
                StatusCode = 500
            };
        }
    }
}
