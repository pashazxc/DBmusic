using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using musicDB.data;
using musicDB.models;

namespace musicDB
{
    public partial class Form1 : Form
    {
        private readonly DbContextOptions<MusicDbContext> _options;

        public Form1()
        {
            InitializeComponent();
            _options = new DbContextOptionsBuilder<MusicDbContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MusicDb;Trusted_Connection=True;MultipleActiveResultSets=true")
                .Options;

            LoadTablesToListBox();
        }

        private void LoadTablesToListBox()
        {
            List<string> tables = new List<string>
            {
                "Artists",
                "Albums",
                "Tracks",
                "TrackAlbums",
                "AlbumArtists",
                "TrackArtists"
            };

            listBoxTables.Items.Clear();
            listBoxTables.Items.AddRange(tables.ToArray());
        }

        private void LoadDataFromSelectedTable(string tableName)
        {
            using (var dbContext = new MusicDbContext(_options))
            {
                var dataSet = dbContext.GetType().GetProperty(tableName).GetValue(dbContext, null);

                if (dataSet is IQueryable queryable)
                {
                    dataGridView.DataSource = queryable.Cast<object>().ToList();
                }
            }
        }

        private void listBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxTables.SelectedItem != null)
            {
                string selectedTable = listBoxTables.SelectedItem.ToString();
                LoadDataFromSelectedTable(selectedTable);
            }
        }

        private void comboBoxActions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAction = this.comboBoxActions.SelectedItem.ToString();
            switch (selectedAction)
            {
                case "Додати":
                    this.textBoxInput.Text = "INSERT INTO TableName (Column1, Column2) VALUES (Value1, Value2);";
                    break;
                case "Змінити":
                    this.textBoxInput.Text = "UPDATE TableName SET Column1 = Value1 WHERE Condition;";
                    break;
                case "Видалити":
                    this.textBoxInput.Text = "DELETE FROM TableName WHERE Condition;";
                    break;
                case "Фільтр":
                    this.textBoxInput.Text = "SELECT * FROM TableName WHERE Condition;";
                    break;
                case "Сортування":
                    this.textBoxInput.Text = "SELECT * FROM TableName ORDER BY Column1 ASC;";
                    break;
                case "Пагинація":
                    this.textBoxInput.Text = "SELECT * FROM TableName ORDER BY Column1 OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY;";
                    break;
            }
        }

        private async void buttonExecute_Click(object sender, EventArgs e)
        {
            string input = textBoxInput.Text;
            try
            {
                using (var connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=MusicDb;Trusted_Connection=True;"))
                {
                    await connection.OpenAsync();
                    using (var command = new SqlCommand(input, connection))
                    {
                        if (input.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                        {
                            DataTable dataTable = new DataTable();
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            adapter.Fill(dataTable);
                            dataGridView.DataSource = dataTable;
                        }
                        else
                        {
                            int rowsAffected = await command.ExecuteNonQueryAsync();
                            MessageBox.Show($"Rows affected: {rowsAffected}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
