
using CSGenio.core.di;
using CSGenio.framework;
using GenioMVC.Metrics;
using Microsoft.Extensions.Logging;
using OpenTelemetry;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System;
using System.Diagnostics.Metrics;
using System.IO;


namespace GenioMVC;

/// <summary>
/// Webconfig Telemetry configuration section reader
/// </summary>
public class TelemetryConfigurationSection : System.Configuration.ConfigurationSection
{
    public enum LoggerConfigType
    {
        LOG4NET, // Default Value
        OTLP
    }

    [System.Configuration.ConfigurationProperty("LoggerType", IsRequired = false)]
    public LoggerConfigType LoggerType
    {
        get { return (LoggerConfigType)this["LoggerType"]; }
        set { this["LoggerType"] = value; }
    }
    [System.Configuration.ConfigurationProperty("CollectorAddress", IsRequired = false)]
    public string CollectorAddress
    {
        get { return (string)this["CollectorAddress"]; }
        set { this["CollectorAddress"] = value; }
    }
    [System.Configuration.ConfigurationProperty("EnableTracing", IsRequired = false)]
    public bool EnableTracing
    {
        get { return (bool)this["EnableTracing"]; }
        set { this["EnableTracing"] = value; }
    }
    [System.Configuration.ConfigurationProperty("EnableInternalMetrics", IsRequired = false)]
    public bool EnableInternalMetrics
    {
        get { return (bool)this["EnableInternalMetrics"]; }
        set { this["EnableInternalMetrics"] = value; }
    }
    [System.Configuration.ConfigurationProperty("CustomApplicationId", IsRequired = false)]
    public string CustomApplicationId
    {
        get { return (string)this["CustomApplicationId"]; }
        set { this["CustomApplicationId"] = value; }
    }
    [System.Configuration.ConfigurationProperty("CustomInstanceId", IsRequired = false)]
    public string CustomInstanceId
    {
        get { return (string)this["CustomInstanceId"]; }
        set { this["CustomInstanceId"] = value; }
    }
}

/// <summary>
/// Telemetry service for Asp.net
/// Holds all the providers necessary to interact with OpenTelemetry.
/// Handles disabled configurations with default empty providers.
/// </summary>
public class OpenTelemetryProvider : IDisposable
{
    private TracerProvider _tracerProvider;
    private MeterProvider _meterProvider;
    private ILoggerFactory _loggerProvider;
    private bool disposedValue;


    //public void ConfigureTelemetry(TelemetryConfigurationSection telemetryConfig=null)
    public static OpenTelemetryProvider Create(TelemetryConfigurationSection telemetryConfig = null)
    {
        OpenTelemetryProvider res = new();

        telemetryConfig ??= System.Configuration.ConfigurationManager.GetSection("openTelemetry") as TelemetryConfigurationSection;

        var serviceInstanceId = telemetryConfig?.CustomInstanceId;
        if (string.IsNullOrEmpty(serviceInstanceId))
            serviceInstanceId = Environment.GetEnvironmentVariable("TELEMETRY_CUSTOM_INSTANCE_ID");

        if (string.IsNullOrEmpty(serviceInstanceId))
        {
            //Persist the instanceId so its perserved between service restarts
            var ifile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "temp", "InstanceId.var");
            if (File.Exists(ifile))
            {
                serviceInstanceId = File.ReadAllText(ifile);
            }
            else
            {
                serviceInstanceId = Guid.NewGuid().ToString();
                File.WriteAllText(ifile, serviceInstanceId);
            }
        }

        //Setup the service naming conventions that will label the telemetry scopes
        var serviceName = ResourceBuilder.CreateDefault().AddService(
            !string.IsNullOrEmpty(telemetryConfig?.CustomApplicationId) ? telemetryConfig.CustomApplicationId : Configuration.Application.Id,
            Configuration.Program + "." + Configuration.Acronym,
            Configuration.GenAssemblyVersion,
            false,
            serviceInstanceId);

        // Configure Metrics
        res.ConfigureMetrics(telemetryConfig, serviceName);

        // Configure Logging
        res.ConfigureLogging(telemetryConfig, serviceName);

        // Configure Tracing
        res.ConfigureTracing(telemetryConfig, serviceName);

        return res;
    }


    private void ConfigureMetrics(TelemetryConfigurationSection telemetryConfig, ResourceBuilder serviceName)
    {
        if (telemetryConfig == null || string.IsNullOrEmpty(telemetryConfig.CollectorAddress))
        {
            GenioDI.MetricsOtlp = new MetricsOtlpImpl();
            return;
        }

        Meter mainMeter = new Meter("MainMeter");

        var builder = Sdk.CreateMeterProviderBuilder()
            .SetResourceBuilder(serviceName)
            .AddMeter(mainMeter.Name)
            .AddOtlpExporter(otlpOptions => {
                otlpOptions.Endpoint = new Uri(telemetryConfig.CollectorAddress + "/v1/metrics");
                otlpOptions.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.HttpProtobuf;
            });

        if (telemetryConfig.EnableInternalMetrics)
        {
            builder.AddAspNetInstrumentation();
            builder.AddProcessInstrumentation();
        }

        _meterProvider = builder.Build();

        GenioDI.MetricsOtlp = new MetricsOtlpImpl(mainMeter);
    }

    
    private void ConfigureLogging(TelemetryConfigurationSection telemetryConfig, ResourceBuilder serviceName)
    {
        if (telemetryConfig != null && telemetryConfig.LoggerType == TelemetryConfigurationSection.LoggerConfigType.OTLP)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddOpenTelemetry(options =>
                {
                    options.IncludeScopes = true;
                    options.SetResourceBuilder(serviceName);
                    options.AddOtlpExporter(otlpOptions =>
                    {
                        otlpOptions.Endpoint = new Uri(telemetryConfig.CollectorAddress + "/v1/logs");
                        otlpOptions.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.HttpProtobuf;
                    });
                });
            });

            GenioDI.Log = new OpenTelemetryImpl(loggerFactory);
        }
        else
        {
            log4net.Config.XmlConfigurator.Configure();
        }
    }


    private void ConfigureTracing(TelemetryConfigurationSection telemetryConfig, ResourceBuilder serviceName)
    {
        if (telemetryConfig == null || !telemetryConfig.EnableTracing) return;

        var builder = Sdk.CreateTracerProviderBuilder()
            .SetResourceBuilder(serviceName)
            .AddAspNetInstrumentation(options =>
            {
                options.EnrichWithHttpRequest = (activity, request) =>
                {
                    
                    foreach (var routeVal in request.RequestContext.RouteData.Values)
                        activity.SetTag($"http.route.{routeVal.Key}", routeVal.Value.ToString());
                    foreach (var queryVal in request.Params.AllKeys)
                        activity.SetTag($"http.query.{queryVal}", request.Params[queryVal].ToString());

                    activity.DisplayName = $"{request.HttpMethod} {request.Url.Scheme} {request .Path}";
                };
            })
            .AddOtlpExporter(otlpOptions => {
                otlpOptions.Endpoint = new Uri(telemetryConfig.CollectorAddress + "/v1/traces");
                otlpOptions.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.HttpProtobuf; 
            });

        _tracerProvider = builder.Build();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // dispose managed state (managed objects)
                _tracerProvider?.Dispose();
                _meterProvider?.Dispose();
                _loggerProvider?.Dispose();
            }

            // free unmanaged resources (unmanaged objects) and override finalizer
            // set large fields to null
            _tracerProvider = null;
            _meterProvider = null;
            _loggerProvider = null;
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
