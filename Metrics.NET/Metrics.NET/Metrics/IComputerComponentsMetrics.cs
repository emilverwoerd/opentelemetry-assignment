namespace Metrics.NET.Metrics
{
    public interface IComputerComponentsMetrics
    {
        void AddOrderComplete(int orderId);

        void RecordOrderTotalComponents(int components);

        void AddComputerComponent();
    }
}
