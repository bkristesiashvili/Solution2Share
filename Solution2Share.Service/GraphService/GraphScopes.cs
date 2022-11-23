namespace Solution2Share.Service;

public static class GraphScopes
{
    #region STATIC FIELDS

    public readonly static string[] Scopes =
    {
        "User.Read",
        "Organization.Read.All",
        "Directory.Read.All",
        "MailboxSettings.Read",
        "Calendars.ReadWrite"
    };

    #endregion
}
