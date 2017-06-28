using AnemoneTriz.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace AnemoneTriz.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textModeButton = new AnemoneTriz.Controls.AMButton();
            this.ocrModeButton = new AnemoneTriz.Controls.AMButton();
            this.clipModeButton = new AnemoneTriz.Controls.AMButton();
            this.gameModeButton = new AnemoneTriz.Controls.AMButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FIleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TranslateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShortTranslateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileTranslateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.환경설정OToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AnemoneTrizAboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.번역TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.아네모네트리즈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.단문번역하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일번역하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testFormButton = new AnemoneTriz.Controls.AMButton();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.textModeButton);
            this.panel1.Controls.Add(this.ocrModeButton);
            this.panel1.Controls.Add(this.clipModeButton);
            this.panel1.Controls.Add(this.gameModeButton);
            this.panel1.Location = new System.Drawing.Point(52, 95);
            this.panel1.MinimumSize = new System.Drawing.Size(564, 109);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(565, 109);
            this.panel1.TabIndex = 2;
            // 
            // textModeButton
            // 
            this.textModeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textModeButton.BackColor = System.Drawing.Color.White;
            this.textModeButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.textModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.textModeButton.HighlightColor = System.Drawing.Color.Violet;
            this.textModeButton.Image = global::AnemoneTriz.Properties.Resources.text_icon;
            this.textModeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.textModeButton.Location = new System.Drawing.Point(430, 4);
            this.textModeButton.Name = "textModeButton";
            this.textModeButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.textModeButton.Size = new System.Drawing.Size(130, 100);
            this.textModeButton.TabIndex = 4;
            this.textModeButton.Text = "텍스트 모드";
            this.textModeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.textModeButton.UseVisualStyleBackColor = false;
            // 
            // ocrModeButton
            // 
            this.ocrModeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ocrModeButton.BackColor = System.Drawing.Color.White;
            this.ocrModeButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.ocrModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ocrModeButton.HighlightColor = System.Drawing.Color.Aqua;
            this.ocrModeButton.Image = global::AnemoneTriz.Properties.Resources.ocr_jap_icon;
            this.ocrModeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ocrModeButton.Location = new System.Drawing.Point(288, 4);
            this.ocrModeButton.Name = "ocrModeButton";
            this.ocrModeButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.ocrModeButton.Size = new System.Drawing.Size(130, 100);
            this.ocrModeButton.TabIndex = 3;
            this.ocrModeButton.Text = "OCR 모드";
            this.ocrModeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ocrModeButton.UseVisualStyleBackColor = false;
            // 
            // clipModeButton
            // 
            this.clipModeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clipModeButton.BackColor = System.Drawing.Color.White;
            this.clipModeButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.clipModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clipModeButton.HighlightColor = System.Drawing.Color.Gold;
            this.clipModeButton.Image = global::AnemoneTriz.Properties.Resources.clipboard_icon;
            this.clipModeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.clipModeButton.Location = new System.Drawing.Point(146, 4);
            this.clipModeButton.Name = "clipModeButton";
            this.clipModeButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.clipModeButton.Size = new System.Drawing.Size(130, 100);
            this.clipModeButton.TabIndex = 2;
            this.clipModeButton.Text = "클립보드 모드";
            this.clipModeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.clipModeButton.UseVisualStyleBackColor = false;
            // 
            // gameModeButton
            // 
            this.gameModeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gameModeButton.BackColor = System.Drawing.Color.White;
            this.gameModeButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.gameModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gameModeButton.HighlightColor = System.Drawing.Color.Tomato;
            this.gameModeButton.Image = global::AnemoneTriz.Properties.Resources.computer_icon;
            this.gameModeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.gameModeButton.Location = new System.Drawing.Point(4, 4);
            this.gameModeButton.Name = "gameModeButton";
            this.gameModeButton.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.gameModeButton.Size = new System.Drawing.Size(129, 100);
            this.gameModeButton.TabIndex = 1;
            this.gameModeButton.Text = "게임 모드";
            this.gameModeButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.gameModeButton.UseVisualStyleBackColor = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FIleMenuItem,
            this.TranslateMenuItem,
            this.ToolMenuItem,
            this.AboutMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FIleMenuItem
            // 
            this.FIleMenuItem.Name = "FIleMenuItem";
            this.FIleMenuItem.Size = new System.Drawing.Size(57, 20);
            this.FIleMenuItem.Text = "파일(&F)";
            // 
            // TranslateMenuItem
            // 
            this.TranslateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShortTranslateMenuItem,
            this.FileTranslateMenuItem});
            this.TranslateMenuItem.Name = "TranslateMenuItem";
            this.TranslateMenuItem.Size = new System.Drawing.Size(57, 20);
            this.TranslateMenuItem.Text = "번역(&T)";
            // 
            // ShortTranslateMenuItem
            // 
            this.ShortTranslateMenuItem.Name = "ShortTranslateMenuItem";
            this.ShortTranslateMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ShortTranslateMenuItem.Text = "단문 번역하기(&S)";
            this.ShortTranslateMenuItem.Click += new System.EventHandler(this.ShortTranslateMenuItem_Click);
            // 
            // FileTranslateMenuItem
            // 
            this.FileTranslateMenuItem.Name = "FileTranslateMenuItem";
            this.FileTranslateMenuItem.Size = new System.Drawing.Size(165, 22);
            this.FileTranslateMenuItem.Text = "파일 번역하기(&F)";
            // 
            // ToolMenuItem
            // 
            this.ToolMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.환경설정OToolStripMenuItem});
            this.ToolMenuItem.Name = "ToolMenuItem";
            this.ToolMenuItem.Size = new System.Drawing.Size(60, 20);
            this.ToolMenuItem.Text = "도구(&O)";
            // 
            // 환경설정OToolStripMenuItem
            // 
            this.환경설정OToolStripMenuItem.Name = "환경설정OToolStripMenuItem";
            this.환경설정OToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.환경설정OToolStripMenuItem.Text = "환경설정(&O)";
            // 
            // AboutMenuItem
            // 
            this.AboutMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AnemoneTrizAboutMenuItem});
            this.AboutMenuItem.Name = "AboutMenuItem";
            this.AboutMenuItem.Size = new System.Drawing.Size(59, 20);
            this.AboutMenuItem.Text = "정보(&A)";
            // 
            // AnemoneTrizAboutMenuItem
            // 
            this.AnemoneTrizAboutMenuItem.Name = "AnemoneTrizAboutMenuItem";
            this.AnemoneTrizAboutMenuItem.Size = new System.Drawing.Size(162, 22);
            this.AnemoneTrizAboutMenuItem.Text = "아네모네 트리즈";
            this.AnemoneTrizAboutMenuItem.Click += new System.EventHandler(this.AnemoneTrizAboutMenuItem_Click);
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 번역TToolStripMenuItem
            // 
            this.번역TToolStripMenuItem.Name = "번역TToolStripMenuItem";
            this.번역TToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.번역TToolStripMenuItem.Text = "번역(&T)";
            // 
            // 정보AToolStripMenuItem
            // 
            this.정보AToolStripMenuItem.Name = "정보AToolStripMenuItem";
            this.정보AToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.정보AToolStripMenuItem.Text = "정보(&A)";
            // 
            // 아네모네트리즈ToolStripMenuItem
            // 
            this.아네모네트리즈ToolStripMenuItem.Name = "아네모네트리즈ToolStripMenuItem";
            this.아네모네트리즈ToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.아네모네트리즈ToolStripMenuItem.Text = "아네모네 트리즈";
            // 
            // 단문번역하기ToolStripMenuItem
            // 
            this.단문번역하기ToolStripMenuItem.Name = "단문번역하기ToolStripMenuItem";
            this.단문번역하기ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.단문번역하기ToolStripMenuItem.Text = "단문 번역하기";
            // 
            // 파일번역하기ToolStripMenuItem
            // 
            this.파일번역하기ToolStripMenuItem.Name = "파일번역하기ToolStripMenuItem";
            this.파일번역하기ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.파일번역하기ToolStripMenuItem.Text = "파일 번역하기";
            // 
            // testFormButton
            // 
            this.testFormButton.BackColor = System.Drawing.Color.White;
            this.testFormButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.testFormButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testFormButton.HighlightColor = System.Drawing.Color.Silver;
            this.testFormButton.Location = new System.Drawing.Point(0, 27);
            this.testFormButton.Name = "testFormButton";
            this.testFormButton.Size = new System.Drawing.Size(75, 23);
            this.testFormButton.TabIndex = 4;
            this.testFormButton.Text = "Test Form";
            this.testFormButton.UseVisualStyleBackColor = false;
            this.testFormButton.Click += new System.EventHandler(this.testFormButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(684, 301);
            this.Controls.Add(this.testFormButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 340);
            this.Name = "MainForm";
            this.Text = "아네모네 트리즈";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 번역TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 단문번역하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일번역하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 아네모네트리즈ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FIleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TranslateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShortTranslateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileTranslateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AnemoneTrizAboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 환경설정OToolStripMenuItem;
        private AMButton textModeButton;
        private AMButton ocrModeButton;
        private AMButton clipModeButton;
        private AMButton gameModeButton;
        private AMButton testFormButton;
    }
}

