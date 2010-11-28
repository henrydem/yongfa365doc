using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.ServiceModel.Activation;

namespace WCF_JQuery_JSON_Service
{

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class UserService : IUserService
    {
        public UserInfo GetUserInfoByObject(UserInfo input)
        {
            input.Intro = string.Format("GetUserInfoByObject 姓名：{0},年龄：{1}", input.UserName, input.Age);
            return input;
        }

        public UserInfo GetUserInfoByParams(string UserName, int Age)
        {
            UserInfo input = new UserInfo() { UserName = UserName, Age = Age };
            input.Intro = string.Format("GetUserInfoByParams 姓名：{0},年龄：{1}", input.UserName, input.Age);
            return input;
        }

        public List<UserInfo> GetUserInfoByParamsReturnList(string UserName, int Age)
        {
            List<UserInfo> list = new List<UserInfo>() 
            { 
                new UserInfo() { UserName = UserName+"1", Age = Age,Intro="GetUserInfoByParamsReturnList 1" },
                new UserInfo() { UserName = UserName+"2", Age = Age,Intro=" 2"},
                new UserInfo() { UserName = UserName+"3", Age = Age,Intro="3" }
            };

            return list;
        }


    }
}
