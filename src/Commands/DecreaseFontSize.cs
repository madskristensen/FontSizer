using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace FontSizer.Commands
{
    internal sealed class DecreaseFontSize : FontSizeCommandBase
    {
        public static async Task InitializeAsync(AsyncPackage package)
        {
            IMenuCommandService commandService = await package.GetServiceAsync<IMenuCommandService, IMenuCommandService>();
            var menuCommandID = new CommandID(PackageGuids.guidIncreaseFontSizePackageCmdSet, PackageIds.cmdidDecreaseFontSize);
            var menuItem = new MenuCommand((s, e) => ExecuteAsync(package).ConfigureAwait(false), menuCommandID);
            commandService.AddCommand(menuItem);
        }

        private static async Task ExecuteAsync(AsyncPackage package)
        {
            await AdjustFontSizeAsync(package, new Guid(FontsAndColorsCategory.TextEditor), -2);
            await AdjustFontSizeAsync(package, new Guid(FontsAndColorsCategory.StatementCompletion), -1);
            await AdjustFontSizeAsync(package, new Guid(FontsAndColorsCategory.TextOutputToolWindows), -1);
            await AdjustFontSizeAsync(package, new Guid(FontsAndColorsCategory.Tooltip), -1);
            await AdjustFontSizeAsync(package, new Guid(CodeLensCategory), -1);
        }

    }
}
