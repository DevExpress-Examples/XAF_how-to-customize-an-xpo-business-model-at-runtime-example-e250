Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports MyXPOClassLibrary

Namespace WinSolution.Module
	Public NotInheritable Partial Class WinSolutionModule
		Inherits ModuleBase
		Public Sub New()
			InitializeComponent()
		End Sub
		Public Overrides Sub CustomizeTypesInfo(ByVal typesInfo As DevExpress.ExpressApp.DC.ITypesInfo)
			MyBase.CustomizeTypesInfo(typesInfo)
			typesInfo.FindTypeInfo(GetType(PersistentObject1)).AddAttribute(New DevExpress.Persistent.Base.DefaultClassOptionsAttribute())

			'Dennis: simple creation of a new member.
			typesInfo.FindTypeInfo(GetType(PersistentObject1)).CreateMember("NewIntField", GetType(Integer))

			'Dennis: establishing a One-To-Many relationship between two classes.
			Dim xpDictionary As XPDictionary = DevExpress.ExpressApp.Xpo.XpoTypesInfoHelper.GetXpoTypeInfoSource().XPDictionary
			If xpDictionary.GetClassInfo(GetType(PersistentObject1)).FindMember("PersistentObject2s") Is Nothing Then
				xpDictionary.GetClassInfo(GetType(PersistentObject1)).CreateMember("PersistentObject2s", GetType(XPCollection(Of PersistentObject2)), True, New AggregatedAttribute(), New AssociationAttribute("PersistentObject1-PersistentObject2s", GetType(PersistentObject2)))
			End If
			If xpDictionary.GetClassInfo(GetType(PersistentObject2)).FindMember("PersistentObject1") Is Nothing Then
				xpDictionary.GetClassInfo(GetType(PersistentObject2)).CreateMember("PersistentObject1", GetType(PersistentObject1), New AssociationAttribute("PersistentObject1-PersistentObject2s"))
			End If
			'Dennis: take special note of the fact that you have to refresh information about type, only if you made the changes in the XPDictionary. If you made the changes directly in the TypeInfo, refreshing is not necessary.
			XafTypesInfo.Instance.RefreshInfo(GetType(PersistentObject1))
			XafTypesInfo.Instance.RefreshInfo(GetType(PersistentObject2))
		End Sub
	End Class
End Namespace
