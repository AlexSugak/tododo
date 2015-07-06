"use strict";

var debug = require("debug")("loadTasks");

module.exports = function(context, payload, done) {
	debug("Running");

	var items = [
		{ id: "task-1", name: "some task"},
		{ id: "task-2", name: "another task"}
	];

	context.dispatch("event:TasksLoaded", items);
	done();
};