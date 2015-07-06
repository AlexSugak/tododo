"use strict";

var debug = require("debug")("addTask");

module.exports = function(context, payload, done) {
	debug("Running");

	context.dispatch("event:NewTaskFinished", payload);

	var task = {
		id: "task-" + Math.random(),
		name: payload.name
	};

	context.dispatch("event:TaskAdded", task);
	done();
};