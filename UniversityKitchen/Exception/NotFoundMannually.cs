namespace UniversityKitchen.Exception;


public class NotFoundMannually : System.Exception
{
    public NotFoundMannually(string message) : base(message){}
    public NotFoundMannually(string message, System.Exception inner) : base(message, inner){}
}