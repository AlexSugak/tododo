"use strict";

module.exports = function(context, payload, done) {
	context.dispatch("event:NewTaskChanged", payload);
	done();
};