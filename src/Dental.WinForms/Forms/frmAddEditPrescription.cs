using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dental.WinForms.Forms
{
    public partial class frmAddEditPrescription : Form
    {
        public frmAddEditPrescription()
        {
            InitializeComponent();
        }

        public frmAddEditPrescription(int visitId) : this()
        {

        }
    }
}
