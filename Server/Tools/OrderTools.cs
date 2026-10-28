using System.ComponentModel;
using ModelContextProtocol.Server;
using OrderMcpServer.Service;

namespace OrderMcpServer.Tools;

[McpServerToolType]
public static class OrderTools
{
    [McpServerTool]
    [Description("Retrieves the current status of an order by its ID.")]
    public static string GetOrderStatus(
        [Description("The order ID, such as ORD-1001")]
        string orderId,
        OrderService orderService)
    {
        return orderService.GetOrderStatus(orderId);
    }
}