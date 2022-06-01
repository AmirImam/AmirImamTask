
using Microsoft.Reporting.NETCore;
using System.Collections;

namespace AmirImamTask.API.Services;
public class ReportsService
{
    private readonly IWebHostEnvironment webHostEnvironment;

    public ReportsService(IWebHostEnvironment webHostEnvironment)
    {
        this.webHostEnvironment = webHostEnvironment;

    }
    public string ReportName { get; set; }
    public KeyValuePair<string, IEnumerable> DataSource { get; set; }
    public byte[] Execute()
    {

        string reportPath = $"{webHostEnvironment.WebRootPath}\\Reports\\{ReportName}";
        FileStream reportDefinition = new FileStream(reportPath, FileMode.Open);
        LocalReport report = new LocalReport();
        report.LoadReportDefinition(reportDefinition);
        report.DataSources.Add(new ReportDataSource(DataSource.Key, DataSource.Value));
        byte[] pdf = report.Render("PDF");
        reportDefinition.Close();
        return pdf;

    }

}
//using AspNetCore.Reporting;
//using System.Reflection;

//namespace AmirImamTask.API.Services;

//public class ReportsService : IDisposable
//{
//    private readonly IWebHostEnvironment webHostEnvironment;

//    public ReportsService(IWebHostEnvironment webHostEnvironment)
//    {
//        this.webHostEnvironment = webHostEnvironment;

//    }
//    /// <summary>
//    /// Default: PDF
//    /// </summary>
//    public RenderType ReportType { get; set; } = RenderType.Pdf;
//    public string ReportContentType => ReportType switch
//    {
//        RenderType.Pdf => "application/pdf",
//        _ => ""
//    };
//    public string ReportName { get; set; }
//    public bool EnableExternalImage { get; set; }
//    private LocalReport report;
//    private Dictionary<string, object> DataSourcesList { get; set; }
//        = new Dictionary<string, object>();
//    private Dictionary<string, string> ParametersList { get;set;} 

//    public void AddDataSource(string name, object source)
//            => DataSourcesList[name] = source;
//    public void AddParameter(string key,string value)
//    {
//        if (ParametersList == null)
//        {
//            ParametersList = new();
//        }
//        ParametersList[key] = value;
//    }
//    public ReportResult Execute()
//    {
//        string reportName = ReportName.EndsWith(".rdlc") ? ReportName : $"{ReportName}.rdlc";
//        string reportPath = $"{webHostEnvironment.WebRootPath}\\Reports\\{reportName}";
//        report = new LocalReport(reportPath);

//        foreach (KeyValuePair<string,object> item in DataSourcesList)
//        {
//            report.AddDataSource(item.Key, item.Value);
//        }
//        if(EnableExternalImage == true)
//        {
//            SetEnableExternalImage(true);
//        }
//        var reportResult = report.Execute(ReportType, parameters: ParametersList);
//        return reportResult;
//    }


//    private void SetEnableExternalImage(bool value)
//    {
//        BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
//        FieldInfo field = report.GetType().GetField("localReport", bindFlags);
//        object rptObj = field.GetValue(report);
//        Type type = rptObj.GetType();
//        PropertyInfo pi = type.GetProperty("EnableExternalImages");
//        pi.SetValue(rptObj, value, null);
//    }

//    public void Dispose()
//    {
//        report = null;
//        DataSourcesList.Clear();
//        ParametersList = null;
//    }
//}
