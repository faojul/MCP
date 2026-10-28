namespace OrderMcpServer.Service;

public sealed class OrderService
{
    private static readonly Dictionary<string, string> Orders =
        new(StringComparer.OrdinalIgnoreCase)
        {
            ["ORD-1001"] = "Shipped",
            ["ORD-1002"] = "Processing",
            ["ORD-1003"] = "Delivered"
        };

    public string GetOrderStatus(string orderId)
    {
        return Orders.TryGetValue(orderId, out var status)
            ? $"Order {orderId} status: {status}"
            : $"Order {orderId} was not found.";
    }
}