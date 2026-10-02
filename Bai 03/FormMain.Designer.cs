namespace TechMartManager
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProductId = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.lblProductName = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblUnitPrice = new System.Windows.Forms.Label();
            this.txtUnitPrice = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnChooseImage = new System.Windows.Forms.Button();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.errorProviderInput = new System.Windows.Forms.ErrorProvider(this.components);

            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).BeginInit();
            this.SuspendLayout();

            // MenuStrip
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileToolStripMenuItem });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 0;

            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.exportCSVToolStripMenuItem, this.exitToolStripMenuItem });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";

            this.exportCSVToolStripMenuItem.Name = "exportCSVToolStripMenuItem";
            this.exportCSVToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportCSVToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportCSVToolStripMenuItem.Text = "Export CSV";

            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";

            // StatusStrip
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip1.Location = new System.Drawing.Point(0, 607);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 1;

            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 17);
            this.lblStatus.Text = "Tổng số sản phẩm: 0";

            // TableLayoutPanel (Layout 35% - 65%)
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanelMain.Controls.Add(this.panelLeft, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1008, 583);
            this.tableLayoutPanelMain.TabIndex = 2;

            // PanelLeft (Nhập liệu)
            this.panelLeft.Controls.Add(this.lblTitle);
            this.panelLeft.Controls.Add(this.lblProductId);
            this.panelLeft.Controls.Add(this.txtProductId);
            this.panelLeft.Controls.Add(this.lblProductName);
            this.panelLeft.Controls.Add(this.txtProductName);
            this.panelLeft.Controls.Add(this.lblCategory);
            this.panelLeft.Controls.Add(this.cboCategory);
            this.panelLeft.Controls.Add(this.lblUnitPrice);
            this.panelLeft.Controls.Add(this.txtUnitPrice);
            this.panelLeft.Controls.Add(this.lblQuantity);
            this.panelLeft.Controls.Add(this.txtQuantity);
            this.panelLeft.Controls.Add(this.picAvatar);
            this.panelLeft.Controls.Add(this.btnChooseImage);
            this.panelLeft.Controls.Add(this.flowLayoutPanelButtons);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Padding = new System.Windows.Forms.Padding(10);
            this.panelLeft.Name = "panelLeft";

            this.lblTitle.Text = "THÔNG TIN SẢN PHẨM";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(13, 10);
            this.lblTitle.AutoSize = true;

            this.lblProductId.Text = "Mã sản phẩm:";
            this.lblProductId.Location = new System.Drawing.Point(13, 45);
            this.txtProductId.Location = new System.Drawing.Point(115, 42);
            this.txtProductId.Size = new System.Drawing.Size(200, 23);
            this.txtProductId.ReadOnly = true;

            this.lblProductName.Text = "Tên sản phẩm:";
            this.lblProductName.Location = new System.Drawing.Point(13, 80);
            this.txtProductName.Location = new System.Drawing.Point(115, 77);
            this.txtProductName.Size = new System.Drawing.Size(200, 23);

            this.lblCategory.Text = "Danh mục:";
            this.lblCategory.Location = new System.Drawing.Point(13, 115);
            this.cboCategory.Location = new System.Drawing.Point(115, 112);
            this.cboCategory.Size = new System.Drawing.Size(200, 23);
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.lblUnitPrice.Text = "Đơn giá (VNĐ):";
            this.lblUnitPrice.Location = new System.Drawing.Point(13, 150);
            this.txtUnitPrice.Location = new System.Drawing.Point(115, 147);
            this.txtUnitPrice.Size = new System.Drawing.Size(200, 23);

            this.lblQuantity.Text = "Số lượng:";
            this.lblQuantity.Location = new System.Drawing.Point(13, 185);
            this.txtQuantity.Location = new System.Drawing.Point(115, 182);
            this.txtQuantity.Size = new System.Drawing.Size(200, 23);

            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(115, 220);
            this.picAvatar.Size = new System.Drawing.Size(120, 120);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            this.btnChooseImage.Text = "Chọn ảnh...";
            this.btnChooseImage.Location = new System.Drawing.Point(242, 220);
            this.btnChooseImage.Size = new System.Drawing.Size(75, 28);

            this.flowLayoutPanelButtons.Controls.Add(this.btnAdd);
            this.flowLayoutPanelButtons.Controls.Add(this.btnUpdate);
            this.flowLayoutPanelButtons.Controls.Add(this.btnDelete);
            this.flowLayoutPanelButtons.Controls.Add(this.btnClear);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(13, 360);
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(320, 40);

            this.btnAdd.Text = "Thêm";
            this.btnUpdate.Text = "Sửa";
            this.btnDelete.Text = "Xóa";
            this.btnClear.Text = "Làm mới";

            // PanelRight (Danh sách & Tìm kiếm)
            this.panelRight.Controls.Add(this.dgvProducts);
            this.panelRight.Controls.Add(this.panelSearch);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Padding = new System.Windows.Forms.Padding(5);

            this.panelSearch.Controls.Add(this.lblSearch);
            this.panelSearch.Controls.Add(this.txtSearch);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Height = 40;

            this.lblSearch.Text = "Tìm kiếm:";
            this.lblSearch.Location = new System.Drawing.Point(5, 10);
            this.txtSearch.Location = new System.Drawing.Point(70, 7);
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Size = new System.Drawing.Size(570, 23);

            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.AutoGenerateColumns = false;
            this.dgvProducts.ReadOnly = true;

            // FormMain
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 629);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TechMart Product Manager";

            this.menuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelSearch.ResumeLayout(false);
            this.panelSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCSVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProductId;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblUnitPrice;
        private System.Windows.Forms.TextBox txtUnitPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.ErrorProvider errorProviderInput;
    }
}