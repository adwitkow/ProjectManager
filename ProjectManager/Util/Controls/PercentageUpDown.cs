using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager.Util.Controls
{
    class PercentageUpDown : NumericUpDown
    {
        protected override void UpdateEditText()
        {
            base.UpdateEditText();

            ChangingText = true;
            Text = (int)(this.Value * 100m) + "%";
        }
    }
}
