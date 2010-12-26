using System.Net;
using System.Net.Mail;

namespace YongFa365.Mail
{
    public static class Mail
    {
        #region 使用System.Net.Mail的SMTP发邮件
        /// <summary>
        /// 使用smtp发邮件
        /// </summary>
        /// <param name="smtp">eg: smtp.qq.com</param>
        /// <param name="userName">登录用户</param>
        /// <param name="password">登录密码</param>
        /// <param name="from">发送邮箱</param>
        /// <param name="to">接收邮箱</param>
        /// <param name="subject">主题</param>
        /// <param name="body">内容</param>
        public static void Send(string smtp, string userName, string password, string from, string to, string subject, string body)
        {

            MailMessage msg = new MailMessage(from, to, subject, body);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;

            SmtpClient client = new SmtpClient(smtp);
            client.Credentials = new NetworkCredential(userName, password);
            client.Send(msg);

            //得在 aspx上设置 Async="true" 
            //client.SendAsync(msg, null);

        }

        public static void Send(string body)
        {
            Send("smtp.163.com", "Send@163.com", "pwd", "send@163.com", "to@qq.com", "机器人", body);
        }
        #endregion
    }

}