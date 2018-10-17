using System.Collections.Generic;
using System.ComponentModel;

namespace mRemoteNG.Tools
{
    public class SshGatewayTypeConverter : StringConverter
    {
        public static string[] SshGateways
        {
            get
            {
                var sshGatewayList = new List<string>();

                // Add a blank entry to signify that no ssh-gateway is selected
                sshGatewayList.Add(string.Empty);

                var connectionsList = App.Runtime.ConnectionsService.ConnectionTreeModel.GetRecursiveChildList();
                foreach (var connection in connectionsList)
                {
                    if (connection.Protocol == Connection.Protocol.ProtocolType.SshGateway)
                        sshGatewayList.Add(connection.Name);
                }

                return sshGatewayList.ToArray();
            }
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(SshGateways);
        }

        public override bool GetStandardValuesExclusive(System.ComponentModel.ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
