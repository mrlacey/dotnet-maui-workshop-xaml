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

At the start of this workshop I said we wouldn't change the functionality of the app. That's still the case and so we'll have to imagine a theoretical change we might make to the app in the future. This is probably  reflective of many apps you'll build. You'll build what you need now but also have ideas of things that are likely to be added in the future. In these situations it is wise to do what you can to make those future changes easier. There will be times where you don't know what future changes might be required and in these instances applying general good practices for increased maintainability is even more important.

As an example, lets imagine we want to add a third button to the bottom of the main page of the app. And let's imagine that we need to put it between the two existing buttons.

Look at all the things we'd need to do to add this new button:

- Firstly, we need to look at the `Grid` the contains all the elements in the page. This defines the columns that are used to separate the buttons. As we're adding another button we'll need another column.
- The `RefreshView` has an attached property that specifies that it needs to span all the defined columns. As we've added another column, this must be updated to reflect this.
- The `ActivityIndicator` also needs to be updated so it continues to span all the defined columns.
- The existing `Button`, that's used to find the closest monkey, must be moved into the newly defined (last) column.
- Finally, after we've done all that, we can add the new button.

Before we made any changes there were 5 elements on the page. To add one more we've had to modify 4 of the existing ones. Imagine we were modifying a more complex page that contained many more elements. Having to understand how they all interact and modify many of them to make a single small change or addition is often the reason that it can be hard to modify existing XAML files and make changes without causing unintended consequences.

In terms of responsibility, each element is not only responsible for its own content and how it looks, it's also responsible for where it is positioned in its container (the Grid). We also have multiple reasons for an element to need to be changed:

- If it needs to be positioned differently.
- If other (sibling) elements are added.
- Ff other elements need their position changed.

Hopefully you see that this isn't ideal.

Hopefully you're thinking that the use of a Grid might not be the best way to create easily maintainable XAML files.

You're right.

> **Note**:  
> I'm not saying you should never use grids. Grids can be very useful. They can also be slightly faster to process as .NET MAUI measures and lays out the content it is putting on the screen. However, as mentioned in the last part, this performance benefit comes at the cost of maintainability and so a tradeoff must be made. I'm assuming that you don't write all of your C# code to be the most performant it can be. This certainly isn't the case with the C# created in the previous workshop. Many different features and forms of syntax were used to make the C# code easier to read. It therefore seems appropriate to not always use something in the XAML that might be the most performant if it makes the code harder to maintain. If you absolutely do need the UI to be rendered as fast as possible and you've measured and found that putting everything in a single big grid is the best way to do this then go ahead. If not, don't.

Grids are a great solution to specific layout challenges, but putting everything in a Grid can make it hard to change existing code. If it's you who's going to be making future changes you don't want to make your life difficult. Similarly, if it's going to be someone else who will be making future changes to the code you're writing, you don't want their life to be more complicated than it needs to be either. It's not good for the company creating the code that changes are slow and it's not good for the people who use the application to have to wait longer for changes, updates, and new features.

Now let's move on from the theory and see how we might change the existing code so it's easier to modify without having to make changes in lots of different places. We'll do this by having separate elements for presentation (those that a person will see and interact with) and for the positioning of those presentation elements.

## Separating content and layout

Separating content elements and those that control where and how they're positioned may sound good in principle, but where to start? Don't worry, it's actually very simple.

Let's start by looking at the xaml of the MainPage.

### MainPage.xaml

Forget what's there at the moment, or about specific controls. We can think of the page as having a main content area (which holds the list and activity indicator) and a row of buttons at the bottom. This is a great pace to use a simple Grid. It will expand to fill all the available space (the whole page) and we can divide it into parts that take the space they need (the row of buttons) and a part that takes up all the remaining space (the list or indicator.)

We can modify the Grid on `MainPage.xaml` accordingly:

- Remove the column definitions, as we don't need these.
- Remove the `ColumnSpacing` (as there is now only one colum)
- Remove the `RowSpacing` value as this (zero) is the default and so doesn't need specifying.

```diff
    <Grid
        BackgroundColor="{AppThemeBinding Light={StaticResource LightBackground},
                                          Dark={StaticResource DarkBackground}}"
-        ColumnDefinitions="*,*"
-        ColumnSpacing="5"
-        RowSpacing="0"
        RowDefinitions="*,Auto">
```

This leaves us with two rows. The second (bottom) row is for the buttons. The definition of `Auto` means it will take up only the space it needs to display the buttons. The first (top) row is for our main content.

In the `RefreshView` we can remove the need to span multiple columns.

```diff
        <RefreshView
-            Grid.ColumnSpan="2"
```

In the `ActivityIndicator` we can remove the need to span multiple columns.  
Additionally, we can also remove the need to span multiple rows. (If set to span over the two rows, no-one is likely to notice the difference, but spanning both rows is unnecessary and by assigning the `ActivityIndicator` to the same cell in the `Grid` as the `RefreshView` we make it clearer that these are intended to be displayed in the same place on the screen.)  
Finally, we also want the indicator to be centered horizontally. When set to `Fill` as the value for `HorizontalOptions` the visible parts of the indicator will be centered and space allocated to stretch it to fill the full width of the container, but by explicitly setting the value to `Center` we make it clear that this "centering" is what we want and not simply the side-effect of another option that produces the same visible result.

```diff
        <ActivityIndicator
-            Grid.RowSpan="2"
-            Grid.ColumnSpan="2"
-            HorizontalOptions="Fill"
+            HorizontalOptions="Center"
```

Now we can turn our attention to the buttons at the bottom of the screen.

The first thing we can do is add a new container for all the buttons we want to add (both now and in the future.)

As we want the buttons to be displayed horizontally, we can use a `HorizontalStackLayout` for this.

We also need to make sure it is placed in the bottom row of the Grid, so set `Grid.Row="1"`.

Now that the `Button`s are no longer directly children of the `Grid` we can remove the attached properties that specify the `Row` and `Column` they were previously positioned in.

Previously, the spacing between and around the buttons was specified as part of the `Grid` and each individual `Button`. We can now simplify things by moving all that logic to the element that contains all the buttons.

Rather than put space (a `Margin`) around each individual `Button` we can instead put an equivalent sized `Padding` around the inside of the `HorizontalStackLayout`.

This leaves the space between `Button`s. Previously, this was a combination of the `ColumnSpacing` specified on the `Grid` and the `Margin` applied to the sides of the `Button`s. We can simplify this by combining these values into the `Spacing` property of the `HorizontalStackLayout`.

Let's combine `5` from the `GridSpacing` and `8` from each side of the `Button` into a single values, so (5 + 8 + 8 = 21) `Spacing="21"`.

If we now wanted to add another `Button`, we'd just put it inside the `HorizontalStackLayout` and it would be positioned relative to the other `Button`s such that the order in the xaml file would reflect the order they're shown in the running app. Spacing between the buttons would also be taken care of without needing to specify anything on the new `Button`.

```diff
+        <HorizontalStackLayout Grid.Row="1" HorizontalOptions="Center" Padding="8" Spacing="21">
            <Button
-                Grid.Row="1"
-                Grid.Column="0"
-                Margin="8"
                Command="{Binding GetMonkeysCommand}"
                IsEnabled="{Binding IsNotBusy}"
                Style="{StaticResource ButtonOutline}"
                Text="Get Monkeys" />

            <Button
-                Grid.Row="1"
-                Grid.Column="1"
-                Margin="8"
                Command="{Binding GetClosestMonkeyCommand}"
                IsEnabled="{Binding IsNotBusy}"
                Style="{StaticResource ButtonOutline}"
                Text="Find Closest" />
+        </HorizontalStackLayout>
```

With these changes we've now separated the logic (code) that determines where and how elements are positioned (with the `Grid` and the `HorizontalStackLayout`) from the elements that are displayed on the page (the `RefreshView`, `ActivityIndicator`, and the `Button`s.)

In terms of simplifying the amount of code, we've made the following changes:

- Removed 12 attributes from existing elements.
- Added 1 new element.
- Changed 1 attribute of an existing element.

However, on a semantic level, we've:

- Simplified the structure and complexity of the page.
- Grouped similar or related elements together.
- Used elements and values that help clarify the intent of the XAML in an aid to make it easier to visualize.
- Removed some of the duplication.

All of which should make the code easier for someone else to understand in the future and also make it easier for them to modify without unnecessary effort, duplication, or unintended consequences.

With that page changed, we can now focus on the other page in the app.

### DetailsPage.xaml

<<replace grid with VSP on detail page>>


<<summarize all the changes made above>>

[[point 2 summary]]
<<separation and isolation of elements so that if we need to change or add something we don't have to change things elsewhere too>>


<<compare large file vs small one - would you rather maintain large code files with lots of duplication and unnecessary complexity, or a smaller file where the author has taken time, effort, and consideration to make it easier for those that have to work with the code base after them?>>

As with the last part, if you run the app now you'll see no visual or behavioral difference with the app. At this point it might not be obvious of the benefits of the changes you've made. After all, a large part of the reason for them is to for when future changes are needed. There are more immediate benefits to the changes made in this part and they will become clearer as we continue.

 [Now, head over to Part 3 and we'll look at the use of "magic values"](../Part%203%20-%20Magic%20Values/README.md)!
