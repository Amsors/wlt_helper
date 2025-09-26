using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using NativeWifi;

namespace wlt_helper
{
    public class WltWebFunction:IDisposable
    {
        private readonly HttpClient _httpClient;
        private bool _disposed = false; // 标记资源是否已被释放

        public WltWebFunction()
        {
            // 创建HttpClient实例，并设置默认超时时间为3秒
            _httpClient = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(3)
            };
        }

        public async Task<bool> TestWebsiteAccessAsync(string url)
        {
            try
            {
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3)))
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(url, cts.Token);
                    return response.IsSuccessStatusCode;
                }
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine($"访问 {url} 超时（3秒内未响应）");
                return false;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"访问 {url} 时发生网络错误：{ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"访问 {url} 时发生未知错误：{ex.Message}");
                return false;
            }
        }
        public async Task<string> PostFormAsync(string url, Dictionary<string, string> formData)
        {
            try
            {
                // 将字典数据转换为application/x-www-form-urlencoded格式
                var formContent = new FormUrlEncodedContent(formData);

                // 设置请求头
                formContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/x-www-form-urlencoded");

                // 发送POST请求
                HttpResponseMessage response = await _httpClient.PostAsync(url, formContent);

                // 确保响应成功
                response.EnsureSuccessStatusCode();

                // 读取并返回响应内容
                return await response.Content.ReadAsStringAsync();
            }
            catch (TaskCanceledException)
            {
                throw new TimeoutException($"向 {url} 发送POST请求超时");
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"向 {url} 发送POST请求时发生网络错误：{ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"向 {url} 发送POST请求时发生未知错误：{ex.Message}");
            }
        }

        public static string GetCurrentConnection()
        {
            WlanClient client = new WlanClient();
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // 检查接口是否处于已连接状态
                if (wlanIface.InterfaceState == Wlan.WlanInterfaceState.Connected &&
                    wlanIface.CurrentConnection.isState == Wlan.WlanInterfaceState.Connected)
                {
                    // 返回当前连接的配置文件名称，通常就是SSID
                    return wlanIface.CurrentConnection.profileName;
                }
            }
            return string.Empty;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _httpClient?.Dispose();
                    Debug.WriteLine("托管资源（HttpClient）已释放。");
                }
                _disposed = true;
            }
        }
        ~WltWebFunction()
        {
            Dispose(false);
        }
    }
}
