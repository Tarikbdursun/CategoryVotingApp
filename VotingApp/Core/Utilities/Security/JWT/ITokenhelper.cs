using Core.Entity.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenhelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
