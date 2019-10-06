using AnemoneTriz.Controls;
using System.Drawing;

namespace AnemoneTriz.Forms
{
    partial class ShortTransBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShortTransBox));
            this.layoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.headerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.topActiveBar = new System.Windows.Forms.TableLayoutPanel();
            this.headerSeparator1 = new System.Windows.Forms.TableLayoutPanel();
            this.headerSeparator2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSelectLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.srcLangButton = new AnemoneTriz.Controls.AMButton();
            this.langSwapButton = new AnemoneTriz.Controls.AMButton();
            this.destLangButton = new AnemoneTriz.Controls.AMButton();
            this.translateButton = new AnemoneTriz.Controls.AMButton();
            this.destBoxPanel = new System.Windows.Forms.TableLayoutPanel();
            this.destTextBox = new System.Windows.Forms.RichTextBox();
            this.srcBoxPanel = new System.Windows.Forms.TableLayoutPanel();
            this.srcTextBox = new System.Windows.Forms.RichTextBox();
            this.layoutPanel.SuspendLayout();
            this.headerLayout.SuspendLayout();
            this.headerLayoutPanel.SuspendLayout();
            this.buttonSelectLayoutPanel.SuspendLayout();
            this.destBoxPanel.SuspendLayout();
            this.srcBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutPanel
            // 
            this.layoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutPanel.BackColor = System.Drawing.Color.Transparent;
            this.layoutPanel.ColumnCount = 3;
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.layoutPanel.Controls.Add(this.headerLayout, 0, 0);
            this.layoutPanel.Controls.Add(this.headerSeparator1, 0, 1);
            this.layoutPanel.Controls.Add(this.headerSeparator2, 0, 2);
            this.layoutPanel.Controls.Add(this.buttonSelectLayoutPanel, 1, 4);
            this.layoutPanel.Controls.Add(this.destBoxPanel, 1, 8);
            this.layoutPanel.Controls.Add(this.srcBoxPanel, 1, 6);
            this.layoutPanel.Location = new System.Drawing.Point(0, 0);
            this.layoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.layoutPanel.Name = "layoutPanel";
            this.layoutPanel.RowCount = 10;
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.layoutPanel.Size = new System.Drawing.Size(634, 643);
            this.layoutPanel.TabIndex = 1;
            // 
            // headerLayout
            // 
            this.headerLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLayout.BackColor = System.Drawing.Color.White;
            this.headerLayout.ColumnCount = 1;
            this.layoutPanel.SetColumnSpan(this.headerLayout, 3);
            this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerLayout.Controls.Add(this.headerLayoutPanel, 0, 0);
            this.headerLayout.Location = new System.Drawing.Point(0, 0);
            this.headerLayout.Margin = new System.Windows.Forms.Padding(0);
            this.headerLayout.Name = "headerLayout";
            this.headerLayout.RowCount = 1;
            this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerLayout.Size = new System.Drawing.Size(634, 45);
            this.headerLayout.TabIndex = 3;
            // 
            // headerLayoutPanel
            // 
            this.headerLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.headerLayoutPanel.ColumnCount = 6;
            this.headerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.headerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.headerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.headerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.headerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.headerLayoutPanel.Controls.Add(this.label3, 3, 0);
            this.headerLayoutPanel.Controls.Add(this.label2, 2, 0);
            this.headerLayoutPanel.Controls.Add(this.label1, 1, 0);
            this.headerLayoutPanel.Controls.Add(this.topActiveBar, 1, 1);
            this.headerLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.headerLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.headerLayoutPanel.Name = "headerLayoutPanel";
            this.headerLayoutPanel.RowCount = 2;
            this.headerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.headerLayoutPanel.Size = new System.Drawing.Size(634, 45);
            this.headerLayoutPanel.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(266, 14);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.label3.Size = new System.Drawing.Size(91, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "네이버 파파고";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(161, 14);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.label2.Size = new System.Drawing.Size(65, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "구글 번역";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(53, 14);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "이지트랜스";
            // 
            // topActiveBar
            // 
            this.topActiveBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.topActiveBar.BackColor = System.Drawing.Color.OrangeRed;
            this.topActiveBar.ColumnCount = 1;
            this.topActiveBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topActiveBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topActiveBar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.topActiveBar.Location = new System.Drawing.Point(40, 43);
            this.topActiveBar.Margin = new System.Windows.Forms.Padding(0);
            this.topActiveBar.Name = "topActiveBar";
            this.topActiveBar.RowCount = 1;
            this.topActiveBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topActiveBar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topActiveBar.Size = new System.Drawing.Size(100, 2);
            this.topActiveBar.TabIndex = 1;
            // 
            // headerSeparator1
            // 
            this.headerSeparator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.headerSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(201)))), ((int)(((byte)(204)))));
            this.headerSeparator1.ColumnCount = 1;
            this.layoutPanel.SetColumnSpan(this.headerSeparator1, 3);
            this.headerSeparator1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerSeparator1.Location = new System.Drawing.Point(0, 45);
            this.headerSeparator1.Margin = new System.Windows.Forms.Padding(0);
            this.headerSeparator1.Name = "headerSeparator1";
            this.headerSeparator1.RowCount = 1;
            this.headerSeparator1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerSeparator1.Size = new System.Drawing.Size(634, 1);
            this.headerSeparator1.TabIndex = 4;
            // 
            // headerSeparator2
            // 
            this.headerSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.headerSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(224)))), ((int)(((byte)(228)))));
            this.headerSeparator2.ColumnCount = 1;
            this.layoutPanel.SetColumnSpan(this.headerSeparator2, 3);
            this.headerSeparator2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerSeparator2.Location = new System.Drawing.Point(0, 46);
            this.headerSeparator2.Margin = new System.Windows.Forms.Padding(0);
            this.headerSeparator2.Name = "headerSeparator2";
            this.headerSeparator2.RowCount = 1;
            this.headerSeparator2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.headerSeparator2.Size = new System.Drawing.Size(634, 1);
            this.headerSeparator2.TabIndex = 5;
            // 
            // buttonSelectLayoutPanel
            // 
            this.buttonSelectLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSelectLayoutPanel.ColumnCount = 5;
            this.buttonSelectLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.buttonSelectLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.buttonSelectLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.buttonSelectLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buttonSelectLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.buttonSelectLayoutPanel.Controls.Add(this.srcLangButton, 0, 0);
            this.buttonSelectLayoutPanel.Controls.Add(this.langSwapButton, 1, 0);
            this.buttonSelectLayoutPanel.Controls.Add(this.destLangButton, 2, 0);
            this.buttonSelectLayoutPanel.Controls.Add(this.translateButton, 4, 0);
            this.buttonSelectLayoutPanel.Location = new System.Drawing.Point(40, 72);
            this.buttonSelectLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectLayoutPanel.Name = "buttonSelectLayoutPanel";
            this.buttonSelectLayoutPanel.RowCount = 1;
            this.buttonSelectLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.buttonSelectLayoutPanel.Size = new System.Drawing.Size(554, 35);
            this.buttonSelectLayoutPanel.TabIndex = 6;
            // 
            // srcLangButton
            // 
            this.srcLangButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(116)))), ((int)(((byte)(138)))));
            this.srcLangButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.srcLangButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.srcLangButton.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.srcLangButton.ForeColor = System.Drawing.Color.White;
            this.srcLangButton.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.srcLangButton.Location = new System.Drawing.Point(0, 0);
            this.srcLangButton.Margin = new System.Windows.Forms.Padding(0);
            this.srcLangButton.Name = "srcLangButton";
            this.srcLangButton.Size = new System.Drawing.Size(84, 35);
            this.srcLangButton.TabIndex = 0;
            this.srcLangButton.Text = "일본어";
            this.srcLangButton.UseVisualStyleBackColor = true;
            // 
            // langSwapButton
            // 
            this.langSwapButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(116)))), ((int)(((byte)(138)))));
            this.langSwapButton.BackgroundImage = global::AnemoneTriz.Properties.Resources.swap_icon;
            this.langSwapButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.langSwapButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.langSwapButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.langSwapButton.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.langSwapButton.ForeColor = System.Drawing.Color.White;
            this.langSwapButton.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.langSwapButton.Location = new System.Drawing.Point(84, 0);
            this.langSwapButton.Margin = new System.Windows.Forms.Padding(0);
            this.langSwapButton.Name = "langSwapButton";
            this.langSwapButton.Size = new System.Drawing.Size(44, 35);
            this.langSwapButton.TabIndex = 0;
            this.langSwapButton.UseVisualStyleBackColor = true;
            this.langSwapButton.Click += new System.EventHandler(this.langSwapButton_Click);
            // 
            // destLangButton
            // 
            this.destLangButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(116)))), ((int)(((byte)(138)))));
            this.destLangButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(104)))), ((int)(((byte)(124)))));
            this.destLangButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.destLangButton.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destLangButton.ForeColor = System.Drawing.Color.White;
            this.destLangButton.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.destLangButton.Location = new System.Drawing.Point(128, 0);
            this.destLangButton.Margin = new System.Windows.Forms.Padding(0);
            this.destLangButton.Name = "destLangButton";
            this.destLangButton.Size = new System.Drawing.Size(84, 35);
            this.destLangButton.TabIndex = 0;
            this.destLangButton.Text = "한국어";
            this.destLangButton.UseVisualStyleBackColor = true;
            // 
            // translateButton
            // 
            this.translateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(166)))), ((int)(((byte)(248)))));
            this.translateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(160)))), ((int)(((byte)(236)))));
            this.translateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.translateButton.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.translateButton.ForeColor = System.Drawing.Color.White;
            this.translateButton.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.translateButton.Location = new System.Drawing.Point(454, 0);
            this.translateButton.Margin = new System.Windows.Forms.Padding(0);
            this.translateButton.Name = "translateButton";
            this.translateButton.Size = new System.Drawing.Size(100, 35);
            this.translateButton.TabIndex = 0;
            this.translateButton.Text = "번역하기";
            this.translateButton.UseVisualStyleBackColor = false;
            // 
            // destBoxPanel
            // 
            this.destBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destBoxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.destBoxPanel.ColumnCount = 1;
            this.destBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.destBoxPanel.Controls.Add(this.destTextBox, 0, 0);
            this.destBoxPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.destBoxPanel.Location = new System.Drawing.Point(40, 377);
            this.destBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.destBoxPanel.Name = "destBoxPanel";
            this.destBoxPanel.Padding = new System.Windows.Forms.Padding(1);
            this.destBoxPanel.RowCount = 1;
            this.destBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.destBoxPanel.Size = new System.Drawing.Size(554, 230);
            this.destBoxPanel.TabIndex = 7;
            // 
            // destTextBox
            // 
            this.destTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.destTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.destTextBox.DetectUrls = false;
            this.destTextBox.Location = new System.Drawing.Point(1, 1);
            this.destTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.destTextBox.Name = "destTextBox";
            this.destTextBox.ShortcutsEnabled = false;
            this.destTextBox.Size = new System.Drawing.Size(552, 228);
            this.destTextBox.TabIndex = 0;
            this.destTextBox.Text = "";
            // 
            // srcBoxPanel
            // 
            this.srcBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.srcBoxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.srcBoxPanel.ColumnCount = 1;
            this.srcBoxPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.srcBoxPanel.Controls.Add(this.srcTextBox, 0, 0);
            this.srcBoxPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.srcBoxPanel.Location = new System.Drawing.Point(40, 122);
            this.srcBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.srcBoxPanel.Name = "srcBoxPanel";
            this.srcBoxPanel.Padding = new System.Windows.Forms.Padding(1);
            this.srcBoxPanel.RowCount = 1;
            this.srcBoxPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.srcBoxPanel.Size = new System.Drawing.Size(554, 230);
            this.srcBoxPanel.TabIndex = 7;
            // 
            // srcTextBox
            // 
            this.srcTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.srcTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.srcTextBox.DetectUrls = false;
            this.srcTextBox.Location = new System.Drawing.Point(1, 1);
            this.srcTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.srcTextBox.Name = "srcTextBox";
            this.srcTextBox.ShortcutsEnabled = false;
            this.srcTextBox.Size = new System.Drawing.Size(552, 228);
            this.srcTextBox.TabIndex = 0;
            this.srcTextBox.Text = "";
            // 
            // ShortTransBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(236)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(634, 641);
            this.Controls.Add(this.layoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(460, 485);
            this.Name = "ShortTransBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "아네모네 트리즈 - 단문번역창";
            this.Shown += new System.EventHandler(this.ShortTransBox_Shown);
            this.layoutPanel.ResumeLayout(false);
            this.headerLayout.ResumeLayout(false);
            this.headerLayoutPanel.ResumeLayout(false);
            this.headerLayoutPanel.PerformLayout();
            this.buttonSelectLayoutPanel.ResumeLayout(false);
            this.destBoxPanel.ResumeLayout(false);
            this.srcBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel layoutPanel;
        private System.Windows.Forms.TableLayoutPanel headerLayout;
        private System.Windows.Forms.TableLayoutPanel headerSeparator1;
        private System.Windows.Forms.TableLayoutPanel headerSeparator2;
        private System.Windows.Forms.TableLayoutPanel buttonSelectLayoutPanel;
        private AMButton srcLangButton;
        private AMButton langSwapButton;
        private AMButton destLangButton;
        private AMButton translateButton;
        private System.Windows.Forms.TableLayoutPanel destBoxPanel;
        private System.Windows.Forms.RichTextBox destTextBox;
        private System.Windows.Forms.TableLayoutPanel srcBoxPanel;
        private System.Windows.Forms.RichTextBox srcTextBox;
        private System.Windows.Forms.TableLayoutPanel headerLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel topActiveBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}