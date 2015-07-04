"use strict";

var React = require("react");
var FluxibleApp = require("fluxible");

var routrPlugin = require("fluxible-plugin-routr");
var fetchrPlugin = require("fluxible-plugin-fetchr");

var AppPage = require("./components/AppPage.jsx");

var app = new FluxibleApp({
    appComponent: React.createFactory(AppPage)
});

app.plug(routrPlugin({
    routes: require("./configs/routes")
}));

app.registerStore(require("./stores/AppStore"));

module.exports = app;