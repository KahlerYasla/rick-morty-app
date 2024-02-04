namespace CoreInfrastructureLayer.Helpers
{
    // Singleton pattern
    public sealed class WorkspacePaths
    {
        private static readonly WorkspacePaths instance = new();
        private string? _dbPath;

        public static WorkspacePaths Instance
        {
            get
            {
                return instance;
            }
        }

        public string? DbPath
        {
            get
            {
                if (string.IsNullOrEmpty(_dbPath))
                {
                    string currentDirectory = Environment.CurrentDirectory;

                    Console.WriteLine("Current Path:" + currentDirectory);

                    _dbPath = Path.Combine(currentDirectory + @"/Data/rick_morty.db");

                    Console.WriteLine("DbPath:" + _dbPath);

                    return _dbPath ?? throw new ArgumentNullException("DbPath is null");
                }
                return _dbPath;
            }
            set => _dbPath = value;
        }
    }
}