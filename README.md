<h1 align="center"><project-name>Collatz</h1>

<p align="center"><project-description>A project dedicated to computing, graphing, and displaying the Collatz Conjecture sequence</p>

## Links

- [Repo](https://github.com/ericfoxx/<project-name> "<project-name> Repo")

- [Live](<Homepage url> "Live View")

- [Bugs](https://github.com/Rohit19060/<project-name>/issues "Issues Page")

### About the Conjecture

- [Collatz Graph](https://www.jasondavies.com/collatz-graph/) by Jason Davies
- [The Simplest Math Problem No One Can Solve - Collatz Conjecture](https://www.youtube.com/watch?v=094y1Z2wpJg) - Veritasium | YouTube
- [What is the Collatz Conjecture
and Why Is It so Interesting?](https://cdn.ymaws.com/amatyc.org/resource/resmgr/2021_conference_proceedings/s016a_virtual_9b_2_collatz_c.pdf) - A history and initial analysis of the problem by Alexander Atwood, presented at the AMATYC Annual Conference, 2021

## Screenshots

![Home Page](/screenshots/1.png "Home Page")

![](/screenshots/2.png)

![](/screenshots/3.png)

## Building & Running

In the project directory, compile with your development environment of choice, though it was built with (and contains a Solution file for) Visual Studio 2022. Xunit tests are available in the CollatzTest project.



## Built With

- .Net 7.0
- xunit
- Visual Studio 2022

## Future Updates

- [ ] Traversing & analyzing nodes for Max & Steps at certain intervals (probably at `2^n`)
- [ ] Big Number usage when > `int.Max`
- [ ] Building the `2^n` "spine"
- [ ] "Chunk" handling
- [ ] Command line params for non-interactive mode, graph generation to file, etc.
- [ ] ~~Incorporating [MS Automatic Graph Layout](https://github.com/microsoft/automatic-graph-layout)~~ - UPDATE: not using due to UWP prereq
- [ ] More test coverage

### Algorithm future state ideas

**Spine**: Before enumerating within our designated range (or chunk, see below) we build out the 2^n "spine" by first calculating and linking the powers of 2.
Once we have the powers of 2 graphed, we can shortcut the evaluation of whether a node links to 1 by whether it links to a power of 2 (since all powers of 2 link to 1). 
We can denote powers of 2 in via a `IsPowerOfTwo` bool on Vertex, defaulted to false.

**Chunks**: Select a range of numbers, from `2^j` to `2^k - 1`. Treat this range independently, with multiple egress points.
For example, if `j == 4` (16) and`k == 6` 64), we have:

- 18 -> 9
- 53 -> 160

Perhaps we can handle this with one-way-edge Vertices. Ex:

``` csharp
AttachDownTo(18, 9);
// or:
AttachDownTo(53, 160);
```

And in the chunks which contain the corresponding vertices:

``` csharp
AttachUpTo(9, 18);
// and:
AttachUpTo(160, 53);
```

### Unresolved questions & methods

How do we efficiently traverse & track the unconnected nodes? Perhaps we should practice with a sequence that we know has multiple loops. Ideas:

- 

## Author

**Jesse Smith**

- [Profile](https://github.com/ericfoxx")
- [Email](mailto:eric.foxx@gmail.com?subject=Collatz)

## 🤝 Support

Contributions, issues, and feature requests are welcome!

Give a ⭐️ if you like this project!