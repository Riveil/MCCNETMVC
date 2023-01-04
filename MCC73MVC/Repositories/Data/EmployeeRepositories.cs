using MCC73MVC.Contexts;
using MCC73MVC.Models;

namespace MCC73MVC.Repositories.Data
{
    public class EmployeeRepositories : GeneralRepository<Employee, string>
    {
        public EmployeeRepositories(MyContext context) : base(context)
        {

        }
    }
}
