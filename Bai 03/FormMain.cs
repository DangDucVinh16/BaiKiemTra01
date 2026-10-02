using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TechMartManager
{
    public partial class FormMain : Form
    {
        private readonly BindingList<Product> _productList = new BindingList<Product>();
        private readonly BindingSource _bindingSource = new BindingSource();
        private List<Category> _categoryList = new List<Category>();

        public FormMain()
        {
            InitializeComponent();
            SetupCustomComponents();
            RegisterEvents();
            LoadInitData();
        }

        private void SetupCustomComponents()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ProductId),
                HeaderText = @"Mã SP",
                Width = 80
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.ProductName),
                HeaderText = @"Tên Sản Phẩm",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.CategoryName),
                HeaderText = @"Danh Mục",
                Width = 120
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.UnitPrice),
                HeaderText = @"Đơn Giá",
                DefaultCellStyle = { Format = "N0" },
                Width = 110
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = nameof(Product.Quantity),
                HeaderText = @"Số Lượng",
                Width = 80
            });

            _bindingSource.DataSource = _productList;
            dgvProducts.DataSource = _bindingSource;

            _categoryList = new List<Category>
            {
                new Category(1, "Điện thoại"),
                new Category(2, "Laptop"),
                new Category(3, "Phụ kiện")
            };
            cboCategory.DataSource = _categoryList;
            cboCategory.DisplayMember = nameof(Category.CategoryName);
            cboCategory.ValueMember = nameof(Category.CategoryId);
        }

        private void RegisterEvents()
        {
            dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
            txtSearch.TextChanged += TxtSearch_TextChanged;
            btnChooseImage.Click += BtnChooseImage_Click;

            btnAdd.Click += BtnAdd_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnDelete.Click += BtnDelete_Click;
            btnClear.Click += (s, e) => ClearForm();

            exportCSVToolStripMenuItem.Click += BtnExportCsv_Click;
            exitToolStripMenuItem.Click += (s, e) => Application.Exit();

            _productList.ListChanged += (s, e) => UpdateStatusCount();
        }

        private void LoadInitData()
        {
            _productList.Add(new Product { ProductId = "SP001", ProductName = "iPhone 15 Pro Max", CategoryId = 1, CategoryName = "Điện thoại", UnitPrice = 29990000, Quantity = 15, ImagePath = "" });
            _productList.Add(new Product { ProductId = "SP002", ProductName = "MacBook Pro M3", CategoryId = 2, CategoryName = "Laptop", UnitPrice = 45500000, Quantity = 8, ImagePath = "" });
            _productList.Add(new Product { ProductId = "SP003", ProductName = "Sạc Anker 65W", CategoryId = 3, CategoryName = "Phụ kiện", UnitPrice = 850000, Quantity = 50, ImagePath = "" });

            ClearForm();
            UpdateStatusCount();
        }

        private bool ValidateInput()
        {
            errorProviderInput.Clear();
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                errorProviderInput.SetError(txtProductName, "Tên sản phẩm không được để trống!");
                isValid = false;
            }

            if (!decimal.TryParse(txtUnitPrice.Text, out decimal price) || price <= 0)
            {
                errorProviderInput.SetError(txtUnitPrice, "Đơn giá phải là số lớn hơn 0!");
                isValid = false;
            }

            if (!int.TryParse(txtQuantity.Text, out int qty) || qty < 0)
            {
                errorProviderInput.SetError(txtQuantity, "Số lượng phải là số nguyên ≥ 0!");
                isValid = false;
            }

            return isValid;
        }

        private void ClearForm()
        {
            txtProductId.Text = $"SP{(_productList.Count + 1):D3}";
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();
            picAvatar.Image = null;
            picAvatar.Tag = string.Empty;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            errorProviderInput.Clear();
            dgvProducts.ClearSelection();
        }

        private void UpdateStatusCount()
        {
            lblStatus.Text = $@"Tổng số sản phẩm: {_productList.Count}";
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow != null && dgvProducts.CurrentRow.DataBoundItem is Product selectedProduct)
            {
                txtProductId.Text = selectedProduct.ProductId;
                txtProductName.Text = selectedProduct.ProductName;
                txtUnitPrice.Text = selectedProduct.UnitPrice.ToString("F0");
                txtQuantity.Text = selectedProduct.Quantity.ToString();
                cboCategory.SelectedValue = selectedProduct.CategoryId;

                picAvatar.Tag = selectedProduct.ImagePath;
                if (!string.IsNullOrEmpty(selectedProduct.ImagePath) && File.Exists(selectedProduct.ImagePath))
                {
                    picAvatar.ImageLocation = selectedProduct.ImagePath;
                }
                else
                {
                    picAvatar.Image = null;
                }
            }
        }

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = @"Image Files (*.jpg; *.png; *.jpeg)|*.jpg;*.png;*.jpeg";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    picAvatar.ImageLocation = dialog.FileName;
                    picAvatar.Tag = dialog.FileName;
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var selectedCat = (Category)cboCategory.SelectedItem;
            var newProduct = new Product
            {
                ProductId = txtProductId.Text,
                ProductName = txtProductName.Text.Trim(),
                CategoryId = selectedCat.CategoryId,
                CategoryName = selectedCat.CategoryName,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                Quantity = int.Parse(txtQuantity.Text),
                ImagePath = picAvatar.Tag?.ToString() ?? string.Empty
            };

            _productList.Add(newProduct);
            MessageBox.Show(@"Thêm sản phẩm thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null) return;
            if (!ValidateInput()) return;

            var currentProduct = (Product)dgvProducts.CurrentRow.DataBoundItem;
            var selectedCat = (Category)cboCategory.SelectedItem;

            currentProduct.ProductName = txtProductName.Text.Trim();
            currentProduct.CategoryId = selectedCat.CategoryId;
            currentProduct.CategoryName = selectedCat.CategoryName;
            currentProduct.UnitPrice = decimal.Parse(txtUnitPrice.Text);
            currentProduct.Quantity = int.Parse(txtQuantity.Text);
            currentProduct.ImagePath = picAvatar.Tag?.ToString() ?? string.Empty;

            _bindingSource.ResetBindings(false);
            MessageBox.Show(@"Cập nhật thông tin thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.CurrentRow == null)
            {
                MessageBox.Show(@"Vui lòng chọn sản phẩm cần xóa!", @"Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = (Product)dgvProducts.CurrentRow.DataBoundItem;
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm [{product.ProductName}] không?",
                @"Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _productList.Remove(product);
                ClearForm();
                MessageBox.Show(@"Xóa sản phẩm thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                _bindingSource.DataSource = _productList;
            }
            else
            {
                var filtered = _productList
                    .Where(p => p.ProductName.ToLower().Contains(keyword) || p.ProductId.ToLower().Contains(keyword))
                    .ToList();
                _bindingSource.DataSource = new BindingList<Product>(filtered);
            }
        }

        private void BtnExportCsv_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = @"CSV File (*.csv)|*.csv";
                dialog.FileName = $"Products_Export_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var csvBuilder = new StringBuilder();
                        csvBuilder.AppendLine("MaSP,TenSanPham,DanhMuc,DonGia,SoLuong");

                        foreach (var p in _productList)
                        {
                            csvBuilder.AppendLine($"\"{p.ProductId}\",\"{p.ProductName}\",\"{p.CategoryName}\",{p.UnitPrice},{p.Quantity}");
                        }

                        File.WriteAllText(dialog.FileName, csvBuilder.ToString(), Encoding.UTF8);
                        MessageBox.Show(@"Xuất dữ liệu CSV thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Có lỗi xảy ra khi xuất file: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Category(int id, string name)
        {
            CategoryId = id;
            CategoryName = name;
        }
    }

    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
}