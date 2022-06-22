using Microsoft.AspNetCore.Mvc;

namespace apinet.Controllers;

[ApiController]
[Route("[controller]")]

public class HelloWorldController : ControllerBase
{
       //recivimos la dependencia de HelloworldService
       InterfaceHelloWorldService helloWorldService;
        //pasamos la dependencia al controlador
       public HelloWorldController(InterfaceHelloWorldService helloWorld){

        helloWorldService = helloWorld;
       }
       //cumplimos el standar de swagger
        [HttpGet]//para cumpli el standar de api de swagger
       //creamos un metodo get para retuirnar una respuesta
       public IActionResult Get(){
        return Ok(helloWorldService.GethelloWorld());
       }
}
