# Part 0 - Overview

In this workshop we're going to focus on creating UIs with XAML. If you're not a fan of XAML, and would instead rather create the UI with C# that's a valid option and you're welcome to do so, but we won't be covering that here.  However, you might want to stock around (or skip to the end) and see if the XAML we end up with is more to your liking.

There are lots of ways that the Monkey Finder app you created as part of the .NET MAUI Workshop can be improved, in this workshop we're only going to look at the XAML.  
This is because XAML is often overlooked and yet also one of the most often criticized aspects of building apps with .NET MAUI.

## Why it's important to look in detail about how we write XAML

XAML is often criticized as being overly complex and verbose. I think this often comes down to the way it is written and this doesn't have to be the case. If there are two different ways of writing something, one that takes 6 lines and another that only requires a single line and you chose to use the first option, I don't think it's appropriate to complain about the need for extra lines.

Many people have never been shown that there are multiple ways of writing XAML and I've met very few developers who have ever thought about what "good XAML" looks like.

If this isn't something you've thought about before, take a moment now to think about what would make a good XAML file.

...

What did you come up with?

Here's my list.

Good XAML should be:

* Clear - so that it's easy to read and understand.
* Concise - so there's no unnecessary duplication or unnecessary text.
* Consistent - which makes it easier to read and understand.
* Self describing - so it doesn't need extra comments or time spent deciphering the complex nested XML.
* Maintainable - which is the result of all of the above.

Hopefully you can appreciate that none of my points about what makes good XAML are specific to XAML.

These points will help you write a good code in any programming language. And yes, I do consider XAML to be a programming language. No, it's not turing complete and it's not capable of many things that other programming languages are, but it's a number of text files that we pass to the compiler and ultimately end up creating our application. When we think of XAML files at this level, it becomes obvious that we should be treating them with more care and attention.

If you're new to working with XAML and aren't familiar with some of the problems I've already hinted at, I'll show bad examples so you can see the types of issues you can avoid.


Th
Much of this is due to the way it is written and applying techniques, 

Two other factors 
- not considering options
- not applying best practices that apply to all 

Much of this is due to a lack of spending time trying to make it better

historic structure and examples were based on using tooling 

treat XAML like any other programming language.




## Why is this workshop necessary?

If you're one of the people who has never before thought about what counts as "good XAML" then it should be obvious why considering this is important.

From a wider perspective, I think there are 3 factors that have led to the reason that there's so much low-quality XAML in use today.

1. Developers treat XAML as the designers responsibility - and designers don't care about XAML.
2. The XAML we have today was originally intended to be written by tools and not by hand.
3. There are very few examples of what "good" can look like or effort to improve things.

I'm sure you're an exception to these generalizations but many (most?) developers don't spend a lot of time and effort focusing on the UI of their applications. The design and styling of the UI often falls to other people (designers) and they are not the ones who implement the designs. This disconnect means that no one person takes full ownership of the code used to implement the UI and as long as the running app matches the images created by the designer then everyone can move on to other things (that they'd rather be doing.)

In 2006, when XAML was first released (as part of WPF) the intention and expectation was that developers would use specific design-related tools to create their UIs with XAML and not write it all by hand. Over time we've lost many of these design tools and now there is little option (especially for .NET MAUI) other than to write XAML by hand. Elements defined with multiple levels of nesting and over many lines isn't a problem if you only see the UI through a design tool but if you have to write that by hand (even in an editor with intellisense) it's far from ideal.


no good examples of doing things differently/better


While these may be the reasons we're in the situation we're in they don't excuse it.

We still need to create applications we can easily modify and maintain. It should not be expected that UIs are hard to change without a lot of effort, testing, and unintended consequences.

There is a better way. And we need it.

## What we'll be looking at

Through the following parts of this workshop we'll look at principles, "best practices", and techniques for writing good code (of any kind/language) and applying them to our XAML.


outline/breakdown of the following parts




## Disclaimer

Many of the techniques, principles, and ideas covered in this workshop only have noticeable benefits when working on larger projects and applications. For a simple app like the **Monkey Finder** there is a perfectly valid argument that the XAML you already have is adequate for such an application.

However, you are likely to want to build other applications that are larger and have more pages, views, and other functionality. Many of the problems people run into with building and maintaining larger code bases is that they try and write them in the same way they do trivial apps and then wonder why 

## Getting started

Now that you know why it's important to think about XAML like any other programming language

Now that you're ready to focus on XAML, let's start looking at some code! [Head over to Part 1 to get started](../Part%201%20-%20Fundamentals/README.md)!
