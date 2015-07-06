"use strict";

require('node-jsx').install({
    extension: ".jsx"
});

var express = require("express");
var path = require("path");
var react = require("react");

var bodyParser = require("body-parser");
var navigateAction = require("flux-router-component").navigateAction;
var loadDataAction = require("./actions/loadData");

var htmlComponent = react.createFactory(require("./components/Html.jsx"));

var expressState = require("express-state");
var app = require("./app");
var debug = require("debug")("server");
var server = express();

expressState.extend(server);

server.use("/public", express.static(path.join(__dirname, "build")));
server.use("/css", express.static(path.join(__dirname, "node_modules/bootstrap/dist/css")));
server.use("/css", express.static(path.join(__dirname, "css")));
server.use(bodyParser.json());

function handleError(err, next) {
    if (err.status && err.status === 404) {
        next();
    } else {
        next(err);
    }
}

server.use(function (req, res, next) {
    var context = app.createContext();
    var ac = context.getActionContext();
    debug("Executing navigate action");
    
    ac.executeAction(loadDataAction, {
        force: true
    }, function(err) {
            if (err) {
                handleError(err, next);
                return;
            }

            ac.executeAction(navigateAction, {
                url: req.url
            }, function (err) {
                if (err) {
                    handleError(err, next);
                    return;
                }
                debug("Exposing context state");
                res.expose(app.dehydrate(context), "App");
                
                debug("Rendering Application component into html");
                var AppComponent = app.getAppComponent();
                var html = react.renderToStaticMarkup(htmlComponent({
                    title: "Tododo",
                    state: res.locals.state,
                    context: context.getComponentContext(),
                    markup: react.renderToString(AppComponent({
                        context: context.getComponentContext()
                    }))
                }));
                
                debug("Sending markup");
                res.write(html);
                res.end();
            });
    });
});


var port = process.env.port || 1337;
server.listen(port);
console.log("Listening on port " + port);
