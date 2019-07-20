using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MT.TacticWar.Core.Objects
{
    //Объект (может быть нарисован на карте)
    interface IObject
    {
        /*int mId;
        string mName;
        int mIgrokId;
        int mHealth;*/

        void drawMe(Graphics grf, int left, int top);
    }
}
