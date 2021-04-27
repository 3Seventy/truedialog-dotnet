namespace TrueDialog.Model
{
    /// <summary>
    /// Dictates the template's format.
    /// </summary>
    public enum EncodingType
    {
        /// <summary>
        /// All text is plain and should not be interpreted in anyway.
        /// </summary>
        Text    = 0,

        /// <summary>
        /// The text has Razor encodings in it.
        /// </summary>
        Razor   = 1
    }
}