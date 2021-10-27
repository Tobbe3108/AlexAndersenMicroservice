namespace Delivery.Microservice.Models;

public record Delivery(string? PackageId, int? OrderId = null, string? CustomerName = null, string? CustomerAddress = null, string? OrderDeliveryAddress = null, string? OriginAddress = null, DateTime? DeliveryTime = null)
{
}