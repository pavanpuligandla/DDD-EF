 


namespace Send.Data.Repositories
{
    using DataAccess;
	using DataAccess.Interfaces;
	using DataAccess.Implementation;
	using Services.Entity;
    using Domain;

	public partial interface IAppUserService : IEntityService<AppUser> 
	{
	}

	public partial class AppUserService : EntityService<AppUser, IAppUserRepository>, IAppUserService
	{
		public AppUserService(IAppUserRepository repository)
			: base(repository)
        {
        }
	}  
	public partial interface IProjectService : IEntityService<Project> 
	{
	}

	public partial class ProjectService : EntityService<Project, IProjectRepository>, IProjectService
	{
		public ProjectService(IProjectRepository repository)
			: base(repository)
        {
        }
	}  
	public partial interface IProjectTypeService : IEntityService<ProjectType> 
	{
	}

	public partial class ProjectTypeService : EntityService<ProjectType, IProjectTypeRepository>, IProjectTypeService
	{
		public ProjectTypeService(IProjectTypeRepository repository)
			: base(repository)
        {
        }
	}  
	public partial interface IProjectURLService : IEntityService<ProjectURL> 
	{
	}

	public partial class ProjectURLService : EntityService<ProjectURL, IProjectURLRepository>, IProjectURLService
	{
		public ProjectURLService(IProjectURLRepository repository)
			: base(repository)
        {
        }
	}  
	public partial interface IProjectURLTypeService : IEntityService<ProjectURLType> 
	{
	}

	public partial class ProjectURLTypeService : EntityService<ProjectURLType, IProjectURLTypeRepository>, IProjectURLTypeService
	{
		public ProjectURLTypeService(IProjectURLTypeRepository repository)
			: base(repository)
        {
        }
	}  
	public partial interface IRoleService : IEntityService<Role> 
	{
	}

	public partial class RoleService : EntityService<Role, IRoleRepository>, IRoleService
	{
		public RoleService(IRoleRepository repository)
			: base(repository)
        {
        }
	}  
	public partial interface IUserService : IEntityService<User> 
	{
	}

	public partial class UserService : EntityService<User, IUserRepository>, IUserService
	{
		public UserService(IUserRepository repository)
			: base(repository)
        {
        }
	}  
	public partial interface IUserProjectService : IEntityService<UserProject> 
	{
	}

	public partial class UserProjectService : EntityService<UserProject, IUserProjectRepository>, IUserProjectService
	{
		public UserProjectService(IUserProjectRepository repository)
			: base(repository)
        {
        }
	}  
	public partial interface IUserRoleService : IEntityService<UserRole> 
	{
	}

	public partial class UserRoleService : EntityService<UserRole, IUserRoleRepository>, IUserRoleService
	{
		public UserRoleService(IUserRoleRepository repository)
			: base(repository)
        {
        }
	}  
}