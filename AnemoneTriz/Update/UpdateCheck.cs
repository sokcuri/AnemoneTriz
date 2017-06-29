using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using SharpCompress.Archives;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AnemoneTriz.Interop.NativeMethods;

namespace AnemoneTriz.Update
{
    static class UpdateCheck
    {
        private static string updateURL = @"https://raw.githubusercontent.com/sokcuri/AnemoneTriz/update/update.json";
        private static string zipPath = $"{AppDomain.CurrentDomain.BaseDirectory}update.zip";
        private static string updateFolder = $"{AppDomain.CurrentDomain.BaseDirectory}Update\\";

        public static bool ForceRun { get; set; }
        public static bool UpdateShown { get; set; }
        private static object lockObject = new object();

        public class UpdateInfo
        {
            public string Title { get; set; }
            public string Version { get; set; }
            public string Target { get; set; }
            public string Link { get; set; }
            public string Content { get; set; }
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

            HttpWebResponse response;
            try
            {
                response = await Task.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null) as HttpWebResponse;
            }
            catch
            {
                MessageBox.Show($"업데이트 파일이 존재하지 않아 다운받을 수 없습니다.\n{url}", "업데이트 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                taskDialog.ProgressBar.State = TaskDialogProgressBarState.Error;
                taskDialog.ProgressBar.Value = 100;
                return false;
            }
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
                    using (var output = new FileStream(zipPath, FileMode.Create, FileAccess.Write))
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
        private static bool decompressUpdateFiles()
        {
            try
            {
                using (Stream stream = File.OpenRead(zipPath))
                using (var archive = ArchiveFactory.Open(stream))
                {
                    foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                    {
                        entry.WriteToDirectory(updateFolder, new ExtractionOptions()
                        {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
            }
            // 파일이 존재하지 않음
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("파일이 존재하지 않습니다");
                return false;
            }
            // 압축 파일이 아님
            catch (InvalidOperationException exception)
            {
                MessageBox.Show(exception.Data.ToString() + exception.Message);
                return false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
            return true;
        }

        private static bool runElevateAdmin()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas";
            startInfo.Arguments = "--update";
            try
            {
                Process p = Process.Start(startInfo);
                Application.Exit();
            }
            catch (Win32Exception)
            {
                MessageBox.Show("업데이트를 위해서는 관리자 권한이 필요합니다.\n업데이트 버튼을 다시 누른 후 관리자 권한을 요구하는 메시지에 \"예\"를 눌러주세요.", "업데이트 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private static bool runUpdateInstance()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
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
                MessageBox.Show("업데이트 파일의 실행을 실패했습니다.", "업데이트 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private static void UpdateProcess(UpdateInfo updateInfo, Func<TaskDialog, Task<bool>> updateFunc)
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
                if (ev.LinkText.ToLower().IndexOf("http://") != -1 || ev.LinkText.ToLower().IndexOf("https://") != -1)
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

            taskDialog.Tick += async (s, ev) =>
            {
                lock (lockObject)
                {
                    if (UpdateCheck.ForceRun)
                    {
                        UpdateCheck.ForceRun = false;
                    }
                    else
                    {
                        return;
                    }
                }
                if (await updateFunc(taskDialog))
                    taskDialog.Close();
            };

            TaskDialogResult result = taskDialog.Show();
        }

        public enum UpdateState : int
        {
            UNKNOWN,
            UPDATE_AVALIABLE,
            SERVER_NOT_REACHABLE,
            JSON_DESERIALIZE_FAILED,
            ALREADY_LATEST_VERSION,
            CURRENT_VERSION_GREATER
        }

        public static async void CheckUpdateAvaliable(Action<UpdateState> callback)
        {
            UpdateState state = UpdateState.UNKNOWN;
            UpdateInfo updateInfo = null;
            string receiveText;
            try
            {
                // 업데이트 정보를 가져옴
                receiveText = await GetResponseAsync($"{updateURL}?{Environment.TickCount}");
                updateInfo = JsonConvert.DeserializeObject<UpdateInfo>(receiveText);
                if (updateInfo == null)
                    state = UpdateState.JSON_DESERIALIZE_FAILED;
            }
            catch (Exception)
            {
                state = UpdateState.SERVER_NOT_REACHABLE;
            }

            if (state == UpdateState.UNKNOWN)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                var currentVersion = new Version(fvi.FileVersion);
                var serverVersion = new Version(updateInfo.Version);

                var result = currentVersion.CompareTo(serverVersion);
                if (result > 0)
                {
                    state = UpdateState.CURRENT_VERSION_GREATER;
                }
                else if (result < 0)
                {
                    state = UpdateState.UPDATE_AVALIABLE;
                }
                else
                {
                    state = UpdateState.ALREADY_LATEST_VERSION;
                }
            }
            if (callback != null)
                callback(state);
        }

        public static async void CreateUpdateWindow()
        {
            UpdateInfo updateInfo;
            string receiveText;
            try
            {
                // 업데이트 정보를 가져옴
                receiveText = await GetResponseAsync($"{updateURL}?{Environment.TickCount}");
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

            var updateDownloaded = false;

            UpdateProcess(updateInfo, async (taskDialog) =>
            {
                // 실행중인 프로세스가 관리자 권한인지 확인
                // 관리자 권한이 아닐 경우 관리자 권한을 요구함.
                WindowsPrincipal pricipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                bool hasAdministrativeRight = pricipal.IsInRole(WindowsBuiltInRole.Administrator);
                if (!hasAdministrativeRight)
                {
                    if (!runElevateAdmin())
                    {
                        (taskDialog.Controls["updateButton"] as TaskDialogButton).UseElevationIcon = true;
                        goto UpdateFailed;
                    }
                }

                // 업데이트 파일이 존재하는지 확인하고 없으면 재다운로드 시도
                if (updateDownloaded == true)
                {
                    if (!File.Exists($"{updateFolder}\\AnemoneTriz.exe"))
                    {
                        updateDownloaded = false;
                    }
                }

                // 업데이트 파일을 다운받은 상태면 바로 Update 파일 실행으로 건너뛴다
                if (updateDownloaded == false)
                {
                    (taskDialog.Controls["updateButton"] as TaskDialogButton).Enabled = false;
                    (taskDialog.Controls["noUpdateButton"] as TaskDialogButton).Enabled = false;
                    taskDialog.ProgressBar.State = TaskDialogProgressBarState.Normal;
                    taskDialog.ProgressBar.Value = 0;

                    // 파일 다운로드
                    if (!await GetDownloadAsync($"{updateInfo.Target}?{Environment.TickCount}", taskDialog))
                        goto UpdateFailed;

                    // 압축 풀기
                    if (!decompressUpdateFiles())
                        goto UpdateFailed;
                }

                // 업데이트 파일이 존재하는지 검증
                if (!File.Exists($"{updateFolder}AnemoneTriz.exe"))
                {
                    MessageBox.Show("업데이트할 파일이 존재하지 않습니다.");
                    goto UpdateFailed;
                }

                // 업데이트 압축파일 삭제
                try
                {
                    File.Delete(zipPath);
                }
                catch { }

                updateDownloaded = true;
                if (!runUpdateInstance())
                {
                    goto UpdateFailed;
                }
                return true;

                // 업데이트가 실패했을 때 ProgressBarState를 Error로 두고
                // 버튼을 모두 활성화
                UpdateFailed:
                (taskDialog.Controls["updateButton"] as TaskDialogButton).Enabled = true;
                (taskDialog.Controls["noUpdateButton"] as TaskDialogButton).Enabled = true;
                taskDialog.ProgressBar.State = TaskDialogProgressBarState.Error;
                taskDialog.ProgressBar.Value = 100;
                return false;
            });
        }
        public static void CleanFolder()
        {
            try
            {
                System.IO.DirectoryInfo di = new DirectoryInfo(updateFolder);
                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }
                Directory.Delete(updateFolder);
            }
            catch { }
        }
    }
}