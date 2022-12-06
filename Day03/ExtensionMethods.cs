namespace Day03;
public static class ExtensionMethods
{
    public static int MapPriority(this char value)
    {
        if (Char.IsLower(value)) return value - 'a' + 1;
        if (Char.IsUpper(value)) return value - 'A' + 27;
        return 0;
    }
}
