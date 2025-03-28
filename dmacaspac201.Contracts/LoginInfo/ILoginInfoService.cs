using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dmacaspac201.Contracts.LoginInfo
{
    public interface ILoginInfoService : IService
    {
        List<LoginInfoDto>? GetPerUser(Guid? userId);

        LoginInfoDto? GetPassword(Guid? userId);

        Task<LoginInfoDto?> Update(LoginInfoDto? loginInfoDto);

        LoginInfoDto? GetRole(Guid? userId);
    }
}
