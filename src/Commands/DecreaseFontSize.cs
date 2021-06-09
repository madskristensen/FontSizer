using Community.VisualStudio.Toolkit;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace FontSizer.Commands
{
    [Command(PackageIds.cmdidDecreaseFontSize)]
    internal sealed class DecreaseFontSize : BaseCommand<DecreaseFontSize>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await Helper.AdjustFontSizeAsync(FontsAndColorsCategory.TextEditor, -2);
            await Helper.AdjustFontSizeAsync(FontsAndColorsCategory.StatementCompletion, -1);
            await Helper.AdjustFontSizeAsync(FontsAndColorsCategory.TextOutputToolWindows, -1);
            await Helper.AdjustFontSizeAsync(FontsAndColorsCategory.Tooltip, -1);
            await Helper.AdjustFontSizeAsync(Helper.CodeLensCategory, -1);
        }
    }
}
