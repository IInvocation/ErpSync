using ErpSync.Bpl.Interop.Options;
using System.Diagnostics;
using System.Runtime.InteropServices;
using BpNT;

namespace ErpSync.Bpl.Interop.Connection;

/// <summary>   A bpl application. </summary>
public class BplApplication : IDisposable
{
    /// <summary>   (Immutable) the bp application. </summary>
    internal readonly Application? BpApp;

    public BplApplication(BplOptions options)
    {
        try
        {
            BpApp = new Application();
            object? customernumber = null;
            object? company = null;
            object? postalcode = null;
            BpApp.GetKundendaten(ref customernumber, ref company, ref postalcode);

            BpApp.Init(company.ToString(), string.Empty, options.Login.Username, options.Login.Password);
            BpApp.SelectMand(options.Login.Client);
        }
        catch (COMException e)
        {
            if (BpApp != null)
                Process.GetProcessById(Convert.ToInt32(BpApp.GetAppProcessId())).Kill();

            Console.WriteLine(e);
            throw;
        }
    }

    public void Dispose()
    {
        if (BpApp == null) return;

        BpApp.DeInit();
        Process.GetProcessById(Convert.ToInt32(BpApp.GetAppProcessId())).Kill();
    }
}