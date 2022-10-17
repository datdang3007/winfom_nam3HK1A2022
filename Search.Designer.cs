namespace BanHangDT
{
    partial class Search
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtProduct = new System.Windows.Forms.DataGridView();
            this.clmMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // dtProduct
            // 
            this.dtProduct.AllowUserToAddRows = false;
            this.dtProduct.AllowUserToDeleteRows = false;
            this.dtProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmMA,
            this.clmTEN,
            this.clmGIA,
            this.clmNSX,
            this.clmSL});
            this.dtProduct.Location = new System.Drawing.Point(29, 112);
            this.dtProduct.Name = "dtProduct";
            this.dtProduct.Size = new System.Drawing.Size(744, 296);
            this.dtProduct.TabIndex = 2;
            // 
            // clmMA
            // 
            this.clmMA.HeaderText = "Mã sản phẩm";
            this.clmMA.Name = "clmMA";
            this.clmMA.Width = 140;
            // 
            // clmTEN
            // 
            this.clmTEN.HeaderText = "Tên sản phẩm";
            this.clmTEN.Name = "clmTEN";
            this.clmTEN.Width = 140;
            // 
            // clmGIA
            // 
            this.clmGIA.HeaderText = "Giá";
            this.clmGIA.Name = "clmGIA";
            this.clmGIA.Width = 140;
            // 
            // clmNSX
            // 
            this.clmNSX.HeaderText = "NSX";
            this.clmNSX.Name = "clmNSX";
            this.clmNSX.Width = 140;
            // 
            // clmSL
            // 
            this.clmSL.HeaderText = "Số lượng";
            this.clmSL.Name = "clmSL";
            this.clmSL.Width = 140;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(243, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "TÌM KIẾM SẢN PHẨM";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(724, 414);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(486, 86);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(287, 20);
            this.txtSearch.TabIndex = 5;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 448);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtProduct);
            this.Name = "Search";
            this.Text = "Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Search_FormClosing);
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TextBox txtSearch;
    }
}