using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp_D2D
{
    class SubWindow1Presenter : ISubWindowPresenter
    {
        private readonly Form myForm;

        public SubWindow1Presenter(Form form)
        {
            myForm = form;
        }


        public void Show()
        {
            myForm.Show();
        }
    }
}
