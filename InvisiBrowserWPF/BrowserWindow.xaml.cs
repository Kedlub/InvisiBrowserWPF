using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using MicaWPF.Controls;
using Microsoft.Web.WebView2.Core;

namespace InvisiBrowserWPF;

public partial class BrowserWindow : Window
{
    public static string CacheFolderPath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "InvisiBrowserWPF");
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, 
        int wParam, int lParam);
    [DllImportAttribute("user32.dll")]
    public static extern bool ReleaseCapture();
    
    
    private string _url = "";
    public BrowserWindow()
    {
        InitializeComponent();
    }
    
    public BrowserWindow(string url): this()
    {
        if (!url.Contains("://"))
        {
            url = "https://" + url;
        }
        _url = url;
    }

    private async void BrowserWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        var webView2Environment = await CoreWebView2Environment.CreateAsync(null, CacheFolderPath);
        await Browser.EnsureCoreWebView2Async(webView2Environment);
        Browser.Source = new System.Uri(_url);
    }

    private void BrowserWindow_OnClosed(object? sender, EventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void BrowserWindow_OnMouseMove(object sender, MouseEventArgs e)
    {
    }
    
    public void move_window(object sender, MouseButtonEventArgs e) {
        ReleaseCapture();
        SendMessage(new WindowInteropHelper(this).Handle, 
            WM_NCLBUTTONDOWN, HT_CAPTION, 0);
    }
    
}