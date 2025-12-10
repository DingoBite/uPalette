using UnityEngine;
using uPalette.Runtime.Core.Model;
using Object = UnityEngine.Object;

namespace uPalette.Runtime.Core.Synchronizer.UnityObject
{
    public abstract class UnityObjectSynchronizer : ValueSynchronizer<Object>
    {
        [SerializeField] private UnityObjectEntryId _entryId = new UnityObjectEntryId();

        public override EntryId EntryId => _entryId;
        
        public override Palette<Object> GetPalette(PaletteStore store)
        {
            return store.UnityObjectPalette;
        }
    }

    public abstract class UnityObjectSynchronizer<T> : UnityObjectSynchronizer where T : Component
    {
        [SerializeField] [HideInInspector] private T _component;

        protected T Component
        {
            get
            {
                if (_component == null)
                {
                    _component = GetComponent<T>();
                }

                return _component;
            }
        }
    }
}