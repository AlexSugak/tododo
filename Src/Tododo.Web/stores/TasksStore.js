"use strict";

var createStore = require("fluxible/utils/createStore");
var debug = require("debug")("TasksStore");

var TasksStore = createStore({
    storeName: "TasksStore",
    
    handlers: {
    	"event:TaskAdded": "taskAdded",
    	"event:TaskDeleted": "taskDeleted",
		"event:TasksLoaded": "tasksLoaded"
    },
    tasksLoaded: function(tasks) {
		var self = this;
		this.map = {};

		tasks.forEach(function(item) {
			self.map[item.id] = item;
		});
		this.emitChange();
	},

	// --- event handlers --- 

	taskAdded: function(task) {
		this.map[task.id] = task;
		this.emitChange();
	},
	taskDeleted: function(taskId) {
		delete this.map[taskId];
		this.emitChange();
	},
	getAllTasks: function() {
		var items = [];
		var map = this.map;
		Object.keys(this.map).forEach(function(k) {
			items.push(map[k]);
		});

		return items;
	},


	// --- queries --- 

	getAllTasksCount: function() {
		var map = this.map;
		var count = 0;
		Object.keys(this.map).forEach(function(k) {
			count += 1;
		});

		return count;
	},
	getTask: function(taskId) {
		return this.map[taskId];
	},

    initialize: function () {
    	this.map = {};
    },
    dehydrate: function () {
        return {
        	map: this.map
        };
    },
    rehydrate: function (state) {
    	this.map = state.map;
    }
});

module.exports = TasksStore;