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
            this.sukaldePlaterak = new System.Windows.Forms.GroupBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            // sukaldePlaterak
            // 
            this.sukaldePlaterak.Location = new System.Drawing.Point(158, 76);
            this.sukaldePlaterak.Name = "sukaldePlaterak";
            this.sukaldePlaterak.Size = new System.Drawing.Size(1112, 623);
            this.sukaldePlaterak.TabIndex = 2;
            this.sukaldePlaterak.TabStop = false;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(1276, 76);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(145, 63);
            this.nextButton.TabIndex = 3;
            this.nextButton.Text = "BUKATU";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1276, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 63);
            this.button1.TabIndex = 4;
            this.button1.Text = "EGUNERATU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cocinaPantalla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1433, 746);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.sukaldePlaterak);
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
        private System.Windows.Forms.GroupBox sukaldePlaterak;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button button1;
    }
}