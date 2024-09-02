using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace NascarPage.Utilidades
{
    public static class HttpContextExtensions
    {
        public static async Task InsertarCantidadPaginasCabecera<T>(this HttpContext context, IQueryable<T> query, int records )
        {
            if( context == null ) throw new ArgumentNullException(nameof(context));

            double cantidad = await query.CountAsync();
            double cantidadPags = Math.Ceiling( cantidad / records );
            context.Response.Headers.Append("cantidadDePaginas", cantidadPags.ToString());
        }
    }
}
