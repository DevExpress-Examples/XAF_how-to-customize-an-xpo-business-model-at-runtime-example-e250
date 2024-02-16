using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Model.Core;
using DevExpress.ExpressApp.Model.DomainLogics;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using MyXPOClassLibrary;

namespace CustomizeXPOModel.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class CustomizeXPOModelModule : ModuleBase {
    public CustomizeXPOModelModule() {
		// 
		// CustomizeXPOModelModule
		// 
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.ValidationModule));
        this.AdditionalExportedTypes.Add(typeof(MyXPOClassLibrary.PersistentObject1));
        this.AdditionalExportedTypes.Add(typeof(MyXPOClassLibrary.PersistentObject2));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        // Manage various aspects of the application UI and behavior at the module level.
    }
    public override void CustomizeTypesInfo(DevExpress.ExpressApp.DC.ITypesInfo typesInfo) {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        ITypeInfo typeInfo1 = typesInfo.FindTypeInfo(typeof(PersistentObject1));
        typeInfo1.AddAttribute(new DevExpress.Persistent.Base.DefaultClassOptionsAttribute());

        IMemberInfo memberInfo0 = typeInfo1.FindMember("NewIntField");
        if (memberInfo0 == null) {
            typeInfo1.CreateMember("NewIntField", typeof(int));
        }

        ITypeInfo typeInfo2 = typesInfo.FindTypeInfo(typeof(PersistentObject2));
        IMemberInfo memberInfo1 = typeInfo1.FindMember("PersistentObject2s");
        IMemberInfo memberInfo2 = typeInfo2.FindMember("PersistentObject1");
        if (memberInfo1 == null) {
            memberInfo1 = typeInfo1.CreateMember("PersistentObject2s", typeof(DevExpress.Xpo.XPCollection<PersistentObject2>));
            memberInfo1.AddAttribute(new DevExpress.Xpo.AssociationAttribute("PersistentObject1-PersistentObject2s", typeof(PersistentObject2)), true);
            memberInfo1.AddAttribute(new DevExpress.Xpo.AggregatedAttribute(), true);
        }
        if (memberInfo2 == null) {
            memberInfo2 = typeInfo2.CreateMember("PersistentObject1", typeof(PersistentObject1));
            memberInfo2.AddAttribute(new DevExpress.Xpo.AssociationAttribute("PersistentObject1-PersistentObject2s", typeof(PersistentObject1)), true);
        }

        typesInfo.RefreshInfo(typeof(PersistentObject1));
        typesInfo.RefreshInfo(typeof(PersistentObject2));
    }
 
}
