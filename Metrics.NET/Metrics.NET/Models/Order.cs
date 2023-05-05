namespace Metrics.NET.Models;

public class Order
{
    public int Id { get; set; }

    public List<ComputerComponent> Items { get; set; } = new();
}
