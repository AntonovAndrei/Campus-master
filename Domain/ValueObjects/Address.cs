using Domain.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Domain.ValueObjects;

[Owned]
public class Address : ValueObject
{
    public Address(string country, string town, 
        string street, int house, int? corps = null)
    {
        Country = string.IsNullOrWhiteSpace(country) ? throw new ArgumentException(
            nameof(country) + " can't be empty") : country;
        Town = string.IsNullOrWhiteSpace(town) ? throw new ArgumentException(
            nameof(town) + " can't be empty") : town;
        Street = string.IsNullOrWhiteSpace(street) ? throw new ArgumentException(
            nameof(street) + " can't be empty") : street;
        House = house < 0 && house > 1000 ? throw new ArgumentException(
            nameof(house) + " can't be lees than 0 and more than 1000") : house;
        Corps = corps;
    }
    public string Country { get; set; }
    public string Town { get; set; }
    public string Street { get; set; }
    public int House { get; set; }
    public int? Corps { get; set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Country;
        yield return Town;
        yield return Street;
        yield return House;
        yield return Corps;
    }
}