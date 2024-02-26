# Part 3 - "Magic Values"

In this part, we will look at the use of "magic strings" and "magic numbers" (collectively referred to as "magic values") in XAML files. "Magic values" can make code harder to understand and often mean changes need to be made in more than one place. As such, it's wise to avoid them whenever possible and so we'll look at ways of doing this.

The code examples in this part will continue on from the previous part. If you have the solution open, you can carry on from there. Alternatively, open the [solution in the Start directory](./Start/).

## Outline

Look at the xaml files in the project.
You'll see lots of numbers and string values repeated many times.
Are these the same because they represent the same underlying value, or is it a coincidence? How can you be sure? How would someone modifying the code in the future know which should all be changed together and which shouldn't?
What if there's a typo in a string or a number? Would you know? When would you know?

If we need to modify a value and it's used "everywhere," we really only want to have to change that value in a single place. We don't want to have to reason over the entire codebase and try to work out where all the identical changes should be made.

These are just some of the issues with using "magic values" and how they make the code harder to modify.

In this part, we'll look at:

- Defining things once, in a base class.
- Defining numbers once, as resources.
- Making the most of implicit styles.
- Doing simple math in a XAML file.
- Text resources do more than enable localization.

Yes, this is a lot to look at, but we want to eliminate all the "magic" so we can clearly and easily follow and understand the code.

## Defining things once, in a base class

No one likes doing the same thing more than once. Similarly, you don't want to write the same code multiple times.

The two pages in our app contain duplicate functionality we can encapsulate and simplify. Technically this isn't a "magic value", but the principles of streamlining it apply in the same way as "magic values".

The commonality we'll address is the background of these two pages. If you look at the two files, you may notice that the background isn't specified on the `ContentPage`. Instead, it's defined on the child/content element of each `Page`. Not only does this make it unclear that the colors apply at the page level, it also makes it less obvious that these are the same thing and could be centralized.

[[point 1 example and steps]]

- Let's start by creating a new folder at the root of our app. Call this `Controls`. The name could be anything, but this name is a common convention.

- Inside this new folder, create a new class called `StandardPage.cs`. This name hopefully communicates that this page is used as a standard throughout the app. You could use another name if it makes more sense to you. If you needed to add a page that was very different from the others, you may inherit from this or ate something afresh and give it a name that makes it clear where and when it should be used. There's more on this in the next part.
- Have this class inherit from `ContentPage`.
- Add a constructor to the class that sets the `BackgroundColor` based on the App Theme, like this:

```diff
+namespace MonkeyFinder.Controls;
+
+public class StandardPage : ContentPage
+{
+    public StandardPage()
+    {
+        App.Current.Resources.TryGetValue("LightBackground", out object lightColor);
+        App.Current.Resources.TryGetValue("DarkBackground", out object darkColor);
+
+        this.SetAppThemeColor(ContentPage.BackgroundColorProperty, lightColor as Color, darkColor as Color);
+    }
+}
```

Note that we need to use the `TryGetValue` method to access the application resources in C#, rather than accessing them via a string index. This behavior is by design, even though it is different from what you may be familiar with in other platforms that use XAML.

It is also possible to use a XAML file to configure the binding to the App Theme. I've used a C# file here because it means only adding to a single new file and it highlights that it's perfectly acceptable and even expected to mix the use of C# and XAML in your code. It is left as an exercise for you to explore how you might do this with XAML if that's your preference.

**But, wait.** Our `StandardPage` includes strings that need to match what's specified in `Colors.xaml`. This is the classic example of a "magic string". If we had a typo or difference in one of these strings, we'd end up with functionality that wouldn't work as expected, and we might only find out at runtime.

Fortunately, I have a simple solution.

- Add a NuGet package reference to `RapidXaml.CodeGen.Maui`.
- Rebuild the project.
- If you look in the `Resources/Styles` folder, you'll notice the new file `Colors.cs`. (We'll look at the other added file, `Styles.cs`, later.)
- Inside this file, which is based on `Colors.xaml`, you'll find constant values we can reference.
- We can now update `StandardPage.cs` to reference these constants.

```diff
-        App.Current.Resources.TryGetValue("LightBackground", out object lightColor);
-        App.Current.Resources.TryGetValue("DarkBackground", out object darkColor);
+        App.Current.Resources.TryGetValue(AppColors.LightBackground, out object lightColor);
+        App.Current.Resources.TryGetValue(AppColors.DarkBackground, out object darkColor);
```

With these constants now being used, if the keys in `Colors.xaml` were ever changed, we'd get a compile-time error that there was an inconsistency. This is another benefit we get from not using "magic values".

With our new Page class defied and not using any magic strings, we can start using it in other parts of the app.

- In `GlobalUsings.cs`, add a global using declaration for the namespace containing our new class.

```diff
+global using MonkeyFinder.Controls;
```

- Update `MainPage.xaml.cs` so that it inherits from our new class

```diff
-public partial class MainPage : ContentPage
+public partial class MainPage : StandardPage
```

- Update `MainPage.xaml`:
  - So it uses our new class.
  - Set the XMLNamespace and alias so the new class can be found.
  - Remove the BackgroundColor from the Grid.

```diff
-<ContentPage
+<c:StandardPage

...

+    xmlns:c="clr-namespace:MonkeyFinder.Controls"

...

-    <Grid BackgroundColor="{AppThemeBinding Light={StaticResource LightBackground}, Dark={StaticResource DarkBackground}}" RowDefinitions="*,Auto">
+    <Grid RowDefinitions="*,Auto">

...

-</ContentPage>
+</c:StandardPage>
```

- Update `DetailsPage.xaml.cs` so that it inherits from our new class

```diff
-public partial class DetailsPage : ContentPage
+public partial class DetailsPage : StandardPage
```

- Update `DetailsPage.xaml`:
  - So it uses our new class.
  - Set the XMLNamespace and alias so the new class can be found.
  - Remove the BackgroundColor from the ScrollView.

```diff
-<ContentPage
+<c:StandardPage

...

+    xmlns:c="clr-namespace:MonkeyFinder.Controls"

...

-    <ScrollView BackgroundColor="{AppThemeBinding Light={StaticResource LightBackground}, Dark={StaticResource DarkBackground}}">
+    <ScrollView>

...

-</ContentPage>
+</c:StandardPage>
```

We now have a custom`Page` class we'd use for all pages in the app, and that has the BackgroundColor defined in only one place. If we added another page, we'd use this new page unless there was a good reason not to.

> **Note**:  
> Creating a base class isn't the only way approach that would be appropriate here, but I've walked you through this approach as creating a page to use as the standard for an app is common for apps with more than a handful of different pages.

Creating a base class isn't the only way to simplify our XAML. Let's look at removing duplication by redefining some values as resources we can reuse in multiple places.

## Defining numbers once, as resources

- reused numbers
  - add new resource file
  - large image
  - small image
  - also in grid  & border dimensions
    - Padding/spacing/margin 8 or 10

[[point 2 introduction]]

[[point 2 example and steps]]

[[point 2 summary]]

[[transition sentence]]

## Making the most of implicit styles

- move repeated properties into a style
  - AspectFill in images on both pages
  - ActivityIndicator only one in app so can set more properties there

[[point 3 introduction]]

[[point 3 example and steps]]

[[point 3 summary]]

[[transition sentence]]

## Doing simple math in a XAML file

- creating a markup extension to enable simple math - details page
  - stroke shape in border

[[point 4 introduction]]

[[point 4 example and steps]]

[[point 4 summary]]

## Text resources do more than enable localization

[[point 5 introduction]]

[[point 4 example and steps]]

[[point 5 summary]]

[[PART SUMMARY]]

[Now, head over to Part 4 to learn the impact that different names can have in XAML files](../Part%204%20-%20Naming/README.md)
