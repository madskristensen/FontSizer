using System;
using System.Runtime.InteropServices;
using System.Threading;
using FontSizer.Commands;
using FontSizer.Options;
using Microsoft.VisualStudio.Shell;
using Task = System.Threading.Tasks.Task;

namespace FontSizer
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideOptionPage(typeof(GeneralOptionsPage), "Font Sizer", "General", 0, 0, true)]
    [Guid(PackageGuids.guidIncreaseFontSizePackageString)]
    public sealed class VSPackage : AsyncPackage
    {
        internal static VSPackage Instance { get; private set; }

        internal short GetEnvironmentFontStep()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            var options = (GeneralOptionsPage)GetDialogPage(typeof(GeneralOptionsPage));
            return options?.EnvironmentFontStep ?? GeneralOptionsPage.DefaultEnvironmentFontStep;
        }

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            Instance = this;

            await IncreaseFontSize.InitializeAsync(this);
            await DecreaseFontSize.InitializeAsync(this);
            await IncreaseEnvironmentFontSize.InitializeAsync(this);
            await DecreaseEnvironmentFontSize.InitializeAsync(this);
        }
    }
}
