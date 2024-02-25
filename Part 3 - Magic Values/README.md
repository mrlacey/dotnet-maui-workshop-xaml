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

[[transition sentence]]

## Defining things once, in a base class

No one likes doing the same thing more than once. Similarly, you don't want to write the same code multiple times.

The two pages in our app contain duplicate functionality we can encapsulate and simplify. Technically this isn't a "magic value", but the principles of streamlining it apply in the same way as "magic values".

The commonality we'll address is the background of these two pages. If you look at the two files, you may notice that the background isn't specified on the `ContentPage`. Instead, it's defined on the child/content element of each `Page`. Not only does this make it unclear that the colors apply at the page level, it also makes it less obvious that these are the same thing and could be centralized.

[[point 1 example and steps]]

- create controls folder
- create class
- set background with app theme binding
- update pages to use the base (in XAML & cs)

We now have a custom`Page` class we'd use for all pages in the app. If we added another page, we'd use this new page unless there was a good reason not to.

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
