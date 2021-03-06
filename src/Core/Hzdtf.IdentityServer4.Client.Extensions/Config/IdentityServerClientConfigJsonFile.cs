using Hzdtf.Utility.Attr;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hzdtf.IdentityServer4.Client.Extensions.Config
{
    /// <summary>
    /// IdentityServer客户端配置Json文件
    /// @ 黄振东
    /// </summary>
    [Inject]
    public class IdentityServerClientConfigJsonFile : IIdentityServerClientConfigReader
    {
        /// <summary>
        /// 客户端信息
        /// </summary>
        private readonly IdentityServerClientInfo clients;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="jsonFile">Json文件</param>
        public IdentityServerClientConfigJsonFile(string jsonFile = "Config/identityServer4_Client.json")
        {
            clients = jsonFile.ToJsonObjectFromFile<IdentityServerClientInfo>();
        }

        /// <summary>
        /// 读取客户端信息
        /// </summary>
        /// <returns>客户端信息</returns>
        public IdentityServerClientInfo Reader() => clients;
    }
}
