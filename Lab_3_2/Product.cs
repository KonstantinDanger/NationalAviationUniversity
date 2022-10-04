public class Product : IComparable
{
    public string Name { get; private set; }
    public int Code { get; private set; }
    public DateTime ProductionDate { get; private set; }
    public DateTime ExpirationDate { get; private set; }

    public Product()
    {
        Name = default;
        Code = 0;
        ProductionDate = default;
        ExpirationDate = default;
    }

    public Product(string name, int code, DateTime productionDate, DateTime expirationDate)
    {
        Name = name;
        Code = code;
        ProductionDate = productionDate;
        ExpirationDate = expirationDate;
    }

    public bool CanBeUsed()
    {
        return !IsExpired();
    }

    public bool IsExpired()
    {
        return DateTime.Now > ExpirationDate;
    }

    public override string ToString()
    {
        return String.Format($"product name: {Name} | Code: {Code} | Production date: {ProductionDate} | Expiration date: {ExpirationDate}");
    }

    public int CompareTo(object? obj)
    {
        return (obj as Product)?.Code.CompareTo(this.Code) ?? -1;
    }
}
