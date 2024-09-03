<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128589025/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E250)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->


# How to customize an XPO business model at runtime (Example)

Sometimes there is a requirement to extend existing business classes when you cannot modify their source code.

For instance, you have an assembly where some persistent classes are declared. You want to use it in your XAF application and add attributes, new members, etc..

## Implementation Details

To use types from external assemblies, add them to the application as described in the [Ways to Add a Business Class - Add Classes From a Business Class Library or Module](https://docs.devexpress.com/eXpressAppFramework/112847/concepts/business-model-design/business-model-design-with-xpo/ways-to-add-a-business-class#add-classes-from-a-business-class-library-or-module) article.

To see how to extend business classes at runtime, refer to the [eXpressApp Framework > Concepts > Business Model Design > Types Info Subsystem > Use Metadata to Customize Business Classes Dynamically](https://documentation.devexpress.com/eXpressAppFramework/113583/Concepts/Business-Model-Design/Types-Info-Subsystem/Use-Metadata-to-Customize-Business-Classes-Dynamically) article.

This example demonstrates how to:
- Add an attribute to an existing class
- Create a new simple persistent property
- Create new reference and collection properties linked by an association

## Files to Review

* [PersistentObject1.cs](CS/CustomizeXPOModel/MyXPOClassLibrary/PersistentObject1.cs)
* [PersistentObject2.cs](CS/CustomizeXPOModel/MyXPOClassLibrary/PersistentObject2.cs)
* [Module.cs](CS/CustomizeXPOModel/CustomizeXPOModel.Module/Module.cs) 


### Important notes

1. By design you cannot dynamically add or remove the *OptimisticLocking* and *DeferredDeletion* attributes.
2. Adding custom members for Domain Components (DC) should be done on the *XafApplication.SettingUp* event as described at [How do I define a custom member for a domain component (DC) at runtime?](https://www.devexpress.com/Support/Center/p/S34769).


### Documentation 

[How to: Access Business Class Metadata](https://www.devexpress.com/Support/Center/p/E1649)

[How to create business classes at runtime based on predefined configurations or allow user to define custom members via the application UI](https://www.devexpress.com/Support/Center/p/T284822)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF_how-to-customize-an-xpo-business-model-at-runtime-example-e250&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=XAF_how-to-customize-an-xpo-business-model-at-runtime-example-e250&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
