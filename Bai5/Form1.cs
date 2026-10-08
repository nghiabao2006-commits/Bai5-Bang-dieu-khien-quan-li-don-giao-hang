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
            UpdateClock();
            timerClock.Start();

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
            e.Control.KeyPress -= EditingControl_KeyPress;
            e.Control.KeyPress += EditingControl_KeyPress;

            e.Control.TextChanged -= EditingControl_TextChanged;
            e.Control.TextChanged += EditingControl_TextChanged;
            try
            {
                errorProvider.SetIconAlignment((Control)e.Control, ErrorIconAlignment.MiddleRight);
                errorProvider.SetIconPadding((Control)e.Control, 2);
            }
            catch { }
        }

        private void EditingControl_TextChanged(object sender, EventArgs e)
        {
            var editingControl = sender as TextBox;
            if (editingControl == null) return;

            int colIndex = dataGridViewItems.CurrentCell.ColumnIndex;
            string colName = dataGridViewItems.Columns[colIndex].Name;
            var cell = dataGridViewItems.CurrentCell;

            string text = editingControl.Text;
            string message = string.Empty;

            if (colName == "colQuantity")
            {
                if (!int.TryParse(text, out int q))
                    message = "Số lượng phải là số nguyên";
                else if (q <= 0)
                    message = "Số lượng phải > 0";
            }
            else if (colName == "colWeight")
            {
                if (!decimal.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal w))
                    message = "Trọng lượng phải là số";
                else if (w <= 0)
                    message = "Trọng lượng phải > 0";
            }
            else if (colName == "colUnitPrice")
            {
                if (!decimal.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal p))
                    message = "Đơn giá phải là số";
                else if (p <= 0)
                    message = "Đơn giá phải > 0";
            }

            if (!string.IsNullOrEmpty(message))
            {
                errorProvider.SetError(editingControl, message);
                if (cell != null) cell.ErrorText = message;
            }
            else
            {
                errorProvider.SetError(editingControl, string.Empty);
                if (cell != null) cell.ErrorText = string.Empty;
            }

            if (dataGridViewItems.CurrentCell != null)
            {
                UpdateTotalsLive(dataGridViewItems.CurrentCell.RowIndex, dataGridViewItems.CurrentCell.ColumnIndex, editingControl.Text);
            }
        }

        private void UpdateTotalsLive(int editRow, int editCol, string editText)
        {
            int totalQty = 0;
            decimal totalWeight = 0m;
            decimal totalAmount = 0m;

            for (int r = 0; r < dataGridViewItems.Rows.Count; r++)
            {
                var row = dataGridViewItems.Rows[r];
                if (row.IsNewRow) continue;

                int qty = 0;
                decimal weight = 0m;
                decimal amount = 0m;

                object cQty = row.Cells["colQuantity"].Value;
                object cWeight = row.Cells["colWeight"].Value;
                object cTotal = row.Cells["colTotal"].Value;

                if (r == editRow)
                {
                    if (editCol == dataGridViewItems.Columns["colQuantity"].Index)
                    {
                        if (int.TryParse(editText, out int q)) qty = q;
                    }
                    else if (cQty != null && int.TryParse(cQty.ToString(), out int q2)) qty = q2;

                    if (editCol == dataGridViewItems.Columns["colWeight"].Index)
                    {
                        if (decimal.TryParse(editText, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal w)) weight = w;
                    }
                    else if (cWeight != null && decimal.TryParse(cWeight.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal w2)) weight = w2;

                    if (editCol == dataGridViewItems.Columns["colUnitPrice"].Index)
                    {
                        if (decimal.TryParse(editText, NumberStyles.Any, CultureInfo.CurrentCulture, out decimal t)) amount = t * qty;
                    }
                    else if (cTotal != null && decimal.TryParse(cTotal.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal t2)) amount = t2;
                }
                else
                {
                    if (cQty != null && int.TryParse(cQty.ToString(), out int q3)) qty = q3;
                    if (cWeight != null && decimal.TryParse(cWeight.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal w3)) weight = w3;
                    if (cTotal != null && decimal.TryParse(cTotal.ToString(), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal t3)) amount = t3;
                }

                totalQty += qty;
                totalWeight += qty * weight;
                totalAmount += amount;
            }

            toolStripStatusTotalQty.Text = $"Tổng SL: {totalQty}";
            toolStripStatusTotalWeight.Text = $"Tổng trọng lượng: {totalWeight:N2} kg";
            toolStripStatusTotalAmount.Text = $"Tổng tiền: {totalAmount:N2}";
        }

        private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            var editingControl = sender as TextBox;
            if (editingControl == null) return;

            int colIndex = dataGridViewItems.CurrentCell.ColumnIndex;
            string colName = dataGridViewItems.Columns[colIndex].Name;

            if (colName == "colQuantity")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true;
            }
            else if (colName == "colWeight" || colName == "colUnitPrice")
            {
               
                char dec = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != dec)
                    e.Handled = true;
               
                if (e.KeyChar == dec && editingControl.Text.Contains(dec))
                    e.Handled = true;
            }
        }

        private void DataGridViewItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var col = dataGridViewItems.Columns[e.ColumnIndex];
            var editingControl = dataGridViewItems.EditingControl;
            var cell = dataGridViewItems.Rows[e.RowIndex].Cells[e.ColumnIndex];

            void SetErrorFor(string message)
            {
                if (editingControl != null)
                    errorProvider.SetError(editingControl, message);
                else
                    errorProvider.SetError(dataGridViewItems, message);
                cell.ErrorText = message ?? string.Empty;
            }

            if (col.Name == "colQuantity")
            {
                if (!int.TryParse(Convert.ToString(e.FormattedValue), out int qty))
                {
                    SetErrorFor("Số lượng phải là số nguyên");
                }
                else if (qty <= 0)
                {
                    SetErrorFor("Số lượng phải > 0");
                }
                else
                {
                    SetErrorFor(string.Empty);
                }
            }
            else if (col.Name == "colWeight")
            {
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal w))
                {
                    SetErrorFor("Trọng lượng phải là số");
                }
                else if (w <= 0)
                {
                    SetErrorFor("Trọng lượng phải > 0");
                }
                else
                {
                    SetErrorFor(string.Empty);
                }
            }
            else if (col.Name == "colUnitPrice")
            {
                if (!decimal.TryParse(Convert.ToString(e.FormattedValue), NumberStyles.Any, CultureInfo.CurrentCulture, out decimal p))
                {
                    SetErrorFor("Đơn giá phải là số");
                }
                else if (p <= 0)
                {
                    SetErrorFor("Đơn giá phải > 0");
                }
                else
                {
                    SetErrorFor(string.Empty);
                }
            }
        }

        private void DataGridViewItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
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
                totalWeight += qty * weight; 
                totalAmount += amount;
            }

            toolStripStatusTotalQty.Text = $"Tổng SL: {totalQty}";
            toolStripStatusTotalWeight.Text = $"Tổng trọng lượng: {totalWeight:N2} kg";
            toolStripStatusTotalAmount.Text = $"Tổng tiền: {totalAmount:N2}";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
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
