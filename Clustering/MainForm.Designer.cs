namespace Clustering
{
	partial class MainForm
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
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьСтатистикуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.применитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openImageDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveImageDialog = new System.Windows.Forms.SaveFileDialog();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.pictureBoxInput = new System.Windows.Forms.PictureBox();
			this.pictureBoxOutput = new System.Windows.Forms.PictureBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.trackBarThreshold = new System.Windows.Forms.TrackBar();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBoxClustNumber = new System.Windows.Forms.TextBox();
			this.labelClustNumber = new System.Windows.Forms.Label();
			this.textBoxThreshold = new System.Windows.Forms.TextBox();
			this.labelThreshold = new System.Windows.Forms.Label();
			this.saveStatisticsDialog = new System.Windows.Forms.SaveFileDialog();
			this.labelFilterCoreRank = new System.Windows.Forms.Label();
			this.textBoxFilterCoreRank = new System.Windows.Forms.TextBox();
			this.menuStrip.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).BeginInit();
			this.tableLayoutPanel3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.применитьToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(829, 24);
			this.menuStrip.TabIndex = 1;
			this.menuStrip.Text = "menuStrip";
			// 
			// файлToolStripMenuItem
			// 
			this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьСтатистикуToolStripMenuItem,
            this.выходToolStripMenuItem});
			this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
			this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.файлToolStripMenuItem.Text = "Файл";
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.открытьToolStripMenuItem.Text = "Открыть...";
			this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
			// 
			// сохранитьToolStripMenuItem
			// 
			this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
			this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.сохранитьToolStripMenuItem.Text = "Сохранить...";
			this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
			// 
			// сохранитьСтатистикуToolStripMenuItem
			// 
			this.сохранитьСтатистикуToolStripMenuItem.Name = "сохранитьСтатистикуToolStripMenuItem";
			this.сохранитьСтатистикуToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.сохранитьСтатистикуToolStripMenuItem.Text = "Сохранить статистику...";
			this.сохранитьСтатистикуToolStripMenuItem.Click += new System.EventHandler(this.сохранитьСтатистикуToolStripMenuItem_Click);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
			this.выходToolStripMenuItem.Text = "Выход";
			this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
			// 
			// применитьToolStripMenuItem
			// 
			this.применитьToolStripMenuItem.Name = "применитьToolStripMenuItem";
			this.применитьToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
			this.применитьToolStripMenuItem.Text = "Применить";
			this.применитьToolStripMenuItem.Click += new System.EventHandler(this.применитьToolStripMenuItem_Click);
			// 
			// openImageDialog
			// 
			this.openImageDialog.Filter = "Все файлы|*.*|BMP|*.bmp|JPG|*.jpg|JPEG|*.jpeg|JPE|*.jpe|JFIF|*.jfif|PNG|*.png";
			// 
			// saveImageDialog
			// 
			this.saveImageDialog.Filter = "PNG|*.png|BMP|*.bmp|JPEG|*.jpeg|GIF|*.gif";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(829, 340);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.pictureBoxInput, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.pictureBoxOutput, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 63);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(823, 274);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// pictureBoxInput
			// 
			this.pictureBoxInput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxInput.Location = new System.Drawing.Point(3, 3);
			this.pictureBoxInput.Name = "pictureBoxInput";
			this.pictureBoxInput.Size = new System.Drawing.Size(405, 268);
			this.pictureBoxInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxInput.TabIndex = 0;
			this.pictureBoxInput.TabStop = false;
			// 
			// pictureBoxOutput
			// 
			this.pictureBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxOutput.Location = new System.Drawing.Point(414, 3);
			this.pictureBoxOutput.Name = "pictureBoxOutput";
			this.pictureBoxOutput.Size = new System.Drawing.Size(406, 268);
			this.pictureBoxOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxOutput.TabIndex = 1;
			this.pictureBoxOutput.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.groupBox2, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(823, 54);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.trackBarThreshold);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(405, 48);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Порог бинаризации";
			// 
			// trackBarThreshold
			// 
			this.trackBarThreshold.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trackBarThreshold.Location = new System.Drawing.Point(3, 16);
			this.trackBarThreshold.Maximum = 255;
			this.trackBarThreshold.Name = "trackBarThreshold";
			this.trackBarThreshold.Size = new System.Drawing.Size(399, 29);
			this.trackBarThreshold.TabIndex = 1;
			this.trackBarThreshold.Value = 150;
			this.trackBarThreshold.Scroll += new System.EventHandler(this.trackBarThreshold_Scroll);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBoxFilterCoreRank);
			this.groupBox2.Controls.Add(this.labelFilterCoreRank);
			this.groupBox2.Controls.Add(this.textBoxClustNumber);
			this.groupBox2.Controls.Add(this.labelClustNumber);
			this.groupBox2.Controls.Add(this.textBoxThreshold);
			this.groupBox2.Controls.Add(this.labelThreshold);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(414, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(406, 48);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Параметры";
			// 
			// textBoxClustNumber
			// 
			this.textBoxClustNumber.Location = new System.Drawing.Point(219, 25);
			this.textBoxClustNumber.Name = "textBoxClustNumber";
			this.textBoxClustNumber.Size = new System.Drawing.Size(25, 20);
			this.textBoxClustNumber.TabIndex = 3;
			this.textBoxClustNumber.Text = "4";
			this.textBoxClustNumber.TextChanged += new System.EventHandler(this.textBoxClustNumber_TextChanged);
			// 
			// labelClustNumber
			// 
			this.labelClustNumber.AutoSize = true;
			this.labelClustNumber.Location = new System.Drawing.Point(153, 32);
			this.labelClustNumber.Name = "labelClustNumber";
			this.labelClustNumber.Size = new System.Drawing.Size(60, 13);
			this.labelClustNumber.TabIndex = 2;
			this.labelClustNumber.Text = "Кластеры:";
			// 
			// textBoxThreshold
			// 
			this.textBoxThreshold.Enabled = false;
			this.textBoxThreshold.Location = new System.Drawing.Point(122, 25);
			this.textBoxThreshold.Name = "textBoxThreshold";
			this.textBoxThreshold.ReadOnly = true;
			this.textBoxThreshold.Size = new System.Drawing.Size(25, 20);
			this.textBoxThreshold.TabIndex = 1;
			this.textBoxThreshold.Text = "150";
			// 
			// labelThreshold
			// 
			this.labelThreshold.AutoSize = true;
			this.labelThreshold.Location = new System.Drawing.Point(6, 32);
			this.labelThreshold.Name = "labelThreshold";
			this.labelThreshold.Size = new System.Drawing.Size(110, 13);
			this.labelThreshold.TabIndex = 0;
			this.labelThreshold.Text = "Порог бинаризации:";
			// 
			// saveStatisticsDialog
			// 
			this.saveStatisticsDialog.FileName = "objectStatistics";
			this.saveStatisticsDialog.Filter = "TXT|*.txt";
			// 
			// labelFilterCoreRank
			// 
			this.labelFilterCoreRank.AutoSize = true;
			this.labelFilterCoreRank.Location = new System.Drawing.Point(250, 32);
			this.labelFilterCoreRank.Name = "labelFilterCoreRank";
			this.labelFilterCoreRank.Size = new System.Drawing.Size(107, 13);
			this.labelFilterCoreRank.TabIndex = 4;
			this.labelFilterCoreRank.Text = "Ранг ядра фильтра:";
			// 
			// textBoxFilterCoreRank
			// 
			this.textBoxFilterCoreRank.Location = new System.Drawing.Point(363, 25);
			this.textBoxFilterCoreRank.Name = "textBoxFilterCoreRank";
			this.textBoxFilterCoreRank.Size = new System.Drawing.Size(25, 20);
			this.textBoxFilterCoreRank.TabIndex = 5;
			this.textBoxFilterCoreRank.Text = "7";
			this.textBoxFilterCoreRank.TextChanged += new System.EventHandler(this.textBoxFilterCoreRank_TextChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(829, 364);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.menuStrip);
			this.MainMenuStrip = this.menuStrip;
			this.Name = "MainForm";
			this.Text = "Кластеризация";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxInput)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOutput)).EndInit();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem применитьToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openImageDialog;
		private System.Windows.Forms.SaveFileDialog saveImageDialog;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.PictureBox pictureBoxInput;
		private System.Windows.Forms.PictureBox pictureBoxOutput;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TrackBar trackBarThreshold;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBoxClustNumber;
		private System.Windows.Forms.Label labelClustNumber;
		private System.Windows.Forms.TextBox textBoxThreshold;
		private System.Windows.Forms.Label labelThreshold;
		private System.Windows.Forms.ToolStripMenuItem сохранитьСтатистикуToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveStatisticsDialog;
		private System.Windows.Forms.Label labelFilterCoreRank;
		private System.Windows.Forms.TextBox textBoxFilterCoreRank;
	}
}

