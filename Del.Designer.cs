namespace BanHangDT
{
    partial class Del
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
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtProduct = new System.Windows.Forms.DataGridView();
            this.clmMA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmGIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmNSX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(710, 409);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(274, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "XÓA SẢN PHẨM";
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
            this.dtProduct.Location = new System.Drawing.Point(25, 94);
            this.dtProduct.Name = "dtProduct";
            this.dtProduct.Size = new System.Drawing.Size(744, 296);
            this.dtProduct.TabIndex = 6;
            this.dtProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProduct_CellClick);
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
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(650, 65);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(119, 23);
            this.btnXoa.TabIndex = 9;
            this.btnXoa.Text = "Xóa sản phẩm";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Mã sản phẩm:";
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(102, 68);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(173, 20);
            this.txtMa.TabIndex = 11;
            // 
            // Del
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtMa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtProduct);
            this.Name = "Del";
            this.Text = "Del";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Del_FormClosing);
            this.Load += new System.EventHandler(this.Del_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMA;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmGIA;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNSX;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSL;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMa;
    }
}