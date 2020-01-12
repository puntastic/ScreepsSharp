console.log(`Loading bot code at tick: (${Game.time})...`); 

global.Utils = require('utils');
global._ = Utils.LoadModule('lodash');

Utils.LoadModule('bindings');
Utils.LoadModule('jsinterop')

const MonoLoader = Utils.LoadModule('mono-loader');
global.loader = new MonoLoader({});
 
module.exports.loop = loader.Tick.bind(loader);