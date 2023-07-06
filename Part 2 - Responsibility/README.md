# Part 2 - Responsibility

In this part, we will look at the [Single Responsibility Principle](https://en.wikipedia.org/wiki/Single-responsibility_principle) and how it can be applied to XAML. You don't need any prior knowledge of this principle to complete this part.

The code examples in this part will continue on from the previous part. If you have the solution open, you can carry on from there. Alternatively, open the [solution in the Start directory](./Start/).

## Outline

[[Part introduction - how the SRP relates to XAML]]
At it's simplest, the Single Responsibility Principle is expressed as "A class should have only one reason to change." It can be easy to see how this can be applied to an object-oriented language like C# but it isn't always obvious how this can relate to XAML files.

Instead of thinking about classes, we can apply this rule by asserting that **an _element_ should only have one reason to change**.

In this part, we'll look at:

- How this helps make maintainable code
- Separating content and layout

Yes, there are only two parts to this section but they're the building blocks of making XAML files that are easy to maintain.

## How this helps make maintainable code(Point 1)

[[point 1 introduction]]
<<more than just ViewModels>>
<<how this helps you (why this matters)>>

[[point 1 example and steps]]
<<example with adding an extra button to the main page>>

[[point 1 summary]]

[[transition sentence]]

## Separating content and layout(Point 2)

[[point 2 introduction]]

[[point 2 example and steps]]
<<add button container on main page>>
<<replace grid with VSP on detail page>>

[[point 2 summary]]

As with the last part, if you run the app now you'll see no visual or behavioral difference with the app. We have, however, started making practical changes that make our XAML file easier to maintain.

 [Now, head over to Part 3 and we'll look at the use of "magic values"](../Part%203%20-%20Magic%20Values/README.md)!
