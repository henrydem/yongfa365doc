using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using Microsoft.TeamFoundation.Build.Client;
using System.IO;
using System.Text.RegularExpressions;

namespace TFSFileReplacement
{
    [BuildActivity(HostEnvironmentOption.Agent)]
    public sealed class ReplaceActionActivity : CodeActivity
    {
        /// <summary>
        /// 替换规则集，模板：处理扩展名-_-匹配-_-替换@_@处理扩展名1-_-匹配1-_-替换1
        /// </summary>
        [RequiredArgument]
        public InArgument<string> Rules { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        [RequiredArgument]
        public InArgument<string> FilePath { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var orgRule = Rules.Get(context);
            orgRule = Regex.Replace(orgRule, @"\$\(Date:(.+?)\)", new MatchEvaluator((m) =>
            {
                if (m.Success && m.Groups.Count == 2)
                {
                    return DateTime.Now.ToString(m.Groups[1].Value);
                }
                return string.Empty;
            }));
            var rules = orgRule.Split(new string[] { "@_@", "-_-" }, StringSplitOptions.None);
            var filePath = FilePath.Get(context);


            if (String.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException("路径不能为空", "FilePath");
            }

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("文件不存在", filePath);
            }


            for (int i = 0; i < rules.Length; i += 3)
            {
                var rule = new Param { Extensions = rules[i].Split(';'), RegularExpression = rules[i + 1], Replacement = rules[i + 2] };
                if (rule.Extensions.Any((ex) => { return Regex.IsMatch(filePath, ex, RegexOptions.IgnoreCase); }))
                {
                    var re = new Regex(rule.RegularExpression, RegexOptions.IgnoreCase);
                    var body = File.ReadAllText(filePath);
                    if (re.IsMatch(body))
                    {
                        FileAttributes fileAttributes = File.GetAttributes(filePath);
                        File.SetAttributes(filePath, fileAttributes & ~FileAttributes.ReadOnly);
                        String contents = re.Replace(body, rule.Replacement);
                        File.WriteAllText(filePath, contents);
                        File.SetAttributes(filePath, fileAttributes);
                    }
                }
            }
        }




        private class Param
        {
            /// <summary>
            /// 匹配的扩展名,如".aspx;.ascx"
            /// </summary>
            public string[] Extensions { get; set; }

            /// <summary>
            /// 匹配
            /// </summary>
            public string RegularExpression { get; set; }

            /// <summary>
            /// 替换
            /// </summary>
            public string Replacement { get; set; }

        }
    }
}
