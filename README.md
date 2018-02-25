# skimtypes

So far bit is the only type and has a very Alpha/experimental status.

This product is provided as-is with no guarantees, licensed with MIT license
(see LICENSE file).

Last test run status: 30 Tests Pass, 0 Fail

## bit

What is the purpose of a bit type?

I want to exclusively use 0 or 1 for booleans, I thought I'd need a programming
language to do this but was surprised to find a way to implement it in C#.

Since I just barely built the tradeoffs aren't very apparent yet. Maybe this
was all a big mistake. So far it appears to be less verbose code. The ability
to flip a bit is nice without having to worry about re-assigning the negated
value. I'm curious as to whether this improves or worsens code readability.

```csharp
// create a bit by assigning it a value of 0 or using the constructor
bit myBit = 0;//new bit();

// flip the bit on
myBit.Flip();

// use it in an if statement
if (myBit)
   myBit.Flip();// set it back to 0

// assign it directly with 1 or true
myBit = 1;//true;
```

The bit type has value semantics:

```csharp
bit a = 0;
bit b = a;
b = 1;//a is unaffected by this change
```
