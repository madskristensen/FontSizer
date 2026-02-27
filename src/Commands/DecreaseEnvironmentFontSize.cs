using Community.VisualStudio.Toolkit;
using FontSizer.Options;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace FontSizer.Commands
{
    [Command(PackageIds.cmdidDecreaseEnviornmentFontSize)]
    internal sealed class DecreaseEnvironmentFontSize : BaseCommand<DecreaseEnvironmentFontSize>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            short step = VSPackage.Instance?.GetEnvironmentFontStep() ?? GeneralOptionsPage.DefaultEnvironmentFontStep;
            await Helper.AdjustFontSizeAsync(FontsAndColorsCategory.DialogsAndToolWindows, (short)-step);
        }
    }
}
