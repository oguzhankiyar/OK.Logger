# OK.Logger


A Simple Logger for .Net Standard

## Setup

Setup for MVC Application

```c#
using OK.Logger;
using OK.Logger.SqlServer;

...

public void ConfigureServices(IServiceCollection services)
{
    services.UseOKLogger((config) =>
    {
        config.UseSqlServer("Server=OKCOMPUTER;Database=OK.Logger;Trusted_Connection=True;MultipleActiveResultSets=True;")
              .EnableInternalLog("C:\\oklogger-internal.txt");
    });
}
```

Setup for Console Application

```c#
using OK.Logger;
using OK.Logger.SqlServer;

...

private static ILogger logger = Logger.New((config) =>
{
    config.UseSqlServer("Server=OKCOMPUTER;Database=OK.Logger;Trusted_Connection=True;MultipleActiveResultSets=True;")
          .EnableInternalLog("C:\\oklogger-internal.txt");
});
```

## Usage

Log with data

```c#
logger.Add("Sample log with data", new { SampleProperty = "Sample Property Value" });
```

Log without data

```c#
logger.Add("Sample log without data");
```