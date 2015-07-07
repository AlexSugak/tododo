/** @jsx React.DOM */

var React = require("react");

var StoreMixin = require("fluxible").StoreMixin;
var TasksStore = require("../stores/TasksStore");

var TaskDetailsView = React.createClass({
	mixins: [StoreMixin],
	propTypes: {
		context: React.PropTypes.object.isRequired,
		taskId: React.PropTypes.string.isRequired
	},
	statics: {
		storeListeners: {
			_onChange: [TasksStore]
		}
	},
	getInitialState: function getInitialState() {
		return this.getStateFromStores();
	},
	getStateFromStores: function getStateFromStores() {
		return {
			task: this.getStore(TasksStore).getTask(this.props.taskId)
		};
	},

	_onChange: function() {
		this.setState(this.getStateFromStores());
	},

	render: function render() {
		var task = this.state.task;
		var context = this.props.context;
		if (task === undefined) {
			return <div>Task not found</div>;
		}

		return (
			<div>
				<h1>{task.name}</h1>
				<p>task details</p>
			</div>
		);
	}
});


module.exports = TaskDetailsView;