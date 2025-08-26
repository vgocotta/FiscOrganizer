using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace FiscOrganizer;

public partial class MainForm : Form
{
    private const int WM_SETTINGCHANGE = 0x001A;
    private const int WM_THEMECHANGED = 0x031A;

    public MainForm()
    {
        InitializeComponent();
        // Subscribe to additional theme changes.
        SystemEvents.UserPreferenceChanged += SystemEvents_UserPreferenceChanged;
        UpdateTheme();
    }

    // Unsubscribe when the form is closed.
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        SystemEvents.UserPreferenceChanged -= SystemEvents_UserPreferenceChanged;
        base.OnFormClosed(e);
    }

    // Event handler for when user preferences are changed.
    private void SystemEvents_UserPreferenceChanged(object sender, UserPreferenceChangedEventArgs e)
    {
        if (e.Category == UserPreferenceCategory.General)
        {
            UpdateTheme();
        }
    }

    // Override WndProc to listen for system theme change messages.
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == WM_SETTINGCHANGE || m.Msg == WM_THEMECHANGED)
        {
            UpdateTheme();
        }
        base.WndProc(ref m);
    }

    // Update the form's colors based on the current Windows theme.
    private void UpdateTheme()
    {
        bool isLightTheme = true;
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
        {
            if (key != null)
            {
                object registryValueObject = key.GetValue("AppsUseLightTheme");
                if (registryValueObject != null)
                {
                    isLightTheme = Convert.ToInt32(registryValueObject) > 0;
                }
            }
        }

        if (isLightTheme)
        {
            this.BackColor = Color.White;
            // Update other colors for the light theme as needed.
        }
        else
        {
            this.BackColor = Color.Black;
            // Update other colors for the dark theme as needed.
        }
    }
}