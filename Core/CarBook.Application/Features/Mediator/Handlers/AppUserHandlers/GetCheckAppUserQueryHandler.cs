using CarBook.Application.Features.Mediator.Queries.AppUserQueires;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using CarBook.Application.Interfaces.AppRoleInterfaces;
using CarBook.Application.Interfaces.AppUserInterfaces;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IAppRoleRepository _appRoleRepository;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IAppRoleRepository appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var appUser = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (appUser == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.UserName = appUser.UserName;
                values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleID == appUser.AppRoleID)).RoleName;
                values.ID = appUser.AppUserID;
            }

            return values;
        }
    }
}
