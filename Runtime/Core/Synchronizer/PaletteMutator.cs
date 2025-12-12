using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using uPalette.Runtime.Core.Model;

namespace uPalette.Runtime.Core.Synchronizer
{
    public enum PaletteMutateBehaviour
    {
        None,
        All,
        Active
    }

    public class PaletteMutator<TEntry, TValue> : MonoBehaviour where TEntry : EntryId
    {
        [SerializeField] private List<TEntry> _entries;
        [SerializeField] private PaletteMutateBehaviour _behaviour;
        
        private readonly List<Theme> _themes = new (1);

        public void Mutate(TValue value) => Mutate(value, _behaviour);
        
        public void Mutate(TValue value, PaletteMutateBehaviour behaviour)
        {
            if (behaviour is PaletteMutateBehaviour.None)
                return;
            if (PaletteStore.Instance.Palettes.FirstOrDefault(p => p is Palette<TValue>) is not Palette<TValue> palette)
                return;

            _themes.Clear();
            if (behaviour == PaletteMutateBehaviour.All)
                _themes.AddRange(palette.Themes.Values);
            else if (behaviour == PaletteMutateBehaviour.Active)
                _themes.Add(palette.ActiveTheme.Value);
            else
                throw new ArgumentOutOfRangeException();

            foreach (var entryId in _entries)
            {
                foreach (var (key, property) in palette.Entries[entryId.Value].Values)
                {
                    foreach (var theme in _themes)
                    {
                        if (key == theme.Id)
                            property.SetValueAndNotify(value);
                    }
                }   
            }
        }
    }
}