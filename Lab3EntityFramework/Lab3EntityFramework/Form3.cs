using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3EntityFramework
{
    public partial class Form3 : Form
    {
        LibraryContext db = new LibraryContext();
        private Form4 authForm;
        private Form1 form1 = new Form1();
        private Form2 form2 = new Form2();

        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;

        private Reader currentReader = null;
        public Form3()
        {
            InitializeComponent();
            initDataGridView();
            form1.Show();
            form2.Show();
            splitContainer1.Visible = false;
            authForm = new Form4();
            authForm.auth = GetAuth;
            authForm.Show();
        }

        public void GetAuth(string name, string email, bool registration = false)
        {
            if(registration)
            {
                var reader = new Reader() { Name = name, Email = email };
                db.readers.Add(reader);
                currentReader = reader;

                authForm.Hide();
                splitContainer1.Visible = true;
                db.SaveChanges();
                return;
            }

            var readers = db.readers;
            currentReader = readers.FirstOrDefault(r => r.Name == name && r.Email == email);

            if(currentReader != null)
            {
                authForm.Hide();
                splitContainer1.Visible = true;

                showListInGrid();
            }
            else
            {
                MessageBox.Show("Помилка!!!", "", MessageBoxButtons.OK);
            }
        }

        private void initDataGridView()
        {
            // інициализация таблиці
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.AutoResizeColumns();
        }

        private DataGridViewColumn getDataGridViewColumn1()
        {
            // динамічне створення першої колонки у таблиці
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Назва";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 2;
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
                dataGridViewColumn2.HeaderText = "Автор";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 2;
            }

            return dataGridViewColumn2;
        }

        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Book b in currentReader.books)
            {
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cell1 = new
                DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new
                DataGridViewTextBoxCell();

                cell1.ValueType = typeof(string);
                cell1.Value = b.Title;
                cell2.ValueType = typeof(string);
                cell2.Value = b.Author;

                row.Cells.Add(cell1);
                row.Cells.Add(cell2);

                dataGridView1.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bookToBorrow = db.libraryBooks.FirstOrDefault(b => b.Title == textBox1.Text);

            if (bookToBorrow == null)
            {
                MessageBox.Show("Такої книги немає в бібліотеці!", "", MessageBoxButtons.OK);
                return;
            }

            if (currentReader.books.Any(book => book.Title == textBox1.Text))
            {
                MessageBox.Show("У вас вже є така книга!!!", "", MessageBoxButtons.OK);
                return;
            }

            
            if (bookToBorrow.Сopies > 0)
            {
                bookToBorrow.Сopies--;


                currentReader.books.Add(bookToBorrow);

                db.SaveChanges();
                showListInGrid();
                MessageBox.Show("Книга успішно взята!", "", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Немає доступних копій книги!", "", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var bookToReturn = currentReader.books.FirstOrDefault(b => b.Title == textBox2.Text);

            if (bookToReturn == null)
            {
                MessageBox.Show("У вас немає такої книги!", "", MessageBoxButtons.OK);
                return;
            }

            var libraryBook = db.libraryBooks.FirstOrDefault(b => b.Title == bookToReturn.Title);

            if (libraryBook != null)
            {
                libraryBook.Сopies++; 
            }
            else
            {
                db.libraryBooks.Add(new Book
                {
                    Title = bookToReturn.Title,
                    Author = bookToReturn.Author,
                    Сopies = 1
                });
            }


            currentReader.books.Remove(bookToReturn);

            db.SaveChanges(); 
            showListInGrid();
            MessageBox.Show("Книга успішно повернута!", "", MessageBoxButtons.OK);
        }
    }

    public delegate void AuthHandler(string name, string email, bool registration = false);
}
