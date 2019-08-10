using System;

namespace MT.TacticWar.UI.Editor
{
    class TreeViewNodeSelector
    {
        public Action Select { get; private set; }

        public TreeViewNodeSelector(Action select)
        {
            Select = select;
        }
    }
}
