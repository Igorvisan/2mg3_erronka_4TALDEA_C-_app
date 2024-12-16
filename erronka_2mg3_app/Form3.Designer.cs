namespace erronka_2mg3_app
{
    partial class cocinaPantalla
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
            this.sukaldeUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sukaldeUser
            // 
            this.sukaldeUser.AutoSize = true;
            this.sukaldeUser.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sukaldeUser.ForeColor = System.Drawing.Color.White;
            this.sukaldeUser.Location = new System.Drawing.Point(1319, 9);
            this.sukaldeUser.Name = "sukaldeUser";
            this.sukaldeUser.Size = new System.Drawing.Size(102, 53);
            this.sukaldeUser.TabIndex = 0;
            this.sukaldeUser.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(664, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 53);
            this.label1.TabIndex = 1;
            this.label1.Text = "SUKALDEA";
            // 
            // cocinaPantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 620);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sukaldeUser);
            this.Name = "cocinaPantalla";
            this.Text = "SUKALDEA";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sukaldeUser;
        private System.Windows.Forms.Label label1;
    }
}