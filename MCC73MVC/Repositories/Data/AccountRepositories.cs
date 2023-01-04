using MCC73MVC.Contexts;
using MCC73MVC.Handlers;
using MCC73MVC.Models;
using MCC73MVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MCC73MVC.Repositories.Data;

public class AccountRepositories : GeneralRepository<Account, string>
{
    private readonly MyContext _context;
    private readonly DbSet<Account> _accounts;

    public AccountRepositories(MyContext context) : base(context)
    {
        _context = context;
        _accounts = context.Set<Account>();
    }

    public int Register(RegisterVM register)
    {

        if (!CheckEmail(register.Email))
        {
            return 0; // Email atau Password sudah terdaftar
        }
        Division s = new Division()
        {
            Name = register.DivisionName
        };

        _context.Divisions.Add(s);
        _context.SaveChanges();

        Department d = new Department()
        {
            Name = register.DepartmentName,
            DivisionId = s.Id
        };

        _context.Departments.Add(d);
        _context.SaveChanges();

        Employee e = new Employee()
        {
            NIK = register.NIK,
            FirstName = register.FirstName,
            LastName = register.LastName,
            Gender = register.Gender,
            Email = register.Email
        };

        _context.Employees.Add(e);
        _context.SaveChanges();

        Account a = new Account()
        {
            NIK = register.NIK,
            Password = Hashing.HashPassword(register.Password)
        };
        _accounts.Add(a);
        _context.SaveChanges(); //simpan pada database

        AccountRole ar = new AccountRole()
        {
            AccountNIK = register.NIK,
            RoleId = 1
        };
        _context.AccountRoles.Add(ar);
        _context.SaveChanges();

        //_context.AccountRoles.Add(new AccountRoleRepositories()
        //{
        //    AccountNIK = register.NIK,
        //    RoleId = 2
        //});
        //_context.SaveChanges();

        

        

        return 1;
    }

    public int Login(LoginVM login)
    {
        //versi referensi
        var result = _accounts.Join(_context.Employees, a => a.NIK, e => e.NIK, (a, e) =>
        new LoginVM
        {
            Email = e.Email,
            Password = a.Password
        }).SingleOrDefault(c => c.Email == login.Email);

        if (result == null)
        {
            return 0;
        }
        if (!Hashing.ValidatePassword(login.Password, result.Password))
        {
            return 1;
        }
        return 2;

    }

    private bool CheckEmail(string email)
    {
        var duplicate = _context.Employees.Where(s => s.Email == email ).ToList();

        if (duplicate.Any())
        {
            return false; // Email atau Password sudah ada
        }
        return true; // Email dan Password belum terdaftar
    }

    public List<string> UserRoles(string email)
    {
        var result = (from e in _context.Employees
                      join a in _accounts on e.NIK equals a.NIK
                      join ar in _context.AccountRoles on a.NIK equals ar.AccountNIK
                      join r in _context.Roles on ar.RoleId equals r.Id
                      where e.Email == email
                      select r.Name.ToString()).ToList();
        return result;
    }

}
