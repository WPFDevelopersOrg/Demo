#if WINDOWS
using Microsoft.Maui.Platform;
using PInvoke;
using static PInvoke.User32;
using MicrosoftuiWindowing = Microsoft.UI.Windowing;
using MicrosoftuiXaml = Microsoft.UI.Xaml;
using Microsoftui = Microsoft.UI;
using MicrosoftuixmlMedia = Microsoft.UI.Xaml.Media;
#endif


namespace MauiApp1.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    }

	private void Button_Clicked(object sender, EventArgs e)
	{
#if WINDOWS
        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return;

        var windowHanlde = winuiWindow.GetWindowHandle();
        User32.PostMessage(windowHanlde, WindowMessage.WM_SYSCOMMAND, new IntPtr((int)SysCommands.SC_MAXIMIZE), IntPtr.Zero);
#endif
    }

    private void Button_Clicked_1(object sender, EventArgs e)
	{
#if WINDOWS
        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return;

        var windowHanlde = winuiWindow.GetWindowHandle();
        User32.PostMessage(windowHanlde, WindowMessage.WM_SYSCOMMAND, new IntPtr((int)SysCommands.SC_MINIMIZE), IntPtr.Zero);
#endif
    }

    private void Button_Clicked_2(object sender, EventArgs e)
	{
#if WINDOWS

        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return;
        var appWindow = winuiWindow.GetAppWindow();
        if (appWindow is null)
            return;

        var displyArea = MicrosoftuiWindowing.DisplayArea.Primary;
        double scalingFactor = winuiWindow.GetDisplayDensity();
        var width = 800 * scalingFactor;
        var height = 600 * scalingFactor;
        double startX = (displyArea.WorkArea.Width - width) / 2.0;
        double startY = (displyArea.WorkArea.Height - height) / 2.0;

        appWindow.MoveAndResize(new((int)startX, (int)startY, (int)width, (int)height), displyArea);

        //appWindow.TitleBar?.ResetToDefault();
#endif
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
#if WINDOWS
        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return;
        var appWindow = winuiWindow.GetAppWindow();
        if (appWindow is null)
            return;

        //????????Maui??????????????TitleBar(????????????????)???????????? ?????????????????? ????????
        //??????????????????????????????????????????????????????????????????????????????????????????????????????????????github??????
        winuiWindow.Title = "MyTestApp";
        winuiWindow.ExtendsContentIntoTitleBar = false;
        appWindow.SetPresenter(MicrosoftuiWindowing.AppWindowPresenterKind.FullScreen);
#endif
    }

    private void Button_Clicked_4(object sender, EventArgs e)
    {
#if WINDOWS
        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return;
        var appWindow = winuiWindow.GetAppWindow();
        if (appWindow is null)
            return;

        winuiWindow.ExtendsContentIntoTitleBar = true;
        appWindow.SetPresenter(MicrosoftuiWindowing.AppWindowPresenterKind.Default);

        var application = MicrosoftuiXaml.Application.Current;
        var res = application.Resources;
        res["WindowCaptionBackground"] = res["WindowCaptionBackgroundDisabled"];

        //????????????????????????????????
        TriggertTitleBarRepaint();

#endif
    }

    private void Button_Clicked_5(object sender, EventArgs e)
    {
#if WINDOWS
        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return;
        var appWindow = winuiWindow.GetAppWindow();
        if (appWindow is null)
            return;

        var customOverlappedPresenter = MicrosoftuiWindowing.OverlappedPresenter.Create();
        appWindow.SetPresenter(customOverlappedPresenter);
        winuiWindow.ExtendsContentIntoTitleBar = false;
#endif
    }

    private void Button_Clicked_6(object sender, EventArgs e)
    {
#if WINDOWS
        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return;
        var appWindow = winuiWindow.GetAppWindow();
        if (appWindow is null)
            return;

        winuiWindow.ExtendsContentIntoTitleBar = false;
        var customOverlappedPresenter = MicrosoftuiWindowing.OverlappedPresenter.CreateForContextMenu();
        appWindow.SetPresenter(customOverlappedPresenter);
#endif
    }

    private void Button_Clicked_7(object sender, EventArgs e)
    {
#if WINDOWS
        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return;

        var application = MicrosoftuiXaml.Application.Current;
        var res = application.Resources;

        //????????????????????????????????????????????????????????Winui3??????
        res["WindowCaptionBackground"] = new MicrosoftuixmlMedia.SolidColorBrush(Microsoftui.Colors.Red);

        //????????????????????????????????????????????????????????????????????
        TriggertTitleBarRepaint();
#endif
    }


    bool TriggertTitleBarRepaint()
    {
#if WINDOWS
        var winuiWindow = Window.Handler?.PlatformView as MicrosoftuiXaml.Window;
        if (winuiWindow is null)
            return false ;

        var windowHanlde = winuiWindow.GetWindowHandle();
        var activeWindow = User32.GetActiveWindow();
        if (windowHanlde == activeWindow)
        {
            User32.PostMessage(windowHanlde, WindowMessage.WM_ACTIVATE, new IntPtr((int)0x00), IntPtr.Zero);
            User32.PostMessage(windowHanlde, WindowMessage.WM_ACTIVATE, new IntPtr((int)0x01), IntPtr.Zero);
        }
        else
        {
            User32.PostMessage(windowHanlde, WindowMessage.WM_ACTIVATE, new IntPtr((int)0x01), IntPtr.Zero);
            User32.PostMessage(windowHanlde, WindowMessage.WM_ACTIVATE, new IntPtr((int)0x00), IntPtr.Zero);
        }

#endif
        return true;
    }
}