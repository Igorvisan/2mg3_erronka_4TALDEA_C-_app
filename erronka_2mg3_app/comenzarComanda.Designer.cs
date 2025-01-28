namespace erronka_2mg3_app
{
    partial class nuevComanda
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
            this.nuevoPedido = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.White;
            this.userName.Location = new System.Drawing.Point(1054, 9);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(191, 53);
            this.userName.TabIndex = 3;
            this.userName.Text = "@UserName";
            this.userName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // nuevoPedido
            // 
            this.nuevoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuevoPedido.Location = new System.Drawing.Point(330, 349);
            this.nuevoPedido.Name = "nuevoPedido";
            this.nuevoPedido.Size = new System.Drawing.Size(285, 79);
            this.nuevoPedido.TabIndex = 4;
            this.nuevoPedido.Text = "HACER NUEVA COMANDA";
            this.nuevoPedido.UseVisualStyleBackColor = true;
            this.nuevoPedido.Click += new System.EventHandler(this.nuevoPedido_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(12, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 53);
            this.button1.TabIndex = 5;
            this.button1.Text = "CHAT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(635, 349);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(285, 79);
            this.button2.TabIndex = 6;
            this.button2.Text = "VER PEDIDOS";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // nuevComanda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 767);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nuevoPedido);
            this.Controls.Add(this.userName);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "nuevComanda";
            this.Text = "Comenzar Comanda";
            this.Load += new System.EventHandler(this.comenzarComanda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.Button nuevoPedido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}