namespace TrueDialog.Model
{
    /// <summary>
    /// Describes how a member variable is passed on to the HTTP server.
    /// </summary>
    public enum MappingType
    {
        /// <summary>
        /// The parameter is a required part of the URL segment.
        /// </summary>
        UrlSegment,

        /// <summary>
        /// Parameter is an optional part of the URL segment.
        /// </summary>
        OptionalUrlSegment,

        /// <summary>
        /// Paramter is a GET value.
        /// </summary>
        Get,

        /// <summary>
        /// Paramter appears only in POST/PUT data.
        /// </summary>
        Post,
        
        /// <summary>
        /// Parameter can be set via GET or POST/PUT.
        /// </summary>
        GetOrPost,

        /// <summary>
        /// Parameter is passed in through via an HTTP cookie value.
        /// </summary>
        Cookie,

        /// <summary>
        /// Parameter is passed in through the HTTP header.
        /// </summary>
        Header
    }
}