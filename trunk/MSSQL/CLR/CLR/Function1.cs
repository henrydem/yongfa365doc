using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Collections;
using System.IO;

/*
请先在SQL Server里执行以下命名，来启用CLR
exec sp_configure 'clr enabled',1 --1,启用clr 0,禁用clr
reconfigure
*/

public partial class UserDefinedFunctions
{


    /// <summary>
    /// SQL CLR 使用正则表达式替换，eg:
    /// select dbo.RegexReplace('<span>柳永法</span>','<.+?>','')
    /// update Articles set txtContent=dbo.RegexReplace(txtContent,'<.+?>','')
    /// --结果：柳永法
    /// </summary>
    /// <param name="input">源串，或字段名</param>
    /// <param name="pattern">正则表达式</param>
    /// <returns>替换后结果</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString RegexReplace(SqlChars input, SqlString pattern, SqlString replacement)
    {
        return Regex.Replace(new string(input.Value), pattern.Value, replacement.Value, RegexOptions.Compiled);
    }

    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlDouble GetStringLength(SqlChars input)
    {
        //return Regex.Replace(new string(input.Value),"[^\x00-\xff]","aa").Length;
        return System.Text.Encoding.GetEncoding(936).GetBytes(new string(input.Value)).Length;
    }


    [Microsoft.SqlServer.Server.SqlFunction]
    public static string GetSplit(string str, int x)
    {
        // 返回字符串的长度
        return str.Split(',')[x].Trim();
    }


    /// <summary>
    /// SQL CLR 使用正则表达式替换，eg:
    /// select dbo.RegexSearch('<span>柳永法</span>','<.+?>','')
    /// select * from Articles where dbo.RegexSearch(txtContent,'柳永法')=1;
    /// </summary>
    /// <param name="input">源串，或字段名</param>
    /// <param name="pattern">正则表达式</param>
    /// <returns>查询结果，1,0</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean RegexSearch(SqlChars input, string pattern)
    {
        return Regex.Match(new string(input.Value), pattern, RegexOptions.Compiled).Success;
    }

    /// <summary>
    /// SQL CLR 使用.net的Contains查找是否满足条件,eg:
    /// select dbo.ContainsOne('我是柳永法，','柳永法');
    /// select * from Articles where dbo.ContainsOne(txtContent,'柳永法')=1;
    /// </summary>
    /// <param name="input">源串，或字段名</param>
    /// <param name="search">要搜索的字符串</param>
    /// <returns>返回是否匹配,1,0</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean ContainsOne(SqlChars input, string search)
    {
        return new string(input.Value).Contains(search);
    }




    /// <summary>
    /// SQL CLR 使用.net的Contains查找是否满足其中之一的条件,eg:
    /// select dbo.ContainsAny('我是柳永法，','柳,永,法');
    /// select * from Articles where dbo.ContainsAny(txtContent,'柳,永,法')=1;
    /// </summary>
    /// <param name="input">源串，或字段名</param>
    /// <param name="search">要搜索的字符串，以","分隔，自己处理空格问题</param>
    /// <returns>返回是否匹配,1,0</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean ContainsAny(SqlChars input, string search)
    {
        string strTemp = new string(input.Value);
        foreach (string item in search.Split(','))
        {
            if (strTemp.Contains(item))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// SQL CLR 使用.net的Contains查找是否满足所有的条件,eg:
    /// select dbo.ContainsAll('我是柳永法，','柳,永,法');
    /// select * from Articles where dbo.ContainsAll(txtContent,'柳,永,法')=1;
    /// </summary>
    /// <param name="input">源串，或字段名</param>
    /// <param name="search">要搜索的字符串，以","分隔，自己处理空格问题</param>
    /// <returns>返回是否匹配,1,0</returns>
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlBoolean ContainsAll(SqlChars input, string search)
    {
        string strTemp = new string(input.Value);
        foreach (string item in search.Split(','))
        {
            if (!strTemp.Contains(item))
            {
                return false;
            }
        }
        return true;
    }

};

