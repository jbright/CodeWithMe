using Insight.Database.Schema;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeWithMe.Setup
{
    /// <summary>
    /// Entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Launch the insight schema setup.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Beginning to setup the database.");

            var connectionString = ConfigurationManager.ConnectionStrings["CodeWithMe"].ConnectionString;

            // Will actually create the database if it doesn't exist!
            SchemaInstaller.CreateDatabase(connectionString);

            // Invoke the schema installer to do magic.
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();

                // create the installer to apply changes
                SchemaInstaller installer = new SchemaInstaller(db);
                new SchemaEventConsoleLogger().Attach(installer);

                // get the SQL from the embedded resources
                SchemaObjectCollection schema = new SchemaObjectCollection(Assembly.GetExecutingAssembly());
                schema.StripPrintStatements = true;

                // install the schema
                // (This allows us to have multiple schemas in a single database. Pretty cool).
                installer.Install("CodeWithMe", schema);
            }

            Console.WriteLine();
            Console.WriteLine("Done!");
        }
    }
}
