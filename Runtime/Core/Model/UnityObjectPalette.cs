using System;
using Object = UnityEngine.Object;

namespace uPalette.Runtime.Core.Model
{
    [Serializable]
    public class UnityObjectPalette : Palette<Object>
    {
        protected override Object GetDefaultValue()
        {
            return new Object();
        }
    }
}