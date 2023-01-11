using System;
using pharmaManagement.Modals;
namespace pharmaManagement.Services.TokenManager
{
	public interface IJWTTokenManager
	{
        Tokens Authenticate(string Username, string Role);
    }
}
