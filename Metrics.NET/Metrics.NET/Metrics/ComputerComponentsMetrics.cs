using System.Diagnostics.Metrics;
using Metrics.NET.Metrics.Config;

namespace Metrics.NET.Metrics;

public class ComputerComponentsMetrics : IComputerComponentsMetrics
{
    private readonly Meter _meter;

    private Counter<int> _totalOrdersCounter { get; }
    private Histogram<int> _componentsPerOrderHistogram;
    private ObservableGauge<int> _totalComputerComponents { get; }
    private int _totalComponents = 0;

    public ComputerComponentsMetrics()
    {
        _meter = new(DiagnosticsConfig.ComputerComponentsMeterName);
    }

    public void AddOrderComplete(int orderId) => _totalOrdersCounter.Add(1, KeyValuePair.Create<string, object?>("OrderId", orderId));

    public void RecordOrderTotalComponents(int components) => _componentsPerOrderHistogram.Record(components);

    public void AddComputerComponent() => _totalComponents++;

}
