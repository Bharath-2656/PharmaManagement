using System;
using pharmaManagement.Modals;
namespace pharmaManagement.Services
{
	public interface IJWTTokenManager
	{
        Tokens Authenticate(string Username, string Role);
    }
}
