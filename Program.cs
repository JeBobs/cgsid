public class Program
{
    public static void Main()
    {
        Console.Write("[c]ompress [u]ncompress ? ");
        string? action = Console.ReadLine();

        if (string.IsNullOrEmpty(action))
        {
            Console.WriteLine("No action provided!");
            return;
        }

        switch (action.ToLower())
        {
            case "c":
                Console.Write("String: ");
                string? inputString = Console.ReadLine();
                try
                {
                    int compressedId = CgsID.Compress(inputString);
                    Console.WriteLine($"{compressedId:X16}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                break;

            case "u":
                Console.Write("ID: ");
                string? inputId = Console.ReadLine();
                try
                {
                    int id = Convert.ToInt32(inputId, 16);
                    string uncompressedString = CgsID.Uncompress(id);
                    Console.WriteLine(uncompressedString);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid ID format!");
                }
                break;

            default:
                Console.WriteLine("Unknown option!");
                break;
        }

        Console.ReadKey();
    }
}