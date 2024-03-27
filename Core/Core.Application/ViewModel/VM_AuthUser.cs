using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.ViewModel;

public class VM_AuthUser 
{
    /// <summary>
    /// Validation işlemini fluent validation  ile yaptım belki ilerde data annotations da kullanabilirim
    /// Kerem Sandalcilar
    /// </summary>
    public string Email { get; set; }
    public string Password { get; set; }

}