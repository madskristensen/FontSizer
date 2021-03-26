using System;
using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace FontSizer.Commands
{
    internal sealed class DecreaseFontSize : BaseCommand<DecreaseFontSize>
    {
        public DecreaseFontSize() : base(PackageGuids.guidIncreaseFontSizePackageCmdSet, PackageIds.cmdidDecreaseFontSize)
        { }

        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await Helper.AdjustFontSizeAsync(Package, new Guid(FontsAndColorsCategory.TextEditor), -2);
            await Helper.AdjustFontSizeAsync(Package, new Guid(FontsAndColorsCategory.StatementCompletion), -1);
            await Helper.AdjustFontSizeAsync(Package, new Guid(FontsAndColorsCategory.TextOutputToolWindows), -1);
            await Helper.AdjustFontSizeAsync(Package, new Guid(FontsAndColorsCategory.Tooltip), -1);
            await Helper.AdjustFontSizeAsync(Package, new Guid(Helper.CodeLensCategory), -1);
        }
    }
}
