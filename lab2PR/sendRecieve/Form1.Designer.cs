namespace sendRecieve
{
    partial class Form1
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
            this.SendBox = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.rtxtBody = new System.Windows.Forms.TextBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtRecipient = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.BodyLabel = new System.Windows.Forms.Label();
            this.Subjectlabel = new System.Windows.Forms.Label();
            this.RecipientLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.RecieveBox = new System.Windows.Forms.GroupBox();
            this.btnRecieve = new System.Windows.Forms.Button();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.rtxtRecieve = new System.Windows.Forms.TextBox();
            this.SendBox.SuspendLayout();
            this.RecieveBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendBox
            // 
            this.SendBox.Controls.Add(this.btnSend);
            this.SendBox.Controls.Add(this.rtxtBody);
            this.SendBox.Controls.Add(this.txtSubject);
            this.SendBox.Controls.Add(this.txtRecipient);
            this.SendBox.Controls.Add(this.txtPassword);
            this.SendBox.Controls.Add(this.label1);
            this.SendBox.Controls.Add(this.txtEmail);
            this.SendBox.Controls.Add(this.BodyLabel);
            this.SendBox.Controls.Add(this.Subjectlabel);
            this.SendBox.Controls.Add(this.RecipientLabel);
            this.SendBox.Controls.Add(this.PasswordLabel);
            this.SendBox.Controls.Add(this.EmailLabel);
            this.SendBox.Location = new System.Drawing.Point(12, 12);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(389, 391);
            this.SendBox.TabIndex = 0;
            this.SendBox.TabStop = false;
            this.SendBox.Text = "Send";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(128, 347);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // rtxtBody
            // 
            this.rtxtBody.Location = new System.Drawing.Point(72, 170);
            this.rtxtBody.Multiline = true;
            this.rtxtBody.Name = "rtxtBody";
            this.rtxtBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rtxtBody.Size = new System.Drawing.Size(198, 171);
            this.rtxtBody.TabIndex = 10;
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(72, 125);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(149, 20);
            this.txtSubject.TabIndex = 9;
            // 
            // txtRecipient
            // 
            this.txtRecipient.Location = new System.Drawing.Point(72, 94);
            this.txtRecipient.Name = "txtRecipient";
            this.txtRecipient.Size = new System.Drawing.Size(149, 20);
            this.txtRecipient.TabIndex = 8;
           
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(72, 61);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(149, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(72, 29);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(149, 20);
            this.txtEmail.TabIndex = 5;
            // 
            // BodyLabel
            // 
            this.BodyLabel.AutoSize = true;
            this.BodyLabel.Location = new System.Drawing.Point(6, 173);
            this.BodyLabel.Name = "BodyLabel";
            this.BodyLabel.Size = new System.Drawing.Size(34, 13);
            this.BodyLabel.TabIndex = 4;
            this.BodyLabel.Text = "Body:";
            // 
            // Subjectlabel
            // 
            this.Subjectlabel.AutoSize = true;
            this.Subjectlabel.Location = new System.Drawing.Point(6, 125);
            this.Subjectlabel.Name = "Subjectlabel";
            this.Subjectlabel.Size = new System.Drawing.Size(46, 13);
            this.Subjectlabel.TabIndex = 3;
            this.Subjectlabel.Text = "Subject:";
            // 
            // RecipientLabel
            // 
            this.RecipientLabel.AutoSize = true;
            this.RecipientLabel.Location = new System.Drawing.Point(6, 94);
            this.RecipientLabel.Name = "RecipientLabel";
            this.RecipientLabel.Size = new System.Drawing.Size(55, 13);
            this.RecipientLabel.TabIndex = 2;
            this.RecipientLabel.Text = "Recipient:";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(6, 64);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(56, 13);
            this.PasswordLabel.TabIndex = 1;
            this.PasswordLabel.Text = "Password:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(6, 32);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(35, 13);
            this.EmailLabel.TabIndex = 0;
            this.EmailLabel.Text = "Email:";
            // 
            // RecieveBox
            // 
            this.RecieveBox.Controls.Add(this.btnRecieve);
            this.RecieveBox.Controls.Add(this.MessageLabel);
            this.RecieveBox.Controls.Add(this.rtxtRecieve);
            this.RecieveBox.Location = new System.Drawing.Point(407, 12);
            this.RecieveBox.Name = "RecieveBox";
            this.RecieveBox.Size = new System.Drawing.Size(381, 391);
            this.RecieveBox.TabIndex = 1;
            this.RecieveBox.TabStop = false;
            this.RecieveBox.Text = "Recieve";
            // 
            // btnRecieve
            // 
            this.btnRecieve.Location = new System.Drawing.Point(182, 347);
            this.btnRecieve.Name = "btnRecieve";
            this.btnRecieve.Size = new System.Drawing.Size(75, 23);
            this.btnRecieve.TabIndex = 12;
            this.btnRecieve.Text = "Recieve";
            this.btnRecieve.UseVisualStyleBackColor = true;
            this.btnRecieve.Click += new System.EventHandler(this.btnRecieve_Click);
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Location = new System.Drawing.Point(6, 29);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(53, 13);
            this.MessageLabel.TabIndex = 11;
            this.MessageLabel.Text = "Message:";
            // 
            // rtxtRecieve
            // 
            this.rtxtRecieve.Location = new System.Drawing.Point(65, 32);
            this.rtxtRecieve.Multiline = true;
            this.rtxtRecieve.Name = "rtxtRecieve";
            this.rtxtRecieve.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.rtxtRecieve.Size = new System.Drawing.Size(297, 309);
            this.rtxtRecieve.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RecieveBox);
            this.Controls.Add(this.SendBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SendBox.ResumeLayout(false);
            this.SendBox.PerformLayout();
            this.RecieveBox.ResumeLayout(false);
            this.RecieveBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SendBox;
        private System.Windows.Forms.GroupBox RecieveBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox rtxtBody;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtRecipient;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label BodyLabel;
        private System.Windows.Forms.Label Subjectlabel;
        private System.Windows.Forms.Label RecipientLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Button btnRecieve;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox rtxtRecieve;
    }
}

