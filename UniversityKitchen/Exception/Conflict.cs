namespace UniversityKitchen.Exception;

public class Conflict : System.Exception
{
    public Conflict(string message) : base(message){}
    public Conflict(string message, System.Exception inner) : base(message, inner){}
}