"use strict";

var nothing = function (context, payload, done) {
    done();
};

module.exports = {
    index: {
        path: "/",
        method: "get",
        page: "index",
        action: nothing
    }
};