对于WINFORM程序，使用 System.Configuration.ConfigurationManager；
对于ASP.NET 程序， 使用 System.Web.Configuration.WebConfigurationManager；

ASP.NET(需要有写权限):

Configuration config = WebConfigurationManager.OpenWebConfiguration(null);
AppSettingsSection app = config.AppSettings;
app.Settings.Add("x", "this is X");//添加
app.Settings["x"].Value = "this is not Y";//修改
app.Settings.Remove("x");//删除
config.Save(ConfigurationSaveMode.Modified);

WinForm:

Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
AppSettingsSection app = config.AppSettings;
app.Settings.Add("x", "this is X");
app.Settings["x"].Value = "this is not Y";
app.Settings.Remove("x");
config.Save(ConfigurationSaveMode.Modified);