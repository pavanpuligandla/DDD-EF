using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace DatabaseMigrations
{
    [Migration(201801241228, "Initial Migration")]
    public class M201801241228InitialMigration : Migration
    {
        public override void Up()
        {
            //lookup data
            Execute.Script(@"\MyProjects\DDD-EF\DatabaseMigrations\Scripts\LookupData.sql");
        }

        public override void Down()
        {

        }
    }
}
