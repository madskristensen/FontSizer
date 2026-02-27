using System.ComponentModel;
using Microsoft.VisualStudio.Shell;

namespace FontSizer.Options
{
    public class GeneralOptionsPage : DialogPage
    {
        public const short MinEnvironmentFontStep = 1;
        public const short MaxEnvironmentFontStep = 10;
        public const short DefaultEnvironmentFontStep = 2;

        private short _environmentFontStep = DefaultEnvironmentFontStep;

        [Category("Environment")]
        [DisplayName("Environment font step")]
        [Description("Point-size delta used by the environment increase/decrease commands.")]
        public short EnvironmentFontStep
        {
            get => _environmentFontStep;
            set => _environmentFontStep = Clamp(value);
        }

        protected override void OnApply(PageApplyEventArgs e)
        {
            _environmentFontStep = Clamp(_environmentFontStep);
            base.OnApply(e);
        }

        private static short Clamp(short value)
        {
            if (value < MinEnvironmentFontStep)
            {
                return MinEnvironmentFontStep;
            }

            if (value > MaxEnvironmentFontStep)
            {
                return MaxEnvironmentFontStep;
            }

            return value;
        }
    }
}
