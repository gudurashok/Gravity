using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Scalable.Win.Forms;

namespace Gravity.Root.Forms
{
    public partial class FUserFeedback : FFormBase
    {
        public FUserFeedback()
        {
            InitializeComponent();
        }

        private void uUserFeedback_CloseForm(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
