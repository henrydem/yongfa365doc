using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace NTFS
{
    class ACL
    {
        public enum Roles
        {
            FullControl,
            Read,
            Write,
            Modify

        }

        public static void Add(string Path, string UserName, FileSystemRights Role)
        {
            DirectoryInfo dirinfo = new DirectoryInfo(Path);
            DirectorySecurity sec = dirinfo.GetAccessControl();
            sec.AddAccessRule(new FileSystemAccessRule(UserName, Role, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            dirinfo.SetAccessControl(sec);

        }

        public static string Add(string Path, string UserName, Roles Role)
        {
            try
            {
                DirectoryInfo dirinfo = new DirectoryInfo(Path);

                //ȡ�÷��ʿ����б�   
                DirectorySecurity sec = dirinfo.GetAccessControl();
                switch (Role)
                {
                    case Roles.FullControl:
                        sec.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        break;
                    case Roles.Read:
                        sec.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.Read, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        break;
                    case Roles.Write:
                        sec.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.Write, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        break;
                    case Roles.Modify:
                        sec.AddAccessRule(new FileSystemAccessRule(UserName, FileSystemRights.Modify, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
                        break;
                }


                dirinfo.SetAccessControl(sec);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


            //����

            //    * path Ҫ���� NTFS Ȩ�޵��ļ��С�
            //    * identity �û�����
            //    * rights FileSystemRights ����ֵΪ FileSystemRights.Read��FileSystemRights.Write��FileSystemRights.FullControl �ȣ������á�|�������Ȩ�޺�������

            //InheritanceFlags ָ����Щ����Ȩ�޼̳�

            //    * InheritanceFlags.ContainerInherit �¼��ļ���Ҫ�̳�Ȩ�ޡ�
            //    * InheritanceFlags.None �¼��ļ��С��ļ������̳�Ȩ�ޡ�
            //    * InheritanceFlags.ObjectInherit �¼��ļ�Ҫ�̳�Ȩ�ޡ�

            //�����ᵽ���ļ��С������ļ�������׼ȷ��˵��Ӧ���ǡ�����������Ҷ���󡱣���Ϊ�������������ļ��С��ļ������������������ط�������ע���Ȩ�ޡ�

            //PropagationFlags ��δ���Ȩ��

            //    * PropagationFlags.InheritOnly ���� path �����ã�ֻ�Ǵ������¼���
            //    * PropagationFlags.None �������ã����ȶ� path �����ã�Ҳ�������¼���
            //    * PropagationFlags.NoPropagateInherit ֻ�Ƕ� path �����ã����������¼���

            //PropagationFlags ֻ���� InheritanceFlags ��Ϊ None ʱ�������塣Ҳ����˵ InheritanceFlags ָ�����������ɽ���Ȩ�޼̳У����������� PropagationFlags ָ������δ�����ЩȨ�ޡ�


        }
        public static void Del(string Path, string UserName)
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path);
            DirectorySecurity sec = dInfo.GetAccessControl();

            foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                if (
                    rule.IdentityReference.Value.ToLower() == UserName.ToLower() ||
                    rule.IdentityReference.Value.ToLower().Contains("\\" + UserName.ToLower())
                    )
                {
                    sec.RemoveAccessRuleAll(rule);
                    break;
                }
            }
            dInfo.SetAccessControl(sec);
        }
        public static void DelErr(string Path)
        {
            DirectoryInfo dInfo = new DirectoryInfo(Path);
            DirectorySecurity sec = dInfo.GetAccessControl();

            foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                if (rule.IdentityReference.Value.StartsWith("S-1-5-21"))
                {
                    sec.RemoveAccessRuleAll(rule);
                }
            }
            dInfo.SetAccessControl(sec);
        }


        public static List<String> List(string Path)
        {
            List<String> list = new List<String>();

            try
            {
                DirectoryInfo dInfo = new DirectoryInfo(Path);
                DirectorySecurity sec = dInfo.GetAccessControl();

                foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                {

                    string[] U = rule.IdentityReference.Value.Split('\\');

                    if (!list.Contains(U[U.Length - 1]))
                    {
                        list.Add(U[U.Length - 1]);
                    }

                }
            }
            catch
            {

            }

            return list;
        }


        /// <returns>String,FileSystemRights��ֵ��</returns>  
        public static Hashtable GetACL(String FolderPath)
        {
            Hashtable ret = new Hashtable();
            DirectorySecurity sec = Directory.GetAccessControl(FolderPath, AccessControlSections.All);
            foreach (FileSystemAccessRule rule in sec.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                ret[rule.IdentityReference.Value] = rule.FileSystemRights;

            }
            return ret;
        }


        public static string GetACLString(String FolderPath)
        {
            StringBuilder sb = new StringBuilder();
            Hashtable rights = GetACL(FolderPath);
            foreach (string key in rights.Keys)
            {
                sb.Append(key + ":\t" + ((FileSystemRights)rights[key]).ToString() + "\r\n");
            }
            return sb.ToString();
        }

    }
}
