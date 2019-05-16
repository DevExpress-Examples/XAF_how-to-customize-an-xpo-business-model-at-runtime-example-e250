Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports MyXPOClassLibrary
Imports DevExpress.ExpressApp.DC

Namespace WinSolution.Module
    Partial Public NotInheritable Class WinSolutionModule
        Inherits ModuleBase
        Public Sub New()
            InitializeComponent()
        End Sub
        Public Overrides Sub CustomizeTypesInfo(ByVal typesInfo As DevExpress.ExpressApp.DC.ITypesInfo)
            MyBase.CustomizeTypesInfo(typesInfo)

            Dim typeInfo1 As ITypeInfo = typesInfo.FindTypeInfo(GetType(PersistentObject1))
            typeInfo1.AddAttribute(New DevExpress.Persistent.Base.DefaultClassOptionsAttribute())

            Dim memberInfo0 As IMemberInfo = typeInfo1.FindMember("NewIntField")
            If memberInfo0 Is Nothing Then
                typeInfo1.CreateMember("NewIntField", GetType(Integer))
            End If

            Dim typeInfo2 As ITypeInfo = typesInfo.FindTypeInfo(GetType(PersistentObject2))
            Dim memberInfo1 As IMemberInfo = typeInfo1.FindMember("PersistentObject2s")
            Dim memberInfo2 As IMemberInfo = typeInfo2.FindMember("PersistentObject1")
            If memberInfo1 Is Nothing Then
                memberInfo1 = typeInfo1.CreateMember("PersistentObject2s", GetType(DevExpress.Xpo.XPCollection(Of PersistentObject2)))
                memberInfo1.AddAttribute(New DevExpress.Xpo.AssociationAttribute("PersistentObject1-PersistentObject2s", GetType(PersistentObject2)), True)
                memberInfo1.AddAttribute(New DevExpress.Xpo.AggregatedAttribute(), True)
            End If
            If memberInfo2 Is Nothing Then
                memberInfo2 = typeInfo2.CreateMember("PersistentObject1", GetType(PersistentObject1))
                memberInfo2.AddAttribute(New DevExpress.Xpo.AssociationAttribute("PersistentObject1-PersistentObject2s", GetType(PersistentObject1)), True)
            End If

            typesInfo.RefreshInfo(GetType(PersistentObject1))
            typesInfo.RefreshInfo(GetType(PersistentObject2))
        End Sub
    End Class
End Namespace
