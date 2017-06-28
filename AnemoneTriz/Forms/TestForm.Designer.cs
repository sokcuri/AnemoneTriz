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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestForm));
            this.updateTestButton = new AnemoneTriz.Controls.AMButton();
            this.decompTestButton = new AnemoneTriz.Controls.AMButton();
            this.restartTestButton = new AnemoneTriz.Controls.AMButton();
            this.uacRequestTestButton = new AnemoneTriz.Controls.AMButton();
            this.jsonTestButton = new AnemoneTriz.Controls.AMButton();
            this.taskDialogTest = new AnemoneTriz.Controls.AMButton();
            this.runtimeFunctionTestButton = new AnemoneTriz.Controls.AMButton();
            this.SuspendLayout();
            // 
            // updateTestButton
            // 
            this.updateTestButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.updateTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.updateTestButton.HighlightColor = System.Drawing.Color.Silver;
            this.updateTestButton.Location = new System.Drawing.Point(28, 27);
            this.updateTestButton.Name = "updateTestButton";
            this.updateTestButton.Size = new System.Drawing.Size(133, 31);
            this.updateTestButton.TabIndex = 0;
            this.updateTestButton.Text = "Update Test";
            this.updateTestButton.UseVisualStyleBackColor = true;
            // 
            // decompTestButton
            // 
            this.decompTestButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.decompTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decompTestButton.HighlightColor = System.Drawing.Color.Silver;
            this.decompTestButton.Location = new System.Drawing.Point(28, 76);
            this.decompTestButton.Name = "decompTestButton";
            this.decompTestButton.Size = new System.Drawing.Size(133, 31);
            this.decompTestButton.TabIndex = 0;
            this.decompTestButton.Text = "Decompress Test";
            this.decompTestButton.UseVisualStyleBackColor = true;
            this.decompTestButton.Click += new System.EventHandler(this.decompTestButton_Click);
            // 
            // restartTestButton
            // 
            this.restartTestButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.restartTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartTestButton.HighlightColor = System.Drawing.Color.Silver;
            this.restartTestButton.Location = new System.Drawing.Point(28, 126);
            this.restartTestButton.Name = "restartTestButton";
            this.restartTestButton.Size = new System.Drawing.Size(133, 31);
            this.restartTestButton.TabIndex = 0;
            this.restartTestButton.Text = "Restart Test";
            this.restartTestButton.UseVisualStyleBackColor = true;
            this.restartTestButton.Click += new System.EventHandler(this.restartTestButton_Click);
            // 
            // uacRequestTestButton
            // 
            this.uacRequestTestButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.uacRequestTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uacRequestTestButton.HighlightColor = System.Drawing.Color.Silver;
            this.uacRequestTestButton.Location = new System.Drawing.Point(28, 175);
            this.uacRequestTestButton.Name = "uacRequestTestButton";
            this.uacRequestTestButton.Size = new System.Drawing.Size(133, 31);
            this.uacRequestTestButton.TabIndex = 0;
            this.uacRequestTestButton.Text = "UAC Request Test";
            this.uacRequestTestButton.UseVisualStyleBackColor = true;
            this.uacRequestTestButton.Click += new System.EventHandler(this.uacRequestTestButton_Click);
            // 
            // jsonTestButton
            // 
            this.jsonTestButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.jsonTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.jsonTestButton.HighlightColor = System.Drawing.Color.Silver;
            this.jsonTestButton.Location = new System.Drawing.Point(28, 225);
            this.jsonTestButton.Name = "jsonTestButton";
            this.jsonTestButton.Size = new System.Drawing.Size(133, 31);
            this.jsonTestButton.TabIndex = 0;
            this.jsonTestButton.Text = "JSON Test";
            this.jsonTestButton.UseVisualStyleBackColor = true;
            this.jsonTestButton.Click += new System.EventHandler(this.jsonTestButton_Click);
            // 
            // taskDialogTest
            // 
            this.taskDialogTest.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.taskDialogTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.taskDialogTest.HighlightColor = System.Drawing.Color.Silver;
            this.taskDialogTest.Location = new System.Drawing.Point(28, 276);
            this.taskDialogTest.Name = "taskDialogTest";
            this.taskDialogTest.Size = new System.Drawing.Size(133, 31);
            this.taskDialogTest.TabIndex = 0;
            this.taskDialogTest.Text = "TaskDialog Test";
            this.taskDialogTest.UseVisualStyleBackColor = true;
            this.taskDialogTest.Click += new System.EventHandler(this.taskDialogTest_Click);
            // 
            // runtimeFunctionTestButton
            // 
            this.runtimeFunctionTestButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.runtimeFunctionTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runtimeFunctionTestButton.HighlightColor = System.Drawing.Color.Silver;
            this.runtimeFunctionTestButton.Location = new System.Drawing.Point(185, 27);
            this.runtimeFunctionTestButton.Name = "runtimeFunctionTestButton";
            this.runtimeFunctionTestButton.Size = new System.Drawing.Size(133, 31);
            this.runtimeFunctionTestButton.TabIndex = 0;
            this.runtimeFunctionTestButton.Text = "Runtime-Func Test";
            this.runtimeFunctionTestButton.UseVisualStyleBackColor = true;
            this.runtimeFunctionTestButton.Click += new System.EventHandler(this.runtimeFunctionTestButton_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 335);
            this.Controls.Add(this.runtimeFunctionTestButton);
            this.Controls.Add(this.taskDialogTest);
            this.Controls.Add(this.jsonTestButton);
            this.Controls.Add(this.uacRequestTestButton);
            this.Controls.Add(this.restartTestButton);
            this.Controls.Add(this.decompTestButton);
            this.Controls.Add(this.updateTestButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.AMButton updateTestButton;
        private Controls.AMButton decompTestButton;
        private Controls.AMButton restartTestButton;
        private Controls.AMButton uacRequestTestButton;
        private Controls.AMButton jsonTestButton;
        private Controls.AMButton taskDialogTest;
        private Controls.AMButton runtimeFunctionTestButton;
    }
}