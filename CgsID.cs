public class CgsID
{
    public static int Compress(string input)
    {
        if (input.Length > 12)
        {
            throw new ArgumentException("String too long.");
        }

        int id = 0;
        for (int i = 0; i < 12; i++)
        {
            id *= 0x28;
            if (i >= input.Length)
            {
                continue;
            }
            int c = (int)input[i];
            if (c == 0x5F)
            {
                id += 0x27;
            }
            else if (c >= 0x61)
            {
                id += c - 0x54;
            }
            else if (c >= 0x41)
            {
                id += c - 0x34;
            }
            else if (c >= 0x30)
            {
                id += c - 0x2D;
            }
            else if (c == 0x2F)
            {
                id += 0x2;
            }
            else if (c == 0x2D)
            {
                id += 0x1;
            }
        }
        return id;
    }

    public static string Uncompress(int id)
    {
        char[] chars = new char[12];
        for (int i = 11; i >= 0; i--)
        {
            int c = id % 0x28;
            id /= 0x28;
            if (c == 0x27)
            {
                chars[i] = (char)0x5F;
            }
            else if (c >= 0xD)
            {
                chars[i] = (char)(c + 0x34);
            }
            else if (c >= 0x3)
            {
                chars[i] = (char)(c + 0x2D);
            }
            else if (c == 0x2)
            {
                chars[i] = (char)0x2F;
            }
            else if (c == 0x1)
            {
                chars[i] = (char)0x2D;
            }
            else if (c == 0x0)
            {
                chars[i] = (char)0x20;
            }
            else
            {
                chars[i] = (char)0x0;
            }
        }
        return new string(chars).TrimEnd(' ');
    }
}
