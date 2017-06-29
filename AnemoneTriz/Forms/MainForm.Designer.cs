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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textModeButton = new AnemoneTriz.Controls.AMButton();
            this.ocrModeButton = new AnemoneTriz.Controls.AMButton();
            this.clipModeButton = new AnemoneTriz.Controls.AMButton();
            this.gameModeButton = new AnemoneTriz.Controls.AMButton();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem_shortTranslate = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem_developTestForm = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem_aboutAnemoneTriz = new System.Windows.Forms.MenuItem();
            this.menuItem_openInstallFolder = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem_openHomepageURL = new System.Windows.Forms.MenuItem();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.번역TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.아네모네트리즈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.단문번역하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일번역하기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
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
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem3,
            this.menuItem2,
            this.menuItem4});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "파일(&F)";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_shortTranslate,
            this.menuItem10});
            this.menuItem3.Text = "번역(&T)";
            // 
            // menuItem_shortTranslate
            // 
            this.menuItem_shortTranslate.Index = 0;
            this.menuItem_shortTranslate.Text = "단문 번역(&T)";
            this.menuItem_shortTranslate.Click += new System.EventHandler(this.menuItem_shortTranslate_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 1;
            this.menuItem10.Text = "텍스트 번역(&F)";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7});
            this.menuItem2.Text = "도구(&T)";
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "환경 설정(&O)";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_developTestForm});
            this.menuItem7.Text = "개발자 도구(&D)";
            // 
            // menuItem_developTestForm
            // 
            this.menuItem_developTestForm.Index = 0;
            this.menuItem_developTestForm.Text = "테스트 폼(&T)";
            this.menuItem_developTestForm.Click += new System.EventHandler(this.menuItem_developTestForm_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_aboutAnemoneTriz,
            this.menuItem_openInstallFolder,
            this.menuItem8,
            this.menuItem_openHomepageURL});
            this.menuItem4.Text = "도움말(&A)";
            // 
            // menuItem_aboutAnemoneTriz
            // 
            this.menuItem_aboutAnemoneTriz.Index = 0;
            this.menuItem_aboutAnemoneTriz.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuItem_aboutAnemoneTriz.Text = "아네모네 트리즈";
            this.menuItem_aboutAnemoneTriz.Click += new System.EventHandler(this.menuItem_aboutAnemoneTriz_Click);
            // 
            // menuItem_openInstallFolder
            // 
            this.menuItem_openInstallFolder.Index = 1;
            this.menuItem_openInstallFolder.Text = "프로그램 설치 폴더 열기";
            this.menuItem_openInstallFolder.Click += new System.EventHandler(this.menuItem_openInstallFolder_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "-";
            // 
            // menuItem_openHomepageURL
            // 
            this.menuItem_openHomepageURL.Index = 3;
            this.menuItem_openHomepageURL.Text = "홈페이지 열기";
            this.menuItem_openHomepageURL.Click += new System.EventHandler(this.menuItem_openHomepageURL_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(684, 301);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.MinimumSize = new System.Drawing.Size(700, 340);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "아네모네 트리즈";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 번역TToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 단문번역하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일번역하기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 아네모네트리즈ToolStripMenuItem;
        private AMButton textModeButton;
        private AMButton ocrModeButton;
        private AMButton clipModeButton;
        private AMButton gameModeButton;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem6;
        private MenuItem menuItem4;
        private MenuItem menuItem_aboutAnemoneTriz;
        private MenuItem menuItem_shortTranslate;
        private MenuItem menuItem10;
        private MenuItem menuItem7;
        private MenuItem menuItem_developTestForm;
        private MenuItem menuItem_openInstallFolder;
        private MenuItem menuItem8;
        private MenuItem menuItem_openHomepageURL;
    }
}

