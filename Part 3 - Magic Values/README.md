# Part 3 - "Magic Values"

In this part, we will look at the use of "magic strings" and "magic numbers" (collectively referred to as "magic values") in XAML files. "Magic values" can make code harder to understand and often mean changes need to be made in more than one place. As such, it's wise to avoid them whenever possible and so we'll look at ways of doing this.

The code examples in this part will continue on from the previous part. If you have the solution open, you can carry on from there. Alternatively, open the [solution in the Start directory](./Start/).

## Outline

[[Part introduction]]

Look at the xaml files in the project.
You'll see lots of numbers and string values repeated many times.
Are these the same because they represent the same underlying value, or is it a coincidence? How can you be sure? How would someone modifying the code in the future know which should all be changed together and which shouldn't?
What if there's a typo in a string or a number? Would you know? When would you know?

If we need to modify a value and it's used "everywhere" we really only want to have to change that value in a single place. We don't want to have to reason over the entire codebase and try to work out where all the identical changes should be made.

These are just some of the issues with with using "magic values" and they make the code harder to modify.



In this part, we'll look at:

<<
- reused names (or color values)
- page background
  - move to base
- reused numbers
- move repeated properties into a style
- creating a markup extension to enable simple math - details page
- use attached properties to remove duplication & simplify code - image sizes on mainpage layoutoptions
- enabling binding to a struct
- reference text in a resource file (typically for localization) but also provides an opportunity for reuse
>>

- Point 1
- point 2
- point 3
- point 4

[[transition sentence]]

## Point 1

[[point 1 introduction]]

[[point 1 example and steps]]

[[point 1 summary]]

[[transition sentence]]

## Point 2

[[point 2 introduction]]

[[point 2 example and steps]]

[[point 2 summary]]

[[transition sentence]]

## Point 3

[[point 3 introduction]]

[[point 3 example and steps]]

[[point 3 summary]]

[[transition sentence]]

## Point 4

[[point 4 introduction]]

[[point 4 example and steps]]

[[point 4 summary]]

[[PART SUMMARY]]

[Now, head over to Part 4 to learn the impact that different names can have in XAML files](../Part%204%20-%20Naming/README.md)
