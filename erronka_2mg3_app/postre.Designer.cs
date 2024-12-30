namespace erronka_2mg3_app
{
    partial class postrePantalla
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
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.Label();
            this.postreGroup = new System.Windows.Forms.GroupBox();
            this.finalizarButton = new System.Windows.Forms.Button();
            this.sorbete = new System.Windows.Forms.Button();
            this.tartaWhiskey = new System.Windows.Forms.Button();
            this.pastelVasco = new System.Windows.Forms.Button();
            this.tartaQueso = new System.Windows.Forms.Button();
            this.postreGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(625, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "TPV";
            // 
            // userName
            // 
            this.userName.AutoSize = true;
            this.userName.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userName.ForeColor = System.Drawing.Color.White;
            this.userName.Location = new System.Drawing.Point(1095, 9);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(191, 53);
            this.userName.TabIndex = 1;
            this.userName.Text = "@UserName";
            // 
            // postreGroup
            // 
            this.postreGroup.Controls.Add(this.finalizarButton);
            this.postreGroup.Controls.Add(this.sorbete);
            this.postreGroup.Controls.Add(this.tartaWhiskey);
            this.postreGroup.Controls.Add(this.pastelVasco);
            this.postreGroup.Controls.Add(this.tartaQueso);
            this.postreGroup.Location = new System.Drawing.Point(229, 102);
            this.postreGroup.Name = "postreGroup";
            this.postreGroup.Size = new System.Drawing.Size(859, 525);
            this.postreGroup.TabIndex = 2;
            this.postreGroup.TabStop = false;
            // 
            // finalizarButton
            // 
            this.finalizarButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.finalizarButton.ForeColor = System.Drawing.Color.White;
            this.finalizarButton.Location = new System.Drawing.Point(322, 395);
            this.finalizarButton.Name = "finalizarButton";
            this.finalizarButton.Size = new System.Drawing.Size(204, 72);
            this.finalizarButton.TabIndex = 4;
            this.finalizarButton.Text = "FINALIZAR";
            this.finalizarButton.UseVisualStyleBackColor = false;
            // 
            // sorbete
            // 
            this.sorbete.BackColor = System.Drawing.SystemColors.ControlLight;
            this.sorbete.ForeColor = System.Drawing.Color.White;
            this.sorbete.Location = new System.Drawing.Point(510, 267);
            this.sorbete.Name = "sorbete";
            this.sorbete.Size = new System.Drawing.Size(204, 72);
            this.sorbete.TabIndex = 3;
            this.sorbete.Text = "Sorbete de limon al cava";
            this.sorbete.UseVisualStyleBackColor = false;
            this.sorbete.Click += new System.EventHandler(this.sorbete_Click);
            // 
            // tartaWhiskey
            // 
            this.tartaWhiskey.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tartaWhiskey.ForeColor = System.Drawing.Color.White;
            this.tartaWhiskey.Location = new System.Drawing.Point(510, 111);
            this.tartaWhiskey.Name = "tartaWhiskey";
            this.tartaWhiskey.Size = new System.Drawing.Size(204, 72);
            this.tartaWhiskey.TabIndex = 2;
            this.tartaWhiskey.Text = "Tarta al whiskey";
            this.tartaWhiskey.UseVisualStyleBackColor = false;
            this.tartaWhiskey.Click += new System.EventHandler(this.tartaWhiskey_Click);
            // 
            // pastelVasco
            // 
            this.pastelVasco.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pastelVasco.ForeColor = System.Drawing.Color.White;
            this.pastelVasco.Location = new System.Drawing.Point(129, 267);
            this.pastelVasco.Name = "pastelVasco";
            this.pastelVasco.Size = new System.Drawing.Size(204, 72);
            this.pastelVasco.TabIndex = 1;
            this.pastelVasco.Text = "Pastel vasco";
            this.pastelVasco.UseVisualStyleBackColor = false;
            this.pastelVasco.Click += new System.EventHandler(this.pastelVasco_Click);
            // 
            // tartaQueso
            // 
            this.tartaQueso.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tartaQueso.ForeColor = System.Drawing.Color.White;
            this.tartaQueso.Location = new System.Drawing.Point(129, 111);
            this.tartaQueso.Name = "tartaQueso";
            this.tartaQueso.Size = new System.Drawing.Size(204, 72);
            this.tartaQueso.TabIndex = 0;
            this.tartaQueso.Text = "Tarta de queso";
            this.tartaQueso.UseVisualStyleBackColor = false;
            this.tartaQueso.Click += new System.EventHandler(this.tartaQueso_Click);
            // 
            // postrePantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 768);
            this.Controls.Add(this.postreGroup);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.label1);
            this.Name = "postrePantalla";
            this.Text = "POSTRE";
            this.Load += new System.EventHandler(this.postrePantalla_Load);
            this.postreGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userName;
        private System.Windows.Forms.GroupBox postreGroup;
        private System.Windows.Forms.Button finalizarButton;
        private System.Windows.Forms.Button sorbete;
        private System.Windows.Forms.Button tartaWhiskey;
        private System.Windows.Forms.Button pastelVasco;
        private System.Windows.Forms.Button tartaQueso;
    }
}