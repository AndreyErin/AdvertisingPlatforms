namespace AdvertisingPlatforms.DAL.Const
{
    /// <summary>
    /// Constants for working with files.
    /// </summary>
    public static class FileConstants
    {
        public const string Splitter = ":";
        public const string RowsSplitter = "\r\n";
        public const string RowPattern = @"^[А-Яа-я.\- ]+:[A-Za-z,\/]+$";
        public const string EntitiesSplitter = ",";
    }
}
