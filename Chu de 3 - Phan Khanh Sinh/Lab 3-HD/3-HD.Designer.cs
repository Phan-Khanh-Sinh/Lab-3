namespace Lab_3_HD
{
    partial class frmDocTuFile
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
            btnReadJSON = new Button();
            SuspendLayout();
            // 
            // btnReadJSON
            // 
            btnReadJSON.Font = new Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReadJSON.Location = new Point(159, 53);
            btnReadJSON.Name = "btnReadJSON";
            btnReadJSON.Size = new Size(157, 42);
            btnReadJSON.TabIndex = 0;
            btnReadJSON.Text = "Đọc file JSON";
            btnReadJSON.UseVisualStyleBackColor = true;
            btnReadJSON.Click += btnReadJSON_Click;
            // 
            // frmDocTuFile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(466, 158);
            Controls.Add(btnReadJSON);
            Name = "frmDocTuFile";
            Text = "Đọc từ file JSON";
            ResumeLayout(false);
        }

        #endregion

        private Button btnReadJSON;
    }
}
