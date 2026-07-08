namespace OnlineShop.Infra.Command.Common.Outbox;

public class OutboxMessage
{
    public Guid Id { get; set; }

    public DateTime OccurredOn { get; set; }

    public string Type { get; set; } = string.Empty;

    public string Payload { get; set; } = string.Empty;

    public DateTime? ProcessedOn { get; set; }

    public string? Error { get; set; }
}