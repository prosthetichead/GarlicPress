using GarlicPress.components;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace GarlicPress.forms;
public partial class EditMediaLayersForm : Form
{
    public EditMediaLayersForm()
    {
        InitializeComponent();
        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.AddSingleton(this);
        bwvMediaEditor.HostPage = "wwwroot\\index.html";
        bwvMediaEditor.Services = services.BuildServiceProvider();
        bwvMediaEditor.RootComponents.Add<MediaGenerationEditor>("#app");
    }
}
