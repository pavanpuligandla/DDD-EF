 


namespace Services
{
    using DataAccess.Abstraction;
    using Domain;
    using Services;

	public partial interface IAppUserService : IEntityService<AppUser> 
	{
	}

	public partial class AppUserService : EntityService<AppUser>, IAppUserService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<AppUser> _repository;

		public AppUserService(IUnitOfWork unitOfWork, IRepository<AppUser> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
	public partial interface IProjectService : IEntityService<Project> 
	{
	}

	public partial class ProjectService : EntityService<Project>, IProjectService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Project> _repository;

		public ProjectService(IUnitOfWork unitOfWork, IRepository<Project> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
	public partial interface IProjectTypeService : IEntityService<ProjectType> 
	{
	}

	public partial class ProjectTypeService : EntityService<ProjectType>, IProjectTypeService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProjectType> _repository;

		public ProjectTypeService(IUnitOfWork unitOfWork, IRepository<ProjectType> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
	public partial interface IProjectURLService : IEntityService<ProjectURL> 
	{
	}

	public partial class ProjectURLService : EntityService<ProjectURL>, IProjectURLService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProjectURL> _repository;

		public ProjectURLService(IUnitOfWork unitOfWork, IRepository<ProjectURL> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
	public partial interface IProjectURLTypeService : IEntityService<ProjectURLType> 
	{
	}

	public partial class ProjectURLTypeService : EntityService<ProjectURLType>, IProjectURLTypeService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProjectURLType> _repository;

		public ProjectURLTypeService(IUnitOfWork unitOfWork, IRepository<ProjectURLType> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
	public partial interface IRoleService : IEntityService<Role> 
	{
	}

	public partial class RoleService : EntityService<Role>, IRoleService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Role> _repository;

		public RoleService(IUnitOfWork unitOfWork, IRepository<Role> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
	public partial interface IUserService : IEntityService<User> 
	{
	}

	public partial class UserService : EntityService<User>, IUserService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User> _repository;

		public UserService(IUnitOfWork unitOfWork, IRepository<User> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
	public partial interface IUserProjectService : IEntityService<UserProject> 
	{
	}

	public partial class UserProjectService : EntityService<UserProject>, IUserProjectService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserProject> _repository;

		public UserProjectService(IUnitOfWork unitOfWork, IRepository<UserProject> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
	public partial interface IUserRoleService : IEntityService<UserRole> 
	{
	}

	public partial class UserRoleService : EntityService<UserRole>, IUserRoleService
	{
	    private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<UserRole> _repository;

		public UserRoleService(IUnitOfWork unitOfWork, IRepository<UserRole> repository)
            : base(unitOfWork, repository)
        {
		   _unitOfWork = unitOfWork;
		   _repository = repository;
        }
	}  
}