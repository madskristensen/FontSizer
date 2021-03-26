using System;
using Community.VisualStudio.Toolkit;
using Microsoft;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Task = System.Threading.Tasks.Task;

namespace FontSizer.Commands
{
    internal static class Helper
    {
        public const string CodeLensCategory = "{FC88969A-CBED-4940-8F48-142A503E2381}";

        public static async Task AdjustFontSizeAsync(string categoryGuid, short change)
        {
            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            IVsFontAndColorStorage storage = await VS.Shell.GetFontAndColorStorageAsync();
            Assumes.Present(storage);
            // ReSharper disable once SuspiciousTypeConversion.Global
            var utilities = storage as IVsFontAndColorUtilities;
            if (utilities == null)
            {
                return;
            }

            var pLOGFONT = new LOGFONTW[1];
            var pInfo = new FontInfo[1];
            var category = new Guid(categoryGuid);

            ErrorHandler.ThrowOnFailure(storage.OpenCategory(category, (uint)(__FCSTORAGEFLAGS.FCSF_LOADDEFAULTS | __FCSTORAGEFLAGS.FCSF_PROPAGATECHANGES)));
            try
            {
                if (!ErrorHandler.Succeeded(storage.GetFont(pLOGFONT, pInfo)))
                {
                    return;
                }

                pInfo[0].wPointSize = checked((ushort)(pInfo[0].wPointSize + change));
                ErrorHandler.ThrowOnFailure(storage.SetFont(pInfo));
                ErrorHandler.ThrowOnFailure(utilities.FreeFontInfo(pInfo));
            }
            finally
            {
                storage.CloseCategory();
            }
        }

    }
}
