using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalkUareU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EmployeeEntry em = new EmployeeEntry();
            em.Click +=  this.childControl_Click;

            flowLayoutPanel1.Controls.Add(em);
        }

        private void childControl_Click(object sender, EventArgs e)
        {
            EmployeeEntry em = (EmployeeEntry)sender;
            em.EmpName = "Rashid";           
        }

    }
}
