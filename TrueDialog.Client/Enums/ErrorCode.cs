namespace TrueDialog.Model
{
    /// <summary>
    /// Specific error code to return to the caller when there is an issue.
    /// </summary>
    public enum ErrorCode
    {
        #region Internal Logic Errors
        /*
         * The first block of 256 values (0x00000000 - 0x000000FF) are reserved for these types of errors.
         */

        /// <summary>
        /// There was some sort of unknown error.
        /// </summary>
        UnknownError = 0x00000000,

        /// <summary>
        /// The error code was not set on this validation error.
        /// </summary>
        UnsetErrorCode = 0x00000001,

        #endregion

        #region Object Level Error Codes
        /*
         * These errors details issues on a single object.  (E.g.: object not found, etc)
         * 
         * The block of numbers from 256 to 4095 (0x00000100 - 0x00000FFF) are reserved for these types of errors.
         */

        /// <summary>
        /// The user does not have access to the object specified
        /// </summary>
        Forbidden = 403, // Set to match HTTP status code

        /// <summary>
        /// The object was not found
        /// </summary>
        ObjectNotFound = 404, // Set to match HTTP status code

        #endregion

        #region Property Error Codes
        /*
         * These errors represent issues with submitted property values.  (E.g.: invalid email format, etc)
         * 
         * The block of numbers from 4096 and up are for these types of errors.
         */

        #region Generic Property Errors
        /*
         * These errors can be combined with specific errors to provide some additional details for trying to hunt for a proper response to send to the
         * user or to allow for customer code to react to the issue in some generic but known way.
         * 
         * We reserve the upper byte of the 32-bit integer space for thes errors: 0x01000000 - 0xFF000000.
         */

        /// <summary>
        /// The supplied value cannot be reused
        /// </summary>
        PropertyAlreadyInUse = 0x01000000,

        /// <summary>
        /// The property is required and cannot be left blank.
        /// </summary>
        PropertyRequired = 0x02000000,

        /// <summary>
        /// The property exceeds some maximum.
        /// </summary>
        PropertyTooLarge = 0x03000000,

        /// <summary>
        /// THe property exceeds some minimum.
        /// </summary>
        PropertyTooSmall = 0x04000000,

        /// <summary>
        /// The value of the property is out of range of a specific limit.
        /// </summary>
        PropertyOutOfRange = 0x05000000,

        /// <summary>
        /// The value for the property is invalid.  (E.g.: Invalid email address)
        /// </summary>
        PropertyInvalidValue = 0x06000000,

        #endregion

        #region Specific Errors

        /*
         * For errors that are very specific that cannot be expressed with the generic errors above.
         * 
         * The reserved range is from 0x00001000 - 0x00FFFFFF
         */

        #endregion

        #endregion
    }
}