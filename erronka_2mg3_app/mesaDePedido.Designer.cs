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
            this.mahaiGroup = new System.Windows.Forms.GroupBox();
            this.edariScreenButton = new System.Windows.Forms.Button();
            this.mesa6 = new System.Windows.Forms.Button();
            this.mesa5 = new System.Windows.Forms.Button();
            this.mesa4 = new System.Windows.Forms.Button();
            this.mesa3 = new System.Windows.Forms.Button();
            this.mesa2 = new System.Windows.Forms.Button();
            this.mesa1 = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.Label();
            this.mahaiGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // mahaiGroup
            // 
            this.mahaiGroup.Controls.Add(this.edariScreenButton);
            this.mahaiGroup.Controls.Add(this.mesa6);
            this.mahaiGroup.Controls.Add(this.mesa5);
            this.mahaiGroup.Controls.Add(this.mesa4);
            this.mahaiGroup.Controls.Add(this.mesa3);
            this.mahaiGroup.Controls.Add(this.mesa2);
            this.mahaiGroup.Controls.Add(this.mesa1);
            this.mahaiGroup.Location = new System.Drawing.Point(186, 132);
            this.mahaiGroup.Name = "mahaiGroup";
            this.mahaiGroup.Size = new System.Drawing.Size(894, 498);
            this.mahaiGroup.TabIndex = 0;
            this.mahaiGroup.TabStop = false;
            // 
            // edariScreenButton
            // 
            this.edariScreenButton.Location = new System.Drawing.Point(356, 394);
            this.edariScreenButton.Name = "edariScreenButton";
            this.edariScreenButton.Size = new System.Drawing.Size(176, 59);
            this.edariScreenButton.TabIndex = 6;
            this.edariScreenButton.Text = "CONFIRMAR";
            this.edariScreenButton.UseVisualStyleBackColor = true;
            // 
            // mesa6
            // 
            this.mesa6.Location = new System.Drawing.Point(546, 304);
            this.mesa6.Name = "mesa6";
            this.mesa6.Size = new System.Drawing.Size(176, 59);
            this.mesa6.TabIndex = 5;
            this.mesa6.Text = "Mesa 6";
            this.mesa6.UseVisualStyleBackColor = true;
            this.mesa6.Click += new System.EventHandler(this.mesa6_Click);
            // 
            // mesa5
            // 
            this.mesa5.Location = new System.Drawing.Point(546, 192);
            this.mesa5.Name = "mesa5";
            this.mesa5.Size = new System.Drawing.Size(176, 59);
            this.mesa5.TabIndex = 4;
            this.mesa5.Text = "Mesa 5";
            this.mesa5.UseVisualStyleBackColor = true;
            this.mesa5.Click += new System.EventHandler(this.mesa5_Click);
            // 
            // mesa4
            // 
            this.mesa4.Location = new System.Drawing.Point(546, 88);
            this.mesa4.Name = "mesa4";
            this.mesa4.Size = new System.Drawing.Size(176, 59);
            this.mesa4.TabIndex = 3;
            this.mesa4.Text = "Mesa 4";
            this.mesa4.UseVisualStyleBackColor = true;
            this.mesa4.Click += new System.EventHandler(this.mesa4_Click);
            // 
            // mesa3
            // 
            this.mesa3.Location = new System.Drawing.Point(172, 304);
            this.mesa3.Name = "mesa3";
            this.mesa3.Size = new System.Drawing.Size(176, 59);
            this.mesa3.TabIndex = 2;
            this.mesa3.Text = "Mesa 3";
            this.mesa3.UseVisualStyleBackColor = true;
            this.mesa3.Click += new System.EventHandler(this.mesa3_Click);
            // 
            // mesa2
            // 
            this.mesa2.Location = new System.Drawing.Point(172, 192);
            this.mesa2.Name = "mesa2";
            this.mesa2.Size = new System.Drawing.Size(176, 59);
            this.mesa2.TabIndex = 1;
            this.mesa2.Text = "Mesa 2";
            this.mesa2.UseVisualStyleBackColor = true;
            this.mesa2.Click += new System.EventHandler(this.mesa2_Click);
            // 
            // mesa1
            // 
            this.mesa1.Location = new System.Drawing.Point(172, 88);
            this.mesa1.Name = "mesa1";
            this.mesa1.Size = new System.Drawing.Size(176, 59);
            this.mesa1.TabIndex = 0;
            this.mesa1.Text = "Mesa 1";
            this.mesa1.UseVisualStyleBackColor = true;
            this.mesa1.Click += new System.EventHandler(this.mesa1_Click);
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
            // mesaDePedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 764);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.mahaiGroup);
            this.Name = "mesaDePedido";
            this.Text = "mesaDePedido";
            this.Load += new System.EventHandler(this.mesaDePedido_Load);
            this.mahaiGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox mahaiGroup;
        private System.Windows.Forms.Button edariScreenButton;
        private System.Windows.Forms.Button mesa6;
        private System.Windows.Forms.Button mesa5;
        private System.Windows.Forms.Button mesa4;
        private System.Windows.Forms.Button mesa3;
        private System.Windows.Forms.Button mesa2;
        private System.Windows.Forms.Button mesa1;
        private System.Windows.Forms.Label userName;
    }
}