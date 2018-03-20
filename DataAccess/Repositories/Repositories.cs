 


namespace DataAccess.Repositories
{
    using DataAccess;
	using DataAccess.Abstraction;
	using DataAccess.Implementation;
	using System.Data.Entity;
    using Domain;

	public partial interface IAppUserRepository : IRepository<AppUser> 
	{
	}

	public partial class AppUserRepository : Repository<AppUser>, IAppUserRepository
	{
		public AppUserRepository(DbContext context)
            : base(context)
        {
        }
	}  
	public partial interface IProjectRepository : IRepository<Project> 
	{
	}

	public partial class ProjectRepository : Repository<Project>, IProjectRepository
	{
		public ProjectRepository(DbContext context)
            : base(context)
        {
        }
	}  
	public partial interface IProjectTypeRepository : IRepository<ProjectType> 
	{
	}

	public partial class ProjectTypeRepository : Repository<ProjectType>, IProjectTypeRepository
	{
		public ProjectTypeRepository(DbContext context)
            : base(context)
        {
        }
	}  
	public partial interface IProjectURLRepository : IRepository<ProjectURL> 
	{
	}

	public partial class ProjectURLRepository : Repository<ProjectURL>, IProjectURLRepository
	{
		public ProjectURLRepository(DbContext context)
            : base(context)
        {
        }
	}  
	public partial interface IProjectURLTypeRepository : IRepository<ProjectURLType> 
	{
	}

	public partial class ProjectURLTypeRepository : Repository<ProjectURLType>, IProjectURLTypeRepository
	{
		public ProjectURLTypeRepository(DbContext context)
            : base(context)
        {
        }
	}  
	public partial interface IRoleRepository : IRepository<Role> 
	{
	}

	public partial class RoleRepository : Repository<Role>, IRoleRepository
	{
		public RoleRepository(DbContext context)
            : base(context)
        {
        }
	}  
	public partial interface IUserRepository : IRepository<User> 
	{
	}

	public partial class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(DbContext context)
            : base(context)
        {
        }
	}  
	public partial interface IUserProjectRepository : IRepository<UserProject> 
	{
	}

	public partial class UserProjectRepository : Repository<UserProject>, IUserProjectRepository
	{
		public UserProjectRepository(DbContext context)
            : base(context)
        {
        }
	}  
	public partial interface IUserRoleRepository : IRepository<UserRole> 
	{
	}

	public partial class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
	{
		public UserRoleRepository(DbContext context)
            : base(context)
        {
        }
	}  
}