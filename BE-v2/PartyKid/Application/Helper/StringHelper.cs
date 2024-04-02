using System.Text;

namespace PartyKid;

public static class StringHelper
{
    public static string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }

        return lowerCase ? builder.ToString().ToLower() : builder.ToString();
    }

    public static string RandomPassword()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(NumberHelper.RandomNumber(0, 9));
        builder.Append(RandomString(1, true));
        builder.Append(NumberHelper.RandomNumber(1000, 9999));
        builder.Append(RandomString(1, false));
        builder.Append("!");
        return builder.ToString();
    }
}
