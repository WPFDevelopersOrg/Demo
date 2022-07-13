namespace MauiDesignControl;

// All the code in this file is included in all platforms.
public static class AppHostExtesions
{
    public static MauiAppBuilder ConfigureCustomControls(this MauiAppBuilder builder, bool useCompatibilityRenderers = false)
    {
        builder
            .ConfigureMauiHandlers(handlers =>
            {
                 handlers.AddLibraryHandlers();
            });

        return builder;
    }

    public static IMauiHandlersCollection AddLibraryHandlers(this IMauiHandlersCollection handlers)
    {
        //handlers.AddTransient(typeof(CustomCheckBox), h => new CustomCheckBoxHandler());

        return handlers;
    }
}
