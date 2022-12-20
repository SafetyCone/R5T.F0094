using System;
using System.Threading.Tasks;

using R5T.T0132;
using R5T.T0153.N000;


namespace R5T.F0094
{
    [FunctionalityMarker]
    public partial interface ICodeFileOperations : IFunctionalityMarker
    {
        public async Task<WinFormContext> CreateWinForm(
            string projectFilePath,
            string formName)
        {
            var winFormContext = F0089.WinFormContextOperations.Instance.GetWinFormContext(
                projectFilePath,
                formName);

            await this.CreateWinForm(winFormContext);

            return winFormContext;
        }

        public async Task CreateWinForm(
            WinFormContext winFormContext)
        {
            // Safety checks.
            F0000.FileSystemOperator.Instance.VerifyFileDoesNotExists(winFormContext.CodeFilePath);
            F0000.FileSystemOperator.Instance.VerifyFileDoesNotExists(winFormContext.DesignerFilePath);

            // Run.
            await CodeFileGenerationOperations.Instance.CreateFormClassCodeFile(
                winFormContext.CodeFilePath,
                winFormContext.NamespaceName,
                winFormContext.Name);

            await CodeFileGenerationOperations.Instance.CreateFormDesignerCodeFile(
                winFormContext.DesignerFilePath,
                winFormContext.NamespaceName,
                winFormContext.Name);

            CodeFileGenerationOperations.Instance.CreateWinFormsResxTemplate(
                winFormContext.ResxFilePath);
        }
    }
}
