using System.Text.RegularExpressions;

namespace Domain.Common;

public record Email
{
  public string Value { get; }

  public Email(string value)
  {
    if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
      throw new ArgumentException("Invalid email format");

    Value = value;
  }

  public override string ToString() => Value;
}
