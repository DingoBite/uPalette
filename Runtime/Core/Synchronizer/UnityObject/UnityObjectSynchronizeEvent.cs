using UnityEngine;
using uPalette.Runtime.Core.Model;

namespace uPalette.Runtime.Core.Synchronizer.UnityObject
{
    public sealed class UnityObjectSynchronizeEvent : ValueSynchronizeEvent<Object>
    {
        [SerializeField] private UnityObjectEntryId _entryId = new UnityObjectEntryId();

        public override EntryId EntryId => _entryId;
        public override Palette<Object> GetPalette(PaletteStore store)
        {
            return store.UnityObjectPalette;
        }
    }
}