using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Bai5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // wire up events
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.dataGridViewItems.CellValidating += DataGridViewItems_CellValidating;
            this.dataGridViewItems.CellEndEdit += DataGridViewItems_CellEndEdit;
            this.dataGridViewItems.CellValueChanged += DataGridViewItems_CellValueChanged;
            this.dataGridViewItems.RowsRemoved += DataGridViewItems_RowsChanged;
            this.dataGridViewItems.RowsAdded += DataGridViewItems_RowsChanged;
            this.dataGridViewItems.EditingControlShowing += DataGridViewItems_EditingControlShowing;
            this.timerClock.Tick += TimerClock_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // initialize status and start clock
            UpdateClock();
            timerClock.Start();

            // set some default values
            if (comboShipping.Items.Count > 0)
                comboShipping.SelectedIndex = 0;

            // format numeric columns
            colQuantity.ValueType = typeof(int);
            colWeight.ValueType = typeof(decimal);
            colUnitPrice.ValueType = typeof(decimal);
            colTotal.ValueType = typeof(decimal);

            UpdateTotals();
        }

        private void TimerClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            toolStripStatusTime.Text = "Thời gian: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void DataGridViewItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // ensure previous handlers removed
            e.Control.KeyPress -= EditingControl_KeyPress;
            e.Control.KeyPress += EditingControl_KeyPress;
        }

        private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allow digits, control, decimal point and minus only where appropriate
            var editingControl = sender as TextBox;
            if (editingControl == null) return;

            int colIndex = dataGridViewItems.CurrentCell.ColumnIndex;
            string colName = dataGridViewItems.Columns[colIndex].Name;

            if (colName == "colQuantity")
            {
                // integers only
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
            else if (colName == "colWeight" || colName == "colUnitPrice")
            {
                // allow digits, one decimal separator
                char dec = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != dec)
                    e.Handled = true;
                // prevent more than one decimal
                if (e.KeyChar == dec && editingControl.Text.Contains(dec))
                    e.Handled = true;
            }
        }

        private void DataGridViewItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var col = dataGridViewItems.Columns[e.ColumnIndex];
            var editingControl = dataGridViewItems.EditingControl;

            if (col.Name == "colQuantity")
            {
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out int qty))
                {
                    if (editingControl != null) errorProvider.SetError(editingControl, "Số lượng phải là số nguyên");
                }
                else if (qty <= 0)
                {
                    if (editingControl != null) errorProvider.SetError(editingControl, "Số lượng phải > 0");
                }
                else
                {
                    if (editingControl != null) errorProvider.SetError(editingControl, string.Empty);
                }
            }
            else if (col.Name == "colWeight")
            {
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal w))
                {
                    if (editingControl != null) errorProvider.SetError(editingControl, "Trọng lượng phải là số");
                }
                else if (w <= 0)
                {
                    if (editingControl != null) errorProvider.SetError(editingControl, "Trọng lượng phải > 0");
                }
                else
                {
                    if (editingControl != null) errorProvider.SetError(editingControl, string.Empty);
                }
            }
            else if (col.Name == "colUnitPrice")
            {
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal p))
                {
                    if (editingControl != null) errorProvider.SetError(editingControl, "Đơn giá phải là số");
                }
                else
                {
                    if (editingControl != null) errorProvider.SetError(editingControl, string.Empty);
                }
            }
        }

        private void DataGridViewItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // clear any editing control error
            var editingControl = dataGridViewItems.EditingControl;
            if (editingControl != null) errorProvider.SetError(editingControl, string.Empty);

            // recalc row and totals
            if (e.RowIndex >= 0)
            {
                UpdateRowTotal(dataGridViewItems.Rows[e.RowIndex]);
                UpdateTotals();
            }
        }

        private void DataGridViewItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdateRowTotal(dataGridViewItems.Rows[e.RowIndex]);
                UpdateTotals();
            }
        }

        private void DataGridViewItems_RowsChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void UpdateRowTotal(DataGridViewRow row)
        {
            if (row == null) return;
            try
            {
                var qtyCell = row.Cells["colQuantity"];
                var weightCell = row.Cells["colWeight"];
                var priceCell = row.Cells["colUnitPrice"];
                var totalCell = row.Cells["colTotal"];

                int qty = 0;
                decimal weight = 0m;
                decimal price = 0m;

                if (qtyCell.Value != null && int.TryParse(qtyCell.Value.ToString(), out int q)) qty = q;
                if (weightCell.Value != null && decimal.TryParse(weightCell.Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal w)) weight = w;
                if (priceCell.Value != null && decimal.TryParse(priceCell.Value.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal p)) price = p;

                decimal rowTotal = qty * price;
                totalCell.Value = rowTotal;
            }
            catch
            {
                // ignore malformed rows
            }
        }

        private void UpdateTotals()
        {
            int totalQty = 0;
            decimal totalWeight = 0m;
            decimal totalAmount = 0m;

            foreach (DataGridViewRow row in dataGridViewItems.Rows)
            {
                if (row.IsNewRow) continue;
                int qty = 0;
                decimal weight = 0m;
                decimal amount = 0m;

                var cQty = row.Cells["colQuantity"].Value;
                var cWeight = row.Cells["colWeight"].Value;
                var cTotal = row.Cells["colTotal"].Value;

                if (cQty != null && int.TryParse(cQty.ToString(), out int q)) qty = q;
                if (cWeight != null && decimal.TryParse(cWeight.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal w)) weight = w;
                if (cTotal != null && decimal.TryParse(cTotal.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal t)) amount = t;

                totalQty += qty;
                totalWeight += qty * weight; // weight per item * qty
                totalAmount += amount;
            }

            toolStripStatusTotalQty.Text = $"Total Qty: {totalQty}";
            toolStripStatusTotalWeight.Text = $"Total Weight: {totalWeight:N2} kg";
            toolStripStatusTotalAmount.Text = $"Total Amount: {totalAmount:N2}";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                // add new row and start editing first cell
                int idx = dataGridViewItems.Rows.Add();
                dataGridViewItems.CurrentCell = dataGridViewItems.Rows[idx].Cells[0];
                dataGridViewItems.BeginEdit(true);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (dataGridViewItems.Focused)
                {
                    foreach (DataGridViewRow r in dataGridViewItems.SelectedRows)
                    {
                        if (!r.IsNewRow)
                            dataGridViewItems.Rows.Remove(r);
                    }
                    UpdateTotals();
                    e.Handled = true;
                }
            }
        }
    }
}
