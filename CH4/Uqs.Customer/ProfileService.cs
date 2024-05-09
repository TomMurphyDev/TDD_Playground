
using System.Text.RegularExpressions;

namespace Uqs.Customer;

public partial class ProfileService
{
    public void ChangeUserName(string username)
    {
        ArgumentNullException.ThrowIfNull(username);

        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentOutOfRangeException(nameof(username), "Length");
        }

        if (username.Length is < 8 or > 12)
        {
            throw new ArgumentOutOfRangeException(nameof(username), "Length");
        }

        if (!MyRegex().Match(username).Success)
        {
            throw new ArgumentOutOfRangeException(nameof(username),
            "InvalidChar");
        }
    }

    [GeneratedRegex(@"^[a-zA-Z0-9_]+$")]
    private static partial Regex MyRegex();
}
