using System;
using UnityEditor.IMGUI.Controls;
using TreeViewState = UnityEditor.IMGUI.Controls.TreeViewState<int>;
using Object = UnityEngine.Object;

namespace uPalette.Editor.Core.PaletteEditor
{
    [Serializable]
    internal sealed class UnityObjectPaletteEditorWindowContentsView : PaletteEditorWindowContentsView<Object>
    {
        protected override PaletteEditorTreeView<Object> CreateTreeView(TreeViewState state)
        {
            return new UnityObjectPaletteEditorTreeView(state);
        }
    }
}