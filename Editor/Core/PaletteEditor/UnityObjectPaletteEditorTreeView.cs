using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace uPalette.Editor.Core.PaletteEditor
{
    internal sealed class UnityObjectPaletteEditorTreeView : PaletteEditorTreeView<Object>
    {
        public UnityObjectPaletteEditorTreeView(TreeViewState state) : base(state)
        {
        }

        protected override Object DrawValueField(Rect rect, Object value)
        {
            return EditorGUI.ObjectField(rect, value, typeof(Object), false);
        }
    }
}