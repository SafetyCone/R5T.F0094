using System;


namespace R5T.F0094
{
    public class CodeFileOperations : ICodeFileOperations
    {
        #region Infrastructure

        public static ICodeFileOperations Instance { get; } = new CodeFileOperations();


        private CodeFileOperations()
        {
        }

        #endregion
    }
}
