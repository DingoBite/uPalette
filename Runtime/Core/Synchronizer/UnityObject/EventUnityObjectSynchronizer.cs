using UnityEngine;
using UnityEngine.Events;

namespace uPalette.Runtime.Core.Synchronizer.UnityObject
{
    [UnityObjectSynchronizer(typeof(EventUnityObjectSynchronizer), "Link")]
    public class EventUnityObjectSynchronizer : UnityObjectSynchronizer
    {
        [SerializeField] private UnityEvent<Object> _event;

        private Object _value;

        public override Object GetValue() => _value;

        public override void SetValue(Object value)
        {
            _value = value;
            _event?.Invoke(value);
        }
    }
}