using System.ComponentModel;

namespace Dental.WinForms.UserControls
{
    public partial class ctrlNotification : UserControl
    {
        public ctrlNotification()
        {
            InitializeComponent();
        }

        [DefaultValue(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool NumberVisible
        {
            get => lblNumber.Visible;
            set => lblNumber.Visible = value;
        }

        [DefaultValue("0")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string NumberText
        {
            get => lblNumber.Text;
            set => lblNumber.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color NumberForeColor
        {
            get => lblNumber.ForeColor;
            set => lblNumber.ForeColor = value;
        }
    }
}
