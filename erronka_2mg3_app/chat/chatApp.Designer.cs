namespace erronka_2mg3_app.chat
{
    partial class chatApp
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
            this.sendTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.closeChatButton = new System.Windows.Forms.Button();
            this.userNameText = new System.Windows.Forms.Label();
            this.chatPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // sendTextBox
            // 
            this.sendTextBox.Location = new System.Drawing.Point(12, 567);
            this.sendTextBox.Multiline = true;
            this.sendTextBox.Name = "sendTextBox";
            this.sendTextBox.Size = new System.Drawing.Size(567, 46);
            this.sendTextBox.TabIndex = 0;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(585, 567);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(125, 46);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "BIDALI";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click_1);
            // 
            // closeChatButton
            // 
            this.closeChatButton.Location = new System.Drawing.Point(12, 52);
            this.closeChatButton.Name = "closeChatButton";
            this.closeChatButton.Size = new System.Drawing.Size(125, 46);
            this.closeChatButton.TabIndex = 3;
            this.closeChatButton.Text = "IRTEN";
            this.closeChatButton.UseVisualStyleBackColor = true;
            this.closeChatButton.Click += new System.EventHandler(this.closeChatButton_Click);
            // 
            // userNameText
            // 
            this.userNameText.AutoSize = true;
            this.userNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameText.ForeColor = System.Drawing.Color.Black;
            this.userNameText.Location = new System.Drawing.Point(143, 60);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(125, 25);
            this.userNameText.TabIndex = 4;
            this.userNameText.Text = "@UserName";
            // 
            // chatPanel
            // 
            this.chatPanel.AutoScroll = true;
            this.chatPanel.Location = new System.Drawing.Point(12, 104);
            this.chatPanel.Name = "chatPanel";
            this.chatPanel.Size = new System.Drawing.Size(698, 457);
            this.chatPanel.TabIndex = 5;
            this.chatPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.chatPanel_Paint);
            // 
            // chatApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(10, 100);
            this.ClientSize = new System.Drawing.Size(722, 625);
            this.Controls.Add(this.chatPanel);
            this.Controls.Add(this.userNameText);
            this.Controls.Add(this.closeChatButton);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.sendTextBox);
            this.Name = "chatApp";
            this.Text = "chatApp";
            this.Load += new System.EventHandler(this.chatApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sendTextBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Button closeChatButton;
        private System.Windows.Forms.Label userNameText;
        private System.Windows.Forms.Panel chatPanel;
    }
}