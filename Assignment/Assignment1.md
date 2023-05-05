# Assigment 1

In this Assigment we are going to create a .NET WebApi which we are going to transform to use the open Telemetry metrics

The folder with assignments is there to guide you through the process.

## Step 1
First step is to add the necessary nuget Packages which are:

- OpenTelemetry.Extensions.Hosting 
- OpenTelemetry.Exporter.Console
- OpenTelemetry.Instrumentation.AspNetCore --prerelease
- OpenTelemetry.Instrumentation.Http --prerelease
- OpenTelemetry.Instrumentation.Runtime --prerelease

 
&nbsp;

To register opentelemetry in the application generate the following code in the program.cs

```cs
builder.Services.AddOpenTelemetry()
    .WithMetrics(builder => builder
        .AddConsoleExporter()
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddRuntimeInstrumentation());
```
So what do all these extension methods do?

- AddConsoleExporter
  - The console exporter writes the metrics to the console
- AddAspNetCoreInstrumentation
  - This will gather metrics for **incoming** http requests
- AddHttpClientInstrumentation
  - This will gather metrics for **outgoing** http requests
- AddRuntimeInstrumentation
  - This gives runtime information like the threadpool amount and for example the amount of exceptions being thrown.

With all this in place give it a shot to run the application. In the console you should see some great example of logging data.