namespace TrueDialog.Model
{
    /// <summary>
    /// Constant defines for question types
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// Question accepts yes/no responses.
        /// </summary>
        /// <remarks>
        /// A.K.A. boolean question type
        /// </remarks>
        YesNo = 1,
        
        /// <summary>
        /// Question has multiple choices
        /// </summary>
        MultipleChoice = 2,
        
        /// <summary>
        /// Question accepts any answer format.
        /// </summary>
        /// <remarks>
        /// Note that STOP is always handled by the stop processor, so that value will
        /// not get handled by an open response question.
        /// </remarks>
        OpenResponse = 3,
    }
}
