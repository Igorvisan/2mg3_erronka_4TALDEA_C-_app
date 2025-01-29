namespace erronka_2mg3_app
{
    partial class adminPantalla
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
            this.adminUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataTableProduct = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.gehituBotoia = new System.Windows.Forms.Button();
            this.txtKantitatea = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.productsCombo = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // adminUserName
            // 
            this.adminUserName.AutoSize = true;
            this.adminUserName.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminUserName.ForeColor = System.Drawing.Color.White;
            this.adminUserName.Location = new System.Drawing.Point(1315, 9);
            this.adminUserName.Name = "adminUserName";
            this.adminUserName.Size = new System.Drawing.Size(102, 53);
            this.adminUserName.TabIndex = 0;
            this.adminUserName.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(640, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "ADMIN";
            // 
            // dataTableProduct
            // 
            this.dataTableProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableProduct.Location = new System.Drawing.Point(225, 105);
            this.dataTableProduct.Name = "dataTableProduct";
            this.dataTableProduct.RowHeadersWidth = 51;
            this.dataTableProduct.RowTemplate.Height = 24;
            this.dataTableProduct.Size = new System.Drawing.Size(961, 535);
            this.dataTableProduct.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1192, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 73);
            this.button1.TabIndex = 3;
            this.button1.Text = "ACTUALIZAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gehituBotoia
            // 
            this.gehituBotoia.Location = new System.Drawing.Point(604, 646);
            this.gehituBotoia.Name = "gehituBotoia";
            this.gehituBotoia.Size = new System.Drawing.Size(179, 46);
            this.gehituBotoia.TabIndex = 5;
            this.gehituBotoia.Text = "AÑADIR";
            this.gehituBotoia.UseVisualStyleBackColor = true;
            this.gehituBotoia.Click += new System.EventHandler(this.gehituBotoia_Click);
            // 
            // txtKantitatea
            // 
            this.txtKantitatea.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKantitatea.Location = new System.Drawing.Point(225, 646);
            this.txtKantitatea.Multiline = true;
            this.txtKantitatea.Name = "txtKantitatea";
            this.txtKantitatea.Size = new System.Drawing.Size(226, 46);
            this.txtKantitatea.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(559, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Nombre de producto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(822, 706);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 16);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(303, 695);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cantidad";
            // 
            // productsCombo
            // 
            this.productsCombo.FormattingEnabled = true;
            this.productsCombo.Location = new System.Drawing.Point(225, 75);
            this.productsCombo.Name = "productsCombo";
            this.productsCombo.Size = new System.Drawing.Size(328, 24);
            this.productsCombo.TabIndex = 10;
            this.productsCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // adminPantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1429, 749);
            this.Controls.Add(this.productsCombo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKantitatea);
            this.Controls.Add(this.gehituBotoia);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataTableProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.adminUserName);
            this.Name = "adminPantalla";
            this.Text = "ADMIN";
            this.Load += new System.EventHandler(this.adminPantalla_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableProduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label adminUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataTableProduct;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button gehituBotoia;
        private System.Windows.Forms.TextBox txtKantitatea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox productsCombo;
    }
}