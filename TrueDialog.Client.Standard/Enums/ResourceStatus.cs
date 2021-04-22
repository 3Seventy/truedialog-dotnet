namespace TrueDialog.Model
{
    /// <summary>
    /// The status of a resource.
    /// </summary>
    public enum ResourceStatus
    {
        /// <summary>
        /// The resource is fully active and can be used per normal.
        /// </summary>
        Active = 0,

        /// <summary>
        /// The resource is no longer active and can no longer be used.
        /// </summary>
        Inactive = 1,

        /// <summary>
        /// The resource has been deleted and cannot be used.
        /// </summary>
        Deleted = 2
    }
}