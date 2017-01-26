using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbContext
    {
        public readonly string connectionString;

        public DbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
