namespace Domain.Enums;


public enum Gender
{
    Male,
    Female
}
// public sealed class Gender : SmartEnum<Gender>
// {
//     public static readonly Gender Male = new Gender("m", 1);
//     public static readonly Gender Female = new Gender("f", 2);
//
//     private Gender(string name, int value) : base(name, value)
//     {
//     }
// }