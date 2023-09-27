using GarlicPress.components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace GarlicPress.forms;
public partial class DocumentationForm : Form
{
    public DocumentationForm(string markdownPath)
    {
        InitializeComponent();

        var services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();
        services.AddBlazorWebViewDeveloperTools();
        services.AddSingleton(this);
        bwv_Docs.HostPage = "wwwroot\\index.html";
        bwv_Docs.Services = services.BuildServiceProvider();

        bwv_Docs.RootComponents.Add<MarkdownViewer>("#app", new Dictionary<string, object?>
        {
            { nameof(MarkdownViewer.MarkdownFilePath), markdownPath }
        });
    }
}