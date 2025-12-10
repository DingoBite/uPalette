using System;
using Object = UnityEngine.Object;

namespace uPalette.Runtime.Core.Synchronizer.UnityObject
{
    public sealed class UnityObjectSynchronizerAttribute : ValueSynchronizerAttribute
    {
        public UnityObjectSynchronizerAttribute(Type attachTargetType, string targetPropertyDisplayName)
            : base(typeof(Object), attachTargetType, targetPropertyDisplayName)
        {
        }
    }
}