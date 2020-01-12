##Deployment
Navigate to 'bin/release/[Release|Debug]/netstandard2.1/dist/_framework' and add the following the root level of a zip called 'compressed.zip.wasm':
* blazor.boot.json
* wasm/mono.wasm
* everything in the '/_bin' directory

The following files are needed for deployment:
* mono.js
* compressed.zip
* everything in 'bin/release/[Release|Debug]/netstandard2.1/javascript'

The following needs to be deleted from 'mono.js'
* 'var Module=typeof Module!=="undefined"?Module:{};'