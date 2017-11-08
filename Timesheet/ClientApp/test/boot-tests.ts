// Load required polyfills and testing libraries
import 'reflect-metadata';
import 'zone.js';
import 'zone.js/dist/long-stack-trace-zone';
import 'zone.js/dist/proxy.js';
import 'zone.js/dist/sync-test';
import 'zone.js/dist/jasmine-patch';
import 'zone.js/dist/async-test';
import 'zone.js/dist/fake-async-test';
import * as testing from '@angular/core/testing';
import * as testingBrowser from '@angular/platform-browser-dynamic/testing';
/** IE9, IE10 and IE11 requires all of the following polyfills. **/

import 'core-js/es6/symbol';

import 'core-js/es6/object';

import 'core-js/es6/function';

import 'core-js/es6/parse-int';

import 'core-js/es6/parse-float';

import 'core-js/es6/number';

import 'core-js/es6/math';

import 'core-js/es6/string';

import 'core-js/es6/date';

import 'core-js/es6/array';

import 'core-js/es6/regexp';

import 'core-js/es6/map';

import 'core-js/es6/set';
// There's no typing for the `__karma__` variable. Just declare it as any
declare var __karma__: any;
declare var require: any;

// Prevent Karma from running prematurely
__karma__.loaded = function () {};

// First, initialize the Angular testing environment
testing.getTestBed().initTestEnvironment(
    testingBrowser.BrowserDynamicTestingModule,
    testingBrowser.platformBrowserDynamicTesting()
);

// Then we find all the tests
const context = require.context('../', true, /\.spec\.ts$/);

// And load the modules
context.keys().map(context);

// Finally, start Karma to run the tests
__karma__.start();