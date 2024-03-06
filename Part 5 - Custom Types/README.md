# Part 5 - Custom Types

In this part, we will create and use custom types in our XAML files. These changes will make some of the most dramatic changes to the code we started with but are only possible once we have understood the lessons of the previous parts.

The code examples in this part will continue on from the previous part. If you have the solution open, you can carry on from there. Alternatively, open the [solution in the Start directory](./Start/).

## Outline

Now you've reached the final part of this workshop, you may notice how the XAML in the project already looks very different from what we started with. Despite all these differences, there are still lots of ways that we can further improve it.

In this part, we'll look at:

- Creating types based on Styles
- Composition of multiple types
- Isolating stand-alone pieces of logic

Creating UI controls can be a little daunting. Don't worry. We'll start with some code so straightforward and yet transformational that you will wonder why you've never seen code like it before.

## Creating types based on Styles

Creating reusable Styles is a great way to simplify and standardize our XAML code while also making it easier to maintain. But what if it could do more?

This isn't a trick question, but what does this code mean:

```xml
<Label Style="{StaticResource Heading}" Text="{Binding Name}" />
```

I would describe that code as saying:

1. Create a Label.
2. Make that label look like the "Heading" version of a label.
3. Bind the Text property to the "Name" of the BindingContext. (Show the name on the label.)

One little line, and it's doing three things.  
What if we could reduce that by 50%?

Why couldn't that code read:

```xml
<s:Heading Text="{Binding Name}" />
```

That code says:

1. Create a Heading.
2. Bind the Text property to the "Name" of the BindingContext. (Show the name as the text of the heading.)

Not only is this simpler, but it also provides semantic meaning to the element in the file. I don't need to know that this uses a `Label` control to display the text. I don't need to care.  
Not only does having less code to read make it easier to maintain, but it also makes it easier for someone less familiar with XAML to understand and maintain.  
This approach means that you can use the XAML document to describe the structure of the UI that you want. You don't need to include everything in one file. Many of the specifics can be moved to their own places (files) where they can be looked at in isolation if needed.  
This matches the way you structure your C# code. You don't put everything in one big file or class. You create specific classes for specific purposes. You give those classes meaningful names. And you use those names directly to make the code easier to read and understand. That's all the above is doing to make the code easier to maintain.

But, what is this magical `s:Heading` element, and where did it come from?

It's just a very small, simple C# class that looks like this:

```csharp
    public class Heading : Label
    {
        public Heading()
        {
            if (App.Current.Resources.TryGetValue("Heading", out object result))
            {
                this.Style = result as Style;
            }
        }
    }
```

Isn't that simple?  
Couldn't you easily write a class like that?

All it does is:

- Create a new type called `Heading` that inherits from `Label`
- When created, it gets the resource called "Heading" and applies it to the control.

But wait, you may be thinking, that's a C# file, and all the UI should be done in XAML. Nope. There is absolutely no reason not to mix C# and XAML. Your codebase already contains a combination of the two, and combining them can make your code (and your life) much simpler. Not only are some things easier or require less code in one language, they may even require fewer files.  
Yes, you could create a version of the `Heading` class (control) that uses both a XAML file and a C# one, but why would you when the above works fine?

In fact, you don't need to write the above code at all!

Back in part 3, you installed the NuGet package `RapidXaml.CodeGen.Maui`. This created the `AppColors` class that we used to refer to colors used in `StandardPage.cs` without having to create "magic strings". When you installed that package and built (compiled) the project, it also created a file called `Styles.cs` in the "Resources\Styles" folder.

Open that file now. Inside, you'll see that for every Style, with a defined `x:Key`, a type has been automatically created. This means we can use these new classes in our code right now.

Lets make some changes.

In `MainPage.xaml`, start by adding this XML namespace and alias:

```diff
+    xmlns:s="clr-namespace:MonkeyFinder"
```

I'm using the alias "s" as it's shorter than "style", but that's my preference. Use what works best for you when applying something similar in your own code.

Now we can use the new types in place of the old ones.

Make these changes:

```diff
-   <Frame HeightRequest="{StaticResource SmallSquareImageSize}" Style="{StaticResource CardView}">
+   <s:CardView HeightRequest="{StaticResource SmallSquareImageSize}">

...

-             <Label Style="{StaticResource Heading}" Text="{Binding Name}" />
+             <s:Heading Text="{Binding Name}" />
+             <s:ListDetails Text="{Binding Location}" />
-             <Label Style="{StaticResource ListDetails}" Text="{Binding Location}" />
            </VerticalStackLayout>
        </Grid>
-   </Frame>
+   </s:CardView>

...

-   <Button
+   <s:StandardButton
        Command="{Binding GetMonkeysCommand}"
        IsEnabled="{Binding IsNotBusy}"
-       Style="{StaticResource StandardButton}"
        Text="{x:Static str:UiText.GetMonkeysButtonContent}" />

-   <Button
+   <s:StandardButton
        Command="{Binding GetClosestMonkeyCommand}"
        IsEnabled="{Binding IsNotBusy}"
-       Style="{StaticResource StandardButton}"
        Text="{x:Static str:UiText.FindClosestButtonContent}" />
```

Now make similar changes in `DetailsPage.xaml`:

```diff
+    xmlns:s="clr-namespace:MonkeyFinder"

...

-   <Label
+   <s:Heading
        FontAttributes="Bold"
        HorizontalOptions="Center"
-       Style="{StaticResource Heading}"
        Text="{Binding Monkey.Name}"
        TextColor="White" />

...

-   <Button
+   <s:StandardButton
        Margin="8"
        Command="{Binding OpenMapCommand}"
        HorizontalOptions="Center"
-       Style="{StaticResource StandardButton}"
        Text="{x:Static str:UiText.ShowOnMapButtonContent}"
        WidthRequest="200" />

-   <Label Style="{StaticResource BodyText}" Text="{Binding Monkey.Details}" />
+   <s:BodyText Text="{Binding Monkey.Details}" />
-   <Label Style="{StaticResource AdditionalInformation}" Text="{Binding Monkey.Location, StringFormat='Location: {0}'}" />
+   <s:AdditionalInformation Text="{Binding Monkey.Location, StringFormat='Location: {0}'}" />
-   <Label Style="{StaticResource AdditionalInformation}" Text="{Binding Monkey.Population, StringFormat='Population: {0}'}" />
+   <s:AdditionalInformation Text="{Binding Monkey.Population, StringFormat='Population: {0}'}" />
```

> **Note**:  
> Because the generated Types inherit from the ones the Style was originally applied to, we can still use all the same properties of the original Types.

You've just made some considerable changes, and most of it was because of code you didn't even have to write. However, the creation of the code is less important than the fact you:

- Reduced the size of the code without losing any information.
- Added clarity by removing redundancy and making better use of the names we previously gave to the Styles.
- Created a more semantically meaningful document.

Each of these points contributes to having XAML files that are easier to understand and maintain in the future.

I find making changes like those above, where I can remove a lot of code but still maintain the same functionality, very satisfying. Even more pleasing than removing individual attributes is removing whole elements. That's what we'll get to do next.

## Composition of multiple types

[[point 2 introduction]]


- combining types for simplicity
  - VerticallyScrollingPage (with Header)
  - card view => exercise for you
  - RoundImage (with border)

[[point 2 example and steps]]

[[point 2 summary]]

[[transition sentence]]

## Isolating stand-alone pieces of logic

[[point 3 introduction]]

detail page header

[[point 3 example and steps]]

[[point 3 summary]]

[[PART SUMMARY]]

## Conclusion

[[workshop conclusion]]

[[call to next action]]
