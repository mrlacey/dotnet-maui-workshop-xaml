# Part 2 - Responsibility

In this part, we will look at the [Single Responsibility Principle](https://en.wikipedia.org/wiki/Single-responsibility_principle) and how it can be applied to XAML. You don't need any prior knowledge of this principle to complete this part.

The code examples in this part will continue on from the previous part. If you have the solution open, you can carry on from there. Alternatively, open the [solution in the Start directory](./Start/).

## Outline

At it's simplest, the Single Responsibility Principle is expressed as "A class should have only one reason to change." It can be easy to see how this can be applied to an object-oriented language like C# but it isn't always obvious how this can relate to XAML files.

Instead of thinking about classes, we can apply this rule by asserting that **an _element_ should only have one reason to change**. An element in our XAML files is a representation of an instance of a class and so the comparison is clear. However, rather than looking at the reasons to change a class, we'll be looking at the reasons to change a single instance of a class.

In this part, we'll look at:

- How this helps make maintainable code
- Separating your content and layout

Yes, there are only two parts to this section but they're the building blocks of making XAML files that are easy to maintain.

## How this helps make code easier to maintain

If you have previous experience with .NET MAUI (or other platforms that use XAML) you've probably encountered the idea of putting the data and logic for a particular piece of UI in a `ViewModel`. ViewModels are great at separating the logic from the UI, but they don't do a lot to help make it easier to maintain the XAML files.  
When we think about "maintaining" code we normally mean **changing** it. And, before we can change code we, ideally, need to first **understand** it.

So, to make our XAML code easier to maintain, we want it to be easier to understand. Making something easier to understand starts by making it easier to read. Then, once we've read it, we can more easily understand the consequences of the changes we want to make.

At the start of this workshop I said we wouldn't change the functionality of the app. That's still the case and so we'll have to imagine a theoretical change we might make to the app in the future. This is probably  reflective of many apps you'll build. You'll build what you need now but also have ideas of things that are likely to be added in the future. In these situations it is wise to do what you can to make those future changes easier. There will

As an example, lets imagine we want to add a third button to the bottom of the main page of the app. And let's imagine that we need to put it between the two existing buttons.

Now lets look at all the things we'd need to do to add this new button:

- Firstly, we need to look at the `Grid` the contains all the elements in the page. This defines the columns that are used to separate the buttons. As we're adding another button we'll need another column.
- The `RefreshView` has an attached property that specifies that it needs to span all the defined columns. As we've added another column, this must be updated to reflect this.
- The `ActivityIndicator` also needs to be updated so it continues to span all the defined columns.
- The existing `Button`, that's used to find the closest monkey, must be moved into the newly defined (last) column.
- Finally, after we've done all that, we can add the new button.

Before we made any changes there were 5 elements on the page. To add one more we've had to modify 4 of the existing ones. Imagine we were modifying a more complex page that contained many more elements. Having to understand how they all interact and modify many of them to make a single small change or addition is often the reason that it can be hard to modify existing XAML files and make changes without causing unintended consequences.

Hopefully you see that this isn't ideal.

Hopefully you're thinking that the use of a Grid might not be the best way to create easily maintainable XAML files.

You're right.

> **Note**:  
> I'm not saying you should never use grids. Grids can be very useful. They can also be slightly faster to process as .NET MAUI measures and lays out the content it is putting on the screen. However, as mentioned in the last part, this performance benefit comes at the cost of maintainability and so a tradeoff must be made. I'm assuming that you don't write all of your C# code to be the most performant it can be. This certainly isn't the case with the C# created in the previous workshop. Many different features and forms of syntax were used to make the C# code easier to read. It therefore seems appropriate to not always use something in the XAML that might be the most performant if it makes the code harder to maintain. If you absolutely do need the UI to be rendered as fast as possible and you've measured and found that putting everything in a single big grid is the best way to do this then go ahead. If not, don't.

So, we've seen that code that putting everything in a Grid can make it hard to change existing code. If it's you who's going to be making future changes you don't want to make your life difficult. Similarly, if it's going to be someone else who will be making future changes to the code you're writing, you don't want their life to be more complicated than it needs to be either. It's not good for the company creating the code that changes are slow and it's not good for the people who use the application to have to wait longer for changes, updates, and new features.

Now let's move on from the theory and see how we might change the existing code so it's easier to modify without having to make changes in lots of different places.

## Separating content and layout(Point 2)

[[point 2 introduction]]
<<>>

[[point 2 example and steps]]
<<add button container on main page>>
<<replace grid with VSP on detail page>>

[[point 2 summary]]
<<separation and isolation of elements so that if we need to change or add something we don't have to change things elsewhere too>>

As with the last part, if you run the app now you'll see no visual or behavioral difference with the app. At this point it might not be obvious of the benefits of the changes you've made. After all, a large part of the reason for them is to for when future changes are needed. There are more immediate benefits to the changes made in this part and they will become clearer as we continue.

 [Now, head over to Part 3 and we'll look at the use of "magic values"](../Part%203%20-%20Magic%20Values/README.md)!
