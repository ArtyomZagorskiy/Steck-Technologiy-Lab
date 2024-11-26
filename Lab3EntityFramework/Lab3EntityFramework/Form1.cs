namespace Lab3EntityFramework
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;

        private List<Book> bookList = new List<Book>();

        LibraryContext db = new LibraryContext();

        public Form1()
        {
            InitializeComponent();
            initDataGridView();

            var bList = from b in db.libraryBooks select b;
            foreach (var b in bList) {
                bookList.Add(b);
            }

            showListInGrid();
        }

        private void initDataGridView()
        {
            // ������������� �������
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.AutoResizeColumns();
        }

        private DataGridViewColumn getDataGridViewColumn1()
        {
            // �������� ��������� ����� ������� � �������
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "�����";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn1;
        }

        private DataGridViewColumn getDataGridViewColumn2()
        {
            // �������� ��������� ����� ������� � �������
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "�����";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn2;
        }

        private DataGridViewColumn getDataGridViewColumn3()
        {
            // �������� ��������� ����� ������� � �������
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "ʳ������";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 3;
            }

            return dataGridViewColumn3;
        }

        private void showListInGrid()
        {
            // ����������� �������� � �������
            dataGridView1.Rows.Clear();
            foreach (Book b in bookList)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new
                DataGridViewTextBoxCell();

                cell1.ValueType = typeof(string);
                cell1.Value = b.Title;
                cell2.ValueType = typeof(string);
                cell2.Value = b.Author;
                cell3.ValueType = typeof(string);
                cell3.Value = b.�opies.ToString();

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);

                dataGridView1.Rows.Add(row);
            }
        }

        private void addBook(string title, int copies, string author = "")
        {
            // ��������� �������� �� ��������
            Book b = new Book();
            b.Title = title;
            b.Author = author;
            b.�opies = copies;

            bookList.Add(b);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            showListInGrid();

            db.libraryBooks.Add(b);
            db.SaveChanges();
        }

        private void deleteBook(int elementIndex)
        {
            // ��������� �������� � ��������
            var bookToRemove = bookList[elementIndex];
            db.libraryBooks.Remove(bookToRemove);
            db.SaveChanges();

            bookList.RemoveAt(elementIndex);
            showListInGrid();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("�������!! ������ ����� �� ��ﳿ �����.", "", MessageBoxButtons.OK);
                return;
            }

            if(int.TryParse(textBox3.Text, out int number) && number >= 1)
            {
                addBook(textBox1.Text, number, textBox2.Text);
            }
            
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("�������� �����?", "", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteBook(selectedRow);
                }
                catch (Exception) { }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("�������!! ������ ����� �� ��ﳿ �����.", "", MessageBoxButtons.OK);
                return;
            }

            if (int.TryParse(textBox3.Text, out int number) && number >= 1)
            {
                addBook(textBox1.Text, number, textBox2.Text);
            }
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var context = new LibraryContext())
            {
                bookList = context.libraryBooks.ToList();
            }

            showListInGrid();
        }
    }
}