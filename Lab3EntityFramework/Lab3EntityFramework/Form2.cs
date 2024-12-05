using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace Lab3EntityFramework
{
    public partial class Form2 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;

        private List<Reader> readerList = new List<Reader>();

        LibraryContext db = new LibraryContext();
        public Form2()
        {
            InitializeComponent();
            initDataGridView();

            var rList = from r in db.readers select r;
            foreach (var r in rList)
            {
                readerList.Add(r);

            }

            showListInGrid();
        }

        private void initDataGridView()
        {
            // інициализация таблиці
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.AutoResizeColumns();
        }

        private DataGridViewColumn getDataGridViewColumn1()
        {
            // динамічне створення першої колонки у таблиці
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Ім'я";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn1;
        }

        private DataGridViewColumn getDataGridViewColumn2()
        {
            // динамічне створення другої колонки у таблиці
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Email";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn2;
        }

        private DataGridViewColumn getDataGridViewColumn3()
        {
            // динамічне створення другої колонки у таблиці
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Книги";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn3;
        }

        private void showListInGrid()
        {
            // відображення колекції у таблиці
            dataGridView1.Rows.Clear();
            foreach (Reader r in readerList)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                DataGridViewTextBoxCell();

                cell1.ValueType = typeof(string);
                cell1.Value = r.Name;
                cell2.ValueType = typeof(string);
                cell2.Value = r.Email;
                cell3.ValueType = typeof(string);
                string booksSTR = "";

                for(int i =0; i < r.books.Count; i++)
                {
                    booksSTR += " " + r.books[i].Title + ", \n";
                }

                cell3.Value = booksSTR;

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);

                dataGridView1.Rows.Add(row);
            }
        }

        private void deleteReader(int elementIndex)
        {
            var readerToRemove = readerList[elementIndex];
            db.readers.Remove(readerToRemove);
            db.SaveChanges();

            readerList.RemoveAt(elementIndex);
            showListInGrid();
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Видалити читача?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteReader(selectedRow);
                }
                catch (Exception) { }
            }
        }

        private void оновитиДаніToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new LibraryContext())
            {
                readerList = context.readers.Include(r => r.books).ToList();
            }

            showListInGrid();
        }
    }
}
