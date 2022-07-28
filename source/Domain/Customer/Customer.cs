namespace AlphaCentauri.Domain;

public sealed record Customer(long Id, string Name, DateTime Birthday)
{
    public long Id { get; private set; } = Id;

    public string Name { get; private set; } = Name;

    public DateTime Birthday { get; private set; } = Birthday;

    public void UpdateName(string name) => Name = name;
}
