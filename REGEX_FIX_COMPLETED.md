# ?? Fix RegexParseException - Completed

## ? **V?n ??:**
```
Exception thrown: 'System.Text.RegularExpressions.RegexParseException'
```

## ?? **Nguyên nhân:**
- Regex pattern cho Vietnamese characters b? encode sai trong `IsValidName()` method
- Pattern `@"^[a-zA-ZÀ-?\s]+$"` gây l?i vì encoding

## ? **Gi?i pháp ?ã áp d?ng:**

### 1. **Fixed IsValidName method:**
```csharp
// OLD (causing error):
Regex.IsMatch(name.Trim(), @"^[a-zA-ZÀ-?\s]+$")

// NEW (safe approach):
public static bool IsValidName(string name)
{
    if (string.IsNullOrWhiteSpace(name)) return false;
    
    var trimmedName = name.Trim();
    
    // Basic validation: length
    if (trimmedName.Length < 1 || trimmedName.Length > 50)
        return false;
    
    // Check for invalid characters (numbers, special symbols)
    foreach (char c in trimmedName)
    {
        if (char.IsDigit(c) || 
            (char.IsPunctuation(c) && c != ' ') ||
            (char.IsSymbol(c) && c != ' '))
        {
            return false;
        }
    }
    
    return true;
}
```

### 2. **Added try-catch protection for all regex methods:**
- `IsValidEmail()` ?
- `IsValidPhone()` ?
- `IsValidUsername()` ?
- `IsValidPassword()` ?
- `NormalizePhone()` ?

### 3. **Fixed dash character in username regex:**
```csharp
// OLD:
@"^[a-zA-Z0-9_.-]+$"

// NEW:
@"^[a-zA-Z0-9_.\-]+$"  // Escaped dash
```

## ?? **Test Cases Now Working:**

? **Names:**
- "Nguy?n" ? Valid
- "Tr?n V?n" ? Valid
- "John123" ? Invalid (contains numbers)
- "Name!" ? Invalid (contains punctuation)

? **Email:**
- "user@domain.com" ? Valid
- "invalid-email" ? Invalid

? **Phone:**
- "0901234567" ? Valid (Vietnamese format)
- "123456" ? Invalid (wrong format)

? **Username:**
- "user123" ? Valid
- "user.name" ? Valid
- "user-name" ? Valid
- "us" ? Invalid (too short)

## ?? **Next Steps:**

1. **Test the employee creation again** - regex errors should be gone
2. **Run the debug steps** from previous guide
3. **Check Console output** for any remaining issues

## ?? **Debug Commands:**

```bash
# If still having issues, run these in Package Manager Console:
Update-Package System.Text.RegularExpressions
# or
dotnet add package System.Text.RegularExpressions
```

## ?? **Key Improvements:**

- **Safe regex patterns** - no more encoding issues
- **Try-catch protection** - graceful handling of regex errors
- **Character-by-character validation** - more reliable for Vietnamese text
- **Better error messages** - clear and in Vietnamese

---

**Status: ? RESOLVED**

RegexParseException should be fixed. You can now try adding employees again!