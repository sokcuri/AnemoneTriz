namespace AnemoneTriz.Forms
{
    partial class TestForm
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
            this.amButton1 = new AnemoneTriz.Controls.AMButton();
            this.SuspendLayout();
            // 
            // amButton1
            // 
            this.amButton1.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.amButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.amButton1.HighlightColor = System.Drawing.Color.Silver;
            this.amButton1.Location = new System.Drawing.Point(28, 27);
            this.amButton1.Name = "amButton1";
            this.amButton1.Size = new System.Drawing.Size(115, 31);
            this.amButton1.TabIndex = 0;
            this.amButton1.Text = "Update Test";
            this.amButton1.UseVisualStyleBackColor = true;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 335);
            this.Controls.Add(this.amButton1);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AMButton amButton1;
    }
}