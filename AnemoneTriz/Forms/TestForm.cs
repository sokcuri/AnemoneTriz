using SharpCompress.Archives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SharpCompress.Readers;
using System.Security.Principal;
using System.Net;
using Newtonsoft.Json;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AnemoneTriz.Forms
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void decompTestButton_Click(object sender, EventArgs e)
        {
            string exePath = AppDomain.CurrentDomain.BaseDirectory + "pdf2png.zip";
           
            try
            {
                using (Stream stream = File.OpenRead(exePath))
                using (var archive = ArchiveFactory.Open(stream))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory("extract", new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
            }
            // 파일이 존재하지 않음
            catch(DirectoryNotFoundException)
            {
                MessageBox.Show("파일이 존재하지 않습니다");
            }
            // 압축 파일이 아님
            catch(InvalidOperationException exception)
            {
                MessageBox.Show(exception.Data.ToString() + exception.Message);
            }

        }

        private void restartTestButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void uacRequestTestButton_Click(object sender, EventArgs e)
        {
            WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);

            if (!hasAdministrativeRight)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = true;
                startInfo.WorkingDirectory = Environment.CurrentDirectory;
                startInfo.FileName = Application.ExecutablePath;
                startInfo.Verb = "runas";
                try
                {
                    Process p = Process.Start(startInfo);
                    Application.Exit();
                }
                catch (Win32Exception)
                {
                    MessageBox.Show("UAC 실행 실패");
                    return;
                }
            }
        }
        public static async Task<List<T>> GetResponseAsync<T>(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

            Stream stream = response.GetResponseStream();
            StreamReader strReader = new StreamReader(stream);
            string text = await strReader.ReadToEndAsync();

            return JsonConvert.DeserializeObject<List<T>>(text);
        }

        public static async Task<string> GetResponseAsync(string url)
        {
            HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
            var response = await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null) as HttpWebResponse;

            Stream stream = response.GetResponseStream();
            StreamReader strReader = new StreamReader(stream);
            string text = await strReader.ReadToEndAsync();

            return text;
        }

        private async void jsonTestButton_Click(object sender, EventArgs e)
        {
            var task = GetResponseAsync("http://www.redmine.org/issues.json");
            var text = await task;
            MessageBox.Show(text);
        }

        private void taskDialogTest_Jinsei_Click(object sender, EventArgs e)
        {
            TaskDialog taskDialog = new TaskDialog();
            taskDialog.Caption = "인생에 대해서..";
            taskDialog.InstructionText = "야겜안하는 애들이 사랑이 뭔지나 알겠냐";

            taskDialog.HyperlinksEnabled = true;
            taskDialog.Text = "기껏해야 밖에서도 힘싸움하고 애들 밟고 까이고 떠들고 웃고 즐기기나 하겠지. " +
                              "남자가 여자를 사랑한다는 그 참된 의미를 이해나 하겠냐? " +
                              "슬퍼서 눈물 흘린다는 말의 참의미를 깨달을수나 있겠냐? " +
                              "야겜 안하는새끼는 나중에 커서 지 부모도 잡아먹을새끼가 틀림없어. " +
                              "내가 보증한다. " +
                              "<a href=\"test\">개새끼들...</a>";

            taskDialog.FooterCheckBoxText = "이런거 이제 그만 보여줘요";
            taskDialog.FooterCheckBoxChecked = false;

            TaskDialogButton okButton = new TaskDialogButton("okButton", "그르네");
            okButton.Click += (s, ev) => MessageBox.Show("맞어!");

            TaskDialogButton closeButton = new TaskDialogButton("closeButton", "먼 개소리를");
            closeButton.Click += (s, ev) => taskDialog.Close();

            taskDialog.Controls.Add(okButton);
            taskDialog.Controls.Add(closeButton);

            TaskDialogResult result = taskDialog.Show();
        }
        
        private void taskDialogTest_Click(object sender, EventArgs e)
        {
            TaskDialog taskDialog = new TaskDialog()
            {
                Icon = TaskDialogStandardIcon.Information,
                Caption = "아네모네 트리즈 자동 업데이트",
                InstructionText = "아네모네 트리즈 업데이트가 있습니다",
                DetailsCollapsedLabel = "펼치기",
                DetailsExpandedLabel = "접기",
                DetailsExpandedText = "",
                Text = "업데이트를 진행할까요?"
            };

            var updateText = "<a href=\"http://sokcuri.neko.kr/anemone\">아네모네 트리즈 (3.00.170628)</a>\n\n";
            updateText += "자동 업데이트 테스트";
            taskDialog.Opened += (s, ev) =>
            {
                TaskDialog td = s as TaskDialog;
                td.Icon = TaskDialogStandardIcon.Information;
            };
            taskDialog.ExpansionMode = TaskDialogExpandedDetailsLocation.ExpandFooter;
            taskDialog.DetailsExpandedText = updateText;
            taskDialog.HyperlinksEnabled = true;
            taskDialog.DetailsExpanded = true;
            taskDialog.ProgressBar = new TaskDialogProgressBar();
            taskDialog.ProgressBar.State = TaskDialogProgressBarState.Paused;
            taskDialog.ProgressBar.Value = 100;
            taskDialog.Tick += (s, ev) =>
            {
            };
            taskDialog.HyperlinkClick += (s, ev) =>
            {
                if (ev.LinkText.ToLower().IndexOf("http://") != -1)
                    System.Diagnostics.Process.Start(ev.LinkText); 
            };
            /*
             * * Use TaskDialogCommandLInk * *
            TaskDialogCommandLink updateLink = new TaskDialogCommandLink("updateLink", "업데이트를 진행합니다")
            {
                UseElevationIcon = true,
                Instruction = "업데이트를 진행해주시면 더 열심히 개발하겠습니다. 약속할게요"
            };
            TaskDialogCommandLink noUpdateLink = new TaskDialogCommandLink("noUpdateLink", "업데이트를 하지 않기");
            
            noUpdateLink.Click += (s, ev) => taskDialog.Close();
            taskDialog.Controls.Add(updateLink);
            taskDialog.Controls.Add(noUpdateLink);
            */
            
            TaskDialogButton updateButton = new TaskDialogButton("updateButton", "업데이트");
            TaskDialogButton noUpdateButton = new TaskDialogButton("noUpdateButton", "취소");
            taskDialog.Controls.Add(updateButton);
            taskDialog.Controls.Add(noUpdateButton);
            noUpdateButton.Click += (s, ev) => taskDialog.Close();

            updateButton.Click += (s, ev) =>
            {
                var progress = taskDialog.ProgressBar;
                progress.State = TaskDialogProgressBarState.Normal;
                progress.Value = 0;
                Timer timer = new Timer();
                timer.Interval = 100;
                timer.Tick += (ts, tev) =>
                {
                    if (progress.Value + 1 < 100)
                    {
                        progress.Value += 1;
                    }
                    else
                    {
                        progress.Value = 100;
                        timer.Stop();
                        timer.Dispose();

                        MessageBox.Show("업데이트 완료");
                        taskDialog.Close();
                    }
                };
                timer.Start();
            };
            
            TaskDialogResult result = taskDialog.Show();
        }
    }
}