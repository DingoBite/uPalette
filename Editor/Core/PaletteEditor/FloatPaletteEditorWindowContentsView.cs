using System;
using UnityEditor.IMGUI.Controls;
using TreeViewState = UnityEditor.IMGUI.Controls.TreeViewState<int>;
using uPalette.Runtime.Foundation.CharacterStyles;

namespace uPalette.Editor.Core.PaletteEditor
{
    [Serializable]
    internal sealed class FloatPaletteEditorWindowContentsView : PaletteEditorWindowContentsView<float>
    {
        protected override PaletteEditorTreeView<float> CreateTreeView(TreeViewState state)
        {
            return new FloatPaletteEditorTreeView(state);
        }
    }
    
}
