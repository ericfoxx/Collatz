<h1 align="center"><project-name>Collatz</h1>

<p align="center"><project-description>A project dedicated to computing, graphing, and displaying the Collatz Conjecture sequence</p>

## Links

- [Repo](https://github.com/ericfoxx/<project-name> "<project-name> Repo")

- [Live](<Homepage url> "Live View")

- [Bugs](https://github.com/Rohit19060/<project-name>/issues "Issues Page")

## Screenshots

![Home Page](/screenshots/1.png "Home Page")

![](/screenshots/2.png)

![](/screenshots/3.png)

## Available Commands

In the project directory, you can run:

### `npm start" : "react-scripts start"`,

The app is built using `create-react-app` so this command Runs the app in Development mode. Open [http://localhost:3000](http://localhost:3000) to view it in the browser. You also need to run the server file as well to completely run the app. The page will reload if you make edits.
You will also see any lint errors in the console.

### `"npm run build": "react-scripts build"`,

Builds the app for production to the `build` folder. It correctly bundles React in production mode and optimizes the build for the best performance. The build is minified and the filenames include the hashes. Your app will be ready to deploy!

### `"npm run test": "react-scripts test"`,

Launches the test runner in the interactive watch mode.

### `"npm run dev": "concurrently "nodemon server" "npm run start"`,

For running the server and app together I am using concurrently this helps a lot in the MERN application as it runs both the server (client and server) concurrently. So you can work on them both together.

### `"serve": "node server"`

For running the server file on you can use this command.

### `npm run serve`

## Built With

- .Net 7.0
- xunit

## Future Updates

- [ ] Traversing & analyzing nodes for Max & Steps at certain intervals (probably at `2^n`)
- [ ] Big Number usage when > `int.Max`
- [ ] Building the `2^n` "spine"
- [ ] "Chunk" handling
- [ ] Command line params for non-interactive mode, graph generation to file, etc.
- [ ] Incorporating [MS Automatic Graph Layout](https://github.com/microsoft/automatic-graph-layout)

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