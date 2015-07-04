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
    },
    tasks: {
        path: "/tasks",
        method: "get",
        page: "tasks",
        action: nothing
    },
    employees: {
        path: "/employees",
        method: "get",
        page: "employees",
        action: nothing
    }
};