using TestingCodefirstNetPcl.Framework;

namespace TestingCodefirstNetPcl
{
    public partial class App : Application
    {
        private readonly DatabaseContext _dbContext;

        public App(DatabaseContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override async void OnStart()
        {
            // Initialize the database (create tables) before any page needs it.
            await _dbContext.EnsureInitializedAsync();
        }
    }
}