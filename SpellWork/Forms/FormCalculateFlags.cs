using System;
using System.Windows.Forms;

namespace SpellWork
{
    public partial class FormCalculateFlags : Form
    {
        public uint Flags { get; private set; }
 
        public FormCalculateFlags(Type data, uint value, string remove)
        {
            InitializeComponent();
            
            _clbCalcFlags.SetFlags(data, remove);
            _clbCalcFlags.SetCheckedItemFromFlag(value);

            Text = "Calculate " + data.Name;
        }

        private void _bOk_Click(object sender, EventArgs e)
        {
            Flags = _clbCalcFlags.GetFlagsValue();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void _bNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _clbCalcFlags_SelectedValueChanged(object sender, EventArgs e)
        {
            Flags = _clbCalcFlags.GetFlagsValue();
            _lFlagValue.Text = "Value: " + Flags;
        }
    }
}
