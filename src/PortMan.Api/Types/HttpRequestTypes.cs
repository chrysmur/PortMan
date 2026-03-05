using System;
using System.Collections.Generic;
using System.Text;

namespace PortMan.Application.Types;

public class CreateUserRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Phone { get; set; }
    public required string TaxPin { get; set; }
    public required string Address { get; set; }
}
