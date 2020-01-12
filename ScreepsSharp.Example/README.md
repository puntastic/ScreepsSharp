##Deployment
Navigate to 'bin/release/[Release|Debug]/netstandard2.1/dist/_framework' and add the following the root level of a zip called 'compressed.zip':
* blazor.boot.json
* wasm/mono.wasm
* everything in the '/_bin' directory

The following files are needed for deployment:
* mono.js
* compressed.zip
* 'main.js' (from ScreepsSharp.example)
* Everything in the javascript directory of ScreepsSharp.Blazor