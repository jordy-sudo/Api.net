
    public class HelloWorldServices : InterfaceHelloWorldService //implemento mi interface en el metodo
    {
        public string GethelloWorld(){
            return "Hola mundo desde el servicio";
        }
    }
    public interface InterfaceHelloWorldService{
        string GethelloWorld();
    }
        
