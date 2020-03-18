using Sinca.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Sinca.Permissions
{
    public class SincaPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(SincaPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(SincaPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SincaResource>(name);
        }
    }
}
