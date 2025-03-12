namespace UniversityKitchen.Service.Sidebar;

public interface IRedirecter
{
    Task<string> Redirect(string url);
}