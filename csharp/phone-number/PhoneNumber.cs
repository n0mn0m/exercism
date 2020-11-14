using System;
using System.Linq;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        string digits = string.Concat(phoneNumber.Where(char.IsDigit));
        
        if (digits.Length == 11 && digits.StartsWith('1'))
            digits = digits.Remove(0, 1);
        
        return digits.Length != 10 || digits.First() < '2' || digits[3] < '2' 
            ? throw new ArgumentException() 
            : digits;
    }
}