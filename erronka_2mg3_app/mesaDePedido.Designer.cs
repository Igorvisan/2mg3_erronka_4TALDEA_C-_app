namespace erronka_2mg3_app
{
    partial class mesaDePedido
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
            this.userName = new System.Windows.Forms.Label();
            this.select = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.White;
            this.userName.Location = new System.Drawing.Point(1065, 9);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(191, 53);
            this.userName.TabIndex = 4;
            this.userName.Text = "@UserName";
            this.userName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(518, 624);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(199, 67);
            this.select.TabIndex = 5;
            this.select.Text = "SELECCIONAR";
            this.select.UseVisualStyleBackColor = true;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // mesaDePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 764);
            this.Controls.Add(this.select);
            this.Controls.Add(this.userName);
            this.Name = "mesaDePedido";
            this.Text = "mesaDePedido";
            this.Load += new System.EventHandler(this.mesaDePedido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button select;
    }
}