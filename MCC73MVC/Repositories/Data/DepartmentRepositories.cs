using MCC73MVC.Contexts;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data;

public class DepartmentRepositories : GeneralRepository<Department, int>
{
    public DepartmentRepositories(MyContext context) : base(context)
    {

    }
}
