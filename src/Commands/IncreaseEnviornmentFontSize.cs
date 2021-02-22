using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace FontSizer.Commands
{
    internal sealed class IncreaseEnviornmentFontSize : FontSizeCommandBase
    {
        public static async Task InitializeAsync(AsyncPackage package)
        {
            IMenuCommandService commandService = await package.GetServiceAsync<IMenuCommandService, IMenuCommandService>();
            var menuCommandID = new CommandID(PackageGuids.guidIncreaseFontSizePackageCmdSet, PackageIds.cmdidIncreaseEnviornmentFontSize);
            var menuItem = new MenuCommand((s, e) => ExecuteAsync(package).ConfigureAwait(false), menuCommandID);
            commandService.AddCommand(menuItem);
        }

        private static async Task ExecuteAsync(AsyncPackage package)
        {
            await AdjustFontSizeAsync(package, new Guid(FontsAndColorsCategory.DialogsAndToolWindows), 2);
        }
    }
}
