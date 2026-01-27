using Silksong.ModMenu.Elements;
using Silksong.ModMenu.Plugin;

namespace Benchwarp
{
    public partial class BenchwarpPlugin : IModMenuCustomElement
    {
        internal TextButton? ModMenuEntryButton { get; private set; }

        SelectableElement IModMenuCustomElement.BuildCustomElement()
        {
            new ConfigEntryFactory().GenerateEntryButton("Benchwarp", this, out SelectableElement? sel);
            ModMenuEntryButton = (TextButton?)sel;
            return sel!;
        }

        string IModMenuInterface.ModMenuName()
        {
            return "Benchwarp";
        }
    }
}
