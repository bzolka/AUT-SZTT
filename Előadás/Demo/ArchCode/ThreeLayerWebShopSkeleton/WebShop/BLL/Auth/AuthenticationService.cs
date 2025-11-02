namespace WebShop.BLL.Auth;

public class AuthenticationService
{
    // Very simple username->ID mapping using a stable hash code.
    public int GetUserId(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName)) return 0;
        // Deterministic hash to positive int in a small range for demo.
        unchecked
        {
            int hash = 23;
            foreach (var ch in userName.Trim().ToLowerInvariant())
            {
                hash = hash * 31 + ch;
            }
            return Math.Abs(hash % 10000) + 1; //1..10000
        }
    }
}
