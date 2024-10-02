using System;
namespace CoreService.Middlewares
{
	public class SimpleMiddleware
	{
		private readonly RequestDelegate _next;

		public SimpleMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext context)
		{
            Console.WriteLine("Simple middleware said: hello!");
            //await context.Response.WriteAsync("<div> Simple middleware say hello! </ div>");
			await _next(context);
			//await context.Response.WriteAsync("<div> Simple middleware bye!!! </ div>");
			Console.WriteLine("Simple middleware said: bye!!!");
		}
	}
}

