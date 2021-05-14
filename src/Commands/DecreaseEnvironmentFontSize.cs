using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace FontSizer.Commands
{
    internal sealed class DecreaseEnvironmentFontSize : BaseCommand<DecreaseEnvironmentFontSize>
    {
        public DecreaseEnvironmentFontSize() : base(PackageGuids.guidIncreaseFontSizePackageCmdSet, PackageIds.cmdidDecreaseEnvironmentFontSize)
        { }

        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await Helper.AdjustFontSizeAsync(FontsAndColorsCategory.DialogsAndToolWindows, -2);
        }
    }
}
