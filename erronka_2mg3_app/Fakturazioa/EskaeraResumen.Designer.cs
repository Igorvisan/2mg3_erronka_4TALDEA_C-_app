namespace erronka_2mg3_app.Fakturazioa
{
    partial class EskaeraResumen
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
            this.laburpenBox = new System.Windows.Forms.GroupBox();
            this.totalNumber = new System.Windows.Forms.Label();
            this.totalText = new System.Windows.Forms.Label();
            this.bebidasLista = new System.Windows.Forms.Label();
            this.platosLista = new System.Windows.Forms.Label();
            this.sacarTicketPdf = new System.Windows.Forms.Button();
            this.borrarPedido = new System.Windows.Forms.Button();
            this.lblMesa = new System.Windows.Forms.Label();
            this.numMesa = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.laburpenBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // laburpenBox
            // 
            this.laburpenBox.Controls.Add(this.totalNumber);
            this.laburpenBox.Controls.Add(this.totalText);
            this.laburpenBox.Controls.Add(this.bebidasLista);
            this.laburpenBox.Controls.Add(this.platosLista);
            this.laburpenBox.Controls.Add(this.sacarTicketPdf);
            this.laburpenBox.Controls.Add(this.borrarPedido);
            this.laburpenBox.Location = new System.Drawing.Point(63, 70);
            this.laburpenBox.Name = "laburpenBox";
            this.laburpenBox.Size = new System.Drawing.Size(1167, 615);
            this.laburpenBox.TabIndex = 0;
            this.laburpenBox.TabStop = false;
            // 
            // totalNumber
            // 
            this.totalNumber.AutoSize = true;
            this.totalNumber.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNumber.Location = new System.Drawing.Point(846, 515);
            this.totalNumber.Name = "totalNumber";
            this.totalNumber.Size = new System.Drawing.Size(19, 24);
            this.totalNumber.TabIndex = 13;
            this.totalNumber.Text = "0";
            // 
            // totalText
            // 
            this.totalText.AutoSize = true;
            this.totalText.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalText.Location = new System.Drawing.Point(711, 515);
            this.totalText.Name = "totalText";
            this.totalText.Size = new System.Drawing.Size(68, 24);
            this.totalText.TabIndex = 12;
            this.totalText.Text = "TOTAL:";
            // 
            // bebidasLista
            // 
            this.bebidasLista.AutoSize = true;
            this.bebidasLista.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bebidasLista.Location = new System.Drawing.Point(846, 33);
            this.bebidasLista.Name = "bebidasLista";
            this.bebidasLista.Size = new System.Drawing.Size(82, 24);
            this.bebidasLista.TabIndex = 11;
            this.bebidasLista.Text = "BEBIDAS";
            // 
            // platosLista
            // 
            this.platosLista.AutoSize = true;
            this.platosLista.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.platosLista.Location = new System.Drawing.Point(193, 33);
            this.platosLista.Name = "platosLista";
            this.platosLista.Size = new System.Drawing.Size(75, 24);
            this.platosLista.TabIndex = 10;
            this.platosLista.Text = "PLATOS";
            // 
            // sacarTicketPdf
            // 
            this.sacarTicketPdf.Location = new System.Drawing.Point(319, 502);
            this.sacarTicketPdf.Name = "sacarTicketPdf";
            this.sacarTicketPdf.Size = new System.Drawing.Size(162, 54);
            this.sacarTicketPdf.TabIndex = 9;
            this.sacarTicketPdf.Text = "SACAR TICKET";
            this.sacarTicketPdf.UseVisualStyleBackColor = true;
            this.sacarTicketPdf.Click += new System.EventHandler(this.sacarTicketPdf_Click);
            // 
            // borrarPedido
            // 
            this.borrarPedido.Location = new System.Drawing.Point(118, 502);
            this.borrarPedido.Name = "borrarPedido";
            this.borrarPedido.Size = new System.Drawing.Size(162, 54);
            this.borrarPedido.TabIndex = 8;
            this.borrarPedido.Text = "BORRAR PEDIDO";
            this.borrarPedido.UseVisualStyleBackColor = true;
            this.borrarPedido.Click += new System.EventHandler(this.borrarPedido_Click);
            // 
            // lblMesa
            // 
            this.lblMesa.AutoSize = true;
            this.lblMesa.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMesa.Location = new System.Drawing.Point(569, 43);
            this.lblMesa.Name = "lblMesa";
            this.lblMesa.Size = new System.Drawing.Size(68, 24);
            this.lblMesa.TabIndex = 14;
            this.lblMesa.Text = "MESA: ";
            // 
            // numMesa
            // 
            this.numMesa.AutoSize = true;
            this.numMesa.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMesa.Location = new System.Drawing.Point(655, 43);
            this.numMesa.Name = "numMesa";
            this.numMesa.Size = new System.Drawing.Size(19, 24);
            this.numMesa.TabIndex = 15;
            this.numMesa.Text = "0";
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.Location = new System.Drawing.Point(1130, 9);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(158, 35);
            this.userName.TabIndex = 16;
            this.userName.Text = "@UserName";
            // 
            // EskaeraResumen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 774);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.numMesa);
            this.Controls.Add(this.lblMesa);
            this.Controls.Add(this.laburpenBox);
            this.Name = "EskaeraResumen";
            this.Text = "EskaeraResumen";
            this.Load += new System.EventHandler(this.EskaeraResumen_Load);
            this.laburpenBox.ResumeLayout(false);
            this.laburpenBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox laburpenBox;
        private System.Windows.Forms.Button sacarTicketPdf;
        private System.Windows.Forms.Button borrarPedido;
        private System.Windows.Forms.Label bebidasLista;
        private System.Windows.Forms.Label platosLista;
        private System.Windows.Forms.Label totalNumber;
        private System.Windows.Forms.Label totalText;
        private System.Windows.Forms.Label lblMesa;
        private System.Windows.Forms.Label numMesa;
        private System.Windows.Forms.Label userName;
    }
}