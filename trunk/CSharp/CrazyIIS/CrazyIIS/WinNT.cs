using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;

namespace WinNT
{
    public class User
    {
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="PassWord">����</param>
        /// <returns>���� "OK" �������Ϣ</returns>
        public static string Add(string UserName, string PassWord)
        {
            try
            {

                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry NewUser = dir.Children.Add(UserName, "User");
                NewUser.Invoke("SetPassword", PassWord); //�û�����
                //���õ�¼�ʺ�0x0002
                //�û����ܸ�������0x0040
                //�û�������������0x10000


                NewUser.Invoke("Put", "UserFlags", 0x0040 | 0x10000);
                NewUser.Invoke("Put", "Description", "IIS��վ�����û�");

                //NewUser.Properties["UserFlags"].Add(0x0040 | 0x10000);
                //NewUser.Properties["Description"].Add("IIS��վ�����û�");
                //NewUser.Properties["FullName"].Add(UserName); //�û�ȫ��
                NewUser.CommitChanges();


                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }



        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <returns>���� "OK" �������Ϣ</returns>
        public static string Del(string UserName)
        {

            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                dir.Invoke("Delete", "User", UserName);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// ɾ���û�
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <returns>���� "OK" �������Ϣ</returns>
        public static string Del(string[] UserNames)
        {

            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                foreach (string UserName in UserNames)
                {
                    dir.Invoke("Delete", "User", UserName);
                }

                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static List<String> List()
        {
            List<String> list = new List<String>();
            DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
            foreach (DirectoryEntry child in dir.Children)
            {
                if (child.SchemaClassName == "User")
                {
                    list.Add(child.Name);
                }
            }
            return list;
        }

        //{
        //    try
        //    {
        //        DirectoryEntry obComputer = new DirectoryEntry("WinNt://" + Environment.MachineName);//��ü����ʵ��
        //        DirectoryEntry obUser = obComputer.Children.Find(Username, "User");//�ҵ��û�
        //        obComputer.Children.Remove(obUser);//ɾ���û�
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}




        /// <summary>
        /// �޸ı�������ķ���
        /// </summary>
        /// <param name="intputPwd">�����������</param>
        /// <returns>�ɹ�����"success",ʧ�ܷ���exception</returns>
        public static string SetPassword(string intputPwd)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry user = dir.Children.Find("test", "User");
                user.Invoke("SetPassword", new object[] { intputPwd });
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }


        public static bool ChangePassword(string UserName, string oldPwd, string newPwd)
        {
            try
            {
                DirectoryEntry MachineDirectoryEntry;
                MachineDirectoryEntry = new DirectoryEntry("WinNT://" + System.Environment.MachineName);
                DirectoryEntry CurrentDirectoryEntry = MachineDirectoryEntry.Children.Find(UserName);
                CurrentDirectoryEntry.Invoke("ChangePassword", new Object[] { oldPwd, newPwd });
                CurrentDirectoryEntry.CommitChanges();
                CurrentDirectoryEntry.Close();
                return true;
            }
            catch (Exception exp)
            {
                if (exp.InnerException.Message.Replace("'", "").IndexOf("�������벻��ȷ") != -1)
                    throw new Exception("�����޸�ʧ��,�����ԭʼ���벻��ȷ");
                else
                    throw new Exception(exp.InnerException.Message);
            }
            finally
            {
            }
        }

    }

    public class Group
    {

        public static string Add(string GroupName)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry newEntry = dir.Children.Add(GroupName, "Group");
                //newEntry.Properties["groupType"][0] = "4";
                //newEntry.Properties["Description"].Add("test");
                newEntry.CommitChanges();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public static string Del(string GroupName)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                dir.Invoke("Delete", "Group", GroupName);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }

    public class Other
    {


        public static string AddUserToGroup(string UserName, string GroupName)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry grp = dir.Children.Find(GroupName, "Group");
                DirectoryEntry obUser = dir.Children.Find(UserName, "User");
                if (grp.Name != "")
                {
                    grp.Invoke("Add", obUser.Path.ToString());//���û���ӵ�ĳ��
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public static string DelUserFromGroup(string UserName, string GroupName)
        {
            try
            {
                DirectoryEntry dir = new DirectoryEntry(@"WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry grp = dir.Children.Find(GroupName, "Group");
                DirectoryEntry obUser = dir.Children.Find(UserName, "User");
                if (grp.Name != "" && obUser.Name != "")
                {
                    grp.Invoke("Remove", obUser.Path.ToString());//���û���ӵ�ĳ��
                }
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }




        /// <summary>
        /// ���ݱ����û�����������û�������
        /// </summary>
        /// <param name="localGroup">�����û���</param>
        /// <returns>�û�������</returns>
        static List<String> GetUsersList(DirectoryEntry directoryEntry)
        {
            List<String> arrUsers = new List<String>();

            try
            {

                foreach (object member in (IEnumerable)directoryEntry.Invoke("Members"))
                {
                    DirectoryEntry dirmem = new DirectoryEntry(member);
                    arrUsers.Add(dirmem.Name);
                }
                return arrUsers;
            }
            catch { return arrUsers; }

        }

        /// <summary>
        /// �����û���,��ѯ���ذ����û�HashTable(�����ơ�ȫ����������������
        /// </summary>
        /// <param name="localGroup">�û�������</param>
        /// <returns>�����û�HashTable(�����ơ�ȫ����������������</returns>
        public static List<String> GetUsersByGroup(string localGroup)
        {
            List<String> arr = new List<String>();//al����HASHTABLE������

            try
            {

                DirectoryEntry group = new DirectoryEntry("WinNT://" + Environment.MachineName + "/" + localGroup + ",group");

                foreach (string user in GetUsersList(group))
                {
                    arr.Add(user);
                }
            }
            catch (Exception ex)
            {
                string errMsg = ex.ToString();
            }
            return arr;
        }


    }
}
