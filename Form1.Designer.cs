using musicDB.data;
using musicDB.models;

namespace musicDB
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxActions;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonExecute;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
             
            this.listBoxTables.Location = new System.Drawing.Point(12, 12);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.Size = new System.Drawing.Size(200, 400);
            this.listBoxTables.TabIndex = 0;
            this.listBoxTables.SelectedIndexChanged += new System.EventHandler(this.listBoxTables_SelectedIndexChanged);
            
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(220, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(560, 400);
            this.dataGridView.TabIndex = 1;


            this.comboBoxActions = new System.Windows.Forms.ComboBox();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.textBoxInput = new System.Windows.Forms.TextBox();

            this.comboBoxActions.Location = new System.Drawing.Point(12, 420);
            this.comboBoxActions.Size = new System.Drawing.Size(200, 23);
            this.comboBoxActions.Items.AddRange(new string[]
            {
                "Додати",
                "Змінити",
                "Видалити",
                "Фільтр",
                "Сортування",
                "Пагинація"
            });
            this.comboBoxActions.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxActions.SelectedIndexChanged += new System.EventHandler(this.comboBoxActions_SelectedIndexChanged);

            this.textBoxInput.Location = new System.Drawing.Point(220, 420);
            this.textBoxInput.Size = new System.Drawing.Size(470, 23);

            this.buttonExecute.Location = new System.Drawing.Point(700, 420);
            this.buttonExecute.Size = new System.Drawing.Size(80, 23);
            this.buttonExecute.Text = "Виконати";
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);

            this.Controls.Add(this.comboBoxActions);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.buttonExecute);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.listBoxTables);
            this.Name = "Form1";
            this.Text = "Music Database Viewer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}