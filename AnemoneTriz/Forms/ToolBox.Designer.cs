namespace AnemoneTriz.Forms
{
    partial class ToolBox
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
            this.pageLabel = new System.Windows.Forms.Label();
            this.nextTextButton = new AnemoneTriz.Controls.AMButton();
            this.prevTextButton = new AnemoneTriz.Controls.AMButton();
            this.SuspendLayout();
            // 
            // pageLabel
            // 
            this.pageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pageLabel.AutoSize = true;
            this.pageLabel.Location = new System.Drawing.Point(719, 21);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(64, 12);
            this.pageLabel.TabIndex = 3;
            this.pageLabel.Text = "pageLabel";
            // 
            // nextTextButton
            // 
            this.nextTextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(166)))), ((int)(((byte)(248)))));
            this.nextTextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(160)))), ((int)(((byte)(236)))));
            this.nextTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nextTextButton.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nextTextButton.ForeColor = System.Drawing.Color.White;
            this.nextTextButton.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nextTextButton.Location = new System.Drawing.Point(119, 9);
            this.nextTextButton.Margin = new System.Windows.Forms.Padding(0);
            this.nextTextButton.Name = "nextTextButton";
            this.nextTextButton.Size = new System.Drawing.Size(100, 35);
            this.nextTextButton.TabIndex = 2;
            this.nextTextButton.Text = "다음으로";
            this.nextTextButton.UseVisualStyleBackColor = false;
            this.nextTextButton.Click += new System.EventHandler(this.nextTextButton_Click);
            // 
            // prevTextButton
            // 
            this.prevTextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(166)))), ((int)(((byte)(248)))));
            this.prevTextButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(160)))), ((int)(((byte)(236)))));
            this.prevTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prevTextButton.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.prevTextButton.ForeColor = System.Drawing.Color.White;
            this.prevTextButton.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.prevTextButton.Location = new System.Drawing.Point(9, 9);
            this.prevTextButton.Margin = new System.Windows.Forms.Padding(0);
            this.prevTextButton.Name = "prevTextButton";
            this.prevTextButton.Size = new System.Drawing.Size(100, 35);
            this.prevTextButton.TabIndex = 1;
            this.prevTextButton.Text = "이전으로";
            this.prevTextButton.UseVisualStyleBackColor = false;
            this.prevTextButton.Click += new System.EventHandler(this.prevTextButton_Click);
            // 
            // ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(808, 58);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.nextTextButton);
            this.Controls.Add(this.prevTextButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ToolBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToolBox";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.AMButton prevTextButton;
        private Controls.AMButton nextTextButton;
        public System.Windows.Forms.Label pageLabel;
    }
}