namespace BookingService.Maui.Provider
{
    public static class ServiceProvider
    {
        public static IServiceProvider Services { get; private set; } = null!;

        public static void Initialize(IServiceProvider serviceProvider) =>
            Services = serviceProvider;

        public static T GetService<T>() where T : class => Services.GetService<T>()!;
    }
}
