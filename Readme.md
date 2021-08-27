<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128589025/15.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E250)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [PersistentObject1.cs](./CS/MyXPOClassLibrary/PersistentObject1.cs) (VB: [PersistentObject1.vb](./VB/MyXPOClassLibrary/PersistentObject1.vb))
* [PersistentObject2.cs](./CS/MyXPOClassLibrary/PersistentObject2.cs) (VB: [PersistentObject2.vb](./VB/MyXPOClassLibrary/PersistentObject2.vb))
* [Module.cs](./CS/WinSolution.Module/Module.cs) (VB: [Module.vb](./VB/WinSolution.Module/Module.vb))
<!-- default file list end -->
# How to customize an XPO business model at runtime (Example)

Sometimes there is a requirement to extend existing business classes when you cannot modify their source code.

For instance, you have an assembly where some persistent classes are declared. You want to use it in your XAF application and add attributes, new members, etc..

To use types from external assemblies, add them to the application as described in the [Ways to Add a Business Class - Add Classes From a Business Class Library or Module](https://docs.devexpress.com/eXpressAppFramework/112847/concepts/business-model-design/business-model-design-with-xpo/ways-to-add-a-business-class#add-classes-from-a-business-class-library-or-module) article.

To see how to extend business classes at runtime, refer to the [eXpressApp Framework > Concepts > Business Model Design > Types Info Subsystem > Use Metadata to Customize Business Classes Dynamically](https://documentation.devexpress.com/eXpressAppFramework/113583/Concepts/Business-Model-Design/Types-Info-Subsystem/Use-Metadata-to-Customize-Business-Classes-Dynamically) article.

This example demonstrates how to:
- Add an attribute to an existing class
- Create a new simple persistent property
- Create new reference and collection properties linked by an association

### Important notes

1. By design you cannot dynamically add or remove the *OptimisticLocking* and *DeferredDeletion* attributes.
2. Adding custom members for Domain Components (DC) should be done on the *XafApplication.SettingUp* event as described at [How do I define a custom member for a domain component (DC) at runtime?](https://www.devexpress.com/Support/Center/p/S34769).
3. In XAF versions prior to 15.1.4, you cannot dynamically establish an association between two persistent classes via the XafTypesInfo API. Use the [XPDictionary API](https://www.devexpress.com/Support/Center/Example/Details/E5139/) instead.

### See also:

[How to: Access Business Class Metadata](https://www.devexpress.com/Support/Center/p/E1649)

[How to create business classes at runtime based on predefined configurations or allow user to define custom members via the application UI](https://www.devexpress.com/Support/Center/p/T284822)
