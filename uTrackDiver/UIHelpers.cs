using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uTrackDiver
{
    public static class UIHelpers
    {
        #region UI Invokers        

        public static void InvokeSetEnabledState(Control ctrl, bool enabled)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke((MethodInvoker)delegate { ctrl.Enabled = enabled; });
            else
                ctrl.Enabled = enabled;
        }

        public static void InvokeSetEnabledState(ToolStrip strip, ToolStripItem item, bool enabled)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { item.Enabled = enabled; });
            else
                item.Enabled = enabled;
        }

        public static void InvokeSetCheckedState(ToolStrip strip, ToolStripButton item, bool checkedState)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { item.Checked = checkedState; });
            else
                item.Checked = checkedState;
        }

        public static void InvokeSetText(Control ctrl, string text)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke((MethodInvoker)delegate { ctrl.Text = text; });
            else
                ctrl.Text = text;
        }

        public static void InvokeSetText(StatusStrip strip, ToolStripStatusLabel lbl, string text)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { lbl.Text = text; });
            else
                lbl.Text = text;
        }

        public static void InvokeSetText(StatusStrip strip, ToolStripStatusLabel lbl, string text, Color foreColor, Color backColor)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate
                {
                    lbl.Text = text;
                    lbl.BackColor = backColor;
                    lbl.ForeColor = foreColor;
                });
            else
            {
                lbl.Text = text;
                lbl.BackColor = backColor;
                lbl.ForeColor = foreColor;
            }
        }

        public static void InvokeSetVisible(Control ctrl, bool visible)
        {
            if (ctrl.InvokeRequired)
                ctrl.Invoke((MethodInvoker)delegate { ctrl.Visible = visible; });
            else
                ctrl.Visible = visible;
        }

        public static void InvokeSetVisible(ToolStrip strip, ToolStripItem item, bool visible)
        {
            if (strip.InvokeRequired)
                strip.Invoke((MethodInvoker)delegate { item.Visible = visible; });
            else
                item.Visible = visible;
        }

        #endregion

        public static void TrySetCbxItem(ComboBox cbx, string item)
        {
            int idx = cbx.Items.IndexOf(item);
            if (idx >= 0)
                cbx.SelectedIndex = idx;
        }

        public static void SetNumericEditValue(NumericUpDown nedit, double value)
        {
            decimal val = Convert.ToDecimal(value);
            if (val > nedit.Maximum) val = nedit.Maximum;
            if (val < nedit.Minimum) val = nedit.Minimum;
            nedit.Value = val;
        }
    }
}
