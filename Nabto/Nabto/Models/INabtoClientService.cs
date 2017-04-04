using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nabto.Models
{
    public interface INabtoClientService
    {
        void StartUp();
      
        string CreatSession(string UserName, string Password);

        
        string GetRpcInvoke(string XMLData,string URL);
        string OpenTCPTunnel(string remoteHost, int remotePort);

        string GetTunnelState();

        string ShutDownTunnel();
    }
}
