using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace UitslagControle.Services
{
    class Misc
    {
        public void PlusOne(TextBox box)
        {
            try
            {
                int i = Convert.ToInt32(box.Text);
                box.Text = (++i).ToString();
            }
            catch
            {
                box.Text = "0";
            }
        }

        public void MinOne(TextBox box)
        {
            try
            {
                int i = Convert.ToInt32(box.Text);
                box.Text = (--i).ToString();
                if (i < 0)
                {
                    box.Text = "0";
                }
            }
            catch
            {
                box.Text = "0";
            }
        }
    }
}
