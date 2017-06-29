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
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;
using System.Net.Cache;
using static AnemoneTriz.Interop.NativeMethods;

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
        
        private void manualRestartTestButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
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
                MessageBox.Show("재시작 실패");
                return;
            }
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
            // 존재하는 캐시 지우기
            DeleteUrlCacheEntry(url);

            // 캐시 저장안함 폴리시를 리퀘스트에 설정
            HttpRequestCachePolicy cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CachePolicy = cachePolicy;

            var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);

            Stream stream = response.GetResponseStream();
            StreamReader strReader = new StreamReader(stream);
            string text = await strReader.ReadToEndAsync();

            return JsonConvert.DeserializeObject<List<T>>(text);
        }

        public static async Task<string> GetResponseAsync(string url)
        {
            // 존재하는 캐시 지우기
            DeleteUrlCacheEntry(url);

            // 캐시 저장안함 폴리시를 리퀘스트에 설정
            HttpRequestCachePolicy cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CachePolicy = cachePolicy;

            var response = await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null) as HttpWebResponse;

            Stream stream = response.GetResponseStream();
            StreamReader strReader = new StreamReader(stream);
            string text = await strReader.ReadToEndAsync();

            return text;
        }

        public static async Task<bool> GetDownloadAsync(string url, TaskDialog taskDialog)
        {
            // 존재하는 캐시 지우기
            DeleteUrlCacheEntry(url);

            // 캐시 저장안함 폴리시를 리퀘스트에 설정
            HttpRequestCachePolicy cachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.CachePolicy = cachePolicy;
            
            var response = await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null) as HttpWebResponse;
            long contentLength = response.ContentLength;
            taskDialog.ProgressBar.Maximum = 100;

            Stream stream = response.GetResponseStream();

            bool success = await Task<bool>.Run(() =>
            {
                long receivedBytes = 0;
                byte[] buffer = new byte[8 * 1024];
                int len;

                try
                {
                    using (var output = new FileStream("update.zip", FileMode.Create, FileAccess.Write))
                    while ((len = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        receivedBytes += len;
                        var percentage = ((double)receivedBytes * 100.0) / contentLength;
                        if (taskDialog != null && taskDialog.ProgressBar != null)
                            taskDialog.ProgressBar.Value = Convert.ToInt32(percentage);

                        output.Write(buffer, 0, len);
                    }
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("업데이트 파일을 작성할 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            });
            if (!success)
            {
                taskDialog.ProgressBar.State = TaskDialogProgressBarState.Error;
                taskDialog.ProgressBar.Value = 100;
                return false;
            }
            taskDialog.ProgressBar.Value = 100;
            await Task.Delay(1000);
            return true;
        }
        
        private async void jsonTestButton_Click(object sender, EventArgs e)
        {
            var task = GetResponseAsync("http://www.redmine.org/issues.json");
            var text = await task;
            MessageBox.Show(text);
        }
        
        private void taskDialogTest_Click(object sender, EventArgs e)
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
        
        private void UpdateProcess(UpdateInfo updateInfo,  Func<TaskDialog, Task <bool>> updateFunc)
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

            var updateTitle = updateInfo.Title.Replace("{Version}", updateInfo.Version);
            if (updateInfo.Link != string.Empty)
                updateTitle = $"<a href=\"{updateInfo.Link}\">{updateTitle}</a>";

            var updateText = $"{updateTitle}\n\n{updateInfo.Content}";
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

            TaskDialogButton updateButton = new TaskDialogButton("updateButton", "업데이트");
            TaskDialogButton noUpdateButton = new TaskDialogButton("noUpdateButton", "취소");
            taskDialog.Controls.Add(updateButton);
            taskDialog.Controls.Add(noUpdateButton);
            noUpdateButton.Click += (s, ev) =>
            {
                taskDialog.Close();
            };

            updateButton.Click += async (s, ev) =>
            {
                if (await updateFunc(taskDialog))
                    taskDialog.Close();
            };

            TaskDialogResult result = taskDialog.Show();
        }

        private void runtimeFunctionTestButton_Click(object sender, EventArgs e)
        {
            string function_context = "x + 2 * y";
            string code = @"
                using System;
            
                namespace UserFunctions
                {                
                    public class BinaryFunction
                    {                
                        public static double Function(double x, double y)
                        {
                            return func_xy;
                        }
                    }
                }
            ";

            string finalCode = code.Replace("func_xy", function_context);

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults results = provider.CompileAssemblyFromSource(new CompilerParameters(), finalCode);

            Type binaryFunction = results.CompiledAssembly.GetType("UserFunctions.BinaryFunction");
            MethodInfo function = binaryFunction.GetMethod("Function");

            var betterFunction = (Func<double, double, double>)Delegate.CreateDelegate
            (typeof(Func<double, double, double>), function);

            MessageBox.Show($"{function_context} = {betterFunction(2, 3)}");
        }

        public class UpdateInfo
        {
            public string Title { get; set; }
            public string Version { get; set; }
            public string Target { get; set; }
            public string Link { get; set; }
            public string Content { get; set; }
        }

        private async void updateTestButton_Click(object sender, EventArgs e)
        {
            UpdateInfo updateInfo;
            string receiveText;
            try
            {
                // 업데이트 정보를 가져옴
                receiveText = await GetResponseAsync("https://raw.githubusercontent.com/sokcuri/AnemoneTriz/update/update.json");
                updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(receiveText);
                if (updateInfo == null)
                    throw new Exception("JSON Deserialize 실패");
            }
            catch (Exception exception)
            {
                MessageBox.Show($"업데이트 정보를 가져올 수 없습니다. {exception.Message}");
                return;
            }
            
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            UpdateProcess(updateInfo, async (taskDialog) =>
            {
                (taskDialog.Controls["updateButton"] as TaskDialogButton).Enabled = false;
                (taskDialog.Controls["noUpdateButton"] as TaskDialogButton).Enabled = false;

                taskDialog.ProgressBar.State = TaskDialogProgressBarState.Normal;
                taskDialog.ProgressBar.Value = 0;

                // 파일 다운로드
                bool success = await GetDownloadAsync("https://github.com/sokcuri/TweetDeckPlayer/releases/download/2.22/TweetDeckPlayer-v2.22-win32-x64.zip", taskDialog);

                if (!success)
                {
                    (taskDialog.Controls["updateButton"] as TaskDialogButton).Enabled = true;
                    (taskDialog.Controls["noUpdateButton"] as TaskDialogButton).Enabled = true;
                    taskDialog.ProgressBar.Value = 100;
                    return false;
                }
                return true;
            });
        }
    }
}