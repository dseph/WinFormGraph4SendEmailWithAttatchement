namespace WinFormGraph4SendEmailWithAttatchement
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            AppIdEntry = new TextBox();
            TenantIdEntry = new TextBox();
            ClientSecretEntry = new TextBox();
            FromAddress = new TextBox();
            ToAddress = new TextBox();
            Subject = new TextBox();
            AttatchmentFilePath = new TextBox();
            EditorBody = new TextBox();
            btnSend = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(57, 80);
            label1.Name = "label1";
            label1.Size = new Size(161, 32);
            label1.TabIndex = 0;
            label1.Text = "Client App ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 134);
            label2.Name = "label2";
            label2.Size = new Size(118, 32);
            label2.TabIndex = 1;
            label2.Text = "Tenant Id:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 175);
            label3.Name = "label3";
            label3.Size = new Size(154, 32);
            label3.TabIndex = 2;
            label3.Text = "Client Secret:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 268);
            label4.Name = "label4";
            label4.Size = new Size(142, 32);
            label4.TabIndex = 3;
            label4.Text = "From SMTP:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(61, 307);
            label5.Name = "label5";
            label5.Size = new Size(112, 32);
            label5.TabIndex = 4;
            label5.Text = "To SMTP:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(63, 387);
            label6.Name = "label6";
            label6.Size = new Size(98, 32);
            label6.TabIndex = 5;
            label6.Text = "Subject:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(61, 461);
            label7.Name = "label7";
            label7.Size = new Size(73, 32);
            label7.TabIndex = 6;
            label7.Text = "Body:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(56, 542);
            label8.Name = "label8";
            label8.Size = new Size(196, 32);
            label8.TabIndex = 7;
            label8.Text = "Attachment Path:";
            // 
            // AppIdEntry
            // 
            AppIdEntry.Location = new Point(293, 77);
            AppIdEntry.Name = "AppIdEntry";
            AppIdEntry.Size = new Size(857, 39);
            AppIdEntry.TabIndex = 8;
            // 
            // TenantIdEntry
            // 
            TenantIdEntry.Location = new Point(292, 127);
            TenantIdEntry.Name = "TenantIdEntry";
            TenantIdEntry.Size = new Size(862, 39);
            TenantIdEntry.TabIndex = 9;
            // 
            // ClientSecretEntry
            // 
            ClientSecretEntry.Location = new Point(292, 172);
            ClientSecretEntry.Name = "ClientSecretEntry";
            ClientSecretEntry.PasswordChar = '*';
            ClientSecretEntry.Size = new Size(858, 39);
            ClientSecretEntry.TabIndex = 10;
            // 
            // FromAddress
            // 
            FromAddress.Location = new Point(291, 255);
            FromAddress.Name = "FromAddress";
            FromAddress.Size = new Size(858, 39);
            FromAddress.TabIndex = 11;
            // 
            // ToAddress
            // 
            ToAddress.Location = new Point(291, 300);
            ToAddress.Name = "ToAddress";
            ToAddress.Size = new Size(858, 39);
            ToAddress.TabIndex = 12;
            // 
            // Subject
            // 
            Subject.Location = new Point(292, 384);
            Subject.Name = "Subject";
            Subject.Size = new Size(857, 39);
            Subject.TabIndex = 13;
            // 
            // AttatchmentFilePath
            // 
            AttatchmentFilePath.Location = new Point(292, 542);
            AttatchmentFilePath.Name = "AttatchmentFilePath";
            AttatchmentFilePath.Size = new Size(857, 39);
            AttatchmentFilePath.TabIndex = 14;
            // 
            // EditorBody
            // 
            EditorBody.Location = new Point(291, 429);
            EditorBody.Multiline = true;
            EditorBody.Name = "EditorBody";
            EditorBody.ScrollBars = ScrollBars.Both;
            EditorBody.Size = new Size(869, 98);
            EditorBody.TabIndex = 15;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(997, 619);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(144, 42);
            btnSend.TabIndex = 16;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1198, 692);
            Controls.Add(btnSend);
            Controls.Add(EditorBody);
            Controls.Add(AttatchmentFilePath);
            Controls.Add(Subject);
            Controls.Add(ToAddress);
            Controls.Add(FromAddress);
            Controls.Add(ClientSecretEntry);
            Controls.Add(TenantIdEntry);
            Controls.Add(AppIdEntry);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox AppIdEntry;
        private TextBox TenantIdEntry;
        private TextBox ClientSecretEntry;
        private TextBox FromAddress;
        private TextBox ToAddress;
        private TextBox Subject;
        private TextBox AttatchmentFilePath;
        private TextBox EditorBody;
        private Button btnSend;
    }
}
