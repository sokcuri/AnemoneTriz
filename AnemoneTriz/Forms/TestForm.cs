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
using AnemoneTriz.Update;

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
            try
            {
                File.Copy(Application.ExecutablePath, $"{AppDomain.CurrentDomain.BaseDirectory}\\Update\\AnemoneTriz.exe", true);
            }
            catch
            {
                MessageBox.Show("파일 복사가 실패했습니다.");
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = $"{AppDomain.CurrentDomain.BaseDirectory}\\Update\\AnemoneTriz.exe";
            startInfo.Verb = "runas";

            string newerVersion = "3.0.0.629";

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string olderVersion = fvi.FileVersion;

            startInfo.Arguments = $"--updating " +
                                  $"--olderVersion:\"{Convert.ToBase64String(Encoding.UTF8.GetBytes(olderVersion))}\" " +
                                  $"--newerVersion:\"{Convert.ToBase64String(Encoding.UTF8.GetBytes(newerVersion))}\" " +
                                  $"--BaseDirectory:\"{Convert.ToBase64String(Encoding.UTF8.GetBytes(AppDomain.CurrentDomain.BaseDirectory))}\" " +
                                  $"--CurrentDirectory:\"{Convert.ToBase64String(Encoding.UTF8.GetBytes(Environment.CurrentDirectory))}\" " +
                                  $"--PID:\"{Convert.ToBase64String(Encoding.UTF8.GetBytes(Process.GetCurrentProcess().Id.ToString()))}\" " +
                                  $"--ExePath:\"{Convert.ToBase64String(Encoding.UTF8.GetBytes(Application.ExecutablePath))}\" " +
                                  $"--AppPath:\"{Convert.ToBase64String(Encoding.UTF8.GetBytes(Application.StartupPath))}\"";

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

        private void updateTestButton_Click(object sender, EventArgs e)
        {
            UpdateCheck.CreateUpdateWindow();
        }
    }
}