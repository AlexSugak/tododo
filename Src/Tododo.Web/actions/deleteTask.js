"use strict";

var debug = require("debug")("deleteTask");

module.exports = function(context, payload, done) {
	debug("Running");

	context.dispatch("event:TaskDeleted", payload.taskId);
	done();
};