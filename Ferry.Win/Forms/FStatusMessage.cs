using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferry.Win.Forms
{
    public partial class FStatusMessage : Form
    {
        public FStatusMessage()
        {
            InitializeComponent();
        }

        public void SetStatusMessage(string message)
        {
            lblMessage.Text = message;
        }
    }
}
