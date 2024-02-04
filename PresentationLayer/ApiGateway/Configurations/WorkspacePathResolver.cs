using CoreInfrastructureLayer.Helpers;

namespace rick_morty_app.Configurations
{
    public class WorkspacePathResolver : IDisposable
    {
        private string? DbPath { get; set; }

        public void Dispose()
        {
            DbPath = null;

            GC.SuppressFinalize(this);
            GC.Collect();
        }

        public void SetDbPath()
        {
            Console.WriteLine("\n");
            Console.WriteLine("WorkspacePathResolver is working...");

            // get the root directory of the project
            string rootDirectory = Directory.GetParent(Environment.CurrentDirectory)!.Parent!.FullName;

            Console.WriteLine("Current Path:" + rootDirectory);

            DbPath = Path.Combine(rootDirectory + @"/DataAccessLayer/Data/rick_morty.db");

            Console.WriteLine("DbPath:" + DbPath);
            Console.WriteLine("\n");

            WorkspacePaths.Instance.DbPath = DbPath;
        }
    }
}