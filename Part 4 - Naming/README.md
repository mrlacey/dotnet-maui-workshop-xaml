# Part 4 - Naming

In this part, we will look at the names we give to the elements and resources we use in XAML files. We'll look at how to use names that help with code maintainability and make it easier to read and understand. We'll then extend these principles to see how to create semantically meaningful files.

The code examples in this part will continue on from the previous part. If you have the solution open, you can carry on from there. Alternatively, open the [solution in the Start directory](./Start/).

## Outline

Naming is a famously tricky part of software development. Naming is difficult because it is so crucial to explaining the code and why it is there. Understanding code is critical to its easy maintenance, so we can't overlook it.

In this part, we'll look at:

- What makes a good name
- Naming Resources and Styles
- Naming Elements and Controls

What makes a good name is often subjective and the names used in your UI have different requirements to other parts of a codebase. Let's get into it.

## What makes a good name

[[point 1 introduction]]
General advice for naming in software is to use a specific, descriptive name for what something does. While this is good advice for objects, it doesn't help produce maintainable XAML.

Consider one of the names we're using in the code, the Style `ButtonOutline`.  
At first glance, it may seem like a good name. It applies to a `Button` control, so "Button" as the first part of the name makes sense. But what about the "Outline" part of the name?  
You may argue that as it creates a button with an outline drawn around it when used, it's a good name. As a description of what the code currently does, it does meet that purpose, but that's not what makes a good name for something in the UI.

A good name for something in the UI tells us:

- Where to use it
- When to use it
- What it is at an abstract level

Again, you might think you should use this style whenever you need a button drawn with an outline, so it is a good name.  
But what happens when the app's design is updated?

Imagine, at some point in the future, the app must be updated to reflect a new design. This update could be as part of a "UI refresh", a change in corporate branding, or something else. Now, instead of a button with an outline, the desired new style is to have a solid color behind the text on the button.

If we keep the same name for the style, it would be very odd and confusing to anyone looking at the code in the future. "It says 'ButtonOutline', but it's a solid color without an outline. - What's going on?" Confusing code is not easy to maintain or change with confidence.

We could create a new Style for the new requirement and use that instead. But, doing this would lead to changes throughout the code base. One of the benefits of defining something once and referencing it in multiple places is that it should make maintenance and modification of all instances easier. Would you consider something easy to maintain if you have to change every reference to it when you change that thing?

No, a better name for this would be "StandardButton".  
In our app, we want all buttons to look like this "as standard". If we have a reason not to apply this styling as an implicit Style on all buttons, a name that includes something like "standard" as part of the name makes it clear that this is not a special or different button. It looks the way buttons are supposed to look in the app.

> **Note**:  
> Be careful of using "Default" when you mean "Standard" or something that is the ordinary version of something. "Default buttons" are typically the ones you expect or want the user to select from several options. If a page/screen/prompt/dialog included three "DefaultButton"s it could be confusing. If it included two "StandardButton"s and one "DefaultButton" a person looking at the code could hopefully understand more of the intent and expected behavior of the app.

There are similar issues with having lots of the same elements in a XAML file. If a XAML file contains lots of nested `Grid` or `StackLayout` controls, it can be hard to understand what the purpose of each one is. When these controls are given names to make their purpose clearer, it can remove uncertainty when changing the code.

The above points for what makes a good name should serve as guidelines for naming items in the UI.

With these guidelines defined, we can now start applying them to the code.

## Naming Resources and Styles

[[point 2 introduction]]

- of styles
  - OutlineButton
  - LargeLabel
  - MediumLabel
  - SmallLabel


[[point 2 example and steps]]

[[point 2 summary]]

[[transition sentence]]

## Naming Elements and Controls

[[point 3 introduction]]




[[point 3 example and steps]]


Give things names as a form of documentation so the code is easier to understand.
why, not what.

- of types
  - RowOfButtons
    - make sure all buttons are the same size
  - Header
  - PageBody

[[point 3 summary]]


In this part, we covered what makes a good name for something in XAML and updated the code to reflect this. There's more that we can do with these names than specify them. We'll see that next.

[Now, head over to Part 5 and we'll see how we can use custom types](../Part%205%20-%20Custom%20Types/README.md)
