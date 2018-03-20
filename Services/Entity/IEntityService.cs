using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Entity
{
    public interface IEntityService<TEntity> : IQueryable<TEntity>
    {

        //TODO: Signatures 
    }
}
