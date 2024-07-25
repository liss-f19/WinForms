using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    //https://www.youtube.com/watch?v=yNXJ63D7ZDc&ab_channel=DiscoTech
    public class DoubleClickCustomButton : Button
    {
        public DoubleClickCustomButton()
        {
            this.SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
    }
}

