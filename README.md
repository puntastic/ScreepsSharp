# Getting started
## Prereqs
* [.Net core 3.1 sdk](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [Visual studio 16.4+](https://visualstudio.microsoft.com/vs/preview/)
* Asp.net workload

## Deployment
* Build /Tutorial/Section5
* Navigate to: 
  * /Tutorial/Section5/bin/[Debug|Release]/netstandard2.1/
* Copy<sup>1</sup> the following into a zip file called compressed.zip.wasm:
  * dist/_framework/wasm/mono.wasm
  * dist/_framework/blazor.boot.json
  * dist/_framework/_bin/*.dll
* Remove 'var Module=typeof Module!=="undefined"?Module:{};' from the start of dist/_framework/wasm/mono.js
* Copy the following onto the server:
  * Everything in bin/.../javascript/
  * Modified mono.js
  * compressed.zip.wasm

That should with luck get everything working. Note that saving files within the screeps client seems to cause problems reloading the modules.

1 ) Inbuilt windows zip handler didn't do it for me. I had to use 7zip on [max compression](https://superuser.com/questions/281573/what-are-the-best-options-to-use-when-compressing-files-using-7-zip).
 Note that screeps base64 encodes files being uploading making them larger; <5mb locally may still hit the server size limit.
