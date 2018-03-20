using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Domain;
using System.Linq.Expressions;

namespace Services.Entity
{
    public class EntityService<TEntity, TRepository> : IQueryable<TEntity>
        where TRepository : IRepository<TEntity>
        where TEntity : class
    {
        private readonly TRepository _repository;

        protected EntityService(TRepository repository)
        {
            _repository = repository;
        }

        protected TRepository Repository
        {
            get { return _repository; }
        }

        public Expression Expression
        {
            get { return _repository.Expression; }
        }

        public Type ElementType
        {
            get { return _repository.ElementType; }
        }

        public IQueryProvider Provider
        {
            get { return _repository.Provider; }
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return _repository.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _repository.GetEnumerator();
        }
    }
}
