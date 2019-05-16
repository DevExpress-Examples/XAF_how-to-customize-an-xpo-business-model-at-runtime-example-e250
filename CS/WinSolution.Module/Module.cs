using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using MyXPOClassLibrary;

namespace WinSolution.Module {
    public sealed partial class WinSolutionModule : ModuleBase {
        public WinSolutionModule() {
            InitializeComponent();
        }
        public override void CustomizeTypesInfo(DevExpress.ExpressApp.DC.ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);

            ITypeInfo typeInfo1 = typesInfo.FindTypeInfo(typeof(PersistentObject1));
            typeInfo1.AddAttribute(new DevExpress.Persistent.Base.DefaultClassOptionsAttribute());

            IMemberInfo memberInfo0 = typeInfo1.FindMember("NewIntField");
            if(memberInfo0 == null) {
                typeInfo1.CreateMember("NewIntField", typeof(int));
            }

            ITypeInfo typeInfo2 = typesInfo.FindTypeInfo(typeof(PersistentObject2));
            IMemberInfo memberInfo1 = typeInfo1.FindMember("PersistentObject2s");
            IMemberInfo memberInfo2 = typeInfo2.FindMember("PersistentObject1");
            if(memberInfo1 == null) {
                memberInfo1 = typeInfo1.CreateMember("PersistentObject2s", typeof(DevExpress.Xpo.XPCollection<PersistentObject2>));
                memberInfo1.AddAttribute(new DevExpress.Xpo.AssociationAttribute("PersistentObject1-PersistentObject2s", typeof(PersistentObject2)), true);
                memberInfo1.AddAttribute(new DevExpress.Xpo.AggregatedAttribute(), true);
            }
            if(memberInfo2 == null) {
                memberInfo2 = typeInfo2.CreateMember("PersistentObject1", typeof(PersistentObject1));
                memberInfo2.AddAttribute(new DevExpress.Xpo.AssociationAttribute("PersistentObject1-PersistentObject2s", typeof(PersistentObject1)), true);
            }

            typesInfo.RefreshInfo(typeof(PersistentObject1));
            typesInfo.RefreshInfo(typeof(PersistentObject2));
        }
    }
}
