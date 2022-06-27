namespace TestTask
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDepartment = new System.Windows.Forms.ToolStripMenuItem();
            this.EditJobTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.AddEmployeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 43);
            this.dataGridView1.MaximumSize = new System.Drawing.Size(1280, 600);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(1280, 600);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1280, 600);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.ColumnHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(73, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditDepartment,
            this.EditJobTitle,
            this.AddEmployeeToolStripMenuItem,
            this.SalaryToolStripMenuItem,
            this.ReportToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // EditDepartment
            // 
            this.EditDepartment.Name = "EditDepartment";
            this.EditDepartment.Size = new System.Drawing.Size(298, 26);
            this.EditDepartment.Text = "Редактирование отделов";
            this.EditDepartment.Click += new System.EventHandler(this.EditDepartment_Click);
            // 
            // EditJobTitle
            // 
            this.EditJobTitle.Name = "EditJobTitle";
            this.EditJobTitle.Size = new System.Drawing.Size(298, 26);
            this.EditJobTitle.Text = "Редактирование должностей ";
            this.EditJobTitle.Click += new System.EventHandler(this.EditJobTitle_Click);
            // 
            // AddEmployeeToolStripMenuItem
            // 
            this.AddEmployeeToolStripMenuItem.Name = "AddEmployeeToolStripMenuItem";
            this.AddEmployeeToolStripMenuItem.Size = new System.Drawing.Size(298, 26);
            this.AddEmployeeToolStripMenuItem.Text = "Добавление сотрудника ";
            this.AddEmployeeToolStripMenuItem.Click += new System.EventHandler(this.AddEmployeeToolStripMenuItem_Click);
            // 
            // SalaryToolStripMenuItem
            // 
            this.SalaryToolStripMenuItem.Name = "SalaryToolStripMenuItem";
            this.SalaryToolStripMenuItem.Size = new System.Drawing.Size(298, 26);
            this.SalaryToolStripMenuItem.Text = "Выплаты ";
            this.SalaryToolStripMenuItem.Click += new System.EventHandler(this.SalaryToolStripMenuItem_Click);
            // 
            // ReportToolStripMenuItem
            // 
            this.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem";
            this.ReportToolStripMenuItem.Size = new System.Drawing.Size(298, 26);
            this.ReportToolStripMenuItem.Text = "Отчет";
            this.ReportToolStripMenuItem.Click += new System.EventHandler(this.ReportToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(1218, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Help";
            this.label1.MouseEnter += new System.EventHandler(this.label1_MouseEnter);
            this.label1.MouseLeave += new System.EventHandler(this.label1_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 613);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1300, 660);
            this.MinimumSize = new System.Drawing.Size(1300, 300);
            this.Name = "Form1";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditDepartment;
        private System.Windows.Forms.ToolStripMenuItem EditJobTitle;
        private System.Windows.Forms.ToolStripMenuItem AddEmployeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReportToolStripMenuItem;
        private System.Windows.Forms.Label label1;
    }
}

