"use strict";

var React = require("react");
var FluxibleApp = require("fluxible");

var routrPlugin = require("fluxible-plugin-routr");

var AppPage = require("./components/AppPage.jsx");

var app = new FluxibleApp({
    appComponent: React.createFactory(AppPage)
});

app.plug(routrPlugin({
    routes: require("./configs/routes")
}));

app.registerStore(require("./stores/AppStore"));
app.registerStore(require("./stores/SyncStore"));
app.registerStore(require("./stores/TasksStore"));
app.registerStore(require("./stores/NewTaskStore"));

module.exports = app;