using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TacticWar.TW_Units
{
    //Объект (может быть нарисован на карте)
    interface CObject
    {
        /*int mId;
        string mName;
        int mIgrokId;
        int mHealth;*/

        void drawMe(Graphics grf, int left, int top);
    }
}
