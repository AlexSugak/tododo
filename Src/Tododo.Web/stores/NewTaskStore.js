"use strict";

var createStore = require("fluxible/utils/createStore");

var NewTakStore = createStore({
	storeName: "NewTakStore",
	handlers: {
		"event:NewTaskChanged": "_changed",
		"event:NewTaskFinished": "_finished"
	},
	_changed: function(e) {
		this.text = e.value;
		this.emitChange();
	},
	_finished: function() {
		this.text = "";
		this.emitChange();
	},

	initialize: function() {
		this.text = "";
	},

	getItem: function() {
		return {
			text: this.text
		};
	},


	dehydrate: function() {
		return {
		};
	},
	rehydrate: function() {
	}
});


module.exports = NewTakStore;

