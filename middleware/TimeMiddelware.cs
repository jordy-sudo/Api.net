public class TimeMiddleware{
    readonly RequestDelegate next;//para poder tener el orden cuando se ejecutna los middlware

    public TimeMiddleware(RequestDelegate nextRequest){
        next = nextRequest;
    }
    //creo  una tarea que invoca el request
    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context){
        await next(context);
        //creamos una condicion para saber si se solicita la hora y q hacer en ese caso
        if(context.Request.Query.Any(p=>p.Key=="time")){
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());//regreso la hora actual en formato corto
        }

    }
}

//metodo que ayuda a designar y poder usar el middelware dentro de neustra aplicacion 
//es decir poder usar app.Mimiddleware
public static class TimeMiddlewareExtension{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder builder){
        return builder.UseMiddleware<TimeMiddleware>();
    }
}