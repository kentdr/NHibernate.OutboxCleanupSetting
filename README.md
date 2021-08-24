# NHibernate.OutboxCleanupSetting
Example application for turning off NServiceBus.NHibernate outbox auto cleanup in a .NET Core 2.2 Web project.

## Things to Note
- The project targets .NET Core 2.2
- The project has a reference to the `System.Configuration.ConfigurationManager` Nuget package.  This is required for `ConfigurationManager` to work properly.
- The app.config file was manually created and the `NServiceBus/Outbox/NHibernate/FrequencyToRunDeduplicationDataCleanup` setting was added to the `appSettings` section
- The build action for app.config is set to *Content* and *Copy if newer*
- Endpoint configuration code is in `NServiceBusEndpoint.cs`

The outbox cleanup process was properly disabled when running IISExpress from Visual Studio. I also published to a folder and ran it manually using the `dotnet` CLI.
