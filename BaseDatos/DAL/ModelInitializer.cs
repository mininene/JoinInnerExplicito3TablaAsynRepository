using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaseDatos.DAL
{
    public class ModelInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {


        }
    }
}